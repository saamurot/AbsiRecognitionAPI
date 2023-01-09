using AbsiRecognitionAPI.Business.Entities;
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

    }
}
