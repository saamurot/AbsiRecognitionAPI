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

    }
}
