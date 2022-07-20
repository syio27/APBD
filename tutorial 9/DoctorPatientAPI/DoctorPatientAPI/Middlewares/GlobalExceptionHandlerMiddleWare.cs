using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorPatientAPI.Middlewares
{
    public class GlobalExceptionHandlerMiddleWare
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandlerMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        // TODO: log all errors to log.txt
        public async Task Invoke(HttpContext httpContext)
        {
            string filePath = @"C:\Users\77076\Desktop\APBD\tutorial 9\tutorial-9-ihord-syio27\DoctorPatientAPI\DoctorPatientAPI\Log\log.txt";

            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("-----------------------------------------------------------------------------");
                    writer.WriteLine("Date : " + DateTime.Now.ToString());
                    writer.WriteLine();

                    while (ex != null)
                    {
                        writer.WriteLine(ex.GetType().FullName);
                        writer.WriteLine("Message : " + ex.Message);
                        writer.WriteLine("StackTrace : " + ex.StackTrace);

                        ex = ex.InnerException;
                    }
                }
                httpContext.Response.StatusCode = 500;
                await httpContext.Response.WriteAsync("ERROR OCCURED -> CHECK LOG.TXT FILE");
            }
        }
    }
}
