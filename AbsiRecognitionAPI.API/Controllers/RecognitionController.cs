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
using System.Web.Hosting;
using System.Web;
using System.Web.Http;
using System.Linq;

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
                    log.Error(" Error in EncryptData in Master Controller" + ex);
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
                    EmailID = EmailID,
                    Password = Password,
                    LoginType = LoginType
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
        [Route("Recognition/GetCategoryWiseCardsByID")]
        public HttpResponseMessage GetCategoryWiseCardsByID(Int64 ID)
        {
            HttpResponseMessage response;
            try
            {
                var j = new
                {
                    ID = ID
                };
                object res = IRecognitionManager.GetCategoryWiseCardsByID(j);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in GetCategoryWiseCardsByID in Recognition Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpPost]
        [Route("Recognition/InsertCategoryMaster")]
        public HttpResponseMessage InsertCategoryMaster(RecognitionOneEntity RecognitionOneEntity)
        {
            HttpResponseMessage response;
            try
            {
                Int64 result = IRecognitionManager.InsertCategoryMaster(RecognitionOneEntity);
                response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error("Error in InsertCategoryMaster", ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message + "Error:InsertCategoryMaster");
            }
            return response;
        }
        [HttpPost]
        [Route("Recognition/InsertCategoryWiseCards")]
        public HttpResponseMessage InsertCategoryWiseCards(RecognitionOneEntity RecognitionOneEntity)
        {
            HttpResponseMessage response;
            try
            {
                Int64 result = IRecognitionManager.InsertCategoryWiseCards(RecognitionOneEntity);
                response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error("Error in InsertCategoryWiseCards", ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message + "Error:InsertCategoryWiseCards");
            }
            return response;
        }

        [HttpPost]
        [Route("Recognition/UpdateCategoryMaster")]
        public HttpResponseMessage UpdateCategoryMaster(RecognitionOneEntity RecognitionOneEntity)
        {
            HttpResponseMessage response;
            try
            {
                object res = IRecognitionManager.UpdateCategoryMaster(RecognitionOneEntity);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in UpdateCategoryMaster in Recognition Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }
        [HttpPost]
        [Route("Recognition/UpdateCategoryWiseCards")]
        public HttpResponseMessage UpdateCategoryWiseCards(RecognitionOneEntity RecognitionOneEntity)
        {
            HttpResponseMessage response;
            try
            {
                object res = IRecognitionManager.UpdateCategoryWiseCards(RecognitionOneEntity);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in UpdateCategoryWiseCards in Recognition Controller" + ex);
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
                    log.Error(" Error in GetStaffDetailsByTypeID in Recognition Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
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
                    log.Error(" Error in GetStaffDetailsByID in Recognition Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("Recognition/GetCategoryWiseCards")]
        public HttpResponseMessage GetCategoryWiseCards()
        {
            HttpResponseMessage response;
            try
            {
                object res = IRecognitionManager.GetCategoryWiseCards();
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in GetCategoryWiseCards in Recognition Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("Recognition/GetCategoryMasterByID")]
        public HttpResponseMessage GetCategoryMasterByID(Int64 ID)
        {
            HttpResponseMessage response;
            try
            {
                var j = new
                {
                    ID = ID
                };
                object res = IRecognitionManager.GetCategoryMasterByID(j);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in GetCategoryMasterByID in Recognition Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("Recognition/EnableCategoryWiseCards")]
        public HttpResponseMessage EnableCategoryWiseCards(Int64 ID)
        {
            HttpResponseMessage response;
            try
            {
                var j = new
                {
                    ID = ID
                };
                object res = IRecognitionManager.EnableCategoryWiseCards(j);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in EnableCategoryWiseCards in Recognition Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("Recognition/DisableCategoryWiseCards")]
        public HttpResponseMessage DisableCategoryWiseCards(Int64 ID)
        {
            HttpResponseMessage response;
            try
            {
                var j = new
                {
                    ID = ID
                };
                object res = IRecognitionManager.DisableCategoryWiseCards(j);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in DisableCategoryWiseCards in Recognition Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("Recognition/EnableCategoryMaster")]
        public HttpResponseMessage EnableCategoryMaster(Int64 ID)
        {
            HttpResponseMessage response;
            try
            {
                var j = new
                {
                    ID = ID
                };
                object res = IRecognitionManager.EnableCategoryMaster(j);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in EnableCategoryMaster in Recognition Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("Recognition/DisableCategoryMaster")]
        public HttpResponseMessage DisableCategoryMaster(Int64 ID)
        {
            HttpResponseMessage response;
            try
            {
                var j = new
                {
                    ID = ID
                };
                object res = IRecognitionManager.DisableCategoryMaster(j);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in DisableCategoryMaster in Recognition Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("Recognition/GetCategoryMaster")]
        public HttpResponseMessage GetCategoryMaster()
        {
            HttpResponseMessage response;
            try
            {
                object res = IRecognitionManager.GetCategoryMaster();
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in GetCategoryMaster in Recognition Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpPost]
        [Route("Recognition/UploadCategoryCards")]
        public HttpResponseMessage UploadCategoryCards()
        {
            HttpResponseMessage response;
            try
            {
                string result = string.Empty;
                var httpRequest = HttpContext.Current.Request;
                if (httpRequest.Files.Count > 0)
                {
                    foreach (string file in httpRequest.Files)
                    {
                        var postedFile = httpRequest.Files[file];
                        //var type = postedFile.ContentType;
                        var Name = postedFile.FileName.Split('\\').LastOrDefault().Split('/').LastOrDefault().Replace(" ", null);
                        var time = DateTime.Now.ToString("yyyyMMddHHmmss");
                        var fileName = time + Name;
                        Directory.CreateDirectory(HostingEnvironment.MapPath("~/Assets/Cards"));
                        string filePath = HostingEnvironment.MapPath("~/Assets/Cards/" + fileName);
                        postedFile.SaveAs(filePath);
                        result = filePath;
                    }
                }
                response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error("Recognition/UploadCategoryCards/:" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Recognition Error " + ex.Message);
            }
            return response;
        }

    }
}
