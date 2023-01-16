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
using AbsiRecognitionAPI.Business.Entities;

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
        [HttpGet]
        [Route("Master/GetManagerPointsMaster")]
        public HttpResponseMessage GetManagerPointsMaster()
        {
            HttpResponseMessage response;
            try
            {
                object res = IMasterManager.GetManagerPointsMaster();
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in GetManagerPointsMaster in Master Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }
        [HttpGet]
        [Route("Master/GetManagerPointsTransactions")]
        public HttpResponseMessage GetManagerPointsTransactions()
        {
            HttpResponseMessage response;
            try
            {
                object res = IMasterManager.GetManagerPointsTransactions();
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error(" Error in GetManagerPointsTransactions in Master Controller" + ex);
                }
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }
        [HttpGet]
        [Route("Master/GetManagerPointsMasterByID")]
        public HttpResponseMessage GetManagerPointsMasterByID(Int64 ID)
        {
            HttpResponseMessage response;
            try
            {
                var j = new
                {
                    ID = ID
                };
                object res = IMasterManager.GetManagerPointsMasterByID(j);
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
        [Route("Master/GetManagerPointsTransactionsByID")]
        public HttpResponseMessage GetManagerPointsTransactionsByID(Int64 ID)
        {
            HttpResponseMessage response;
            try
            {
                var j = new
                {
                    ID = ID
                };
                object res = IMasterManager.GetManagerPointsTransactionsByID(j);
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
        [HttpPost]
        [Route("Master/InsertManagerPointsMaster")]
        public HttpResponseMessage InsertManagerPointsMaster(MasterEntity MasterEntity)
        {
            HttpResponseMessage response;
            try
            {
                Int64 result = IMasterManager.InsertManagerPointsMaster(MasterEntity);
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
        [Route("Master/InsertManagerPointsTransactions")]
        public HttpResponseMessage InsertManagerPointsTransactions(MasterEntity MasterEntity)
        {
            HttpResponseMessage response;
            try
            {
                Int64 result = IMasterManager.InsertManagerPointsTransactions(MasterEntity);
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
        [Route("Master/UpdateManagerPointsMaster")]
        public HttpResponseMessage UpdateManagerPointsMaster(MasterEntity MasterEntity)
        {
            HttpResponseMessage response;
            try
            {
                object res = IMasterManager.UpdateManagerPointsMaster(MasterEntity);
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
        [Route("Master/UpdateManagerPointsTransactions")]
        public HttpResponseMessage UpdateManagerPointsTransactions(MasterEntity MasterEntity)
        {
            HttpResponseMessage response;
            try
            {
                object res = IMasterManager.UpdateManagerPointsTransactions(MasterEntity);
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
        [Route("Master/DeleteManagerPointsMaster")]
        public HttpResponseMessage DeleteManagerPointsMaster(Int64 ID)
        {
            HttpResponseMessage response;
            try
            {
                var filter = new { ID = ID };
                Int64 Result = IMasterManager.DeleteManagerPointsMaster(filter);
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
        [Route("Master/DeleteManagerPointsTransactions")]
        public HttpResponseMessage DeleteManagerPointsTransactions(Int64 ID)
        {
            HttpResponseMessage response;
            try
            {
                var filter = new { ID = ID };
                Int64 Result = IMasterManager.DeleteManagerPointsTransactions(filter);
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
    }
}