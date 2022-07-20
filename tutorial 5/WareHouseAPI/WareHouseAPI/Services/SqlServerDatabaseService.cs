using Microsoft.Extensions.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;
using WareHouseAPI.Exceptions;
using WareHouseAPI.Models;

namespace WareHouseAPI.Services
{
    public interface IDatabaseService
    {
        Task<int> AddOrder(ProductWarehouseDTO dto);
    }
    public class SqlServerDatabaseService : IDatabaseService
    {
        private IConfiguration _configuration;

        public SqlServerDatabaseService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> AddOrder(ProductWarehouseDTO dto)
        {
            using SqlConnection con = new SqlConnection(_configuration.GetConnectionString("default"));
            using SqlCommand com = new SqlCommand();
            com.Connection = con;
            await con.OpenAsync();
            
            // Scenario 1
            // check IdProduct exists
            com.CommandText = "SELECT Price FROM Product WHERE IdProduct = @IdProduct";
            com.Parameters.AddWithValue("@IdProduct", dto.IdProduct);
            var read = await com.ExecuteReaderAsync();
            if (!read.HasRows)
            {
                throw new DoesntExistException("Provided IdProduct doesnt exist in database");
            }
            await read.ReadAsync();
            double price = double.Parse(read["Price"].ToString());
            await read.CloseAsync();
            com.Parameters.Clear();

            // check IdWareHouse exists
            com.CommandText = "SELECT IdWarehouse FROM Warehouse WHERE IdWarehouse = @IdWarehouse";
            com.Parameters.AddWithValue("@IdWarehouse", dto.IdWarehouse);
            read = await com.ExecuteReaderAsync();
            if (!read.HasRows)
            {
                throw new DoesntExistException("Provided IdWarehouse doesnt exist in database");
            }
            await read.CloseAsync();
            com.Parameters.Clear();

            // Scenario 2
            com.CommandText = "SELECT TOP 1 [Order].IdOrder FROM [Order] " +
                                "LEFT JOIN Product_Warehouse ON [Order].IdOrder = Product_Warehouse.IdOrder " +
                                "WHERE [Order].IdProduct = @IdProduct " +
                                "AND [Order].Amount = @Amount " +
                                "AND Product_Warehouse.IdProductWarehouse IS NULL " +
                                "AND [Order].CreatedAt < @CreatedAt";
            com.Parameters.AddWithValue("@IdProduct", dto.IdProduct);
            com.Parameters.AddWithValue("@Amount", dto.Amount);
            com.Parameters.AddWithValue("@CreatedAt", dto.CreatedAt);
            read = await com.ExecuteReaderAsync();
            if (!read.HasRows)
            {
                throw new UnableFulfillException("There is no suitable order, unable to fulfill");
            }
            await read.ReadAsync();
            int idOrder = int.Parse(read["IdOrder"].ToString());
            await read.CloseAsync();
            com.Parameters.Clear();

            // Scenario 3
            com.CommandText = "SELECT IdOrder FROM Product_Warehouse WHERE IdOrder = @IdOrder";
            com.Parameters.AddWithValue("@IdOrder", idOrder);
            read = await com.ExecuteReaderAsync();
            if (!read.HasRows)
            {
                throw new OrderClosedException("Provided IdOrder has been already completed");
            }
            await read.CloseAsync();
            com.Parameters.Clear();

            DbTransaction tran = await con.BeginTransactionAsync();
            com.Transaction = (SqlTransaction)tran;

            try
            {
                int updated = -1;
                // Scenarion 4
                com.CommandText = "UPDATE [Order] SET FulfilledAt = @CreatedAt WHERE IdOrder = @IdOrder";
                com.Parameters.AddWithValue("@IdOrder", idOrder);
                com.Parameters.AddWithValue("@CreatedAt", dto.CreatedAt);

                updated = await com.ExecuteNonQueryAsync();
                if (updated < 0) throw new TransactionErrorException("Error occured during update");
                com.Parameters.Clear();

                // Scenario 5
                int inserted = -1;
                com.CommandText = "INSERT INTO Product_Warehouse(IdWarehouse, IdProduct, IdOrder, Amount, Price, CreatedAt) " +
                                  "VALUES(@IdWarehouse, @IdProduct, @IdOrder, @Amount, @Price, @CreatedAt)";
                com.Parameters.AddWithValue("@IdWarehouse", dto.IdWarehouse);
                com.Parameters.AddWithValue("@IdProduct", dto.IdProduct);
                com.Parameters.AddWithValue("@IdOrder", idOrder);
                com.Parameters.AddWithValue("@Amount", dto.Amount);
                com.Parameters.AddWithValue("@Price", dto.Amount * price);
                com.Parameters.AddWithValue("@CreatedAt", dto.CreatedAt);

                inserted = await com.ExecuteNonQueryAsync();
                if (inserted < 0) throw new TransactionErrorException("Error occured during insert");
                com.Parameters.Clear();


                // commit changes to db if everything ok
                await tran.CommitAsync();
            }
            catch (TransactionErrorException e)
            {
                await tran.RollbackAsync();
            }

            //Scenario 6
            com.CommandText = "SELECT TOP 1 IdProductWarehouse FROM Product_Warehouse ORDDER BY IdProductWarehouse DISC";
            read = await com.ExecuteReaderAsync();
            await read.ReadAsync();
            int idProductWarehouse = int.Parse(read["IdProductWarehouse"].ToString());
            await read.CloseAsync();

            return idProductWarehouse;
        }
    }
}
