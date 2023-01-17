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




        Int64 InsertKudosBadges(object filter);
        Int64 UpdateKudosBadges(object filter);
        Int64 DeleteKudosBadges(object filter);
        IEnumerable<T> GetKudosBadgesByID<T>(object filter);
        IEnumerable<T> GetKudosBadges<T>();
        IEnumerable<T> EnableKudosBadges<T>(object filter);
        IEnumerable<T> DisableKudosBadges<T>(object filter);

        Int64 InsertKudosBadgeCategory(object filter);
        Int64 UpdateKudosBadgeCategory(object filter);
        Int64 DeleteKudosBadgeCategory(object filter);
        IEnumerable<T> GetKudosBadgeCategoryByID<T>(object filter);
        IEnumerable<T> GetKudosBadgeCategory<T>();
        IEnumerable<T> EnableKudosBadgeCategory<T>(object filter);
        IEnumerable<T> DisableKudosBadgeCategory<T>(object filter);


        Int64 InsertCelebrationTemplates(object filter);
        Int64 InsertCelebrationTemplatesCategory(object filter);
        Int64 UpdateCelebrationTemplates(object filter);
        Int64 UpdateCelebrationTemplatesCategory(object filter);
        IEnumerable<T> GetCelebrationTemplates<T>();
        IEnumerable<T> GetCelebrationTemplatesCategory<T>();
        IEnumerable<T> GetCelebrationTemplatesByID<T>(object filter);
        IEnumerable<T> GetCelebrationTemplatesCategoryByID<T>(object filter);

        IEnumerable<T> EnableCelebrationTemplates<T>(object filter);
        IEnumerable<T> DisableCelebrationTemplates<T>(object filter);

        IEnumerable<T> EnableCelebrationTemplatesCategory<T>(object filter);
        IEnumerable<T> DisableCelebrationTemplatesCategory<T>(object filter);

        Int64 DeleteCelebrationTemplates(object filter);
        Int64 DeleteCelebrationTemplatesCategory(object filter);
        IEnumerable<T> GetSpecialDaysOfStaff<T>(object filter);



        IEnumerable<T> GetKudosByHR<T>();
        IEnumerable<T>GetKudosByHRByID<T>(object filter);
        Int64 InsertKudosByHR(object filter);
        Int64 UpdateKudosByHR(object filter);
        Int64 DeleteKudosByHR(object filter);



        IEnumerable<T> GetCelebrationByHR<T>();
        IEnumerable<T> GetCelebrationByHRByID<T>(object filter);
        Int64 InsertCelebrationByHR(object filter);
        Int64 UpdateCelebrationByHR(object filter);
        Int64 DeleteCelebrationByHR(object filter);



    }
}
