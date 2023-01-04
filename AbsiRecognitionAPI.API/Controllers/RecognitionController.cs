using AbsiRecognitionAPI.Business.Entities;
using AbsiRecognitionAPI.Business.Interface;
using log4net;
using StaticWebAPI.Business.Entities;
using System;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;

namespace AbsiRecognitionAPI.API.Controllers
{
    public class RecognitionController : ApiController
    {
        public IRecognitionManager IRecognitionManager;

        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public RecognitionController(IRecognitionManager IRecognitionManager)
        {
            this.IRecognitionManager = IRecognitionManager;
        }

        public static string EncryptText(string text)
        {
            if (text != string.Empty)
            {
                string EncryptionKey = "AMAZEINCBNG";
                byte[] clearBytes = Encoding.Unicode.GetBytes(text);
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(clearBytes, 0, clearBytes.Length);
                            cs.Close();
                        }
                        text = Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
            return text;
        }
        public static string DecryptText(string cipherText)
        {
            string EncryptionKey = "AMAZEINCBNG";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }

        [HttpPost]
        [Route("Recognition/EncryptData")]
        public HttpResponseMessage EncryptData(RecognitionOneEntity entity)
        {
            HttpResponseMessage response;
            try
            {
                var input = entity.TextToEncrypt;
                string res = EncryptText(input);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in GetStaffDetails in Master Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpPost]
        [Route("Recognition/DecryptData")]
        public HttpResponseMessage DecryptData(RecognitionOneEntity entity)
        {
            HttpResponseMessage response;
            try
            {
                var input = entity.TextToDecrypt;
                string res = DecryptText(input);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in GetStaffDetails in Master Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("Recognition/GetStaffDetails")]
        public HttpResponseMessage GetStaffDetails()
        {
            HttpResponseMessage response;
            try
            {
                object res = IRecognitionManager.GetStaffDetails();
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in GetStaffDetails in Master Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("Recognition/CheckStaffLogin")]
        public HttpResponseMessage CheckStaffLogin(string EmailID, string Password, Int64 LoginType)
        {
            HttpResponseMessage response;
            try
            {
                var filter = new
                {
                    EmailID= EmailID,
                    Password= Password,
                    LoginType= LoginType
                };
                object res = IRecognitionManager.CheckStaffLogin(filter);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in CheckStaffLogin in Recognition Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }
        [HttpGet]
        [Route("Recognition/GetManagerPointsMaster")]
        public HttpResponseMessage GetManagerPointsMaster()
        {
            HttpResponseMessage response;
            try
            {
                object res = IRecognitionManager.GetManagerPointsMaster();
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in GetManagerPointsMaster in Recognition Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("Recognition/GetManagerPointsTransactions")]
        public HttpResponseMessage GetManagerPointsTransactions()
        {
            HttpResponseMessage response;
            try
            {
                object res = IRecognitionManager.GetManagerPointsTransactions();
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in GetManagerPointsTransactions in Recognition Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpPost]
        [Route("Recognition/InsertManagerPointsMaster")]
        public HttpResponseMessage InsertManagerPointsMaster(RecognitionOneEntity RecognitionOneEntity)
        {
            HttpResponseMessage response;
            try
            {


                Int64 result = IRecognitionManager.InsertManagerPointsMaster(RecognitionOneEntity);
                response = Request.CreateResponse(HttpStatusCode.OK, result);


            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error("Error in InsertManagerPointsMaster", ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message + "Error:InsertManagerPointsMaster");
            }
            return response;
        }

        [HttpPost]
        [Route("Recognition/InsertManagerPointsTransactions")]
        public HttpResponseMessage InsertManagerPointsTransactions(RecognitionOneEntity RecognitionOneEntity)
        {
            HttpResponseMessage response;
            try
            {


                Int64 result = IRecognitionManager.InsertManagerPointsTransactions(RecognitionOneEntity);
                response = Request.CreateResponse(HttpStatusCode.OK, result);


            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error("Error in InsertManagerPointsTransactions", ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message + "Error:InsertManagerPointsTransactions");
            }
            return response;
        }

        [HttpPost]
        [Route("Recognition/UpdateManagerPointsMaster")]
        public HttpResponseMessage UpdateCertificationChapterMaster(RecognitionOneEntity RecognitionOneEntity)
        {
            HttpResponseMessage response;
            try
            {
                object res = IRecognitionManager.UpdateManagerPointsMaster(RecognitionOneEntity);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in UpdateManagerPointsMaster in Recognition Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }
        [HttpPost]
        [Route("Recognition/UpdateManagerPointsTransactions")]
        public HttpResponseMessage UpdateManagerPointsTransactions(RecognitionOneEntity RecognitionOneEntity)
        {
            HttpResponseMessage response;
            try
            {
                object res = IRecognitionManager.UpdateManagerPointsTransactions(RecognitionOneEntity);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in UpdateManagerPointsTransactions in Recognition Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }
        [HttpGet]
        [Route("Recognition/GetManagerPointsMasterByID")]
        public HttpResponseMessage GetManagerPointsMasterByID(Int64 ID)
        {
            HttpResponseMessage response;
            try
            {
                var j = new
                {
                    ID = ID
                };
                object res = IRecognitionManager.GetManagerPointsMasterByID(j);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in GetManagerPointsMasterByID in Recognition Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("Recognition/GetManagerPointsTransactionsByID")]
        public HttpResponseMessage GetManagerPointsTransactionsByID(Int64 ID)
        {
            HttpResponseMessage response;
            try
            {
                var j = new
                {
                    ID = ID
                };
                object res = IRecognitionManager.GetManagerPointsTransactionsByID(j);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in GetManagerPointsTransactionsByID in Recognition Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }
        [HttpGet]
        [Route("Recognition/DeleteManagerPointsMaster")]
        public HttpResponseMessage DeleteManagerPointsMaster(Int64 ID)
        {
            HttpResponseMessage response;
            try
            {
                var filter = new { ID = ID };
                Int64 Result = IRecognitionManager.DeleteManagerPointsMaster(filter);
                response = Request.CreateResponse(HttpStatusCode.OK, Result);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error("Error in Users/DeleteManagerPointsMaster :" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message + " Users/DeleteManagerPointsMaster");
            }
            return response;
        }

        [HttpGet]
        [Route("Recognition/DeleteManagerPointsTransactions")]
        public HttpResponseMessage DeleteManagerPointsTransactions(Int64 ID)
        {
            HttpResponseMessage response;
            try
            {
                var filter = new { ID = ID };
                Int64 Result = IRecognitionManager.DeleteManagerPointsTransactions(filter);
                response = Request.CreateResponse(HttpStatusCode.OK, Result);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error("Error in Users/DeleteManagerPointsTransactions :" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message + " Users/DeleteManagerPointsTransactions");
            }
            return response;
        }
        [HttpGet]
        [Route("Recognition/GetManagerPointsRequests")]
        public HttpResponseMessage GetManagerPointsRequests()
        {
            HttpResponseMessage response;
            try
            {
                object res = IRecognitionManager.GetManagerPointsRequests();
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in GetManagerPointsRequests in Recognition Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }
        [HttpGet]
        [Route("Recognition/GetStatusMaster")]
        public HttpResponseMessage GetStatusMaster()
        {
            HttpResponseMessage response;
            try
            {
                object res = IRecognitionManager.GetStatusMaster();
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in GetStatusMaster in Recognition Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }
        [HttpGet]
        [Route("Recognition/GetManagerPointsRequestsByID")]
        public HttpResponseMessage GetManagerPointsRequestsByID(Int64 ID)
        {
            HttpResponseMessage response;
            try
            {
                var j = new
                {
                    ID = ID
                };
                object res = IRecognitionManager.GetManagerPointsRequestsByID(j);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in GetManagerPointsRequestsByID in Recognition Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }
        [HttpPost]
        [Route("Recognition/InsertManagerPointsRequests")]
        public HttpResponseMessage InsertManagerPointsRequests(RecognitionOneEntity RecognitionOneEntity)
        {
            HttpResponseMessage response;
            try
            {
                Int64 result = IRecognitionManager.InsertManagerPointsRequests(RecognitionOneEntity);
                response = Request.CreateResponse(HttpStatusCode.OK, result);

            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error("Error in InsertManagerPointsRequests", ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message + "Error:InsertManagerPointsRequests");
            }
            return response;
        }

        [HttpPost]
        [Route("Recognition/UpdateManagerPointsRequests")]
        public HttpResponseMessage UpdateManagerPointsRequests(RecognitionOneEntity RecognitionOneEntity)
        {
            HttpResponseMessage response;
            try
            {
                object res = IRecognitionManager.UpdateManagerPointsRequests(RecognitionOneEntity);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in UpdateManagerPointsRequests in Recognition Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }
        [HttpGet]
        [Route("Recognition/DeleteManagerPointsRequests")]
        public HttpResponseMessage DeleteManagerPointsRequests(Int64 ID)
        {
            HttpResponseMessage response;
            try
            {
                var filter = new { ID = ID };
                Int64 Result = IRecognitionManager.DeleteManagerPointsRequests(filter);
                response = Request.CreateResponse(HttpStatusCode.OK, Result);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error("Error in Users/DeleteManagerPointsRequests :" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message + " Users/DeleteManagerPointsRequests");
            }
            return response;
        }

        [HttpGet]
        [Route("Recognition/GetStaffDetailsByID")]
        public HttpResponseMessage GetStaffDetailsByID(Int64 ID)
        {
            HttpResponseMessage response;
            try
            {
                var j = new
                {
                    ID = ID
                };
                object res = IRecognitionManager.GetStaffDetailsByID(j);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in GetStaffDetailsByID in Master Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }


        [HttpGet]
        [Route("Recognition/GetStaffDetailsByTypeID")]
        public HttpResponseMessage GetStaffDetailsByTypeID(Int64 TypeID)
        {
            HttpResponseMessage response;
            try
            {
                var j = new
                {
                    TypeID = TypeID
                };
                object res = IRecognitionManager.GetStaffDetailsByTypeID(j);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in GetStaffDetailsByTypeID in Master Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

    }
}
