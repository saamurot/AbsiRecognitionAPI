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
    public class MasterRepository : Repository, IMasterRrepository
    {



        //getD Details

        public IEnumerable<T> GetDesignationMaster<T>()
        {
            try
            {
                return db.Query<T>("SProc_GetDesignationMaster", commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public IEnumerable<T> GetEmployee<T>()
        {
            try
            {
                return db.Query<T>("SProc_GetEmployee", commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public IEnumerable<T> GetEmployeeBankDetails<T>()
        {
            try
            {
                return db.Query<T>("SProc_GetEmployeeBankDetails", commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //Insert Details
        public Int64 InsertDepartmentMaster(object filter)
        {
            try
            {
                return db.Query<Int64>("[dbo].[SProc_InsertDepartmentMaster]", filter, commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Int64 InsertDesignationMaster(object filter)
        {
            try
            {
                return db.Query<Int64>("[dbo].[SProc_InsertDesignationMaster]", filter, commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Int64 InsertEmployee(object filter)
        {
            try
            {
                return db.Query<Int64>("[dbo].[SProc_InsertEmployee]", filter, commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Int64 InsertEmployeeBankDetails(object filter)
        {
            try
            {
                return db.Query<Int64>("[dbo].[SProc_InsertEmployeeBankDetails]", filter, commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        //Update Details---------------------------
        public Int64 UpdateDepartmentMaster(object filter)
        {
            try
            {
                return db.Query<Int64>("SProc_UpdateDepartmentMaster", filter, commandType: System.Data.CommandType.StoredProcedure).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Int64 UpdateDesignationMaster(object filter)
        {
            try
            {
                return db.Query<Int64>("SProc_UpdateDesignationMaster", filter, commandType: System.Data.CommandType.StoredProcedure).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Int64 UpdateEmployee(object filter)
        {
            try
            {
                return db.Query<Int64>("SProc_UpdateEmployee", filter, commandType: System.Data.CommandType.StoredProcedure).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Int64 UpdateEmployeeBankDetails(object filter)
        {
            try
            {
                return db.Query<Int64>("SProc_UpdateEmployeeBankDetails", filter, commandType: System.Data.CommandType.StoredProcedure).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Int64 UpdateJoiningEmployeeBasicInformation(object filter)
        {
            try
            {
                return db.Query<Int64>("SProc_UpdateJoiningEmployeeBasicInformation", filter, commandType: System.Data.CommandType.StoredProcedure).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Delete Deatils------------------------------------------------------
        public Int64 DeleteDepartmentMaster(object filter)
        {
            try
            {
                return db.Execute("[SProc_DeleteDepartmentMaster]", filter, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Int64 DeleteDesignationMaster(object filter)
        {
            try
            {
                return db.Execute("[SProc_DeleteDesignationMaster]", filter, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Int64 DeleteEmployee(object filter)
        {
            try
            {
                return db.Execute("[SProc_DeleteEmployee]", filter, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Int64 DeleteEmployeeBankDetailsr(object filter)
        {
            try
            {
                return db.Execute("[SProc_DeleteEmployeeBankDetailsr]", filter, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<T> GetDepartmentMaster<T>()
        {
            try
            {
                return db.Query<T>("SProc_GetDepartmentMaster", commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<T> GetEmployeeByID<T>(object football)
        {
            try
            {
                return db.Query<T>("SProc_GetEmployeeByID",football, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<T> GetJoiningEmployeeAcademicInformationByID<T>(object filter)
        {
            try
            {
                return db.Query<T>("SProc_GetJoiningEmployeeAcademicInformationByID", filter, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<T> GetJoiningEmployeeAddressInformationByID<T>(object filter)
        {
            try
            {
                return db.Query<T>("SProc_GetJoiningEmployeeAddressInformationByID", filter, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<T> GetJoiningEmployeeBasicInformationByID<T>(object filter)
        {
            try
            {
                return db.Query<T>("SProc_GetJoiningEmployeeBasicInformationByID", filter, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<T> GetJoiningEmployeeFamilyMembersInformationByID<T>(object filter)
        {
            try
            {
                return db.Query<T>("SProc_GetJoiningEmployeeFamilyMembersInformationByID", filter, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<T> GetJoiningEmployeeHealthInformationByID<T>(object filter)
        {
            try
            {
                return db.Query<T>("SProc_GetJoiningEmployeeHealthInformationByID", filter, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<T> GetJoiningEmployeeOtherInformationByID<T>(object filter)
        {
            try
            {
                return db.Query<T>("SProc_GetJoiningEmployeeOtherInformationByID", filter, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<T> GetJoiningEmployeeProfessionalExperienceByID<T>(object filter)
        {
            try
            {
                return db.Query<T>("SProc_GetJoiningEmployeeProfessionalExperienceByID", filter, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Int64 InsertJoiningEmployeeBasicInformation(object filter)
        {
            try
            {
                return db.Query<Int64>("[dbo].[SProc_InsertJoiningEmployeeBasicInformation]", filter, commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long InsertJoiningEmployeeAcademicInformation(object filter)
        {
            try
            {
                return db.Query<Int64>("[dbo].[SProc_InsertJoiningEmployeeAcademicInformation]", filter, commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long InsertJoiningEmployeeAddressInformation(object filter)
        {
            try
            {
                return db.Query<Int64>("[dbo].[SProc_InsertJoiningEmployeeAddressInformation]", filter, commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long InsertJoiningEmployeeFamilyMembersInformation(object filter)
        {
            try
            {
                return db.Query<Int64>("[dbo].[SProc_InsertJoiningEmployeeFamilyMembersInformation]", filter, commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long InsertJoiningEmployeeHealthInformation(object filter)
        {
            try
            {
                return db.Query<Int64>("[dbo].[SProc_InsertJoiningEmployeeHealthInformation]", filter, commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long InsertJoiningEmployeeOtherInformation(object filter)
        {
            try
            {
                return db.Query<Int64>("[dbo].[SProc_InsertJoiningEmployeeOtherInformation]", filter, commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long InsertJoiningEmployeeProfessionalExperience(object filter)
        {
            try
            {
                return db.Query<Int64>("[dbo].[SProc_InsertJoiningEmployeeProfessionalExperience]", filter, commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<T> GetJoiningEmployeeBasicInformation<T>()
        {
            try
            {
                return db.Query<T>("SProc_GetJoiningEmployeeBasicInformation", commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<T> GetJoiningEmployeeFormTrace<T>(object filter)
        {
            try
            {
                return db.Query<T>("SProc_GetJoiningEmployeeFormTrace",filter, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<T> UpdateJoiningEmployeeFormTrace<T>(object filter)
        {
            try
            {
                return db.Query<T>("SProc_UpdateJoiningEmployeeFormTrace", filter, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
