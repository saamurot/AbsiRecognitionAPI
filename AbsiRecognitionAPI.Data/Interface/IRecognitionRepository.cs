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
        IEnumerable<T> GetManagerPointsMasterByID<T>(object filter);
        IEnumerable<T> GetManagerPointsTransactionsByID<T>(object filter);
        IEnumerable<T> GetManagerPointsMaster<T>();
        IEnumerable<T> GetManagerPointsTransactions<T>();
        IEnumerable<T> GetStatusMaster<T>();
        IEnumerable<T> GetManagerPointsRequests<T>();
        IEnumerable<T> GetManagerPointsRequestsByID<T>(object filter);



        Int64 InsertManagerPointsMaster(object filter);
        Int64 InsertManagerPointsTransactions(object filter);
        Int64 InsertManagerPointsRequests(object filter);




        Int64 UpdateManagerPointsMaster(object filter);
        Int64 UpdateManagerPointsTransactions(object filter);
        Int64 UpdateManagerPointsRequests(object filter);





        int DeleteManagerPointsMaster(object filter);
        int DeleteManagerPointsTransactions(object filter);
        int DeleteManagerPointsRequests(object filter);

        IEnumerable<T> GetStaffDetailsByID<T>(object filter);
    }
}
