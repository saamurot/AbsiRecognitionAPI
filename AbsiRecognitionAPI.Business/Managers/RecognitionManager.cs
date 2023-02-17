using AbsiRecognitionAPI.Business.Entities;
using AbsiRecognitionAPI.Business.Interface;
using AbsiRecognitionAPI.Data.Interface;
using StaticWebAPI.Business.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbsiRecognitionAPI.Business.Managers
{
    public class RecognitionManager : IRecognitionManager
    {
        public IRecognitionRepository IRecognitionRepository;
        public RecognitionManager(IRecognitionRepository IMasterRrepository)
        {
            this.IRecognitionRepository = IMasterRrepository;
        }

        public IEnumerable<dynamic> GetStaffDetails()
        {
            try
            {
                return IRecognitionRepository.GetStaffDetails<dynamic>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<dynamic> CheckStaffLogin(object filter)
        {
            try
            {
                return IRecognitionRepository.CheckStaffLogin<dynamic>(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
        public IEnumerable<dynamic> GetCategoryWiseCardsByID(object filter)
        {
            try
            {
                return IRecognitionRepository.GetCategoryWiseCardsByID<dynamic>(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Int64 InsertCategoryMaster(RecognitionOneEntity RecognitionOneEntity)
        {
            try
            {
                var filter = new
                {
                    Category = RecognitionOneEntity.Category,
                    Description = RecognitionOneEntity.Description,
                    //Status = RecognitionOneEntity.Status,
                };
                return IRecognitionRepository.InsertCategoryMaster(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Int64 InsertCategoryWiseCards(RecognitionOneEntity RecognitionOneEntity)
        {
            try
            {
                var filter = new
                {
                    CategoryID = RecognitionOneEntity.CategoryID,
                    CardName = RecognitionOneEntity.CardName,
                    Description = RecognitionOneEntity.Description,
                    //Status = RecognitionOneEntity.Status,
                    CardUrl= RecognitionOneEntity.CardUrl

                };
                return IRecognitionRepository.InsertCategoryWiseCards(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Int64 UpdateCategoryMaster(RecognitionOneEntity RecognitionOneEntity)
        {
            try
            {
                var filter = new
                {
                    ID = RecognitionOneEntity.ID,
                    Category = RecognitionOneEntity.Category,
                    Description = RecognitionOneEntity.Description,
                    //Status = RecognitionOneEntity.Status,

                };
                return IRecognitionRepository.UpdateCategoryMaster(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Int64 UpdateCategoryWiseCards(RecognitionOneEntity RecognitionOneEntity)
        {
            try
            {
                var filter = new
                {

                    ID = RecognitionOneEntity.ID,
                    CategoryID = RecognitionOneEntity.CategoryID,
                    CardName = RecognitionOneEntity.CardName,
                    Description = RecognitionOneEntity.Description,
                    //Status = RecognitionOneEntity.Status,
                    CardUrl= RecognitionOneEntity.CardUrl
                };
                return IRecognitionRepository.UpdateCategoryWiseCards(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<dynamic> GetStaffDetailsByTypeID(object filter)
        {
            try
            {
                return IRecognitionRepository.GetStaffDetailsByTypeID<dynamic>(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<dynamic> GetStaffDetailsByID(object filter)
        {
            try
            {
                return IRecognitionRepository.GetStaffDetailsByID<dynamic>(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<dynamic> GetCategoryWiseCards()
        {
            try
            {
                return IRecognitionRepository.GetCategoryWiseCards<dynamic>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<dynamic> GetCategoryMasterByID(object filter)
        {
            try
            {
                return IRecognitionRepository.GetCategoryMasterByID<dynamic>(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<dynamic> EnableCategoryWiseCards(object filter)
        {
            try
            {
                return IRecognitionRepository.EnableCategoryWiseCards<dynamic>(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<dynamic> DisableCategoryWiseCards(object filter)
        {
            try
            {
                return IRecognitionRepository.DisableCategoryWiseCards<dynamic>(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<dynamic> EnableCategoryMaster(object filter)
        {
            try
            {
                return IRecognitionRepository.EnableCategoryMaster<dynamic>(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<dynamic> DisableCategoryMaster(object filter)
        {
            try
            {
                return IRecognitionRepository.DisableCategoryMaster<dynamic>(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<dynamic> GetCategoryMaster()
        {
            try
            {
                return IRecognitionRepository.GetCategoryMaster<dynamic>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Int64 InsertKudosBadges(KudobadgesEntity KudobadgesEntity)
        {
            try
            {
                var filter = new
                {
                    CategoryID= KudobadgesEntity.CategoryID,
                    BadgeName= KudobadgesEntity.BadgeName,
                    Description = KudobadgesEntity.Description,
                    BadgeURL = KudobadgesEntity.BadgeURL,
                };
                return IRecognitionRepository.InsertKudosBadges(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Int64 UpdateKudosBadges(KudobadgesEntity KudobadgesEntity)
        {
            try
            {
                var filter = new
                {
                    ID = KudobadgesEntity.ID,
                    CategoryID = KudobadgesEntity.CategoryID,
                    BadgeName = KudobadgesEntity.BadgeName,
                    Description = KudobadgesEntity.Description,
                    BadgeURL= KudobadgesEntity.BadgeURL
                };
                return IRecognitionRepository.UpdateKudosBadges(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Int64 DeleteKudosBadges(object filter)
        {
            try
            {
                return IRecognitionRepository.DeleteKudosBadges(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<dynamic> GetKudosBadgesByID(object filter)
        {
            try
            {
                return IRecognitionRepository.GetKudosBadgesByID<dynamic>(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<dynamic> GetKudosBadges()
        {
            try
            {
                return IRecognitionRepository.GetKudosBadges<dynamic>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<dynamic> EnableKudosBadges(object filter)
        {
            try
            {
                return IRecognitionRepository.EnableKudosBadges<dynamic>(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<dynamic> DisableKudosBadges(object filter)
        {
            try
            {
                return IRecognitionRepository.DisableKudosBadges<dynamic>(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Int64 InsertKudosBadgeCategory(KudobadgesEntity KudobadgesEntity)
        {
            try
            {
                var filter = new
                {
                    Category = KudobadgesEntity.Category,
                    Description = KudobadgesEntity.Description,
                };
                return IRecognitionRepository.InsertKudosBadgeCategory(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Int64 UpdateKudosBadgeCategory(KudobadgesEntity KudobadgesEntity)
        {
            try
            {
                var filter = new
                {
                    ID = KudobadgesEntity.ID,
                    Category = KudobadgesEntity.Category,
                    Description = KudobadgesEntity.Description,
                };
                return IRecognitionRepository.UpdateKudosBadgeCategory(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Int64 DeleteKudosBadgeCategory(object filter)
        {
            try
            {
                return IRecognitionRepository.DeleteKudosBadgeCategory(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public IEnumerable<dynamic> GetKudosBadgeCategoryByID(object filter)
        {
            try
            {
                return IRecognitionRepository.GetKudosBadgeCategoryByID<dynamic>(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<dynamic> GetKudosBadgesByCategoryID(object filter)
        {
            try
            {
                return IRecognitionRepository.GetKudosBadgesByCategoryID<dynamic>(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<dynamic> GetKudosBadgeCategory()
        {
            try
            {
                return IRecognitionRepository.GetKudosBadgeCategory<dynamic>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<dynamic> EnableKudosBadgeCategory(object filter)
        {
            try
            {
                return IRecognitionRepository.EnableKudosBadgeCategory<dynamic>(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<dynamic> DisableKudosBadgeCategory(object filter)
        {
            try
            {
                return IRecognitionRepository.DisableKudosBadgeCategory<dynamic>(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Int64 InsertCelebrationTemplates(KudobadgesEntity KudobadgesEntity)
        {
            try
            {
                var filter = new
                {
                    CategoryID = KudobadgesEntity.CategoryID,
                    TemplateName = KudobadgesEntity.TemplateName,
                    Description = KudobadgesEntity.Description,
                    TemplateURL = KudobadgesEntity.TemplateURL,
                };
                return IRecognitionRepository.InsertCelebrationTemplates(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Int64 InsertCelebrationTemplatesCategory(KudobadgesEntity KudobadgesEntity)
        {
            try
            {
                var filter = new
                {
                    Category = KudobadgesEntity.Category,
                    Description = KudobadgesEntity.Description,
                };
                return IRecognitionRepository.InsertCelebrationTemplatesCategory(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Int64 UpdateCelebrationTemplates(KudobadgesEntity KudobadgesEntity)
        {
            try
            {
                var filter = new
                {
                    ID = KudobadgesEntity.ID,
                    CategoryID = KudobadgesEntity.CategoryID,
                    TemplateName = KudobadgesEntity.TemplateName,
                    Description = KudobadgesEntity.Description,
                    TemplateURL = KudobadgesEntity.TemplateURL
                };
                return IRecognitionRepository.UpdateCelebrationTemplates(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Int64 UpdateCelebrationTemplatesCategory(KudobadgesEntity KudobadgesEntity)
        {
            try
            {
                var filter = new
                {
                    ID = KudobadgesEntity.ID,
                    Category = KudobadgesEntity.Category,
                    Description = KudobadgesEntity.Description,
                 
                };
                return IRecognitionRepository.UpdateCelebrationTemplatesCategory(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<dynamic> GetCelebrationTemplates()
        {
            try
            {
                return IRecognitionRepository.GetCelebrationTemplates<dynamic>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<dynamic> GetCelebrationTemplatesCategory()
        {
            try
            {
                return IRecognitionRepository.GetCelebrationTemplatesCategory<dynamic>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<dynamic> GetCelebrationTemplatesByID(object filter)
        {
            try
            {
                return IRecognitionRepository.GetCelebrationTemplatesByID<dynamic>(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<dynamic> GetCelebrationTemplatesCategoryByID(object filter)
        {
            try
            {
                return IRecognitionRepository.GetCelebrationTemplatesCategoryByID<dynamic>(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<dynamic> EnableCelebrationTemplates(object filter)
        {
            try
            {
                return IRecognitionRepository.EnableCelebrationTemplates<dynamic>(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<dynamic> DisableCelebrationTemplates(object filter)
        {
            try
            {
                return IRecognitionRepository.DisableCelebrationTemplates<dynamic>(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<dynamic> EnableCelebrationTemplatesCategory(object filter)
        {
            try
            {
                return IRecognitionRepository.EnableCelebrationTemplatesCategory<dynamic>(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<dynamic> DisableCelebrationTemplatesCategory(object filter)
        {
            try
            {
                return IRecognitionRepository.DisableCelebrationTemplatesCategory<dynamic>(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Int64 DeleteCelebrationTemplates(object filter)
        {
            try
            {
                return IRecognitionRepository.DeleteCelebrationTemplates(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Int64 DeleteCelebrationTemplatesCategory(object filter)
        {
            try
            {
                return IRecognitionRepository.DeleteCelebrationTemplatesCategory(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<dynamic> GetSpecialDaysOfStaff(object filter)
        {
            try
            {
                return IRecognitionRepository.GetSpecialDaysOfStaff<dynamic>(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<dynamic> GetStaffByManagerID(object filter)
        {
            try
            {
                return IRecognitionRepository.GetStaffByManagerID<dynamic>(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //--------------------------

        public IEnumerable<dynamic> GetKudosByHR()
        {
            try
            {
                return IRecognitionRepository.GetKudosByHR<dynamic>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public IEnumerable<dynamic> GetKudosByHRByID(object filter)
        {
            try
            {
                return IRecognitionRepository.GetKudosByHRByID<dynamic>(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Int64 InsertKudosByHR(object filter)
        {
            try
            {
                return IRecognitionRepository.InsertKudosByHR(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Int64 InsertKudosByManager(object filter)
        {
            try
            {
                return IRecognitionRepository.InsertKudosByManager(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public Int64 UpdateKudosByHR(KudobadgesEntity KudobadgesEntity)
        {
            try
            {
                var filter = new
                {
                    ID = KudobadgesEntity.ID,
                    RecognisedBy = KudobadgesEntity.RecognisedBy,
                    RecognitionCategory = KudobadgesEntity.RecognitionCategory,
                    StaffID = KudobadgesEntity.StaffID,
                    Title = KudobadgesEntity.Title,
                    CategoryID = KudobadgesEntity.CategoryID,
                    BadgeID = KudobadgesEntity.BadgeID,
                    Point = KudobadgesEntity.Point,
                    ImageUrl = KudobadgesEntity.ImageUrl,
                    Message = KudobadgesEntity.Message,
                    EmailSent = KudobadgesEntity.EmailSent,
                    CCList= KudobadgesEntity.CCList

                };
                return IRecognitionRepository.UpdateKudosByHR(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Int64 DeleteKudosByHR(object filter)
        {
            try
            {
                return IRecognitionRepository.DeleteKudosByHR(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //--------
        public IEnumerable<dynamic> GetCelebrationByHR()
        {
            try
            {
                return IRecognitionRepository.GetCelebrationByHR<dynamic>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<dynamic> GetEmployeePointsMaster()
        {
            try
            {
                return IRecognitionRepository.GetEmployeePointsMaster<dynamic>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public IEnumerable<dynamic> GetCelebrationByHRByID(object filter)
        {
            try
            {
                return IRecognitionRepository.GetCelebrationByHRByID<dynamic>(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<dynamic> GetManagerByStaffID(object filter)
        {
            try
            {
                return IRecognitionRepository.GetManagerByStaffID<dynamic>(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Int64 InsertCelebrationByHR(object Entity)
        {
            try
            {
                //var filter = new
                //{
                //    RecognisedBy = KudobadgesEntity.RecognisedBy,
                //    RecognitionCategory = KudobadgesEntity.RecognitionCategory,
                //    StaffID = KudobadgesEntity.StaffID,
                //    Title = KudobadgesEntity.Title,
                //    CategoryID = KudobadgesEntity.CategoryID,
                //    TemplateID = KudobadgesEntity.TemplateID,
                //    ImageUrl = KudobadgesEntity.ImageUrl,
                //    Message = KudobadgesEntity.Message,


                //};
                return IRecognitionRepository.InsertCelebrationByHR(Entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public Int64 UpdateCelebrationByHR(KudobadgesEntity KudobadgesEntity)
        {
            try
            {
                var filter = new
                {
                    ID = KudobadgesEntity.ID,
                    RecognisedBy = KudobadgesEntity.RecognisedBy,
                    RecognitionCategory = KudobadgesEntity.RecognitionCategory,
                    StaffID = KudobadgesEntity.StaffID,
                    Title = KudobadgesEntity.Title,
                    CategoryID = KudobadgesEntity.CategoryID,
                    TemplateID = KudobadgesEntity.TemplateID,
                    ImageUrl = KudobadgesEntity.ImageUrl,
                    Message = KudobadgesEntity.Message,
                    EmailSent = KudobadgesEntity.EmailSent,
                    CCList= KudobadgesEntity.CCList

                };
                return IRecognitionRepository.UpdateCelebrationByHR(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Int64 DeleteCelebrationByHR(object filter)
        {
            try
            {
                return IRecognitionRepository.DeleteCelebrationByHR(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Int64 InsertCelebrationByManager(object Entity)
        {
            try
            {
              //  var filter = new
               // {
                   // RecognisedBy = KudobadgesEntity.RecognisedBy,
                   // RecognitionCategory = KudobadgesEntity.RecognitionCategory,
                //   StaffID = KudobadgesEntity.StaffID,
                 //  Title = KudobadgesEntity.Title,
                  //  CategoryID = KudobadgesEntity.CategoryID,
                  //  TemplateID = KudobadgesEntity.TemplateID,
                  // ImageUrl = KudobadgesEntity.ImageUrl,
                  //  Message = KudobadgesEntity.Message,
                  //  CCLIst= KudobadgesEntity.CCList

               // };
                return IRecognitionRepository.InsertCelebrationByManager(Entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<dynamic> GetCelebrationByManager()
        {
            try
            {
                return IRecognitionRepository.GetCelebrationByManager<dynamic>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<dynamic> GetKudosByEmployee()
        {
            try
            {
                return IRecognitionRepository.GetKudosByEmployee<dynamic>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<dynamic> GetCelebrationByEmployee()
        {
            try
            {
                return IRecognitionRepository.GetCelebrationByEmployee<dynamic>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Int64 InsertKudosByEmployee(object Entity)
        {
            try
            {
                return IRecognitionRepository.InsertKudosByEmployee(Entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Int64 InsertCelebrationByEmployee(object Entity)
        {
            try
            {
                return IRecognitionRepository.InsertCelebrationByEmployee(Entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public IEnumerable<dynamic> GetKudosByUserID(object filter)
        {
            try
            {
                return IRecognitionRepository.GetKudosByUserID<dynamic>(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<dynamic> GetCelebrationByUserID(object filter)
        {
            try
            {
                return IRecognitionRepository.GetCelebrationByUserID<dynamic>(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<dynamic> GetAvailablePointsByUserID(object filter)
        {
            try
            {
                return IRecognitionRepository.GetAvailablePointsByUserID<dynamic>(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<dynamic> GetKudosByUserIDandDate(object filter)
        {
            try
            {
                return IRecognitionRepository.GetKudosByUserIDandDate<dynamic>(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public IEnumerable<dynamic> CheckCategoryAvailability(object filter)
        {
            try
            {
                return IRecognitionRepository.CheckCategoryAvailability<dynamic>(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<dynamic> CheckCelebrationTemplates(object filter)
        {
            try
            {
                return IRecognitionRepository.CheckCelebrationTemplates<dynamic>(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<dynamic> CheckCelebrationTemplatesCategory(object filter)
        {
            try
            {
                return IRecognitionRepository.CheckCelebrationTemplatesCategory<dynamic>(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
        public IEnumerable<dynamic> CheckKudosBadgesName(object filter)
        {
            try
            {
                return IRecognitionRepository.CheckKudosBadgesName<dynamic>(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public IEnumerable<dynamic> GetManagerPointsTransactionsByUserID(object filter)
        {
            try
            {
                return IRecognitionRepository.GetManagerPointsTransactionsByUserID<dynamic>(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<dynamic> GetNewJoineeByDate(object filter)
        {
            try
            {
                return IRecognitionRepository.GetNewJoineeByDate<dynamic>(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<dynamic> GetTodaysBirthDay(object filter)
        {
            try
            {
                return IRecognitionRepository.GetTodaysBirthDay<dynamic>(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public IEnumerable<dynamic> GetTodaysMarriageAnniversary(object filter)
        {
            try
            {
                return IRecognitionRepository.GetTodaysMarriageAnniversary<dynamic>(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<dynamic> GetTodaysWorkAnniversary(object filter)
        {
            try
            {
                return IRecognitionRepository.GetTodaysWorkAnniversary<dynamic>(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
