using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbsiRecognitionAPI.Data.Interface
{
    public interface IMasterRrepository
    {
        //get details
        IEnumerable<T> GetDepartmentMaster<T>();
        IEnumerable<T> GetDesignationMaster<T>();
        IEnumerable<T> GetEmployee<T>();
        IEnumerable<T> GetEmployeeBankDetails<T>();
        IEnumerable<T> GetEmployeeByID<T>(object football);

        // Insert Details
        Int64 InsertDepartmentMaster(object filter);
        Int64 InsertDesignationMaster(object filter);
        Int64 InsertEmployee(object filter);
        Int64 InsertEmployeeBankDetails(object filter);






        //update Details
        Int64 UpdateDepartmentMaster(object filter);
        Int64 UpdateDesignationMaster(object filter);
        Int64 UpdateEmployee(object filter);
        Int64 UpdateEmployeeBankDetails(object filter);

        // Delete Details
        Int64 DeleteDepartmentMaster(object filter);
        Int64 DeleteDesignationMaster(object filter);
        Int64 DeleteEmployee(object filter);
        Int64 DeleteEmployeeBankDetailsr(object filter);


        Int64 UpdateJoiningEmployeeBasicInformation(object filter);

        IEnumerable<T> GetJoiningEmployeeBasicInformation<T>();

        IEnumerable<T> GetJoiningEmployeeAcademicInformationByID<T>(object filter);
        IEnumerable<T> GetJoiningEmployeeAddressInformationByID<T>(object filter);
        IEnumerable<T> GetJoiningEmployeeBasicInformationByID<T>(object filter);
        IEnumerable<T> GetJoiningEmployeeFamilyMembersInformationByID<T>(object filter);
        IEnumerable<T> GetJoiningEmployeeHealthInformationByID<T>(object filter);
        IEnumerable<T> GetJoiningEmployeeOtherInformationByID<T>(object filter);
        IEnumerable<T> GetJoiningEmployeeProfessionalExperienceByID<T>(object filter);

        Int64 InsertJoiningEmployeeAcademicInformation(object filter);
        Int64 InsertJoiningEmployeeAddressInformation(object filter);
        Int64 InsertJoiningEmployeeBasicInformation(object filter);
        Int64 InsertJoiningEmployeeFamilyMembersInformation(object filter);
        Int64 InsertJoiningEmployeeHealthInformation(object filter);
        Int64 InsertJoiningEmployeeOtherInformation(object filter);
        Int64 InsertJoiningEmployeeProfessionalExperience(object filter);

        IEnumerable<T> GetJoiningEmployeeFormTrace<T>(object filter);
        IEnumerable<T> UpdateJoiningEmployeeFormTrace<T>(object filter);

    }
}
