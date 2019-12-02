using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientPaymentPOC.Utilities.Misc
{
    public class ResponseData
    {
        public string Message { get; set; }
        public bool Status { get; set; }
        public object Data { get; set; }

        public static ResponseData SendExceptionMsg(Exception ex)
        {
            return new ResponseData
            {
                Status = false,
                Message = $"{ex}: {ex.Message}",
                Data = null
            };
        }

        public static ResponseData SendFailMsg(string message = null, object data = null)
        {
            return new ResponseData
            {
                Status = false,
                Message = message ?? "Operation Failed",
                Data = data
            };
        }

        public static ResponseData SendSuccessMsg(string message = null, object data = null)
        {
            return new ResponseData
            {
                Status = true,
                Message = message ?? "Operation Successful",
                Data = data
            };
        }
    }
}
