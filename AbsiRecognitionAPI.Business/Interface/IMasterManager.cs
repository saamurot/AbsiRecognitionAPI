using AbsiRecognitionAPI.Business.Entities;
using StaticWebAPI.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbsiRecognitionAPI.Business.Interface
{
    public interface IMasterManager
    {
        IEnumerable<dynamic> GetManagerPointsMaster();
        IEnumerable<dynamic> GetManagerPointsTransactions();
        IEnumerable<dynamic> GetManagerPointsMasterByID(object filter);
        IEnumerable<dynamic> GetManagerPointsTransactionsByID(object filter);
        Int64 InsertManagerPointsMaster(MasterEntity MasterEntity);
        Int64 InsertManagerPointsTransactions(MasterEntity MasterEntity);
        Int64 UpdateManagerPointsMaster(MasterEntity MasterEntity);
        Int64 UpdateManagerPointsTransactions(MasterEntity MasterEntity);
        Int64 DeleteManagerPointsMaster(object filter);
        Int64 DeleteManagerPointsTransactions(object filter);

    }
}
