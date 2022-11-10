using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbsiRecognitionAPI.Data.Interface
{
    public interface IRecognitionRepository
    {
        IEnumerable<T> GetStaffDetails<T>();
        IEnumerable<T> CheckStaffLogin<T>(object filter);
    }
}
