using AbsiRecognitionAPI.Business.Interface;
using AbsiRecognitionAPI.Data.Interface;
using AbsiRecognitionAPI.Data.Repositories;
using StaticWebAPI.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbsiRecognitionAPI.Business.Managers
{
    public class MasterManager : IMasterManager
    {
        public IMasterRrepository IMasterRrepository;
        public MasterManager(IMasterRrepository IMasterRrepository)
        {
            this.IMasterRrepository = IMasterRrepository;
        }
       
    }
}
