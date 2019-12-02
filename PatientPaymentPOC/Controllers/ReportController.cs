using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PatientPaymentPOC.Data.Models.TbInvoice;
using PatientPaymentPOC.Data.Models.tbpatientinfo;
using PatientPaymentPOC.Data.Models.tbpayments;
using PatientPaymentPOC.Utilities.Misc;
using System;
using System.Data.SqlClient;

namespace PatientPaymentPOC.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReportController : Controller
    {
        public IConfiguration Configuration { get; }

        public ReportController(IConfiguration configuration)
        {
            Configuration = configuration;

        }


        #region InvoieReporta
        /// <summary>
        /// Get all the Patient Information
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetInvoiceById(int InvoiceId)
        {
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            TbInvoice invoiceDetails = new TbInvoice();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"select * from tbInvoice where InvoiceId = {InvoiceId}";

                SqlCommand command = new SqlCommand(sql, connection);

                connection.Open();
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        invoiceDetails.InvoiceId = Convert.ToInt32(dataReader["InvoiceId"]);
                        invoiceDetails.PatientId = Convert.ToInt32(dataReader["PatientId"]);
                        invoiceDetails.TotalAmt = Convert.ToInt32(dataReader["TotalAmt"]);
                        invoiceDetails.Status = Convert.ToString(dataReader["Status"]);
                        invoiceDetails.DateCreated = Convert.ToDateTime(dataReader["DateCreated"]);
                        invoiceDetails.InvoiceDate = Convert.ToDateTime(dataReader["InvoiceDate"]);
                    }

                }
                return Json(ResponseData.SendSuccessMsg(message: null, data: invoiceDetails));
            }

           

        }
        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetInvoicesByUserId(int UserId)
        {

            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            TbInvoice invoiceDetails = new TbInvoice();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"select * from tbInvoice where PatientId = {UserId}";

                SqlCommand command = new SqlCommand(sql, connection);

                connection.Open();
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        invoiceDetails.InvoiceId = Convert.ToInt32(dataReader["InvoiceId"]);
                        invoiceDetails.PatientId = Convert.ToInt32(dataReader["PatientId"]);
                        invoiceDetails.TotalAmt = Convert.ToInt32(dataReader["TotalAmt"]);
                        invoiceDetails.Status = Convert.ToString(dataReader["Status"]);
                        invoiceDetails.DateCreated = Convert.ToDateTime(dataReader["DateCreated"]);
                        invoiceDetails.InvoiceDate = Convert.ToDateTime(dataReader["InvoiceDate"]);
                    }

                }
                return Json(ResponseData.SendSuccessMsg(message: null, data: invoiceDetails));
            }


        }
        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetInvoicesBtw2Dates(DateTime StartDate, DateTime EndDate)
        {


            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            TbInvoice invoiceDetails = new TbInvoice();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"select * from tbInvoice where InvoiceDate betweeen '{StartDate}' and  '{EndDate}'";

                SqlCommand command = new SqlCommand(sql, connection);

                connection.Open();
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        invoiceDetails.InvoiceId = Convert.ToInt32(dataReader["InvoiceId"]);
                        invoiceDetails.PatientId = Convert.ToInt32(dataReader["PatientId"]);
                        invoiceDetails.TotalAmt = Convert.ToInt32(dataReader["TotalAmt"]);
                        invoiceDetails.Status = Convert.ToString(dataReader["Status"]);
                        invoiceDetails.DateCreated = Convert.ToDateTime(dataReader["DateCreated"]);
                        invoiceDetails.InvoiceDate = Convert.ToDateTime(dataReader["InvoiceDate"]);
                    }

                }
                return Json(ResponseData.SendSuccessMsg(message: null, data: invoiceDetails));
            }

        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetInvoicesByInvoiceDate(DateTime InvoiceDate)
        {


            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            TbInvoice invoiceDetails = new TbInvoice();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"select * from tbInvoice where InvoiceDate = '{InvoiceDate}'";

                SqlCommand command = new SqlCommand(sql, connection);

                connection.Open();
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        invoiceDetails.InvoiceId = Convert.ToInt32(dataReader["InvoiceId"]);
                        invoiceDetails.PatientId = Convert.ToInt32(dataReader["PatientId"]);
                        invoiceDetails.TotalAmt = Convert.ToInt32(dataReader["TotalAmt"]);
                        invoiceDetails.Status = Convert.ToString(dataReader["Status"]);
                        invoiceDetails.DateCreated = Convert.ToDateTime(dataReader["DateCreated"]);
                        invoiceDetails.InvoiceDate = Convert.ToDateTime(dataReader["InvoiceDate"]);
                    }

                }
                return Json(ResponseData.SendSuccessMsg(message: null, data: invoiceDetails));
            }

        }
        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetInvoicesByInvoiceStatus(string InvoiceStatus)
        {


            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            TbInvoice invoiceDetails = new TbInvoice();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"select * from tbInvoice where Status = '{InvoiceStatus}'";

                SqlCommand command = new SqlCommand(sql, connection);

                connection.Open();
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        invoiceDetails.InvoiceId = Convert.ToInt32(dataReader["InvoiceId"]);
                        invoiceDetails.PatientId = Convert.ToInt32(dataReader["PatientId"]);
                        invoiceDetails.TotalAmt = Convert.ToInt32(dataReader["TotalAmt"]);
                        invoiceDetails.Status = Convert.ToString(dataReader["Status"]);
                        invoiceDetails.DateCreated = Convert.ToDateTime(dataReader["DateCreated"]);
                        invoiceDetails.InvoiceDate = Convert.ToDateTime(dataReader["InvoiceDate"]);
                    }

                }
                return Json(ResponseData.SendSuccessMsg(message: null, data: invoiceDetails));
            }


        }
        #endregion

        #region PaymentsReports


        //-------------------------------Payments Reports Queries

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetPaymentyPaymentId(int PaymentId)
        {

            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            tbpayments PaymentsDetails = new tbpayments();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"select * from tbpayments where PaymentId = {PaymentId}";

                SqlCommand command = new SqlCommand(sql, connection);

                connection.Open();
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        PaymentsDetails.PaymentId = Convert.ToInt32(dataReader["PaymentId"]);
                        PaymentsDetails.InvoiceId = Convert.ToInt32(dataReader["InvoiceId"]);
                         PaymentsDetails.InvoiceTotalAmt = Convert.ToInt32(dataReader["InvoiceTotalAmt"]);
                         PaymentsDetails.AmtPaidSoFar = Convert.ToInt32(dataReader["AmtPaidSoFar"]);
                         PaymentsDetails.AmtPaidNow = Convert.ToInt32(dataReader["AmtPaidNow"]);
                         PaymentsDetails.Balance = Convert.ToInt32(dataReader["Balance"]);
                        PaymentsDetails.ModeOfPayment = Convert.ToString(dataReader["ModeOfPayment"]);
                        PaymentsDetails.PaymentDate = Convert.ToDateTime(dataReader["PaymentDate"]);
                        PaymentsDetails.DateCreated = Convert.ToDateTime(dataReader["DateCreated"]);
                    }
                }
                connection.Close();
                return Json(ResponseData.SendSuccessMsg(message: null, data: PaymentsDetails));
            }

        }
        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetPaymentsByInvoiceId(int InvoiceId)
        {


            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            tbpayments PaymentsDetails = new tbpayments();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"select * from tbpayments where InvoiceId = {InvoiceId}";

                SqlCommand command = new SqlCommand(sql, connection);

                connection.Open();
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        PaymentsDetails.PaymentId = Convert.ToInt32(dataReader["PaymentId"]);
                        PaymentsDetails.InvoiceId = Convert.ToInt32(dataReader["InvoiceId"]);
                        PaymentsDetails.InvoiceTotalAmt = Convert.ToInt32(dataReader["InvoiceTotalAmt"]);
                        PaymentsDetails.AmtPaidSoFar = Convert.ToInt32(dataReader["AmtPaidSoFar"]);
                        PaymentsDetails.AmtPaidNow = Convert.ToInt32(dataReader["AmtPaidNow"]);
                        PaymentsDetails.Balance = Convert.ToInt32(dataReader["Balance"]);
                        PaymentsDetails.ModeOfPayment = Convert.ToString(dataReader["ModeOfPayment"]);
                        PaymentsDetails.PaymentDate = Convert.ToDateTime(dataReader["PaymentDate"]);
                        PaymentsDetails.DateCreated = Convert.ToDateTime(dataReader["DateCreated"]);
                    }
                }
                connection.Close();
                return Json(ResponseData.SendSuccessMsg(message: null, data: PaymentsDetails));

            }
        }
        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetPaymentsByPatientId(int PatientId)
        {

            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            tbpayments PaymentsDetails = new tbpayments();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"select * from tbpayments where PatientId = {PatientId}";

                SqlCommand command = new SqlCommand(sql, connection);

                connection.Open();
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        PaymentsDetails.PaymentId = Convert.ToInt32(dataReader["PaymentId"]);
                        PaymentsDetails.InvoiceId = Convert.ToInt32(dataReader["InvoiceId"]);
                        PaymentsDetails.InvoiceTotalAmt = Convert.ToInt32(dataReader["InvoiceTotalAmt"]);
                        PaymentsDetails.AmtPaidSoFar = Convert.ToInt32(dataReader["AmtPaidSoFar"]);
                        PaymentsDetails.AmtPaidNow = Convert.ToInt32(dataReader["AmtPaidNow"]);
                        PaymentsDetails.Balance = Convert.ToInt32(dataReader["Balance"]);
                        PaymentsDetails.ModeOfPayment = Convert.ToString(dataReader["ModeOfPayment"]);
                        PaymentsDetails.PaymentDate = Convert.ToDateTime(dataReader["PaymentDate"]);
                        PaymentsDetails.DateCreated = Convert.ToDateTime(dataReader["DateCreated"]);
                    }
                }
                connection.Close();
                return Json(ResponseData.SendSuccessMsg(message: null, data: PaymentsDetails));

            }

        }
        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetPaymentByPaymentDate(DateTime PaymentDate)
        {


            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            tbpayments PaymentsDetails = new tbpayments();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"select * from tbpayments where PaymentDate = '{PaymentDate}'";

                SqlCommand command = new SqlCommand(sql, connection);

                connection.Open();
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        PaymentsDetails.PaymentId = Convert.ToInt32(dataReader["PaymentId"]);
                        PaymentsDetails.InvoiceId = Convert.ToInt32(dataReader["InvoiceId"]);
                        PaymentsDetails.InvoiceTotalAmt = Convert.ToInt32(dataReader["InvoiceTotalAmt"]);
                        PaymentsDetails.AmtPaidSoFar = Convert.ToInt32(dataReader["AmtPaidSoFar"]);
                        PaymentsDetails.AmtPaidNow = Convert.ToInt32(dataReader["AmtPaidNow"]);
                        PaymentsDetails.Balance = Convert.ToInt32(dataReader["Balance"]);
                        PaymentsDetails.ModeOfPayment = Convert.ToString(dataReader["ModeOfPayment"]);
                        PaymentsDetails.PaymentDate = Convert.ToDateTime(dataReader["PaymentDate"]);
                        PaymentsDetails.DateCreated = Convert.ToDateTime(dataReader["DateCreated"]);
                    }
                }
                connection.Close();
                return Json(ResponseData.SendSuccessMsg(message: null, data: PaymentsDetails));

            }


        }
        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetPaymentBy2PaymentDates(DateTime StartDate, DateTime EndDate)
        {



            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            tbpayments PaymentsDetails = new tbpayments();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"select * from tbpayments where PaymentDate between '{StartDate}' and '{EndDate}'";

                SqlCommand command = new SqlCommand(sql, connection);

                connection.Open();
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        PaymentsDetails.PaymentId = Convert.ToInt32(dataReader["PaymentId"]);
                        PaymentsDetails.InvoiceId = Convert.ToInt32(dataReader["InvoiceId"]);
                        PaymentsDetails.InvoiceTotalAmt = Convert.ToInt32(dataReader["InvoiceTotalAmt"]);
                        PaymentsDetails.AmtPaidSoFar = Convert.ToInt32(dataReader["AmtPaidSoFar"]);
                        PaymentsDetails.AmtPaidNow = Convert.ToInt32(dataReader["AmtPaidNow"]);
                        PaymentsDetails.Balance = Convert.ToInt32(dataReader["Balance"]);
                        PaymentsDetails.ModeOfPayment = Convert.ToString(dataReader["ModeOfPayment"]);
                        PaymentsDetails.PaymentDate = Convert.ToDateTime(dataReader["PaymentDate"]);
                        PaymentsDetails.DateCreated = Convert.ToDateTime(dataReader["DateCreated"]);
                    }
                }
                connection.Close();
                return Json(ResponseData.SendSuccessMsg(message: null, data: PaymentsDetails));

            }

        }
        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetPaymentByAmountRange(int MinAmt, int MaxAmt)
        {



            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            tbpayments PaymentsDetails = new tbpayments();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"select * from tbpayments where AmtPaidNow between {MinAmt} and {MaxAmt}";

                SqlCommand command = new SqlCommand(sql, connection);

                connection.Open();
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        PaymentsDetails.PaymentId = Convert.ToInt32(dataReader["PaymentId"]);
                        PaymentsDetails.InvoiceId = Convert.ToInt32(dataReader["InvoiceId"]);
                        PaymentsDetails.InvoiceTotalAmt = Convert.ToInt32(dataReader["InvoiceTotalAmt"]);
                        PaymentsDetails.AmtPaidSoFar = Convert.ToInt32(dataReader["AmtPaidSoFar"]);
                        PaymentsDetails.AmtPaidNow = Convert.ToInt32(dataReader["AmtPaidNow"]);
                        PaymentsDetails.Balance = Convert.ToInt32(dataReader["Balance"]);
                        PaymentsDetails.ModeOfPayment = Convert.ToString(dataReader["ModeOfPayment"]);
                        PaymentsDetails.PaymentDate = Convert.ToDateTime(dataReader["PaymentDate"]);
                        PaymentsDetails.DateCreated = Convert.ToDateTime(dataReader["DateCreated"]);
                    }
                }
                connection.Close();
                return Json(ResponseData.SendSuccessMsg(message: null, data: PaymentsDetails));

            }

        }
        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetPaymentByPaymentMode(string PaymentMode)
        {

            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            tbpayments PaymentsDetails = new tbpayments();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"select * from tbpayments where ModeOfPayment = '{PaymentMode}'";

                SqlCommand command = new SqlCommand(sql, connection);

                connection.Open();
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        PaymentsDetails.PaymentId = Convert.ToInt32(dataReader["PaymentId"]);
                        PaymentsDetails.InvoiceId = Convert.ToInt32(dataReader["InvoiceId"]);
                        PaymentsDetails.InvoiceTotalAmt = Convert.ToInt32(dataReader["InvoiceTotalAmt"]);
                        PaymentsDetails.AmtPaidSoFar = Convert.ToInt32(dataReader["AmtPaidSoFar"]);
                        PaymentsDetails.AmtPaidNow = Convert.ToInt32(dataReader["AmtPaidNow"]);
                        PaymentsDetails.Balance = Convert.ToInt32(dataReader["Balance"]);
                        PaymentsDetails.ModeOfPayment = Convert.ToString(dataReader["ModeOfPayment"]);
                        PaymentsDetails.PaymentDate = Convert.ToDateTime(dataReader["PaymentDate"]);
                        PaymentsDetails.DateCreated = Convert.ToDateTime(dataReader["DateCreated"]);
                    }
                }
                connection.Close();
                return Json(ResponseData.SendSuccessMsg(message: null, data: PaymentsDetails));

            }
        }
        #endregion

        #region PatientInfoReports


        //----------------------- Patients Info Report

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetPatientByPatientId(int PatientId)
        {

            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            TbPatientInfo PatientDetails = new TbPatientInfo();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"select * from tbpatientInfo where PatientId = {PatientId}";

                SqlCommand command = new SqlCommand(sql, connection);

                connection.Open();
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
           
                        PatientDetails.PatientId = Convert.ToInt32(dataReader["PatientId"]);
                        PatientDetails.FirstName = Convert.ToString(dataReader["Status"]);
                        PatientDetails.LastName = Convert.ToString(dataReader["Status"]);
                        PatientDetails.DOB = Convert.ToDateTime(dataReader["DateCreated"]);
                        PatientDetails.Email = Convert.ToString(dataReader["Email"]);
                        PatientDetails.PhoneNo = Convert.ToString(dataReader["PhoneNo"]);
                        PatientDetails.State = Convert.ToString(dataReader["State"]);
                        PatientDetails.LGA = Convert.ToString(dataReader["LGA"]);
                        PatientDetails.Gender = Convert.ToString(dataReader["Gender"]);
                        PatientDetails.BGroup = Convert.ToString(dataReader["BGroup"]);
                        PatientDetails.GType = Convert.ToString(dataReader["GType"]);
                        PatientDetails.DateCreated = Convert.ToDateTime(dataReader["DateCreated"]);
                    }

                }
                return Json(ResponseData.SendSuccessMsg(message: null, data: PatientDetails));
            }


        }


        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetPatientByFirstName(string FirstName)
        {


            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            TbPatientInfo PatientDetails = new TbPatientInfo();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"select * from tbpatientInfo where FirstName = '{FirstName}'";

                SqlCommand command = new SqlCommand(sql, connection);

                connection.Open();
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {

                        PatientDetails.PatientId = Convert.ToInt32(dataReader["PatientId"]);
                        PatientDetails.FirstName = Convert.ToString(dataReader["Status"]);
                        PatientDetails.LastName = Convert.ToString(dataReader["Status"]);
                        PatientDetails.DOB = Convert.ToDateTime(dataReader["DateCreated"]);
                        PatientDetails.Email = Convert.ToString(dataReader["Email"]);
                        PatientDetails.PhoneNo = Convert.ToString(dataReader["PhoneNo"]);
                        PatientDetails.State = Convert.ToString(dataReader["State"]);
                        PatientDetails.LGA = Convert.ToString(dataReader["LGA"]);
                        PatientDetails.Gender = Convert.ToString(dataReader["Gender"]);
                        PatientDetails.BGroup = Convert.ToString(dataReader["BGroup"]);
                        PatientDetails.GType = Convert.ToString(dataReader["GType"]);
                        PatientDetails.DateCreated = Convert.ToDateTime(dataReader["DateCreated"]);
                    }

                }
                return Json(ResponseData.SendSuccessMsg(message: null, data: PatientDetails));
            }


        }
        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetPatientByEmail(string Email)
        {

            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            TbPatientInfo PatientDetails = new TbPatientInfo();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"select * from tbpatientInfo where Email = '{Email}'";

                SqlCommand command = new SqlCommand(sql, connection);

                connection.Open();
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {

                        PatientDetails.PatientId = Convert.ToInt32(dataReader["PatientId"]);
                        PatientDetails.FirstName = Convert.ToString(dataReader["Status"]);
                        PatientDetails.LastName = Convert.ToString(dataReader["Status"]);
                        PatientDetails.DOB = Convert.ToDateTime(dataReader["DateCreated"]);
                        PatientDetails.Email = Convert.ToString(dataReader["Email"]);
                        PatientDetails.PhoneNo = Convert.ToString(dataReader["PhoneNo"]);
                        PatientDetails.State = Convert.ToString(dataReader["State"]);
                        PatientDetails.LGA = Convert.ToString(dataReader["LGA"]);
                        PatientDetails.Gender = Convert.ToString(dataReader["Gender"]);
                        PatientDetails.BGroup = Convert.ToString(dataReader["BGroup"]);
                        PatientDetails.GType = Convert.ToString(dataReader["GType"]);
                        PatientDetails.DateCreated = Convert.ToDateTime(dataReader["DateCreated"]);
                    }

                }
                return Json(ResponseData.SendSuccessMsg(message: null, data: PatientDetails));
            }

        }
        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetPatientByPhoneNo(string PhoneNo)
        {


            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            TbPatientInfo PatientDetails = new TbPatientInfo();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"select * from tbpatientInfo where PhoneNo = '{PhoneNo}'";

                SqlCommand command = new SqlCommand(sql, connection);

                connection.Open();
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {

                        PatientDetails.PatientId = Convert.ToInt32(dataReader["PatientId"]);
                        PatientDetails.FirstName = Convert.ToString(dataReader["Status"]);
                        PatientDetails.LastName = Convert.ToString(dataReader["Status"]);
                        PatientDetails.DOB = Convert.ToDateTime(dataReader["DateCreated"]);
                        PatientDetails.Email = Convert.ToString(dataReader["Email"]);
                        PatientDetails.PhoneNo = Convert.ToString(dataReader["PhoneNo"]);
                        PatientDetails.State = Convert.ToString(dataReader["State"]);
                        PatientDetails.LGA = Convert.ToString(dataReader["LGA"]);
                        PatientDetails.Gender = Convert.ToString(dataReader["Gender"]);
                        PatientDetails.BGroup = Convert.ToString(dataReader["BGroup"]);
                        PatientDetails.GType = Convert.ToString(dataReader["GType"]);
                        PatientDetails.DateCreated = Convert.ToDateTime(dataReader["DateCreated"]);
                    }

                }
                return Json(ResponseData.SendSuccessMsg(message: null, data: PatientDetails));
            }

        }
        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetPatientByBGroup(string BGroup)
        {

            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            TbPatientInfo PatientDetails = new TbPatientInfo();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"select * from tbpatientInfo where BGroup = '{BGroup}'";

                SqlCommand command = new SqlCommand(sql, connection);

                connection.Open();
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {

                        PatientDetails.PatientId = Convert.ToInt32(dataReader["PatientId"]);
                        PatientDetails.FirstName = Convert.ToString(dataReader["Status"]);
                        PatientDetails.LastName = Convert.ToString(dataReader["Status"]);
                        PatientDetails.DOB = Convert.ToDateTime(dataReader["DateCreated"]);
                        PatientDetails.Email = Convert.ToString(dataReader["Email"]);
                        PatientDetails.PhoneNo = Convert.ToString(dataReader["PhoneNo"]);
                        PatientDetails.State = Convert.ToString(dataReader["State"]);
                        PatientDetails.LGA = Convert.ToString(dataReader["LGA"]);
                        PatientDetails.Gender = Convert.ToString(dataReader["Gender"]);
                        PatientDetails.BGroup = Convert.ToString(dataReader["BGroup"]);
                        PatientDetails.GType = Convert.ToString(dataReader["GType"]);
                        PatientDetails.DateCreated = Convert.ToDateTime(dataReader["DateCreated"]);
                    }

                }
                return Json(ResponseData.SendSuccessMsg(message: null, data: PatientDetails));
            }

        }
        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetPatientByGType(string GType)
        {


            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            TbPatientInfo PatientDetails = new TbPatientInfo();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"select * from tbpatientInfo where GType = '{GType}'";

                SqlCommand command = new SqlCommand(sql, connection);

                connection.Open();
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {

                        PatientDetails.PatientId = Convert.ToInt32(dataReader["PatientId"]);
                        PatientDetails.FirstName = Convert.ToString(dataReader["Status"]);
                        PatientDetails.LastName = Convert.ToString(dataReader["Status"]);
                        PatientDetails.DOB = Convert.ToDateTime(dataReader["DateCreated"]);
                        PatientDetails.Email = Convert.ToString(dataReader["Email"]);
                        PatientDetails.PhoneNo = Convert.ToString(dataReader["PhoneNo"]);
                        PatientDetails.State = Convert.ToString(dataReader["State"]);
                        PatientDetails.LGA = Convert.ToString(dataReader["LGA"]);
                        PatientDetails.Gender = Convert.ToString(dataReader["Gender"]);
                        PatientDetails.BGroup = Convert.ToString(dataReader["BGroup"]);
                        PatientDetails.GType = Convert.ToString(dataReader["GType"]);
                        PatientDetails.DateCreated = Convert.ToDateTime(dataReader["DateCreated"]);
                    }

                }
                return Json(ResponseData.SendSuccessMsg(message: null, data: PatientDetails));
            }

        }

        #endregion
    }
}