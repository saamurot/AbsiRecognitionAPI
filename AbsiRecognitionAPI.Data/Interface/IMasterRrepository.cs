using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbsiRecognitionAPI.Data.Interface
{
    public interface IMasterRrepository
    {
        IEnumerable<T> GetManagerPointsMaster<T>();
        IEnumerable<T> GetManagerPointsTransactions<T>();
        IEnumerable<T> GetManagerPointsMasterByID<T>(object filter);
        IEnumerable<T> GetManagerPointsTransactionsByID<T>(object filter);
        Int64 InsertManagerPointsMaster(object filter);
        Int64 InsertEmployeePointsMaster(object filter);
        Int64 InsertManagerPointsTransactions(object filter);
        Int64 UpdateManagerPointsMaster(object filter);
        Int64 UpdateManagerPointsTransactions(object filter);
        Int64 DeleteManagerPointsMaster(object filter);
        Int64 DeleteManagerPointsTransactions(object filter);

        IEnumerable<T> GetManagerPointsMasterByUserID<T>(object filter);
    }
}
