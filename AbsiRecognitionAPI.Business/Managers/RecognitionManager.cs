using AbsiRecognitionAPI.Business.Interface;
using AbsiRecognitionAPI.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbsiRecognitionAPI.Business.Managers
{
    public class RecognitionManager : IRecognitionManager
    {
        public IRecognitionRepository IRecognitionRepository;
        public RecognitionManager(IRecognitionRepository IMasterRrepository)
        {
            this.IRecognitionRepository = IMasterRrepository;
        }

        public IEnumerable<dynamic> GetStaffDetails()
        {
            try
            {
                return IRecognitionRepository.GetStaffDetails<dynamic>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<dynamic> CheckStaffLogin(object filter)
        {
            try
            {
                return IRecognitionRepository.CheckStaffLogin<dynamic>(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
