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
    }
}