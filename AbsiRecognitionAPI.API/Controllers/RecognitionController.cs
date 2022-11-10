using AbsiRecognitionAPI.Business.Entities;
using AbsiRecognitionAPI.Business.Interface;
using log4net;
using System;
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
                    log.Error(" Error in CheckStaffLogin in Master Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }
    }
}
