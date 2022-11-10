using AbsiRecognitionAPI.Business.Interface;
using AbsiRecognitionAPI.Data.Interface;
using AbsiRecognitionAPI.Data.Repositories;
using StaticWebAPI.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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



        // Get Details--------------------------------------------------------
        public IEnumerable<dynamic> GetDepartmentMaster()
        {
            try
            {
                return IMasterRrepository.GetDepartmentMaster<dynamic>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public IEnumerable<dynamic> GetDesignationMaster()
        {
            try
            {
                return IMasterRrepository.GetDesignationMaster<dynamic>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public IEnumerable<dynamic> GetEmployee()
        {
            try
            {
                return IMasterRrepository.GetEmployee<dynamic>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public IEnumerable<dynamic> GetEmployeeBankDetails()
        {
            try
            {
                return IMasterRrepository.GetEmployeeBankDetails<dynamic>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // Insert Details-----------------------------------------------------
        public Int64 InsertDepartmentMaster(MasterEntity MasterEntity)
        {
            try
            {
                var filter = new
                {
                    Department = MasterEntity.Department
                };
                return IMasterRrepository.InsertDepartmentMaster(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Int64 InsertDesignationMaster(MasterEntity MasterEntity)
        {
            try
            {
                var filter = new
                {
                    Designation = MasterEntity.Designation
                };
                return IMasterRrepository.InsertDesignationMaster(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Int64 InsertEmployee(MasterEntity MasterEntity)
        {
            try
            {
                var filter = new
                {
                    EmployeeID = MasterEntity.EmployeeID,
                    EmployeeName = MasterEntity.EmployeeName,
                    DateOfJoining = MasterEntity.DateOfJoining,
                    DepartmentID = MasterEntity.DepartmentID,
                    DesignationID = MasterEntity.DesignationID,
                    RMID = MasterEntity.RMID
                };
                return IMasterRrepository.InsertEmployee(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Int64 InsertEmployeeBankDetails(MasterEntity MasterEntity)
        {
            try
            {
                var filter = new
                {

                    EmployeeID = MasterEntity.EmployeeID,
                    BankName = MasterEntity.BankName,
                    AccountNumber = MasterEntity.AccountNumber,
                    PanNumber = MasterEntity.PanNumber,
                    PFUAN = MasterEntity.PFUAN,
                    IFSCCode = MasterEntity.IFSCCode
                };
                return IMasterRrepository.InsertEmployeeBankDetails(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        // Update Details--------------------------------------------------------
        public Int64 UpdateDepartmentMaster(MasterEntity Entity)
        {
            try
            {
                var filter = new
                {
                    Department = Entity.Department



                };
                return IMasterRrepository.UpdateDepartmentMaster(filter);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public Int64 UpdateDesignationMaster(MasterEntity Entity)
        {
            try
            {
                var filter = new
                {
                    Designation = Entity.Designation

                };
                return IMasterRrepository.UpdateDesignationMaster(filter);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Int64 UpdateEmployee(MasterEntity Entity)
        {
            try
            {
                var filter = new
                {
                    ID = Entity.ID,
                    EmployeeID = Entity.EmployeeID,
                    EmployeeName = Entity.EmployeeName,
                    DateOfJoining = Entity.DateOfJoining,
                    DepartmentID = Entity.DepartmentID,
                    DesignationID = Entity.DesignationID,
                    RMID = Entity.RMID
                };
                return IMasterRrepository.UpdateEmployee(filter);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public Int64 UpdateEmployeeBankDetails(MasterEntity Entity)
        {
            try
            {
                var filter = new
                {
                    ID = Entity.ID,
                    BankName = Entity.BankName,
                    AccountNumber = Entity.AccountNumber,
                    PanNumber = Entity.PanNumber,
                    PFUAN = Entity.PFUAN,
                    IFSCCode = Entity.IFSCCode
                };
                return IMasterRrepository.UpdateEmployeeBankDetails(filter);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public Int64 UpdateJoiningEmployeeBasicInformation(MasterEntity Entity)
        {
            try
            {
                var filter = new
                {
                    ID = Entity.ID,
                    EmployeeType = Entity.EmployeeType,
                    EmployeeNumber = Entity.EmployeeNumber,
                    FirstName = Entity.FirstName,
                    LastName = Entity.LastName,
                    DesignationID = Entity.DesignationID,
                    DepartmentID = Entity.DepartmentID,
                    ReportingManagerID = Entity.ReportingManagerID,
                    DateOfBirth = Entity.DateOfBirth,
                    Gender = Entity.Gender,
                    JoiningDate = Entity.JoiningDate,
                    Location = Entity.Location,
                    MannerOfEntry = Entity.MannerOfEntry,
                    BirthPlace = Entity.BirthPlace,
                    MaritalStatus = Entity.MaritalStatus,
                    MarriageDate = Entity.MarriageDate,
                    PanNumber = Entity.PanNumber,
                    PassportNumber = Entity.PassportNumber,
                    VoterIDNumber = Entity.VoterIDNumber,
                    DrivingLicenceNumber = Entity.DrivingLicenceNumber,
                    PreviousPFNumber = Entity.PreviousPFNumber,
                    UANNumber = Entity.UANNumber

                };
                return IMasterRrepository.UpdateJoiningEmployeeBasicInformation(filter);
            }
            catch (Exception e)
            {
                throw e;
            }
        }



        // Delete Details-------------------------------------------------------------------
        public Int64 DeleteDepartmentMaster(object filter)
        {
            try
            {
                return IMasterRrepository.DeleteDepartmentMaster(filter);
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
                return IMasterRrepository.DeleteDesignationMaster(filter);
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
                return IMasterRrepository.DeleteEmployee(filter);
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
                return IMasterRrepository.DeleteEmployeeBankDetailsr(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<dynamic> GetEmployeeByID(object football)
        {
            try
            {
                return IMasterRrepository.GetEmployeeByID<dynamic>(football);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<dynamic> GetJoiningEmployeeAcademicInformationByID(object filter)
        {
            try
            {
                return IMasterRrepository.GetJoiningEmployeeAcademicInformationByID<dynamic>(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<dynamic> GetJoiningEmployeeAddressInformationByID(object filter)
        {
            try
            {
                return IMasterRrepository.GetJoiningEmployeeAddressInformationByID<dynamic>(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<dynamic> GetJoiningEmployeeBasicInformationByID(object filter)
        {
            try
            {
                return IMasterRrepository.GetJoiningEmployeeBasicInformationByID<dynamic>(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<dynamic> GetJoiningEmployeeFamilyMembersInformationByID(object filter)
        {
            try
            {
                return IMasterRrepository.GetJoiningEmployeeFamilyMembersInformationByID<dynamic>(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<dynamic> GetJoiningEmployeeHealthInformationByID(object filter)
        {
            try
            {
                return IMasterRrepository.GetJoiningEmployeeHealthInformationByID<dynamic>(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<dynamic> GetJoiningEmployeeOtherInformationByID(object filter)
        {
            try
            {
                return IMasterRrepository.GetJoiningEmployeeOtherInformationByID<dynamic>(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<dynamic> GetJoiningEmployeeProfessionalExperienceByID(object filter)
        {
            try
            {
                return IMasterRrepository.GetJoiningEmployeeProfessionalExperienceByID<dynamic>(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Int64 InsertJoiningEmployeeBasicInformation(MasterEntity MasterEntity)
        {
            try
            {
                var filter = new
                {
                    EmployeeType = MasterEntity.EmployeeType,
                    EmployeeNumber = MasterEntity.EmployeeNumber,
                    FirstName = MasterEntity.FirstName,
                    LastName = MasterEntity.LastName,
                    DesignationID = MasterEntity.DesignationID,
                    DepartmentID = MasterEntity.DepartmentID,
                    ReportingManagerID = MasterEntity.ReportingManagerID
                };
                return IMasterRrepository.InsertJoiningEmployeeBasicInformation(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long InsertJoiningEmployeeAcademicInformation(MasterEntity MasterEntity)
        {
            try
            {
                var filter = new
                {
                    ID = MasterEntity.ID,
                    JEBIID = MasterEntity.JEBIID,
                    Qualification = MasterEntity.Qualification,
                    CollegeName = MasterEntity.CollegeName,
                    Board = MasterEntity.Board,
                    Location = MasterEntity.Location,
                    Duration = MasterEntity.Duration,
                    Percentage = MasterEntity.Percentage,
                    YearOfPassing = MasterEntity.YearOfPassing,
                };
                return IMasterRrepository.InsertJoiningEmployeeAcademicInformation(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long InsertJoiningEmployeeAddressInformation(MasterEntity MasterEntity)
        {
            try
            {
                var filter = new
                {
                    JEBIID = MasterEntity.JEBIID,
                    PermanentAddress = MasterEntity.PermanentAddress,
                    PhoneNumber = MasterEntity.PhoneNumber,
                    PresentAddress = MasterEntity.PresentAddress,
                    EmailID = MasterEntity.EmailID,
                    EmergencyContactPersonName = MasterEntity.EmergencyContactPersonName,
                    EmergencyContactPersonPhoneNumber = MasterEntity.EmergencyContactPersonPhoneNumber,
                    EmergencyContactPersonAddress = MasterEntity.EmergencyContactPersonAddress,
                };
                return IMasterRrepository.InsertJoiningEmployeeAddressInformation(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long InsertJoiningEmployeeFamilyMembersInformation(MasterEntity MasterEntity)
        {
            try
            {
                var filter = new
                {
                    ID = MasterEntity.ID,
                    JEBIID = MasterEntity.JEBIID,
                    Name = MasterEntity.Name,
                    Relation = MasterEntity.Relation,
                    PhoneNumber = MasterEntity.PhoneNumber,
                    Occupation = MasterEntity.Occupation,
                    BloodGroup = MasterEntity.BloodGroup
                };
                return IMasterRrepository.InsertJoiningEmployeeFamilyMembersInformation(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long InsertJoiningEmployeeHealthInformation(MasterEntity MasterEntity)
        {
            try
            {
                var filter = new
                {
                    JEBIID = MasterEntity.JEBIID,
                    BloodGroup = MasterEntity.BloodGroup,
                    Height = MasterEntity.Height,
                    Weight = MasterEntity.Weight,
                    Allergies = MasterEntity.Allergies,
                    SurgeryInThePast = MasterEntity.SurgeryInThePast
                };
                return IMasterRrepository.InsertJoiningEmployeeHealthInformation(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long InsertJoiningEmployeeOtherInformation(MasterEntity MasterEntity)
        {
            try
            {
                var filter = new
                {
                    ID = MasterEntity.ID,
                    JEBIID = MasterEntity.JEBIID,
                    Name = MasterEntity.Name,
                    CompanyOrRelation = MasterEntity.CompanyOrRelation,
                    ContactNumber = MasterEntity.ContactNumber
                };
                return IMasterRrepository.InsertJoiningEmployeeOtherInformation(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long InsertJoiningEmployeeProfessionalExperience(MasterEntity MasterEntity)
        {
            try
            {
                var filter = new
                {
                    ID = MasterEntity.ID,
                    JEBIID = MasterEntity.JEBIID,
                    Company = MasterEntity.Company,
                    FromDate = MasterEntity.FromDate,
                    ToDate = MasterEntity.ToDate,
                    Designation = MasterEntity.Designation,
                    ReasonForLeaving = MasterEntity.ReasonForLeaving
                };
                return IMasterRrepository.InsertJoiningEmployeeProfessionalExperience(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<dynamic> GetJoiningEmployeeBasicInformation()
        {
            try
            {
                return IMasterRrepository.GetJoiningEmployeeBasicInformation<dynamic>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<dynamic> GetJoiningEmployeeFormTrace(object filter)
        {
            try
            {
                return IMasterRrepository.GetJoiningEmployeeFormTrace<dynamic>(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<dynamic> UpdateJoiningEmployeeFormTrace(object filter)
        {
            try
            {
                return IMasterRrepository.UpdateJoiningEmployeeFormTrace<dynamic>(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
