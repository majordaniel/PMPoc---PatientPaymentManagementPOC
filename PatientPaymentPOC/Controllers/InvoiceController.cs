using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PatientPaymentPOC.Data.Models.TbInvoice;
using PatientPaymentPOC.Utilities.Misc;

namespace PatientPaymentPOC.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InvoiceController : Controller
    {

        public IConfiguration Configuration { get; }
        public InvoiceController(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        [HttpPost]
        public async Task<JsonResult> CreateInvoice(TbInvoice InvoiceDetail)
        {
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            int TotalInvoiceAmt = 0;
            DateTime Today = DateTime.Now;

            foreach (var item in InvoiceDetail.TbInvoiceItem)
            {
                int amount = item.ItemAmt;
                TotalInvoiceAmt += amount;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"Insert Into TbInvoice (PatientId, TotalAmt, InvoiceDate, Status,DateCreated)  OUTPUT INSERTED.InvoiceId Values ('{InvoiceDetail.PatientId}', '{TotalInvoiceAmt}','{Today}'," +
                    $"'{InvoiceDetail.Status}','{Today}')";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;

                    connection.Open();
                    int IdAdded = Convert.ToInt32(command.ExecuteScalar());
                    /// command.ExecuteNonQuery();
                  command.Dispose();
                    connection.Close();
                   connection.Dispose();

                    foreach (var item in InvoiceDetail.TbInvoiceItem)
                    {

                        string connectionString2 = Configuration["ConnectionStrings:DefaultConnection"];
                        using (SqlConnection connection2 = new SqlConnection(connectionString2))
                        {

                            string query2 = $"Insert into TbInvoiceItem (InvoiceId,ItemDescription,ItemAmt,DateCreated) Values({IdAdded},'{item.ItemDescription}','{item.ItemAmt}','{Today}')";

                            connection2.Open();

                            //Create a Command object
                            SqlCommand command2 = new SqlCommand(query2, connection2);
                            //   var comandResult = command.ExecuteNonQuery();
                            var comandResult = command2.ExecuteScalar();
                            //Execute the command to SQL Server and return the newly created ID
                            int InsertedItemId = Convert.ToInt32(comandResult);

                            //Close and dispose
                            command2.Dispose();

                            connection2.Close();
                            connection2.Dispose();
                        }

                    }
                    return Json(ResponseData.SendSuccessMsg(message: $"Invoice Id {IdAdded} Created ", data: null));
                }

               
            }

        }
    }
}