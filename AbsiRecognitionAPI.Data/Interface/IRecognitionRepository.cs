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
        IEnumerable<T> GetCategoryWiseCardsByID<T>(object filter);


        Int64 InsertManagerPointsMaster(object filter);
        Int64 InsertManagerPointsTransactions(object filter);
        Int64 InsertManagerPointsRequests(object filter);
        Int64 InsertCategoryMaster(object filter);
        Int64 InsertCategoryWiseCards(object filter);



        Int64 UpdateManagerPointsMaster(object filter);
        Int64 UpdateManagerPointsTransactions(object filter);
        Int64 UpdateManagerPointsRequests(object filter);
        Int64 UpdateCategoryMaster(object filter);
        Int64 UpdateCategoryWiseCards(object filter);


        Int64 DeleteManagerPointsMaster(object filter);
        Int64 DeleteManagerPointsTransactions(object filter);
        Int64 DeleteManagerPointsRequests(object filter);

        IEnumerable<T> GetSuperAdminPointsTransactions<T>();
        IEnumerable<T> GetSuperAdminPointsTransactionsByID<T>(object filter);
        Int64 InsertSuperAdminPointsTransactions(object filter);
        Int64 UpdateSuperAdminPointsTransactions(object filter);
        Int64 DeleteSuperAdminPointsTransactions(object filter);


        IEnumerable<T> GetSuperAdminPointsMaster<T>();
        IEnumerable<T> GetSuperAdminPointsMasterByID<T>(object filter);
        Int64 InsertSuperAdminPointsMaster(object filter);
        Int64 UpdateSuperAdminPointsMaster(object filter);
        Int64 DeleteSuperAdminPointsMaster(object filter);

    }
}
