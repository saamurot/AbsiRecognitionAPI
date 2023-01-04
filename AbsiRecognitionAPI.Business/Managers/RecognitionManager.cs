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
        public IEnumerable<dynamic> GetManagerPointsMaster()
        {
            try
            {
                return IRecognitionRepository.GetManagerPointsMaster<dynamic>();
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
                return IRecognitionRepository.GetManagerPointsTransactions<dynamic>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Int64 InsertManagerPointsMaster(RecognitionOneEntity RecognitionOneEntity)
        {
            try
            {
                var filter = new
                {
                    UserID = RecognitionOneEntity.UserID,
                    AvailabalePoints = RecognitionOneEntity.AvailabalePoints,
                };
                return IRecognitionRepository.InsertManagerPointsMaster(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Int64 InsertManagerPointsTransactions(RecognitionOneEntity RecognitionOneEntity)
        {
            try
            {
                var filter = new
                {

                  
                    MPMID = RecognitionOneEntity.MPMID,
                    TransactionType = RecognitionOneEntity.TransactionType,
                    Points = RecognitionOneEntity.Points,
                    ClosingBalance = RecognitionOneEntity.ClosingBalance,
                };
                return IRecognitionRepository.InsertManagerPointsTransactions(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Int64 UpdateManagerPointsMaster(RecognitionOneEntity RecognitionOneEntity)
        {
            try
            {
                var filter = new
                {
                    ID = RecognitionOneEntity.ID,
                    UserID = RecognitionOneEntity.UserID,
                    AvailabalePoints = RecognitionOneEntity.AvailabalePoints,

                };
                return IRecognitionRepository.UpdateManagerPointsMaster(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Int64 UpdateManagerPointsTransactions(RecognitionOneEntity RecognitionOneEntity)
        {
            try
            {
                var filter = new
                {
                    ID = RecognitionOneEntity.ID,
                    MPMID = RecognitionOneEntity.MPMID,
                    TransactionType = RecognitionOneEntity.TransactionType,
                    Points = RecognitionOneEntity.Points,
                    ClosingBalance = RecognitionOneEntity.ClosingBalance,

                };
                return IRecognitionRepository.UpdateManagerPointsTransactions(filter);
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
                return IRecognitionRepository.GetManagerPointsMasterByID<dynamic>(filter);
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
                return IRecognitionRepository.GetManagerPointsTransactionsByID<dynamic>(filter);
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
                return IRecognitionRepository.DeleteManagerPointsMaster(filter);
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
                return IRecognitionRepository.DeleteManagerPointsTransactions(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<dynamic> GetStatusMaster()
        {
            try
            {
                return IRecognitionRepository.GetStatusMaster<dynamic>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<dynamic> GetManagerPointsRequests()
        {
            try
            {
                return IRecognitionRepository.GetManagerPointsRequests<dynamic>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<dynamic> GetManagerPointsRequestsByID(object filter)
        {
            try
            {
                return IRecognitionRepository.GetManagerPointsRequestsByID<dynamic>(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Int64 InsertManagerPointsRequests(RecognitionOneEntity RecognitionOneEntity)
        {
            try
            {
                var filter = new
                {


                    SuperAdminID = RecognitionOneEntity.SuperAdminID,
                    PointsRequested = RecognitionOneEntity.PointsRequested,
                   // ApprovedPoints = RecognitionOneEntity.ApprovedPoints,
                   // StatusID = RecognitionOneEntity.StatusID,
                    ManagerID = RecognitionOneEntity.ManagerID,
                    
                };
                return IRecognitionRepository.InsertManagerPointsRequests(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Int64 UpdateManagerPointsRequests(RecognitionOneEntity RecognitionOneEntity)
        {
            try
            {
                var filter = new
                {
                    ID = RecognitionOneEntity.ID,
                    SuperAdminID = RecognitionOneEntity.SuperAdminID,
                    PointsRequested = RecognitionOneEntity.PointsRequested,
                    //ApprovedPoints = RecognitionOneEntity.ApprovedPoints,
                    //StatusID = RecognitionOneEntity.StatusID,
                    ManagerID = RecognitionOneEntity.ManagerID,

                };
                return IRecognitionRepository.UpdateManagerPointsRequests(filter);
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
                return IRecognitionRepository.DeleteManagerPointsRequests(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
