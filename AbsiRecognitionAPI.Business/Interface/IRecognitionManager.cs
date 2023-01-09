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
        IEnumerable<dynamic> GetStaffDetailsByTypeID(object filter);
        IEnumerable<dynamic> GetStaffDetailsByID(object filter);

       
        IEnumerable<dynamic> GetCategoryWiseCardsByID(object filter);
        Int64 InsertCategoryMaster(RecognitionOneEntity RecognitionOneEntity);
        Int64 InsertCategoryWiseCards(RecognitionOneEntity RecognitionOneEntity);
        Int64 UpdateCategoryMaster(RecognitionOneEntity RecognitionOneEntity);
        Int64 UpdateCategoryWiseCards(RecognitionOneEntity RecognitionOneEntity);

        IEnumerable<dynamic> GetCategoryWiseCards();
        IEnumerable<dynamic> GetCategoryMasterByID(object filter);

        IEnumerable<dynamic> EnableCategoryWiseCards(object filter);
        IEnumerable<dynamic> DisableCategoryWiseCards(object filter);
        IEnumerable<dynamic> EnableCategoryMaster(object filter);
        IEnumerable<dynamic> DisableCategoryMaster(object filter);
        IEnumerable<dynamic> GetCategoryMaster();
    }
}
