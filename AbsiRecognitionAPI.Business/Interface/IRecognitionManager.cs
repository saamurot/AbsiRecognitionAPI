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

        Int64 InsertKudosBadges(KudobadgesEntity KudobadgesEntity);
        Int64 UpdateKudosBadges(KudobadgesEntity KudobadgesEntity);
        Int64 DeleteKudosBadges(object filter);
        IEnumerable<dynamic> GetKudosBadgesByID(object filter);
        IEnumerable<dynamic> GetKudosBadgesByCategoryID(object filter);
        IEnumerable<dynamic> GetKudosBadges();
        IEnumerable<dynamic> EnableKudosBadges(object filter);
        IEnumerable<dynamic> DisableKudosBadges(object filter);
        Int64 InsertKudosBadgeCategory(KudobadgesEntity KudobadgesEntity);
        Int64 UpdateKudosBadgeCategory(KudobadgesEntity KudobadgesEntity);
        Int64 DeleteKudosBadgeCategory(object filter);
        IEnumerable<dynamic> GetKudosBadgeCategoryByID(object filter);
        IEnumerable<dynamic> GetKudosBadgeCategory();
        IEnumerable<dynamic> EnableKudosBadgeCategory(object filter);
        IEnumerable<dynamic> DisableKudosBadgeCategory(object filter);

        Int64 InsertCelebrationTemplates(KudobadgesEntity KudobadgesEntity);
        Int64 InsertCelebrationTemplatesCategory(KudobadgesEntity KudobadgesEntity);
        Int64 UpdateCelebrationTemplates(KudobadgesEntity KudobadgesEntity);
        Int64 UpdateCelebrationTemplatesCategory(KudobadgesEntity KudobadgesEntity);
        IEnumerable<dynamic> GetCelebrationTemplates();
        IEnumerable<dynamic> GetCelebrationTemplatesCategory();
        IEnumerable<dynamic> GetCelebrationTemplatesByID(object filter);
        IEnumerable<dynamic> GetCelebrationTemplatesCategoryByID(object filter);
        IEnumerable<dynamic> EnableCelebrationTemplates(object filter);
        IEnumerable<dynamic> DisableCelebrationTemplates(object filter);
        IEnumerable<dynamic> EnableCelebrationTemplatesCategory(object filter);
        IEnumerable<dynamic> DisableCelebrationTemplatesCategory(object filter);

        Int64 DeleteCelebrationTemplates(object filter);
        Int64 DeleteCelebrationTemplatesCategory(object filter);
        IEnumerable<dynamic> GetSpecialDaysOfStaff(object filter);
        IEnumerable<dynamic> GetStaffByManagerID(object filter);

        //------------------

        IEnumerable<dynamic> GetKudosByHR();
        IEnumerable<dynamic> GetKudosByHRByID(object filter);
        Int64 InsertKudosByHR(object filter);
        Int64 InsertKudosByManager(object filter);
        Int64 UpdateKudosByHR(KudobadgesEntity KudobadgesEntity);
        Int64 DeleteKudosByHR(object filter);

        //---------------------

        IEnumerable<dynamic> GetCelebrationByHR();
        IEnumerable<dynamic> GetCelebrationByHRByID(object filter);
        IEnumerable<dynamic> GetManagerByStaffID(object filter);
        Int64 InsertCelebrationByHR(object filter);
        Int64 UpdateCelebrationByHR(KudobadgesEntity KudobadgesEntity);
        Int64 DeleteCelebrationByHR(object filter);
        IEnumerable<dynamic> GetEmployeePointsMaster();

        Int64 InsertCelebrationByManager(object filter);
        IEnumerable<dynamic> GetCelebrationByManager();

        IEnumerable<dynamic> GetKudosByEmployee();

        IEnumerable<dynamic> GetCelebrationByEmployee();

        Int64 InsertKudosByEmployee(object filter);

        Int64 InsertCelebrationByEmployee(object filter);

        IEnumerable<dynamic> GetKudosByUserID(object filter);
        IEnumerable<dynamic> GetCelebrationByUserID(object filter);
        IEnumerable<dynamic> GetAvailablePointsByUserID(object filter);

    }
}
