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
using System.Configuration;
using System.Net.Configuration;
using System.Net.Mail;
using System.Web.Configuration;
using System.Web.Http.Results;
using System.Collections.Generic;
using System.Web.Mail;
using System.Collections;
using System.Web.Razor.Parser.SyntaxTree;
using System.Web.UI.WebControls;

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


        [HttpPost]
        [Route("Recognition/sendemail/")]
        public HttpResponseMessage sendemail(RecognitionOneEntity email)
        {
            HttpResponseMessage response;

            Configuration config = WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
            MailSettingsSectionGroup settings = (MailSettingsSectionGroup)config.GetSectionGroup("system.net/mailSettings");

            var client = new SmtpClient("smtp.office365.com", 587)
            {
                Credentials = new NetworkCredential("mamata@amazeinc.in", "bluepink@123"),
                EnableSsl = true
            };
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            msg.From = new MailAddress("mamata@amazeinc.in");
            msg.To.Add(new MailAddress(email.emailto));


            //string[] ToMuliId = email.emailto.Split(',');
            //foreach (string ToEMailId in ToMuliId)
            //{
            //    msg.To.Add(new MailAddress(ToEMailId)); //adding multiple TO Email Id  
            //}
            //string[] CCId = email.emailCC.Split(',');
            //foreach (string CCEmail in CCId)
            //{
            //    msg.CC.Add(new MailAddress(CCEmail)); //Adding Multiple CC email Id  
            //}

            //var htmlString = "<p style='padding: 5px; background-color: blue; font-size: 20px; text-align: center; color: #fff;  width:100% '>HappyBIRTHDAY</p> " +
            //    "<br><p style='text-align: center'><img src='https://103.12.1.103//AbsiRecognitionAPI//Assets//KudosBadges//20230110124136stars-01.png'  style='width:10%'></p>" +
            //    "<br><p style='background-color: yellow; font-size: 20px; text-align: center; width:100% '>1000</p>" +
            //    "<br><p style='text-align:center'><img src='https://103.12.1.103//AbsiRecognitionAPI//Assets//Celebration//20230110123611congratulations.jpg' style='width:100%'></p> " +
            //    "<br><p style='width: 100%; background-color: rgb(184, 184, 192); font-size: 20px; text-align: center; color: #fff;'>contentcontentcontentcontentcontentcontentcontentcontentcontentcontentcontentcontentcontentcontentcontentcontentcontentcontentcontentcontentcontentcontent</p>";


            var htmlString = "<p style='background-color: rgb(51, 51, 156); font-size: 20px; color: #fff; text-align: center; width:100% ;padding: 8px;'>QA</p><br><span>" +
                "<img src='https://103.12.1.103//AbsiRecognitionAPI\\\\Assets\\\\KudosBadges\\\\202302151249332023020611084020230131102454360_F_281428332_I8vdli48NAy8McReaO0qQc3VMDIXUQGd.jpg' style=' width: 30%;padding: 0 15px;'>" +
                "<span style='width: 33%;padding: 0 15px;font-size: 14px;'>contentcontentcontentcontentcontentcontentcontentcontentconont</span><br> <p style='background-color: rgb(255, 213, 4); font-size: 20px; color: #fff; text-align: center; width:30% ;padding: 8px;'>1000</p><p style='text-align:center'>" +
                "<img src='https://103.12.1.103//AbsiRecognitionAPI\\Assets\\KudosBadges\\20230215154743VeniVidiVici.png'style='width:100%'></p>";





            msg.Subject = email.emailsubject;
            msg.Body = htmlString;
            msg.IsBodyHtml = true;
            try
            {
                client.Send(msg);
                response = Request.CreateResponse(HttpStatusCode.OK, "Success");
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.OK, ex);
            }
            return response;
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
        [Route("Recognition/UploadCelebrationTemplates")]
        public HttpResponseMessage UploadCelebrationTemplates()
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
                        Directory.CreateDirectory(HostingEnvironment.MapPath("~/Assets/Celebration"));
                        string filePath = HostingEnvironment.MapPath("~/Assets/Celebration/" + fileName);
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
                    log.Error("Recognition/UploadCelebrationTemplates/:" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Recognition Error " + ex.Message);
            }
            return response;
        }

        [HttpPost]
        [Route("Recognition/UploadKudosBadges")]
        public HttpResponseMessage UploadKudosBadges()
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
                        Directory.CreateDirectory(HostingEnvironment.MapPath("~/Assets/KudosBadges"));
                        string filePath = HostingEnvironment.MapPath("~/Assets/KudosBadges/" + fileName);
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
                    log.Error("Recognition/UploadKudosBadges/:" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Recognition Error " + ex.Message);
            }
            return response;
        }


        [HttpPost]
        [Route("Recognition/UploadKudosBanners")]
        public HttpResponseMessage UploadKudosBanners()
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
                        Directory.CreateDirectory(HostingEnvironment.MapPath("~/Assets/KudosBanners"));
                        string filePath = HostingEnvironment.MapPath("~/Assets/KudosBanners/" + fileName);
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
                    log.Error("Recognition/UploadKudosBadges/:" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Recognition Error " + ex.Message);
            }
            return response;
        }



        [HttpPost]
        [Route("Recognition/InsertKudosBadges")]
        public HttpResponseMessage InsertKudosBadges(KudobadgesEntity KudobadgesEntity)
        {
            HttpResponseMessage response;
            try
            {
                Int64 result = IRecognitionManager.InsertKudosBadges(KudobadgesEntity);
                response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error("Error in InsertKudosBadges", ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message + "Error:InsertCategoryMaster");
            }
            return response;
        }
        [HttpPost]
        [Route("Recognition/UpdateKudosBadges")]
        public HttpResponseMessage UpdateKudosBadges(KudobadgesEntity KudobadgesEntity)
        {
            HttpResponseMessage response;
            try
            {
                object res = IRecognitionManager.UpdateKudosBadges(KudobadgesEntity);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in UpdateKudosBadges in Recognition Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("Recognition/DeleteKudosBadges")]
        public HttpResponseMessage DeleteKudosBadges(Int64 ID)
        {
            HttpResponseMessage response;
            try
            {
                var filter = new { ID = ID };
                Int64 Result = IRecognitionManager.DeleteKudosBadges(filter);
                response = Request.CreateResponse(HttpStatusCode.OK, Result);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error("Error in Users/DeleteKudosBadges :" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message + " Users/DeleteStatusMaster");
            }
            return response;
        }

        [HttpGet]
        [Route("Recognition/GetKudosBadgesByID")]
        public HttpResponseMessage GetKudosBadgesByID(Int64 ID)
        {
            HttpResponseMessage response;
            try
            {
                var j = new
                {
                    ID = ID
                };
                object res = IRecognitionManager.GetKudosBadgesByID(j);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in GetKudosBadgesByID in Recognition Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("Recognition/GetKudosBadges")]
        public HttpResponseMessage GetKudosBadges()
        {
            HttpResponseMessage response;
            try
            {
                object res = IRecognitionManager.GetKudosBadges();
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in GetKudosBadges in Recognition Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("Recognition/EnableKudosBadges")]
        public HttpResponseMessage EnableKudosBadges(Int64 ID)
        {
            HttpResponseMessage response;
            try
            {
                var j = new
                {
                    ID = ID
                };
                object res = IRecognitionManager.EnableKudosBadges(j);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in EnableKudosBadges in Recognition Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("Recognition/DisableKudosBadges")]
        public HttpResponseMessage DisableKudosBadges(Int64 ID)
        {
            HttpResponseMessage response;
            try
            {
                var j = new
                {
                    ID = ID
                };
                object res = IRecognitionManager.DisableKudosBadges(j);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in DisableKudosBadges in Recognition Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpPost]
        [Route("Recognition/InsertKudosBadgeCategory")]
        public HttpResponseMessage InsertKudosBadgeCategory(KudobadgesEntity KudobadgesEntity)
        {
            HttpResponseMessage response;
            try
            {
                Int64 result = IRecognitionManager.InsertKudosBadgeCategory(KudobadgesEntity);
                response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error("Error in InsertKudosBadgeCategory", ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message + "Error:InsertCategoryMaster");
            }
            return response;
        }

        [HttpPost]
        [Route("Recognition/UpdateKudosBadgeCategory")]
        public HttpResponseMessage UpdateKudosBadgeCategory(KudobadgesEntity KudobadgesEntity)
        {
            HttpResponseMessage response;
            try
            {
                object res = IRecognitionManager.UpdateKudosBadgeCategory(KudobadgesEntity);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in UpdateKudosBadgeCategory in Recognition Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("Recognition/DeleteKudosBadgeCategory")]
        public HttpResponseMessage DeleteKudosBadgeCategory(Int64 ID)
        {
            HttpResponseMessage response;
            try
            {
                var filter = new { ID = ID };
                Int64 Result = IRecognitionManager.DeleteKudosBadgeCategory(filter);
                response = Request.CreateResponse(HttpStatusCode.OK, Result);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error("Error in Users/DeleteKudosBadgeCategory :" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message + " Users/DeleteStatusMaster");
            }
            return response;
        }

        [HttpGet]
        [Route("Recognition/GetKudosBadgeCategoryByID")]
        public HttpResponseMessage GetKudosBadgeCategoryByID(Int64 ID)
        {
            HttpResponseMessage response;
            try
            {
                var j = new
                {
                    ID = ID
                };
                object res = IRecognitionManager.GetKudosBadgeCategoryByID(j);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in GetKudosBadgeCategoryByID in Recognition Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }
        [HttpGet]
        [Route("Recognition/GetKudosBadgesByCategoryID")]
        public HttpResponseMessage GetKudosBadgesByCategoryID(Int64 ID)
        {
            HttpResponseMessage response;
            try
            {
                var j = new
                {
                    ID = ID
                };
                object res = IRecognitionManager.GetKudosBadgesByCategoryID(j);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in GetKudosBadgesByCategoryID in Recognition Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("Recognition/GetKudosBadgeCategory")]
        public HttpResponseMessage GetKudosBadgeCategory()
        {
            HttpResponseMessage response;
            try
            {
                object res = IRecognitionManager.GetKudosBadgeCategory();
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in GetKudosBadgeCategory in Recognition Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("Recognition/EnableKudosBadgeCategory")]
        public HttpResponseMessage EnableKudosBadgeCategory(Int64 ID)
        {
            HttpResponseMessage response;
            try
            {
                var j = new
                {
                    ID = ID
                };
                object res = IRecognitionManager.EnableKudosBadgeCategory(j);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in EnableKudosBadgeCategory in Recognition Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("Recognition/DisableKudosBadgeCategory")]
        public HttpResponseMessage DisableKudosBadgeCategory(Int64 ID)
        {
            HttpResponseMessage response;
            try
            {
                var j = new
                {
                    ID = ID
                };
                object res = IRecognitionManager.DisableKudosBadgeCategory(j);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in DisableKudosBadgeCategory in Recognition Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpPost]
        [Route("Recognition/InsertCelebrationTemplates")]
        public HttpResponseMessage InsertCelebrationTemplates(KudobadgesEntity KudobadgesEntity)
        {
            HttpResponseMessage response;
            try
            {
                Int64 result = IRecognitionManager.InsertCelebrationTemplates(KudobadgesEntity);
                response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error("Error in InsertCelebrationTemplates", ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message + "Error:InsertCategoryMaster");
            }
            return response;
        }

        [HttpPost]
        [Route("Recognition/InsertCelebrationTemplatesCategory")]
        public HttpResponseMessage InsertCelebrationTemplatesCategory(KudobadgesEntity KudobadgesEntity)
        {
            HttpResponseMessage response;
            try
            {
                Int64 result = IRecognitionManager.InsertCelebrationTemplatesCategory(KudobadgesEntity);
                response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error("Error in InsertCelebrationTemplatesCategory", ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message + "Error:InsertCategoryMaster");
            }
            return response;
        }

        [HttpPost]
        [Route("Recognition/UpdateCelebrationTemplates")]
        public HttpResponseMessage UpdateCelebrationTemplates(KudobadgesEntity KudobadgesEntity)
        {
            HttpResponseMessage response;
            try
            {
                object res = IRecognitionManager.UpdateCelebrationTemplates(KudobadgesEntity);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in UpdateCelebrationTemplates in Recognition Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpPost]
        [Route("Recognition/UpdateCelebrationTemplatesCategory")]
        public HttpResponseMessage UpdateCelebrationTemplatesCategory(KudobadgesEntity KudobadgesEntity)
        {
            HttpResponseMessage response;
            try
            {
                object res = IRecognitionManager.UpdateCelebrationTemplatesCategory(KudobadgesEntity);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in UpdateCelebrationTemplatesCategory in Recognition Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("Recognition/GetCelebrationTemplates")]
        public HttpResponseMessage GetCelebrationTemplates()
        {
            HttpResponseMessage response;
            try
            {
                object res = IRecognitionManager.GetCelebrationTemplates();
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in GetCelebrationTemplates in Recognition Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("Recognition/GetCelebrationTemplatesCategory")]
        public HttpResponseMessage GetCelebrationTemplatesCategory()
        {
            HttpResponseMessage response;
            try
            {
                object res = IRecognitionManager.GetCelebrationTemplatesCategory();
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in GetCelebrationTemplatesCategory in Recognition Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("Recognition/GetCelebrationTemplatesByID")]
        public HttpResponseMessage GetCelebrationTemplatesByID(Int64 ID)
        {
            HttpResponseMessage response;
            try
            {
                var j = new
                {
                    ID = ID
                };
                object res = IRecognitionManager.GetCelebrationTemplatesByID(j);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in GetCelebrationTemplatesByID in Recognition Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("Recognition/GetCelebrationTemplatesCategoryByID")]
        public HttpResponseMessage GetCelebrationTemplatesCategoryByID(Int64 ID)
        {
            HttpResponseMessage response;
            try
            {
                var j = new
                {
                    ID = ID
                };
                object res = IRecognitionManager.GetCelebrationTemplatesCategoryByID(j);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in GetCelebrationTemplatesCategoryByID in Recognition Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }


        [HttpGet]
        [Route("Recognition/EnableCelebrationTemplates")]
        public HttpResponseMessage EnableCelebrationTemplates(Int64 ID)
        {
            HttpResponseMessage response;
            try
            {
                var j = new
                {
                    ID = ID
                };
                object res = IRecognitionManager.EnableCelebrationTemplates(j);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in EnableCelebrationTemplates in Recognition Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("Recognition/DisableCelebrationTemplates")]
        public HttpResponseMessage DisableCelebrationTemplates(Int64 ID)
        {
            HttpResponseMessage response;
            try
            {
                var j = new
                {
                    ID = ID
                };
                object res = IRecognitionManager.DisableCelebrationTemplates(j);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in DisableCelebrationTemplates in Recognition Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }


        [HttpGet]
        [Route("Recognition/EnableCelebrationTemplatesCategory")]
        public HttpResponseMessage EnableCelebrationTemplatesCategory(Int64 ID)
        {
            HttpResponseMessage response;
            try
            {
                var j = new
                {
                    ID = ID
                };
                object res = IRecognitionManager.EnableCelebrationTemplatesCategory(j);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in EnableCelebrationTemplatesCategory in Recognition Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("Recognition/DisableCelebrationTemplatesCategory")]
        public HttpResponseMessage DisableCelebrationTemplatesCategory(Int64 ID)
        {
            HttpResponseMessage response;
            try
            {
                var j = new
                {
                    ID = ID
                };
                object res = IRecognitionManager.DisableCelebrationTemplatesCategory(j);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in DisableCelebrationTemplatesCategory in Recognition Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("Recognition/DeleteCelebrationTemplates")]
        public HttpResponseMessage DeleteCelebrationTemplates(Int64 ID)
        {
            HttpResponseMessage response;
            try
            {
                var filter = new { ID = ID };
                Int64 Result = IRecognitionManager.DeleteCelebrationTemplates(filter);
                response = Request.CreateResponse(HttpStatusCode.OK, Result);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error("Error in Users/DeleteCelebrationTemplates :" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message + " Users/DeleteStatusMaster");
            }
            return response;
        }
        [HttpGet]
        [Route("Recognition/DeleteCelebrationTemplatesCategory")]
        public HttpResponseMessage DeleteCelebrationTemplatesCategory(Int64 ID)
        {
            HttpResponseMessage response;
            try
            {
                var filter = new { ID = ID };
                Int64 Result = IRecognitionManager.DeleteCelebrationTemplatesCategory(filter);
                response = Request.CreateResponse(HttpStatusCode.OK, Result);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error("Error in Users/DeleteCelebrationTemplatesCategory :" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message + " Users/DeleteStatusMaster");
            }
            return response;
        }


        [HttpGet]
        [Route("Recognition/GetSpecialDaysOfStaff")]
        public HttpResponseMessage GetSpecialDaysOfStaff(Int64 Month)
        {
            HttpResponseMessage response;
            try
            {
                var j = new
                {
                    Month=Month
                };
                object res = IRecognitionManager.GetSpecialDaysOfStaff(j);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in GetSpecialDaysOfStaff in Recognition Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("Recognition/GetStaffByManagerID")]
        public HttpResponseMessage GetStaffByManagerID(Int64 ID)
        {
            HttpResponseMessage response;
            try
            {
                var j = new
                {
                    ID = ID
                };
                object res = IRecognitionManager.GetStaffByManagerID(j);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in GetStaffByManagerID in Recognition Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        //---------------------------------

        [HttpGet]
        [Route("Recognition/GetKudosByHR")]
        public HttpResponseMessage GetKudosByHR()
        {
            HttpResponseMessage response;
            try
            {
                object res = IRecognitionManager.GetKudosByHR();
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in GetKudosByHR in Recognition Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }



        [HttpGet]
        [Route("Recognition/GetKudosByHRByID")]
        public HttpResponseMessage GetKudosByHRByID(Int64 ID)
        {
            HttpResponseMessage response;
            try
            {
                var j = new
                {
                    ID = ID
                };
                object res = IRecognitionManager.GetKudosByHRByID(j);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in GetKudosByHRByID in Recognition Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }



        [HttpPost]
        [Route("Recognition/InsertKudosByHR")]
        public HttpResponseMessage InsertKudosByHR(KudobadgesEntity KudobadgesEntity)
        {
            HttpResponseMessage response;
            try
            {

                var add = "";
                var EmailList = "";

                var CCIDList = KudobadgesEntity.CCIDList?.ToList();
                if (CCIDList != null)
                {
                    for (int j = 0; j < CCIDList.Count; j++)
                    {
                        if (j == 0)
                        {
                            //var A = CCIDList[j].id;
                            EmailList = Convert.ToInt32(CCIDList[j].id).ToString();
                            add = EmailList;
                        }
                        else
                        {
                            EmailList = add + ',' + Convert.ToInt32(CCIDList[j].id).ToString();
                        }
                    }
                }
                else
                {
                    EmailList = null;
                }


                var StaffIDList = KudobadgesEntity.StaffIDList?.ToList();
                if (StaffIDList != null)
                {
                    for (int i = 0; i < StaffIDList.Count; i++)
                    {

                        var Entity = new
                        {
                            RecognisedBy = KudobadgesEntity.RecognisedBy,
                            RecognitionCategory = KudobadgesEntity.RecognitionCategory,
                            StaffID = Convert.ToInt32(StaffIDList[i].id),
                            Title = KudobadgesEntity.Title,
                            CategoryID = KudobadgesEntity.CategoryID,
                            BadgeID = KudobadgesEntity.BadgeID,
                            Point = KudobadgesEntity.Point,
                            ImageUrl = KudobadgesEntity.ImageUrl,
                            Message = KudobadgesEntity.Message,
                            CCList = EmailList
                        };
                        Int64 result = IRecognitionManager.InsertKudosByHR(Entity);
                    }
                }
                response = Request.CreateResponse(HttpStatusCode.OK, 1);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error("Error in InsertKudosByHR", ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message + "Error:InsertKudosByHR");
            }
            return response;
        }


        [HttpPost]
        [Route("Recognition/InsertKudosByManager")]
        public HttpResponseMessage InsertKudosByManager(KudobadgesEntity KudobadgesEntity)
        {
            HttpResponseMessage response;
            try
            {

                var add = "";
                var EmailList = "";

                var CCIDList = KudobadgesEntity.CCIDList?.ToList();
                if (CCIDList != null)
                {
                    for (int j = 0; j < CCIDList.Count; j++)
                    {
                        if (j == 0)
                        {
                            //var A = CCIDList[j].id;
                            EmailList = Convert.ToInt32(CCIDList[j].id).ToString();
                            add = EmailList;
                        }
                        else
                        {
                            EmailList = add + ',' + Convert.ToInt32(CCIDList[j].id).ToString();
                        }
                    }
                }
                else
                {
                    EmailList = null;
                }


                var StaffIDList = KudobadgesEntity.StaffIDList?.ToList();
                if (StaffIDList != null)
                {
                    for (int i = 0; i < StaffIDList.Count; i++)
                    {

                        var Entity = new
                        {
                            RecognisedBy = KudobadgesEntity.RecognisedBy,
                            RecognitionCategory = KudobadgesEntity.RecognitionCategory,
                            StaffID = Convert.ToInt32(StaffIDList[i].id),
                            Title = KudobadgesEntity.Title,
                            CategoryID = KudobadgesEntity.CategoryID,
                            BadgeID = KudobadgesEntity.BadgeID,
                            Point = KudobadgesEntity.Point,
                            ImageUrl = KudobadgesEntity.ImageUrl,
                            Message = KudobadgesEntity.Message,
                            CCList = EmailList
                        };
                        Int64 result = IRecognitionManager.InsertKudosByManager(Entity);
                    }
                }
                response = Request.CreateResponse(HttpStatusCode.OK, 1);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error("Error in InsertKudosByHR", ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message + "Error:InsertKudosByHR");
            }
            return response;
        }


        [HttpPost]
        [Route("Recognition/UpdateKudosByHR")]
        public HttpResponseMessage UpdateKudosByHR(KudobadgesEntity KudobadgesEntity)
        {
            HttpResponseMessage response;
            try
            {
                object res = IRecognitionManager.UpdateKudosByHR(KudobadgesEntity);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in UpdateKudosByHR in Recognition Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }




        [HttpGet]
        [Route("Recognition/DeleteKudosByHR")]
        public HttpResponseMessage DeleteKudosByHR(Int64 ID)
        {
            HttpResponseMessage response;
            try
            {
                var filter = new { ID = ID };
                Int64 Result = IRecognitionManager.DeleteKudosByHR(filter);
                response = Request.CreateResponse(HttpStatusCode.OK, Result);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error("Error in Users/DeleteKudosByHR :" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message + " Users/DeleteKudosByHR");
            }
            return response;
        }


        //-----


        [HttpGet]
        [Route("Recognition/GetCelebrationByHR")]
        public HttpResponseMessage GetCelebrationByHR()
        {
            HttpResponseMessage response;
            try
            {
                object res = IRecognitionManager.GetCelebrationByHR();
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in GetCelebrationByHR in Recognition Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("Recognition/GetEmployeePointsMaster")]
        public HttpResponseMessage GetEmployeePointsMaster()
        {
            HttpResponseMessage response;
            try
            {
                object res = IRecognitionManager.GetEmployeePointsMaster();
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in GetEmployeePointsMaster in Recognition Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }



        [HttpGet]
        [Route("Recognition/GetCelebrationByHRByID")]
        public HttpResponseMessage GetCelebrationByHRByID(Int64 ID)
        {
            HttpResponseMessage response;
            try
            {
                var j = new
                {
                    ID = ID
                };
                object res = IRecognitionManager.GetCelebrationByHRByID(j);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in GetCelebrationByHRByID in Recognition Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }


        [HttpGet]
        [Route("Recognition/GetManagerByStaffID")]
        public HttpResponseMessage GetManagerByStaffID(Int64 ID)
        {
            HttpResponseMessage response;
            try
            {
                var j = new
                {
                    ID = ID
                };
                object res = IRecognitionManager.GetManagerByStaffID(j);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in GetManagerByStaffID in Recognition Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }






        [HttpPost]
        [Route("Recognition/InsertCelebrationByHR")]
        public HttpResponseMessage InsertCelebrationByHR(KudobadgesEntity KudobadgesEntity)
        {
            HttpResponseMessage response;
            try
            {
                var add = "";
                var EmailList = "";
                var CCIDList = KudobadgesEntity.CCIDList?.ToList();
                if (CCIDList != null)
                {
                    for (int j = 0; j < CCIDList.Count; j++)
                    {
                        if (j == 0)
                        {
                            EmailList = Convert.ToInt32(CCIDList[j].id).ToString();
                            add = EmailList;
                        }
                        else
                        {
                            EmailList = add + ',' + Convert.ToInt32(CCIDList[j].id).ToString();
                        }
                    }
                }
                else
                {
                    EmailList = null;
                }
                var StaffIDList = KudobadgesEntity.StaffIDList?.ToList();
                if (StaffIDList != null)
                {
                    for (int i = 0; i < StaffIDList.Count; i++)
                    {

                        var Entity = new
                        {
                            RecognisedBy = KudobadgesEntity.RecognisedBy,
                            RecognitionCategory = KudobadgesEntity.RecognitionCategory,
                            StaffID = Convert.ToInt32(StaffIDList[i].id),
                            Title = KudobadgesEntity.Title,
                            CategoryID = KudobadgesEntity.CategoryID,
                            TemplateID = KudobadgesEntity.TemplateID,
                            ImageUrl = KudobadgesEntity.ImageUrl,
                            Message = KudobadgesEntity.Message,
                            CCList = EmailList
                        };
                        Int64 result = IRecognitionManager.InsertCelebrationByHR(Entity);
                    }
                }
                response = Request.CreateResponse(HttpStatusCode.OK, 1);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error("Error in InsertCelebrationByHR", ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message + "Error:InsertKudosByHR");
            }
            return response;
        }




        [HttpPost]
        [Route("Recognition/UpdateCelebrationByHR")]
        public HttpResponseMessage UpdateCelebrationByHR(KudobadgesEntity KudobadgesEntity)
        {
            HttpResponseMessage response;
            try
            {
                object res = IRecognitionManager.UpdateCelebrationByHR(KudobadgesEntity);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in UpdateCelebrationByHR in Recognition Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }




        [HttpGet]
        [Route("Recognition/DeleteCelebrationByHR")]
        public HttpResponseMessage DeleteCelebrationByHR(Int64 ID)
        {
            HttpResponseMessage response;
            try
            {
                var filter = new { ID = ID };
                Int64 Result = IRecognitionManager.DeleteCelebrationByHR(filter);
                response = Request.CreateResponse(HttpStatusCode.OK, Result);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error("Error in Users/DeleteCelebrationByHR :" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message + " Users/DeleteCelebrationByHR");
            }
            return response;
        }

        [HttpGet]
        [Route("Recognition/GetCelebrationByManager")]
        public HttpResponseMessage GetCelebrationByManager()
        {
            HttpResponseMessage response;
            try
            {
                object res = IRecognitionManager.GetCelebrationByManager();
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in GetCelebrationByManager in Recognition Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpPost]
        [Route("Recognition/InsertCelebrationByManager")]
        public HttpResponseMessage InsertCelebrationByManager(KudobadgesEntity KudobadgesEntity)
        {
            HttpResponseMessage response;
            try
            {
                var add = "";
                var EmailList = "";
                var CCIDList = KudobadgesEntity.CCIDList?.ToList();
                if (CCIDList != null)
                {
                    for (int j = 0; j < CCIDList.Count; j++)
                    {
                        if (j == 0)
                        {
                            EmailList = Convert.ToInt32(CCIDList[j].id).ToString();
                            add = EmailList;
                        }
                        else
                        {
                            EmailList = add + ',' + Convert.ToInt32(CCIDList[j].id).ToString();
                        }
                    }
                }
                else
                {
                    EmailList = null;
                }
                var StaffIDList = KudobadgesEntity.StaffIDList?.ToList();
                if (StaffIDList != null)
                {
                    for (int i = 0; i < StaffIDList.Count; i++)
                    {

                        var Entity = new
                        {
                            RecognisedBy = KudobadgesEntity.RecognisedBy,
                            RecognitionCategory = KudobadgesEntity.RecognitionCategory,
                            StaffID = Convert.ToInt32(StaffIDList[i].id),
                            Title = KudobadgesEntity.Title,
                            CategoryID = KudobadgesEntity.CategoryID,
                            TemplateID = KudobadgesEntity.TemplateID,
                            ImageUrl = KudobadgesEntity.ImageUrl,
                            Message = KudobadgesEntity.Message,
                            CCList = EmailList
                        };
                        Int64 result = IRecognitionManager.InsertCelebrationByManager(Entity);
                    }
                }
                response = Request.CreateResponse(HttpStatusCode.OK, 1);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error("Error in InsertCelebrationByManager", ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message + "Error:InsertCelebrationByManager");
            }
            return response;
        }

        [HttpGet]
        [Route("Recognition/GetKudosByEmployee")]
        public HttpResponseMessage GetKudosByEmployee()
        {
            HttpResponseMessage response;
            try
            {
                object res = IRecognitionManager.GetKudosByEmployee();
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in GetKudosByEmployee in Recognition Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("Recognition/GetCelebrationByEmployee")]
        public HttpResponseMessage GetCelebrationByEmployee()
        {
            HttpResponseMessage response;
            try
            {
                object res = IRecognitionManager.GetCelebrationByEmployee();
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in GetCelebrationByEmployee in Recognition Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpPost]
        [Route("Recognition/InsertKudosByEmployee")]
        public HttpResponseMessage InsertKudosByEmployee(KudobadgesEntity KudobadgesEntity)
        {
            HttpResponseMessage response;
            try
            {
                var add = "";
                var EmailList = "";
                var CCIDList = KudobadgesEntity.CCIDList?.ToList();
                if (CCIDList != null)
                {
                    for (int j = 0; j < CCIDList.Count; j++)
                    {
                        if (j == 0)
                        {
                            EmailList = Convert.ToInt32(CCIDList[j].id).ToString();
                            add = EmailList;
                        }
                        else
                        {
                            EmailList = add + ',' + Convert.ToInt32(CCIDList[j].id).ToString();
                        }
                    }
                }
                else
                {
                    EmailList = null;
                }
                var StaffIDList = KudobadgesEntity.StaffIDList?.ToList();
                if (StaffIDList != null)
                {
                    for (int i = 0; i < StaffIDList.Count; i++)
                    {

                        var Entity = new
                        {
                            RecognisedBy = KudobadgesEntity.RecognisedBy,
                            RecognitionCategory = KudobadgesEntity.RecognitionCategory,
                            StaffID = Convert.ToInt32(StaffIDList[i].id),
                            Title = KudobadgesEntity.Title,
                            CategoryID = KudobadgesEntity.CategoryID,
                            BadgeID = KudobadgesEntity.BadgeID,
                            //Point = KudobadgesEntity.Point,
                            ImageUrl = KudobadgesEntity.ImageUrl,
                            Message = KudobadgesEntity.Message,
                            CCList = EmailList
                        };
                        Int64 result = IRecognitionManager.InsertKudosByEmployee(Entity);
                    }
                }
                response = Request.CreateResponse(HttpStatusCode.OK, 1);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error("Error in InsertKudosByEmployee", ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message + "Error:InsertKudosByEmployee");
            }
            return response;
        }

        [HttpPost]
        [Route("Recognition/InsertCelebrationByEmployee")]
        public HttpResponseMessage InsertCelebrationByEmployee(KudobadgesEntity KudobadgesEntity)
        {
            HttpResponseMessage response;
            try
            {
                var add = "";
                var EmailList = "";
                var CCIDList = KudobadgesEntity.CCIDList?.ToList();
                if (CCIDList != null)
                {
                    for (int j = 0; j < CCIDList.Count; j++)
                    {
                        if (j == 0)
                        {
                            EmailList = Convert.ToInt32(CCIDList[j].id).ToString();
                            add = EmailList;
                        }
                        else
                        {
                            EmailList = add + ',' + Convert.ToInt32(CCIDList[j].id).ToString();
                        }
                    }
                }
                else
                {
                    EmailList = null;
                }
                var StaffIDList = KudobadgesEntity.StaffIDList?.ToList();
                if (StaffIDList != null)
                {
                    for (int i = 0; i < StaffIDList.Count; i++)
                    {

                        var Entity = new
                        {
                            RecognisedBy = KudobadgesEntity.RecognisedBy,
                            RecognitionCategory = KudobadgesEntity.RecognitionCategory,
                            StaffID = Convert.ToInt32(StaffIDList[i].id),
                            Title = KudobadgesEntity.Title,
                            CategoryID = KudobadgesEntity.CategoryID,
                            TemplateID = KudobadgesEntity.TemplateID,
                            ImageUrl = KudobadgesEntity.ImageUrl,
                            Message = KudobadgesEntity.Message,
                            CCList = EmailList
                        };
                        Int64 result = IRecognitionManager.InsertCelebrationByEmployee(Entity);
                    }
                }
                response = Request.CreateResponse(HttpStatusCode.OK, 1);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error("Error in InsertCelebrationByEmployee", ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message + "Error:InsertCelebrationByEmployee");
            }
            return response;
        }


        [HttpGet]
        [Route("Recognition/GetKudosByUserID")]
        public HttpResponseMessage GetKudosByUserID(Int64 StaffID,Int64 Year)
        {
            HttpResponseMessage response;
            try
            {
                var j = new
                {
                    StaffID= StaffID,
                    Year= Year
                };
                object res = IRecognitionManager.GetKudosByUserID(j);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in GetKudosByUserID in Recognition Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("Recognition/GetCelebrationByUserID")]
        public HttpResponseMessage GetCelebrationByUserID(Int64 StaffID, Int64 Year)
        {
            HttpResponseMessage response;
            try
            {
                var j = new
                {
                    StaffID = StaffID,
                    Year = Year
                };
                object res = IRecognitionManager.GetCelebrationByUserID(j);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in GetCelebrationByUserID in Recognition Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }
        [HttpGet]
        [Route("Recognition/GetAvailablePointsByUserID")]
        public HttpResponseMessage GetAvailablePointsByUserID(Int64 UserID)
        {
            HttpResponseMessage response;
            try
            {
                var j = new
                {
                    UserID = UserID
                };
                object res = IRecognitionManager.GetAvailablePointsByUserID(j);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in GetAvailablePointsByUserID in Recognition Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("Recognition/GetKudosByUserIDandDate")]
        public HttpResponseMessage GetKudosByUserIDandDate(Int64 StaffID,DateTime Date)
        {
            HttpResponseMessage response;
            try
            {
                var j = new
                {
                    StaffID = StaffID,
                    Date= Date
                };
                object res = IRecognitionManager.GetKudosByUserIDandDate(j);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in GetKudosByUserIDandDate in Recognition Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }



        [HttpGet]
        [Route("Recognition/CheckCategoryAvailability")]
        public HttpResponseMessage CheckCategoryAvailability(string Category)
        {
            HttpResponseMessage response;
            try
            {
                var filter = new
                {
                    Category= Category
                };
                object res = IRecognitionManager.CheckCategoryAvailability(filter);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in CheckCategoryAvailability in Recognition Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }
        [HttpGet]
        [Route("Recognition/CheckCelebrationTemplates")]
        public HttpResponseMessage CheckCelebrationTemplates(string TemplateName, Int64 CategoryID)
        {
            HttpResponseMessage response;
            try
            {
                var filter = new
                {
                    TemplateName = TemplateName,
                    CategoryID= CategoryID
                };
                object res = IRecognitionManager.CheckCelebrationTemplates(filter);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in CheckCelebrationTemplates in Recognition Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }
        [HttpGet]
        [Route("Recognition/CheckCelebrationTemplatesCategory")]
        public HttpResponseMessage CheckCelebrationTemplatesCategory(string Category)
        {
            HttpResponseMessage response;
            try
            {
                var filter = new
                {
                    Category = Category
                };
                object res = IRecognitionManager.CheckCelebrationTemplatesCategory(filter);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in CheckCelebrationTemplatesCategory in Recognition Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }
        [HttpGet]
        [Route("Recognition/CheckKudosBadgesName")]
        public HttpResponseMessage CheckKudosBadgesName(string BadgeName, Int64 CategoryID)
        {
            HttpResponseMessage response;
            try
            {
                var filter = new
                {
                    BadgeName = BadgeName,
                    CategoryID= CategoryID
                };
                object res = IRecognitionManager.CheckKudosBadgesName(filter);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in CheckKudosBadgesName in Recognition Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }
        [HttpGet]
        [Route("Recognition/GetManagerPointsTransactionsByUserID")]
        public HttpResponseMessage GetManagerPointsTransactionsByUserID(Int64 UserID)
        {
            HttpResponseMessage response;
            try
            {
                var j = new
                {
                    UserID = UserID
                };
                object res = IRecognitionManager.GetManagerPointsTransactionsByUserID(j);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in GetManagerPointsTransactionsByUserID in Recognition Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("Recognition/GetNewJoineeByDate")]
        public HttpResponseMessage GetNewJoineeByDate(DateTime Date)
        {
            HttpResponseMessage response;
            try
            {
                var j = new
                {
                    Date = Date
                };
                object res = IRecognitionManager.GetNewJoineeByDate(j);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in GetNewJoineeByDate in Recognition Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }
        [HttpGet]
        [Route("Recognition/GetTodaysBirthDay")]
        public HttpResponseMessage GetTodaysBirthDay(DateTime Date)
        {
            HttpResponseMessage response;
            try
            {
                var D = new
                {
                    Date = Date
                };
                object res = IRecognitionManager.GetTodaysBirthDay(D);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in GetTodaysBirthDay in Master Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }


        [HttpGet]
        [Route("Recognition/GetTodaysMarriageAnniversary")]
        public HttpResponseMessage GetTodaysMarriageAnniversary(DateTime Date)
        {
            HttpResponseMessage response;
            try
            {
                var D = new
                {
                    Date = Date
                };
                object res = IRecognitionManager.GetTodaysMarriageAnniversary(D);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in GetTodaysMarriageAnniversary in Master Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }


        [HttpGet]
        [Route("Recognition/GetTodaysWorkAnniversary")]
        public HttpResponseMessage GetTodaysWorkAnniversary(DateTime Date)
        {
            HttpResponseMessage response;
            try
            {
                var D = new
                {
                    Date = Date
                };
                object res = IRecognitionManager.GetTodaysWorkAnniversary(D);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in GetTodaysWorkAnniversary in Master Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }
    }
}
