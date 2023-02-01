using AbsiRecognitionAPI.Data.Interface;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbsiRecognitionAPI.Data.Repositories
{
    public class RecognitionRepository : Repository, IRecognitionRepository
    {
        public IEnumerable<T> GetStaffDetails<T>()
        {
            try
            {
                return db.Query<T>("SProc_GetStaffDetails", commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<T> CheckStaffLogin<T>(object filter)
        {
            try
            {
                return db.Query<T>("SProc_CheckStaffLogin", filter, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<T> GetStaffDetailsByTypeID<T>(object filter)
        {
            try
            {
                return db.Query<T>("SProc_GetStaffDetailsByTypeID", filter, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<T> GetStaffDetailsByID<T>(object filter)
        {
            try
            {
                return db.Query<T>("SProc_GetStaffDetailsByID", filter, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<T> GetCategoryWiseCardsByID<T>(object filter)
        {
            try
            {
                return db.Query<T>("SProc_GetCategoryWiseCardsByID", filter, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Int64 InsertCategoryMaster(object filter)
        {
            try
            {
                return db.Query<Int64>("[dbo].[SProc_InsertCategoryMaster]", filter, commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Int64 InsertCategoryWiseCards(object filter)
        {
            try
            {
                return db.Query<Int64>("[dbo].[SProc_InsertCategoryWiseCards]", filter, commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Int64 UpdateCategoryMaster(object filter)
        {
            try
            {
                return db.Query<Int64>("SProc_UpdateCategoryMaster", filter, commandType: System.Data.CommandType.StoredProcedure).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Int64 UpdateCategoryWiseCards(object filter)
        {
            try
            {
                return db.Query<Int64>("SProc_UpdateCategoryWiseCards", filter, commandType: System.Data.CommandType.StoredProcedure).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<T> GetCategoryWiseCards<T>()
        {
            try
            {
                return db.Query<T>("SProc_GetCategoryWiseCards", commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<T> GetCategoryMasterByID<T>(object filter)
        {
            try
            {
                return db.Query<T>("SProc_GetCategoryMasterByID", filter, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<T> EnableCategoryWiseCards<T>(object filter)
        {
            try
            {
                return db.Query<T>("SProc_EnableCategoryWiseCards", filter, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<T> DisableCategoryWiseCards<T>(object filter)
        {
            try
            {
                return db.Query<T>("SProc_DisableCategoryWiseCards", filter, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<T> EnableCategoryMaster<T>(object filter)
        {
            try
            {
                return db.Query<T>("SProc_EnableCategoryMaster", filter, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<T> DisableCategoryMaster<T>(object filter)
        {
            try
            {
                return db.Query<T>("SProc_DisableCategoryMaster", filter, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<T> GetCategoryMaster<T>()
        {
            try
            {
                return db.Query<T>("SProc_GetCategoryMaster", commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Int64 InsertKudosBadges(object filter)
        {
            try
            {
                return db.Query<Int64>("[dbo].[SProc_InsertKudosBadges]", filter, commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Int64 UpdateKudosBadges(object filter)
        {
            try
            {
                return db.Query<Int64>("SProc_UpdateKudosBadges", filter, commandType: System.Data.CommandType.StoredProcedure).SingleOrDefault();
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
                return db.Execute("[SProc_DeleteKudosBadges]", filter, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<T> GetKudosBadgesByID<T>(object filter)
        {
            try
            {
                return db.Query<T>("SProc_GetKudosBadgesByID", filter, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<T> GetKudosBadges<T>()
        {
            try
            {
                return db.Query<T>("SProc_GetKudosBadges", commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<T> EnableKudosBadges<T>(object filter)
        {
            try
            {
                return db.Query<T>("SProc_EnableKudosBadges", filter, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<T> DisableKudosBadges<T>(object filter)
        {
            try
            {
                return db.Query<T>("SProc_DisableKudosBadges", filter, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Int64 InsertKudosBadgeCategory(object filter)
        {
            try
            {
                return db.Query<Int64>("[dbo].[SProc_InsertKudosBadgeCategory]", filter, commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Int64 UpdateKudosBadgeCategory(object filter)
        {
            try
            {
                return db.Query<Int64>("SProc_UpdateKudosBadgeCategory", filter, commandType: System.Data.CommandType.StoredProcedure).SingleOrDefault();
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
                return db.Execute("[SProc_DeleteKudosBadgeCategory]", filter, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<T> GetKudosBadgeCategoryByID<T>(object filter)
        {
            try
            {
                return db.Query<T>("SProc_GetKudosBadgeCategoryByID", filter, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<T> GetKudosBadgesByCategoryID<T>(object filter)
        {
            try
            {
                return db.Query<T>("SProc_GetKudosBadgesByCategoryID", filter, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<T> GetKudosBadgeCategory<T>()
        {
            try
            {
                return db.Query<T>("SProc_GetKudosBadgeCategory", commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        

        public IEnumerable<T> EnableKudosBadgeCategory<T>(object filter)
        {
            try
            {
                return db.Query<T>("SProc_EnableKudosBadgeCategory", filter, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<T> DisableKudosBadgeCategory<T>(object filter)
        {
            try
            {
                return db.Query<T>("SProc_DisableKudosBadgeCategory", filter, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Int64 InsertCelebrationTemplates(object filter)
        {
            try
            {
                return db.Query<Int64>("[dbo].[SProc_InsertCelebrationTemplates]", filter, commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public Int64 InsertCelebrationTemplatesCategory(object filter)
        {
            try
            {
                return db.Query<Int64>("[dbo].[SProc_InsertCelebrationTemplatesCategory]", filter, commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Int64 UpdateCelebrationTemplates(object filter)
        {
            try
            {
                return db.Query<Int64>("SProc_UpdateCelebrationTemplates", filter, commandType: System.Data.CommandType.StoredProcedure).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Int64 UpdateCelebrationTemplatesCategory(object filter)
        {
            try
            {
                return db.Query<Int64>("SProc_UpdateCelebrationTemplatesCategory", filter, commandType: System.Data.CommandType.StoredProcedure).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<T> GetCelebrationTemplates<T>()
        {
            try
            {
                return db.Query<T>("SProc_GetCelebrationTemplates", commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<T> GetCelebrationTemplatesCategory<T>()
        {
            try
            {
                return db.Query<T>("SProc_GetCelebrationTemplatesCategory", commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<T> GetCelebrationTemplatesByID<T>(object filter)
        {
            try
            {
                return db.Query<T>("SProc_GetCelebrationTemplatesByID", filter, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<T> GetCelebrationTemplatesCategoryByID<T>(object filter)
        {
            try
            {
                return db.Query<T>("SProc_GetCelebrationTemplatesCategoryByID", filter, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<T> EnableCelebrationTemplates<T>(object filter)
        {
            try
            {
                return db.Query<T>("SProc_EnableCelebrationTemplates", filter, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<T> DisableCelebrationTemplates<T>(object filter)
        {
            try
            {
                return db.Query<T>("SProc_DisableCelebrationTemplates", filter, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<T> EnableCelebrationTemplatesCategory<T>(object filter)
        {
            try
            {
                return db.Query<T>("SProc_EnableCelebrationTemplatesCategory", filter, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<T> DisableCelebrationTemplatesCategory<T>(object filter)
        {
            try
            {
                return db.Query<T>("SProc_DisableCelebrationTemplatesCategory", filter, commandType: CommandType.StoredProcedure);
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
                return db.Execute("[SProc_DeleteCelebrationTemplates]", filter, commandType: CommandType.StoredProcedure);
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
                return db.Execute("[SProc_DeleteCelebrationTemplatesCategory]", filter, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<T> GetSpecialDaysOfStaff<T>(object filter)
        {
            try
            {
                return db.Query<T>("SProc_GetSpecialDaysOfStaff", filter, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<T> GetStaffByManagerID<T>(object filter)
        {
            try
            {
                return db.Query<T>("SProc_GetStaffByManagerID", filter, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //---------------------


        public IEnumerable<T> GetKudosByHR<T>()
        {
            try
            {
                return db.Query<T>("SProc_GetKudosByHR", commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public IEnumerable<T> GetKudosByHRByID<T>(object filter)
        {
            try
            {
                return db.Query<T>("SProc_GetKudosByHRByID", filter, commandType: CommandType.StoredProcedure);
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
                return db.Query<Int64>("[dbo].[SProc_InsertKudosByHR]", filter, commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Int64 UpdateKudosByHR(object filter)
        {
            try
            {
                return db.Query<Int64>("SProc_UpdateKudosByHR", filter, commandType: System.Data.CommandType.StoredProcedure).SingleOrDefault();
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
                return db.Execute("[SProc_DeleteKudosByHR]", filter, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //------------------


        public IEnumerable<T>GetCelebrationByHR<T>()
        {
            try
            {
                return db.Query<T>("SProc_GetCelebrationByHR", commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<T> GetEmployeePointsMaster<T>()
        {
            try
            {
                return db.Query<T>("SProc_GetEmployeePointsMaster", commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<T>GetCelebrationByHRByID<T>(object filter)
        {
            try
            {
                return db.Query<T>("SProc_GetCelebrationByHRByID", filter, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<T> GetManagerByStaffID<T>(object filter)
        {
            try
            {
                return db.Query<T>("SProc_GetManagerByStaffID", filter, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Int64 InsertCelebrationByHR(object filter)
        {
            try
            {
                return db.Query<Int64>("[dbo].[SProc_InsertCelebrationByHR]", filter, commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Int64 UpdateCelebrationByHR(object filter)
        {
            try
            {
                return db.Query<Int64>("SProc_UpdateCelebrationByHR", filter, commandType: System.Data.CommandType.StoredProcedure).SingleOrDefault();
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
                return db.Execute("[SProc_DeleteCelebrationByHR]", filter, commandType: CommandType.StoredProcedure);
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
                return db.Query<Int64>("[dbo].[SProc_InsertKudosByManager]", filter, commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Int64 InsertCelebrationByManager(object filter)
        {
            try
            {
                return db.Query<Int64>("[dbo].[SProc_InsertCelebrationByManager]", filter, commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<T> GetCelebrationByManager<T>()
        {
            try
            {
                return db.Query<T>("SProc_GetCelebrationByManager", commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<T> GetKudosByEmployee<T>()
        {
            try
            {
                return db.Query<T>("SProc_GetKudosByEmployee", commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<T> GetCelebrationByEmployee<T>()
        {
            try
            {
                return db.Query<T>("SProc_GetCelebrationByEmployee", commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Int64 InsertKudosByEmployee(object filter)
        {
            try
            {
                return db.Query<Int64>("[dbo].[SProc_InsertKudosByEmployee]", filter, commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Int64 InsertCelebrationByEmployee(object filter)
        {
            try
            {
                return db.Query<Int64>("[dbo].[SProc_InsertCelebrationByEmployee]", filter, commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<T> GetKudosByUserID<T>(object filter)
        {
            try
            {
                return db.Query<T>("SProc_GetKudosByUserID", filter, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    } 

}

