using AbsiRecognitionAPI.Business.Entities;
using StaticWebAPI.Business.Entities;
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


         IEnumerable<dynamic> GetManagerPointsMasterByID(object filter);
        IEnumerable<dynamic> GetManagerPointsTransactionsByID(object filter);
        IEnumerable<dynamic> GetManagerPointsMaster();
        IEnumerable<dynamic> GetManagerPointsTransactions();
        IEnumerable<dynamic> GetStatusMaster();
        IEnumerable<dynamic> GetManagerPointsRequests();
        IEnumerable<dynamic> GetManagerPointsRequestsByID(object filter);
        IEnumerable<dynamic> GetCategoryWiseCardsByID(object filter);



        Int64 InsertManagerPointsMaster(RecognitionOneEntity RecognitionOneEntity);
        Int64 InsertManagerPointsTransactions(RecognitionOneEntity RecognitionOneEntity);
        Int64 InsertManagerPointsRequests(RecognitionOneEntity RecognitionOneEntity);

        Int64 InsertCategoryMaster(RecognitionOneEntity RecognitionOneEntity);
        Int64 InsertCategoryWiseCards(RecognitionOneEntity RecognitionOneEntity);





        Int64 UpdateManagerPointsMaster(RecognitionOneEntity RecognitionOneEntity);
        Int64 UpdateManagerPointsTransactions(RecognitionOneEntity RecognitionOneEntity);
        Int64 UpdateManagerPointsRequests(RecognitionOneEntity RecognitionOneEntity);
        Int64 UpdateCategoryMaster(RecognitionOneEntity RecognitionOneEntity);
        Int64 UpdateCategoryWiseCards(RecognitionOneEntity RecognitionOneEntity);



        Int64 DeleteManagerPointsMaster(object filter);
        Int64 DeleteManagerPointsTransactions(object filter);
        Int64 DeleteManagerPointsRequests(object filter);

    }
}
