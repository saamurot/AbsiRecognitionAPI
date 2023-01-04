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


        public IEnumerable<T> GetManagerPointsMaster<T>()
        {
            try
            {
                return db.Query<T>("SProc_GetManagerPointsMaster", commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<T> GetManagerPointsTransactions<T>()
        {
            try
            {
                return db.Query<T>("SProc_GetManagerPointsTransactions", commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Int64 InsertManagerPointsMaster(object filter)
        {
            try
            {
                return db.Query<Int64>("[dbo].[SProc_InsertManagerPointsMaster]", filter, commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Int64 InsertManagerPointsTransactions(object filter)
        {
            try
            {
                return db.Query<Int64>("[dbo].[SProc_InsertManagerPointsTransactions]", filter, commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Int64 UpdateManagerPointsMaster(object filter)
        {
            try
            {
                return db.Query<Int64>("SProc_UpdateManagerPointsMaster", filter, commandType: System.Data.CommandType.StoredProcedure).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Int64 UpdateManagerPointsTransactions(object filter)
        {
            try
            {
                return db.Query<Int64>("SProc_UpdateManagerPointsTransactions", filter, commandType: System.Data.CommandType.StoredProcedure).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public IEnumerable<T> GetManagerPointsMasterByID<T>(object filter)
        {
            try
            {
                return db.Query<T>("SProc_GetManagerPointsMasterByID", filter, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<T> GetManagerPointsTransactionsByID<T>(object filter)
        {
            try
            {
                return db.Query<T>("SProc_GetManagerPointsTransactionsByID", filter, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Int64 DeleteManagerPointsMaster(object filter)
        {
            try
            {
                return db.Execute("[SProc_DeleteManagerPointsMaster]", filter, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Int64 DeleteManagerPointsTransactions(object filter)
        {
            try
            {
                return db.Execute("[SProc_DeleteManagerPointsTransactions]", filter, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<T> GetStatusMaster<T>()
        {
            try
            {
                return db.Query<T>("SProc_GetStatusMaster", commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<T> GetManagerPointsRequests<T>()
        {
            try
            {
                return db.Query<T>("SProc_GetManagerPointsRequests", commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<T> GetManagerPointsRequestsByID<T>(object filter)
        {
            try
            {
                return db.Query<T>("SProc_GetManagerPointsRequestsByID", filter, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Int64 InsertManagerPointsRequests(object filter)
        {
            try
            {
                return db.Query<Int64>("[dbo].[SProc_InsertManagerPointsRequests]", filter, commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Int64 UpdateManagerPointsRequests(object filter)
        {
            try
            {
                return db.Query<Int64>("SProc_UpdateManagerPointsRequests", filter, commandType: System.Data.CommandType.StoredProcedure).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Int64 DeleteManagerPointsRequests(object filter)
        {
            try
            {
                return db.Execute("[SProc_DeleteManagerPointsRequests]", filter, commandType: CommandType.StoredProcedure);
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

        public IEnumerable<T> GetSuperAdminPointsTransactions<T>()
        {
            try
            {
                return db.Query<T>("SProc_GetSuperAdminPointsTransactions", commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public IEnumerable<T> GetSuperAdminPointsTransactionsByID<T>(object filter)
        {
            try
            {
                return db.Query<T>("SProc_GetSuperAdminPointsTransactionsByID", filter, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Int64 InsertSuperAdminPointsTransactions(object filter)
        {
            try
            {
                return db.Query<Int64>("[dbo].[SProc_InsertSuperAdminPointsTransactions]", filter, commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Int64 UpdateSuperAdminPointsTransactions(object filter)
        {
            try
            {
                return db.Query<Int64>("SProc_UpdateSuperAdminPointsTransactions", filter, commandType: System.Data.CommandType.StoredProcedure).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Int64 DeleteSuperAdminPointsTransactions(object filter)
        {
            try
            {
                return db.Execute("[SProc_DeleteSuperAdminPointsTransactions]", filter, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public IEnumerable<T> GetSuperAdminPointsMaster<T>()
        {
            try
            {
                return db.Query<T>("SProc_GetSuperAdminPointsMaster", commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public IEnumerable<T> GetSuperAdminPointsMasterByID<T>(object filter)
        {
            try
            {
                return db.Query<T>("SProc_GetSuperAdminPointsMasterByID", filter, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Int64 InsertSuperAdminPointsMaster(object filter)
        {
            try
            {
                return db.Query<Int64>("[dbo].[SProc_InsertSuperAdminPointsMaster]", filter, commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Int64 UpdateSuperAdminPointsMaster(object filter)
        {
            try
            {
                return db.Query<Int64>("SProc_UpdateSuperAdminPointsMaster", filter, commandType: System.Data.CommandType.StoredProcedure).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Int64 DeleteSuperAdminPointsMaster(object filter)
        {
            try
            {
                return db.Execute("[SProc_DeleteSuperAdminPointsMaster]", filter, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
