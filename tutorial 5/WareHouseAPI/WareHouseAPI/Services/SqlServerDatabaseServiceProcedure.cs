using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WareHouseAPI.Exceptions;
using WareHouseAPI.Models;

namespace WareHouseAPI.Services
{
    public interface IDatabaseServiceProcedure
    {
        Task<int> AddOrderProcedure(ProductWarehouseDTO dto);
    }
    public class SqlServerDatabaseServiceProcedure : IDatabaseServiceProcedure
    {
        private IConfiguration _configuration;

        public SqlServerDatabaseServiceProcedure(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> AddOrderProcedure(ProductWarehouseDTO dto)
        {
            using SqlConnection con = new SqlConnection(_configuration.GetConnectionString("default"));
            using SqlCommand com = new SqlCommand("AddProductToWarehouse", con);
            com.Connection = con;
            await con.OpenAsync();

            DbTransaction tran = await con.BeginTransactionAsync();
            com.Transaction = (SqlTransaction)tran;
            try
            {
                int rows = -1;
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@IdProduct", dto.IdProduct);
                com.Parameters.AddWithValue("@IdWarehouse", dto.IdWarehouse);
                com.Parameters.AddWithValue("@Amount", dto.Amount);
                com.Parameters.AddWithValue("@CreatedAt", dto.CreatedAt);

                rows = await com.ExecuteNonQueryAsync();

                if (rows < 0) throw new TransactionErrorException();
                await tran.CommitAsync();
            }
            catch (Exception e)
            {
                await tran.RollbackAsync();
                throw new Exception();
            }

            com.CommandText = "SELECT TOP 1 IdProductWarehouse FROM Product_Warehouse ORDDER BY IdProductWarehouse DISC";
            var read = await com.ExecuteReaderAsync();
            await read.ReadAsync();
            int idProductWarehouse = int.Parse(read["IdProductWarehouse"].ToString());
            await read.CloseAsync();

            return idProductWarehouse;
        }
    }
}
