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
        IEnumerable<T> GetStaffDetailsByTypeID<T>(object filter);
        IEnumerable<T> GetStaffDetailsByID<T>(object filter);


        IEnumerable<T> GetCategoryWiseCardsByID<T>(object filter);
        Int64 InsertCategoryMaster(object filter);
        Int64 InsertCategoryWiseCards(object filter);
        Int64 UpdateCategoryMaster(object filter);
        Int64 UpdateCategoryWiseCards(object filter);
        IEnumerable<T> GetCategoryWiseCards<T>();
        IEnumerable<T> GetCategoryMaster<T>();
        IEnumerable<T> GetCategoryMasterByID<T>(object filter);
        IEnumerable<T> EnableCategoryWiseCards<T>(object filter);
        IEnumerable<T> DisableCategoryWiseCards<T>(object filter);
        IEnumerable<T> EnableCategoryMaster<T>(object filter);
        IEnumerable<T> DisableCategoryMaster<T>(object filter);

    }
}
