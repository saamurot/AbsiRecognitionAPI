using AbsiRecognitionAPI.Business.Entities;
using AbsiRecognitionAPI.Business.Interface;
using AbsiRecognitionAPI.Data.Interface;
using AbsiRecognitionAPI.Data.Repositories;
using StaticWebAPI.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AbsiRecognitionAPI.Business.Managers
{
    public class MasterManager : IMasterManager
    {
        public IMasterRrepository IMasterRrepository;
        public MasterManager(IMasterRrepository IMasterRrepository)
        {
            this.IMasterRrepository = IMasterRrepository;
        }
        public IEnumerable<dynamic> GetManagerPointsMaster()
        {
            try
            {
                return IMasterRrepository.GetManagerPointsMaster<dynamic>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<dynamic> GetManagerPointsTransactions()
        {
            try
            {
                return IMasterRrepository.GetManagerPointsTransactions<dynamic>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<dynamic> GetManagerPointsMasterByID(object filter)
        {
            try
            {
                return IMasterRrepository.GetManagerPointsMasterByID<dynamic>(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<dynamic> GetStaffDetailsByUsernamePassword(object filter)
        {
            try
            {
                return IMasterRrepository.GetStaffDetailsByUsernamePassword<dynamic>(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<dynamic> GetManagerPointsTransactionsByID(object filter)
        {
            try
            {
                return IMasterRrepository.GetManagerPointsTransactionsByID<dynamic>(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Int64 InsertManagerPointsMaster(MasterEntity MasterEntity)
        {
            try
            {
                var filter = new
                {
                    UserID = MasterEntity.UserID,
                    Points = MasterEntity.Points,
                    AssignedBy = MasterEntity.AssignedBy

                };
                return IMasterRrepository.InsertManagerPointsMaster(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public Int64 InsertEmployeePointsMaster(MasterEntity MasterEntity)
        {
            try
            {
                var filter = new
                {
                    UserID = MasterEntity.UserID,
                    Points = MasterEntity.Points,
                    AssignedBy = MasterEntity.AssignedBy

                };
                return IMasterRrepository.InsertEmployeePointsMaster(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Int64 InsertManagerPointsTransactions(MasterEntity MasterEntity)
        {
            try
            {
                var filter = new
                {
                    UserID = MasterEntity.UserID,
                    TransactionType = MasterEntity.TransactionType,
                    Points=MasterEntity.Points,
                    ClosingBalance=MasterEntity.ClosingBalance,
                    AssignedBy = MasterEntity.AssignedBy
                };
                return IMasterRrepository.InsertManagerPointsTransactions(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Int64 UpdateManagerPointsMaster(MasterEntity MasterEntity)
        {
            try
            {
                var filter = new
                {
                    ID = MasterEntity.ID,
                    UserID = MasterEntity.UserID,
                    AvailablePoints = MasterEntity.AvailablePoints

                };
                return IMasterRrepository.UpdateManagerPointsMaster(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Int64 UpdateManagerPointsTransactions(MasterEntity MasterEntity)
        {
            try
            {
                var filter = new
                {
                    ID = MasterEntity.ID,
                    UserID = MasterEntity.UserID,
                    TransactionType = MasterEntity.TransactionType,
                    Points = MasterEntity.Points,
                    ClosingBalance = MasterEntity.ClosingBalance

                };
                return IMasterRrepository.UpdateManagerPointsTransactions(filter);
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
                return IMasterRrepository.DeleteManagerPointsMaster(filter);
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
                return IMasterRrepository.DeleteManagerPointsTransactions(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<dynamic> GetManagerPointsMasterByUserID(object filter)
        {
            try
            {
                return IMasterRrepository.GetManagerPointsMasterByUserID<dynamic>(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
