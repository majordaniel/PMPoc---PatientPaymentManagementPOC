using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PatientPaymentPOC.Data.Models.tbpayments;

using PatientPaymentPOC.Utilities.Misc;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace PatientPaymentPOC.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PaymentController : Controller
    {
        public IConfiguration Configuration { get; }
        //private string ConnectionString = string.Empty;
        public PaymentController(IConfiguration configuration)
        {
            Configuration = configuration;
            // string connectionString = Configuration["ConnectionStrings:DefaultConnection"];

        }

        /// <summary>
        /// The Endpoint to capture Patients payments
        /// </summary>
        /// <param name="patientInfo"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<JsonResult> MakePayments(tbpayments paymentdetails)
        {

            var connectionString = Configuration["ConnectionStrings:DefaultConnection"];

            var DateCreated = DateTime.Now;
            var getInvoiceDetails = $"select TotalAmt from TbInvoice where InvoiceId = {paymentdetails.InvoiceId}";


            var getThePaidAmountSofarOnInvoice = $"select sum(AmtPaidNow) as AMTPAIDSOFAR from TbPayments where InvoiceId = {paymentdetails.InvoiceId}";


            //Create and open a connection to SQL Server
            SqlConnection connection = new SqlConnection(connectionString);
            SqlConnection connection2 = new SqlConnection(connectionString);
            SqlConnection connection3 = new SqlConnection(connectionString);
            SqlConnection connection4 = new SqlConnection(connectionString);
            connection.Open();
            connection2.Open();


            //Create a Command object
            SqlCommand command = new SqlCommand(getInvoiceDetails, connection);
            SqlCommand command2 = new SqlCommand(getThePaidAmountSofarOnInvoice, connection2);

            //Create DataReader for storing the returning table into server memory
            SqlDataReader dataReader = command.ExecuteReader();
            SqlDataReader dataReader2 = command2.ExecuteReader();

            int InvoiceTotalAmount = 0;
            int TotalAmountPaidSofarOnTheInvoice = 0;

            string InvoiceStatus = null;
            //load into the result object the returned row from the database
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    InvoiceTotalAmount = Convert.ToInt32(dataReader["TotalAmt"]);
                }
            }

            if (dataReader2.HasRows)
            {
                while (dataReader.Read())
                {
                    //if (!dataReader2.IsDBNull(1))
                    //{

                    //}
                    //else
                    //{
                    //    TotalAmountPaidSofarOnTheInvoice = 0;
                    //}
                    TotalAmountPaidSofarOnTheInvoice = Convert.ToInt32(dataReader["AMTPAIDSOFAR"]);
                }
            }
            if (paymentdetails.AmtPaidNow + TotalAmountPaidSofarOnTheInvoice >= InvoiceTotalAmount)
            {
                InvoiceStatus = "Fully Paid";
            }
            if (paymentdetails.AmtPaidNow + TotalAmountPaidSofarOnTheInvoice <= InvoiceTotalAmount)
            {
                InvoiceStatus = "Partially Paid";
            }

            int Balance = 0;
            Balance = InvoiceTotalAmount - TotalAmountPaidSofarOnTheInvoice + (int)paymentdetails.AmtPaidNow;
            //------ perform the Main Insert -------------

            var XXX = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                var insertQuery = $" INSERT INTO TbPayments(InvoiceId ,InvoiceTotalAmt,AmtPaidSoFar ,AmtPaidNow ,Balance,PaymentDate ,ModeOfPayment ,DateCreated)" +
                $" VALUES('{paymentdetails.InvoiceId}', {InvoiceTotalAmount}, {TotalAmountPaidSofarOnTheInvoice}, {paymentdetails.AmtPaidNow}, {Balance}, '{DateCreated}', 'CASH', '{DateCreated}')";

                conn.Open();
                //Create a Command object
                SqlCommand MainCommand = new SqlCommand(insertQuery, conn);
                //   var comandResult = command.ExecuteNonQuery();
                var commandResult = MainCommand.ExecuteScalar();
                int NewPaymentId = Convert.ToInt32(commandResult);
                XXX = NewPaymentId;
                //Close and dispose
                command2.Dispose();

                connection2.Close();
                connection2.Dispose();
            }
            

            int TheAmoutPaidAllTogether = 0;

            TheAmoutPaidAllTogether = TotalAmountPaidSofarOnTheInvoice + (int)paymentdetails.AmtPaidNow;


            //----- update the Invoice Table on the status of the invoice
            var changeInvoiceStatus = $"update TbInvoice set Status = '{InvoiceStatus}' where " +
                $"InvoiceId = {paymentdetails.InvoiceId}";
            connection4.Open();

            //Create a Command object
            SqlCommand command3 = new SqlCommand(changeInvoiceStatus, connection4);
            //   var comandResult = command.ExecuteNonQuery();
            var comandResult3 = command3.ExecuteScalar();


            return Json(ResponseData.SendSuccessMsg(message: $"You have succesfully made a payment with PaymentId = {XXX}  on the Invoice Id {paymentdetails.InvoiceId} the Invoice is {InvoiceStatus} with a total amount paid so far on" +
                $"this invoice is = {TheAmoutPaidAllTogether}", data: null));

        }

    }
}