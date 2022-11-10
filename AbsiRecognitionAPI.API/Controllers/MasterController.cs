using AbsiRecognitionAPI.Business.Interface;
using System.Net.Http;
using System.Net;
using System;
using System.Web.Http;
using log4net;
using System.Reflection;
using StaticWebAPI.Business.Entities;
using System.Configuration;
using System.Web.Configuration;
using System.Web;
using System.Net.Configuration;
using System.Net.Mail;
using System.Linq;
using System.IO;
using System.Web.Hosting;

namespace AbsiRecognitionAPI.API.Controllers
{
    public class MasterController : ApiController
    {

        public IMasterManager IMasterManager;

        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public MasterController(IMasterManager IMasterManager)
        {
            this.IMasterManager = IMasterManager;
        }

        [HttpPost]
        [Route("Master/InsertNewJoineePhotos")]
        public HttpResponseMessage InsertExcel()
        {
            HttpResponseMessage response;
            try
            {
                string result = string.Empty;
                //Int64 res = 0;
                var httpRequest = HttpContext.Current.Request;
                if (httpRequest.Files.Count > 0)
                {
                    foreach (string file in httpRequest.Files)
                    {
                        var postedFile = httpRequest.Files[file];
                        var Name = postedFile.FileName.Split('\\').LastOrDefault().Split('/').LastOrDefault().Replace(" ", null);
                        var fn = Name.Split('.').FirstOrDefault();
                        var ext = Name.Split('.').LastOrDefault();
                        var time = DateTime.Now.ToString("yyyyMMddHHmmss");
                        //var fileName = time + Name;
                        var fileName = fn + '-' + time + '.' + ext;
                        Directory.CreateDirectory(HostingEnvironment.MapPath("~/Images/New-Joinees"));
                        string filePath = HostingEnvironment.MapPath("~/Images/New-Joinees/" + fileName);
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
                    log.Error("LatestNews/Gallery Images Error/Error:" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Uploadimage Error " + ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("Master/SendMail/")]
        public HttpResponseMessage SendMail()
        {
            HttpResponseMessage response;

            Configuration config = WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
            MailSettingsSectionGroup settings = (MailSettingsSectionGroup)config.GetSectionGroup("system.net/mailSettings");

            //smtp - mail.outlook.com
            var client = new SmtpClient("smtp.office365.com", 587)
            {
                Credentials = new NetworkCredential("sanath@amazeinc.in", "Mnbvcxz1029@"),
                EnableSsl = true,
            };

            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();

            msg.From = new MailAddress("sanath@amazeinc.in");
            //msg.ReplyToList.Add(new MailAddress("rajaneesh@amazeinc.in"));
            msg.To.Add(new MailAddress("anup@amazeinc.in"));
            //msg.Subject = email.emailsubject;
            //msg.Body = email.emailbody;
            msg.Subject = "TEST EMAIL FOR AMAZE PAY ROLL APPLICATION";
            msg.Body = "TEST FOR REPLY TO";
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


        // Get Details-------------------------------------------------------------------------------------

        [HttpGet]
        [Route("Master/GetDepartmentMaster")]
        public HttpResponseMessage GetDepartmentMaster()
        {
            HttpResponseMessage response;
            try
            {
                object res = IMasterManager.GetDepartmentMaster();
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in GetDepartmentMaster in Master Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }


        [HttpGet]
        [Route("Master/GetDesignationMaster")]
        public HttpResponseMessage GetDesignationMaster()
        {
            HttpResponseMessage response;
            try
            {
                object res = IMasterManager.GetDesignationMaster();
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in GetDesignationMaster in Master Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }



        [HttpGet]
        [Route("Master/GetEmployee")]
        public HttpResponseMessage GetEmployee()
        {
            HttpResponseMessage response;
            try
            {
                object res = IMasterManager.GetEmployee();
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in GetEmployee in Master Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("Master/GetEmployeeByID")]
        public HttpResponseMessage GetEmployeeByID(Int64 ID)
        {
            HttpResponseMessage response;
            try
            {
                var json = new
                {
                    ID = ID
                };
                object res = IMasterManager.GetEmployeeByID(json);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in GetEmployee in Master Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }



        [HttpGet]
        [Route("Master/GetEmployeeBankDetails")]
        public HttpResponseMessage GetEmployeeBankDetails()
        {
            HttpResponseMessage response;
            try
            {
                object res = IMasterManager.GetEmployeeBankDetails();
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in GetEmployeeBankDetails in Master Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }




        // Insert Details--------------------------------------------------------------------------------------------------------------

        [HttpPost]
        [Route("Master/InsertDepartmentMaster")]
        public HttpResponseMessage InsertDepartmentMaster(MasterEntity MasterEntity)
        {
            HttpResponseMessage response;
            try
            {
                Int64 result = IMasterManager.InsertDepartmentMaster(MasterEntity);
                response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error("Error in InsertDepartmentMaster", ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message + "Error:InsertDepartmentMaster");
            }
            return response;
        }


        [HttpPost]
        [Route("Master/InsertDesignationMaster")]
        public HttpResponseMessage InsertDesignationMaster(MasterEntity MasterEntity)
        {
            HttpResponseMessage response;
            try
            {
                Int64 result = IMasterManager.InsertDesignationMaster(MasterEntity);
                response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error("Error in InsertDesignationMaster", ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message + "Error:InsertDesignationMaster");
            }
            return response;
        }


        [HttpPost]
        [Route("Master/InsertEmployee")]
        public HttpResponseMessage InsertEmployee(MasterEntity MasterEntity)
        {
            HttpResponseMessage response;
            try
            {
                Int64 result = IMasterManager.InsertEmployee(MasterEntity);
                MasterEntity.EmployeeID = (int)result;
                Int64 results = IMasterManager.InsertEmployeeBankDetails(MasterEntity);
                response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error("Error in InsertEmployee", ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message + "Error:InsertEmployee");
            }
            return response;
        }


        [HttpPost]
        [Route("Master/InsertEmployeeBankDetails")]
        public HttpResponseMessage InsertEmployeeBankDetails(MasterEntity MasterEntity)
        {
            HttpResponseMessage response;
            try
            {
                Int64 result = IMasterManager.InsertEmployeeBankDetails(MasterEntity);
                response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error("Error in InsertEmployeeBankDetails", ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message + "Error:InsertEmployeeBankDetails");
            }
            return response;
        }







        // Update Details------------------------------------
        [HttpPost]
        [Route("Master/UpdateDepartmentMaster")]
        public HttpResponseMessage UpdateDepartmentMaster([FromBody] MasterEntity entity)
        {
            HttpResponseMessage response;
            try
            {
                object res = IMasterManager.UpdateDepartmentMaster(entity);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in UpdateDepartmentMaster in Master Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }


        [HttpPost]
        [Route("Master/UpdateDesignationMaster")]
        public HttpResponseMessage UpdateDesignationMaster([FromBody] MasterEntity entity)
        {
            HttpResponseMessage response;
            try
            {
                object res = IMasterManager.UpdateDesignationMaster(entity);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in UpdateDesignationMaster in Master Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }



        [HttpPost]
        [Route("Master/UpdateEmployee")]
        public HttpResponseMessage UpdateEmployee([FromBody] MasterEntity entity)
        {
            HttpResponseMessage response;
            try
            {
                object res = IMasterManager.UpdateEmployee(entity);
                object ress = IMasterManager.UpdateEmployeeBankDetails(entity);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in UpdateEmployee in Master Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }



        [HttpPost]
        [Route("Master/UpdateEmployeeBankDetails")]
        public HttpResponseMessage UpdateEmployeeBankDetails([FromBody] MasterEntity entity)
        {
            HttpResponseMessage response;
            try
            {
                object res = IMasterManager.UpdateEmployeeBankDetails(entity);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in UpdateEmployeeBankDetails in Master Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpPost]
        [Route("Master/UpdateJoiningEmployeeBasicInformation")]
        public HttpResponseMessage UpdateJoiningEmployeeBasicInformation([FromBody] MasterEntity entity)
        {
            HttpResponseMessage response;
            try
            {
                object res = IMasterManager.UpdateJoiningEmployeeBasicInformation(entity);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in UpdateJoiningEmployeeBasicInformation in Master Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }


        // Delete Details-------------------------------------------------------------------------------------------------------------------

        [HttpGet]
        [Route("Master/DeleteDepartmentMaster")]
        public HttpResponseMessage DeleteDepartmentMaster(Int64 ID)
        {
            HttpResponseMessage response;
            try
            {
                var filter = new { ID = ID };
                Int64 Result = IMasterManager.DeleteDepartmentMaster(filter);
                response = Request.CreateResponse(HttpStatusCode.OK, Result);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error("Error in Users/DeleteDepartmentMaster :" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message + " Users/DeleteDepartmentMaster");
            }
            return response;
        }



        [HttpGet]
        [Route("Master/DeleteDesignationMaster")]
        public HttpResponseMessage DeleteDesignationMaster(Int64 ID)
        {
            HttpResponseMessage response;
            try
            {
                var filter = new { ID = ID };
                Int64 Result = IMasterManager.DeleteDesignationMaster(filter);
                response = Request.CreateResponse(HttpStatusCode.OK, Result);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error("Error in Users/DeleteDesignationMaster :" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message + " Users/DeleteDesignationMaster");
            }
            return response;
        }


        [HttpGet]
        [Route("Master/DeleteEmployee")]
        public HttpResponseMessage DeleteEmployee(Int64 ID)
        {
            HttpResponseMessage response;
            try
            {
                var filter = new { ID = ID };
                Int64 Result = IMasterManager.DeleteEmployee(filter);
                response = Request.CreateResponse(HttpStatusCode.OK, Result);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error("Error in Users/DeleteEmployee :" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message + " Users/DeleteEmployee");
            }
            return response;
        }


        [HttpGet]
        [Route("Master/DeleteEmployeeBankDetailsr")]
        public HttpResponseMessage DeleteEmployeeBankDetailsr(Int64 ID)
        {
            HttpResponseMessage response;
            try
            {
                var filter = new { ID = ID };
                Int64 Result = IMasterManager.DeleteEmployeeBankDetailsr(filter);
                response = Request.CreateResponse(HttpStatusCode.OK, Result);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error("Error in Users/DeleteEmployeeBankDetailsr :" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message + " Users/DeleteEmployeeBankDetailsr");
            }
            return response;
        }

        [HttpGet]
        [Route("Master/GetJoiningEmployeeAcademicInformationByID")]
        public HttpResponseMessage GetJoiningEmployeeAcademicInformationByID(Int64 ID)
        {
            HttpResponseMessage response;
            try
            {
                var json = new
                {
                    ID = ID
                };
                object res = IMasterManager.GetJoiningEmployeeAcademicInformationByID(json);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in GetJoiningEmployeeAcademicInformationByID in Master Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("Master/GetJoiningEmployeeAddressInformationByID")]
        public HttpResponseMessage GetJoiningEmployeeAddressInformationByID(Int64 ID)
        {
            HttpResponseMessage response;
            try
            {
                var json = new
                {
                    ID = ID
                };
                object res = IMasterManager.GetJoiningEmployeeAddressInformationByID(json);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in GetJoiningEmployeeAddressInformationByID in Master Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("Master/GetJoiningEmployeeBasicInformationByID")]
        public HttpResponseMessage GetJoiningEmployeeBasicInformationByID(Int64 ID)
        {
            HttpResponseMessage response;
            try
            {
                var json = new
                {
                    ID = ID
                };
                object res = IMasterManager.GetJoiningEmployeeBasicInformationByID(json);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in GetJoiningEmployeeBasicInformationByID in Master Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("Master/GetJoiningEmployeeFamilyMembersInformationByID")]
        public HttpResponseMessage GetJoiningEmployeeFamilyMembersInformationByID(Int64 ID)
        {
            HttpResponseMessage response;
            try
            {
                var json = new
                {
                    ID = ID
                };
                object res = IMasterManager.GetJoiningEmployeeFamilyMembersInformationByID(json);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in GetJoiningEmployeeFamilyMembersInformationByID in Master Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("Master/GetJoiningEmployeeHealthInformationByID")]
        public HttpResponseMessage GetJoiningEmployeeHealthInformationByID(Int64 ID)
        {
            HttpResponseMessage response;
            try
            {
                var json = new
                {
                    ID = ID
                };
                object res = IMasterManager.GetJoiningEmployeeHealthInformationByID(json);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in GetJoiningEmployeeHealthInformationByID in Master Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("Master/GetJoiningEmployeeOtherInformationByID")]
        public HttpResponseMessage GetJoiningEmployeeOtherInformationByID(Int64 ID)
        {
            HttpResponseMessage response;
            try
            {
                var json = new
                {
                    ID = ID
                };
                object res = IMasterManager.GetJoiningEmployeeOtherInformationByID(json);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in GetJoiningEmployeeOtherInformationByID in Master Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("Master/GetJoiningEmployeeProfessionalExperienceByID")]
        public HttpResponseMessage GetJoiningEmployeeProfessionalExperienceByID(Int64 ID)
        {
            HttpResponseMessage response;
            try
            {
                var json = new
                {
                    ID = ID
                };
                object res = IMasterManager.GetJoiningEmployeeProfessionalExperienceByID(json);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in GetJoiningEmployeeProfessionalExperienceByID in Master Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpPost]
        [Route("Master/InsertJoiningEmployeeBasicInformation")]
        public HttpResponseMessage InsertJoiningEmployeeBasicInformation(MasterEntity MasterEntity)
        {
            HttpResponseMessage response;
            try
            {
                Int64 result = IMasterManager.InsertJoiningEmployeeBasicInformation(MasterEntity);
                response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error("Error in InsertJoiningEmployeeBasicInformation", ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message + "Error:InsertJoiningEmployeeBasicInformation");
            }
            return response;
        }

        [HttpPost]
        [Route("Master/InsertJoiningEmployeeAcademicInformation")]
        public HttpResponseMessage InsertJoiningEmployeeAcademicInformation(MasterEntity MasterEntity)
        {
            HttpResponseMessage response;
            try
            {
                Int64 result = IMasterManager.InsertJoiningEmployeeAcademicInformation(MasterEntity);
                response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error("Error in InsertJoiningEmployeeAcademicInformation", ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message + "Error:InsertJoiningEmployeeBasicInformation");
            }
            return response;
        }

        [HttpPost]
        [Route("Master/InsertJoiningEmployeeAddressInformation")]
        public HttpResponseMessage InsertJoiningEmployeeAddressInformation(MasterEntity MasterEntity)
        {
            HttpResponseMessage response;
            try
            {
                Int64 result = IMasterManager.InsertJoiningEmployeeAddressInformation(MasterEntity);
                response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error("Error in InsertJoiningEmployeeAddressInformation", ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message + "Error:InsertJoiningEmployeeBasicInformation");
            }
            return response;
        }

        [HttpPost]
        [Route("Master/InsertJoiningEmployeeFamilyMembersInformation")]
        public HttpResponseMessage InsertJoiningEmployeeFamilyMembersInformation(MasterEntity MasterEntity)
        {
            HttpResponseMessage response;
            try
            {
                Int64 result = IMasterManager.InsertJoiningEmployeeFamilyMembersInformation(MasterEntity);
                response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error("Error in InsertJoiningEmployeeFamilyMembersInformation", ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message + "Error:InsertJoiningEmployeeBasicInformation");
            }
            return response;
        }

        [HttpPost]
        [Route("Master/InsertJoiningEmployeeHealthInformation")]
        public HttpResponseMessage InsertJoiningEmployeeHealthInformation(MasterEntity MasterEntity)
        {
            HttpResponseMessage response;
            try
            {
                Int64 result = IMasterManager.InsertJoiningEmployeeHealthInformation(MasterEntity);
                response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error("Error in InsertJoiningEmployeeHealthInformation", ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message + "Error:InsertJoiningEmployeeBasicInformation");
            }
            return response;
        }

        [HttpPost]
        [Route("Master/InsertJoiningEmployeeOtherInformation")]
        public HttpResponseMessage InsertJoiningEmployeeOtherInformation(MasterEntity MasterEntity)
        {
            HttpResponseMessage response;
            try
            {
                Int64 result = IMasterManager.InsertJoiningEmployeeOtherInformation(MasterEntity);
                response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error("Error in InsertJoiningEmployeeOtherInformation", ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message + "Error:InsertJoiningEmployeeBasicInformation");
            }
            return response;
        }

        [HttpPost]
        [Route("Master/InsertJoiningEmployeeProfessionalExperience")]
        public HttpResponseMessage InsertJoiningEmployeeProfessionalExperience(MasterEntity MasterEntity)
        {
            HttpResponseMessage response;
            try
            {
                Int64 result = IMasterManager.InsertJoiningEmployeeProfessionalExperience(MasterEntity);
                response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error("Error in InsertJoiningEmployeeProfessionalExperience", ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message + "Error:InsertJoiningEmployeeBasicInformation");
            }
            return response;
        }

        [HttpGet]
        [Route("Master/GetJoiningEmployeeBasicInformation")]
        public HttpResponseMessage GetJoiningEmployeeBasicInformation()
        {
            HttpResponseMessage response;
            try
            {
                object res = IMasterManager.GetJoiningEmployeeBasicInformation();
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in GetJoiningEmployeeBasicInformation in Master Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("Master/GetJoiningEmployeeFormTrace")]
        public HttpResponseMessage GetJoiningEmployeeFormTrace(Int64 JEBIID)
        {
            HttpResponseMessage response;
            try
            {
                var filter = new { JEBIID = JEBIID };
                object res = IMasterManager.GetJoiningEmployeeFormTrace(filter);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in GetJoiningEmployeeFormTrace in Master Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("Master/UpdateJoiningEmployeeFormTrace")]
        public HttpResponseMessage UpdateJoiningEmployeeFormTrace(Int64 JEBIID, Int64 Stage)
        {
            HttpResponseMessage response;
            try
            {
                var filter = new { JEBIID = JEBIID, Stage = Stage };
                object res = IMasterManager.UpdateJoiningEmployeeFormTrace(filter);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in UpdateJoiningEmployeeFormTrace in Master Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

    }
}