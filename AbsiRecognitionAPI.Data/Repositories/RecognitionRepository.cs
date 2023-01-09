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
    }
}
