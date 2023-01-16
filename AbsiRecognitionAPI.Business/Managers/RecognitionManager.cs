﻿using AbsiRecognitionAPI.Business.Entities;
using AbsiRecognitionAPI.Business.Interface;
using AbsiRecognitionAPI.Data.Interface;
using StaticWebAPI.Business.Entities;
using System;
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
    }
}
