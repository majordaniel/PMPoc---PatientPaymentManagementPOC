using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PatientPaymentPOC.Data.Models.tbpatientinfo;
using PatientPaymentPOC.Utilities.Misc;

namespace PatientPaymentPOC.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PatientInfoController : Controller
    {
        public IConfiguration Configuration { get; }
        private string ConnectionString = string.Empty;
        public PatientInfoController(IConfiguration configuration)
        {
            Configuration = configuration;
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];

        }


        /// <summary>
        /// Create a new Patient Info
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        [HttpPost]
        [AllowAnonymous]
        public async Task<JsonResult> AddPatientInfo(TbPatientInfo patientInfo)
        {


            var connectionString = Configuration["ConnectionStrings:DefaultConnection"];

            var DateCreated = DateTime.Now;
            //Create the SQL Query for inserting an article

            string sqlQuery = $"Insert Into tbPatientInfo(FirstName, LastName, DOB, Email, PhoneNo, State, LGA, Gender, BGroup, GType, DateCreated) OUTPUT INSERTED.PatientId Values " +
                $"('{patientInfo.FirstName}', '{patientInfo.LastName}', '{patientInfo.DOB}', '{patientInfo.Email}', '{patientInfo.PhoneNo}', '{patientInfo.State}', " +
           $"'{patientInfo.LGA}','{patientInfo.Gender}','{patientInfo.BGroup}','{patientInfo.GType}','{DateCreated}')";


            //Create and open a connection to SQL Server
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            //Create a Command object
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            //   var comandResult = command.ExecuteNonQuery();
            var comandResult = command.ExecuteScalar();
            //Execute the command to SQL Server and return the newly created ID
            int newPatInfoID = Convert.ToInt32(comandResult);

            //Close and dispose
            command.Dispose();
            connection.Close();
            connection.Dispose();

            // Set return value
            //  return newArticleID;
            return Json(ResponseData.SendSuccessMsg(message: $"SUccessfull Created a New Patient Info with Id = {newPatInfoID}", data: null));


        }
        /// <summary>
        /// Get all the Patient Information
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetAllPatientInfo()
        {
            #region another
            //--------------------------------------------------
            //List<TbPatientInfo> PatientList = new List<TbPatientInfo>();

            //string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    //SqlDataReader
            //    connection.Open();

            //    string sql = "Select * From PatientInfo";
            //    SqlCommand command = new SqlCommand(sql, connection);

            //    using (SqlDataReader dataReader = command.ExecuteReader())
            //    {
            //        while (dataReader.Read())
            //        {
            //            TbPatientInfo patient = new TbPatientInfo();
            //            patient.PatientId = Convert.ToInt32(dataReader["PatientId"]);
            //            patient.FirstName = Convert.ToString(dataReader["FirstName"]);
            //            patient.LastName = Convert.ToString(dataReader["LastName"]);
            //            patient.DOB = Convert.ToDateTime(dataReader["DOB"]);
            //            patient.Email = Convert.ToString(dataReader["Email"]);
            //            patient.PhoneNo = Convert.ToString(dataReader["PhoneNo"]);
            //            patient.State = Convert.ToString(dataReader["State"]);
            //            patient.LGA = Convert.ToString(dataReader["LGA"]);
            //            patient.Gender = Convert.ToString(dataReader["Gender"]);
            //            patient.BGroup = Convert.ToString(dataReader["BGroup"]);
            //            patient.GType = Convert.ToString(dataReader["Gtype"]);
            //            patient.DateCreated = Convert.ToDateTime(dataReader["DateCreated"]);

            //            PatientList.Add(patient);
            //        }
            //    }

            //    connection.Close();
            //}
            //return Json(ResponseData.SendSuccessMsg(message: null, data: PatientList));

            //------------------------------------------------------------------

            #endregion 
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            List<TbPatientInfo> PatientList = new List<TbPatientInfo>();

            //Create the SQL Query for returning all the articles
            string sqlQuery = String.Format("select * from TbPatientInfo");
 
            //Create and open a connection to SQL Server
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
 
            SqlCommand command = new SqlCommand(sqlQuery, connection);
 
            //Create DataReader for storing the returning table into server memory
            SqlDataReader dataReader = command.ExecuteReader();

            TbPatientInfo patientInfo = null;
 
            //load into the result object the returned row from the database
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    patientInfo = new TbPatientInfo();

                    patientInfo.PatientId = Convert.ToInt32(dataReader["PatientId"]);
                    patientInfo.FirstName = Convert.ToString(dataReader["FirstName"]);
                    patientInfo.LastName = Convert.ToString(dataReader["LastName"]);
                    patientInfo.DOB = Convert.ToDateTime(dataReader["DOB"]);
                    patientInfo.Email = Convert.ToString(dataReader["Email"]);
                    patientInfo.PhoneNo = Convert.ToString(dataReader["PhoneNo"]);
                    patientInfo.State = Convert.ToString(dataReader["State"]);
                    patientInfo.LGA = Convert.ToString(dataReader["LGA"]);
                    patientInfo.Gender = Convert.ToString(dataReader["Gender"]);
                    patientInfo.BGroup = Convert.ToString(dataReader["BGroup"]);
                    patientInfo.GType = Convert.ToString(dataReader["Gtype"]);
                    patientInfo.DateCreated = Convert.ToDateTime(dataReader["DateCreated"]);
                    PatientList.Add(patientInfo);
                }
                connection.Close();
            }
 
            return Json(ResponseData.SendSuccessMsg(message: null, data: PatientList));
        }


        /// <summary>
        /// Get the information of a single patient
        /// </summary>
        /// <param name="PatientId"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<JsonResult> GetAPatientInfo(int PatientId)
        {

            #region another
            //--------------------------------------------------------------------------------

            //Article result = new Article();

            ////Create the SQL Query for returning an article category based on its primary key
            //string sqlQuery = String.Format("select * from Article where ArticleID={0}", articleId);

            ////Create and open a connection to SQL Server
            //SqlConnection connection = new SqlConnection(ConnectionString);
            //connection.Open();

            //SqlCommand command = new SqlCommand(sqlQuery, connection);

            //SqlDataReader dataReader = command.ExecuteReader();

            ////load into the result object the returned row from the database
            //if (dataReader.HasRows)
            //{
            //    while (dataReader.Read())
            //    {
            //        result.ArticleId = Convert.ToInt32(dataReader["ArticleID"]);
            //        result.Body = dataReader["Body"].ToString();
            //        result.CategoryId = Convert.ToInt32(dataReader["CategoryID"]);
            //        result.PublishDate = Convert.ToDateTime(dataReader["PublishDate"]);
            //        result.Title = dataReader["Title"].ToString();
            //    }
            //}

            //return result;
            //---------------------------------------------------------------------------------------

            #endregion
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];

            TbPatientInfo patientInfo = new TbPatientInfo();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"Select * From TbPatientInfo Where PatientId='{PatientId}'";
                SqlCommand command = new SqlCommand(sql, connection);

                connection.Open();

                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        patientInfo.PatientId = Convert.ToInt32(dataReader["PatientId"]);
                        patientInfo.FirstName = Convert.ToString(dataReader["FirstName"]);
                        patientInfo.LastName = Convert.ToString(dataReader["LastName"]);
                        patientInfo.DOB = Convert.ToDateTime(dataReader["DOB"]);
                        patientInfo.Email = Convert.ToString(dataReader["Email"]);
                        patientInfo.PhoneNo = Convert.ToString(dataReader["PhoneNo"]);
                        patientInfo.State = Convert.ToString(dataReader["State"]);
                        patientInfo.LGA = Convert.ToString(dataReader["LGA"]);
                        patientInfo.Gender = Convert.ToString(dataReader["Gender"]);
                        patientInfo.BGroup = Convert.ToString(dataReader["BGroup"]);
                        patientInfo.GType = Convert.ToString(dataReader["GType"]);
                        patientInfo.DateCreated = Convert.ToDateTime(dataReader["DateCreated"]);
                    }
                }
                connection.Close();
                return Json(ResponseData.SendSuccessMsg(message: null, data: patientInfo));
            
            }

          return Json(ResponseData.SendFailMsg(message: null, data: null));
        }
    }


}