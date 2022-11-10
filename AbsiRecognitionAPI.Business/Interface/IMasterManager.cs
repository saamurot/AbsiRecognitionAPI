using StaticWebAPI.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbsiRecognitionAPI.Business.Interface
{
    public interface IMasterManager
    {
        // Get details------------------------
        IEnumerable<dynamic> GetDepartmentMaster();
        IEnumerable<dynamic> GetDesignationMaster();
        IEnumerable<dynamic> GetEmployee();
        IEnumerable<dynamic> GetEmployeeBankDetails();
        IEnumerable<dynamic> GetEmployeeByID(object football);


        // Insert Details------------------------------------
        Int64 InsertDepartmentMaster(MasterEntity MasterEntity);
        Int64 InsertDesignationMaster(MasterEntity MasterEntity);
        Int64 InsertEmployee(MasterEntity MasterEntity);
        Int64 InsertEmployeeBankDetails(MasterEntity MasterEntity);
        

        // Update Details--------------------
        Int64 UpdateDepartmentMaster(MasterEntity Entity);
        Int64 UpdateDesignationMaster(MasterEntity Entity);
        Int64 UpdateEmployee(MasterEntity Entity);
        Int64 UpdateEmployeeBankDetails(MasterEntity Entity);
        Int64 UpdateJoiningEmployeeBasicInformation(MasterEntity MasterEntity);



        // Delete Deatils-----------------------------------------
        Int64 DeleteDepartmentMaster(object filter);
        Int64 DeleteDesignationMaster(object filter);
        Int64 DeleteEmployee(object filter);
        Int64 DeleteEmployeeBankDetailsr(object filter);

        IEnumerable<dynamic> GetJoiningEmployeeBasicInformation();

        IEnumerable<dynamic> GetJoiningEmployeeAcademicInformationByID(object filter);
        IEnumerable<dynamic> GetJoiningEmployeeAddressInformationByID(object filter);
        IEnumerable<dynamic> GetJoiningEmployeeBasicInformationByID(object filter);
        IEnumerable<dynamic> GetJoiningEmployeeFamilyMembersInformationByID(object filter);
        IEnumerable<dynamic> GetJoiningEmployeeHealthInformationByID(object filter);
        IEnumerable<dynamic> GetJoiningEmployeeOtherInformationByID(object filter);
        IEnumerable<dynamic> GetJoiningEmployeeProfessionalExperienceByID(object filter);

        Int64 InsertJoiningEmployeeAcademicInformation(MasterEntity MasterEntity);
        Int64 InsertJoiningEmployeeAddressInformation(MasterEntity MasterEntity);
        Int64 InsertJoiningEmployeeBasicInformation(MasterEntity MasterEntity);
        Int64 InsertJoiningEmployeeFamilyMembersInformation(MasterEntity MasterEntity);
        Int64 InsertJoiningEmployeeHealthInformation(MasterEntity MasterEntity);
        Int64 InsertJoiningEmployeeOtherInformation(MasterEntity MasterEntity);
        Int64 InsertJoiningEmployeeProfessionalExperience(MasterEntity MasterEntity);

        IEnumerable<dynamic> GetJoiningEmployeeFormTrace(object filter);
        IEnumerable<dynamic> UpdateJoiningEmployeeFormTrace(object filter);

    }
}
