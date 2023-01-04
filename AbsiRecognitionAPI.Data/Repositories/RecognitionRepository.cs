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
        public int DeleteManagerPointsMaster(object filter)
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
        public int DeleteManagerPointsTransactions(object filter)
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
        public int DeleteManagerPointsRequests(object filter)
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





    }
}
