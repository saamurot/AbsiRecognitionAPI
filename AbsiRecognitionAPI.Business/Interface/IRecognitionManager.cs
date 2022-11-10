using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbsiRecognitionAPI.Business.Interface
{
    public interface IRecognitionManager
    {
        IEnumerable<dynamic> GetStaffDetails();
        IEnumerable<dynamic> CheckStaffLogin(object filter);
    }
}
