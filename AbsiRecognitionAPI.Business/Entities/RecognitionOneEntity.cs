using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbsiRecognitionAPI.Business.Entities
{
    public class RecognitionOneEntity
    {
        public string TextToEncrypt { get; set; }
        public string TextToDecrypt { get; set; }
        public Int64 UserID { get; set; }
        public Int64 AvailabalePoints { get; set; }
        public Int64 MPMID { get; set; }
        public Int64 Points { get; set; }
        public Int64 ClosingBalance { get; set; }
        public string TransactionType { get; set; }
        public Int64 ID { get; set; }
        public Int64 SuperAdminID { get; set; }
        public Int64 PointsRequested { get; set; }
        public Int64 ApprovedPoints { get; set; }
        public Int64 StatusID { get; set; }
        public Int64 ManagerID { get; set; }
        public string Description { get; set; }
        public Boolean Status { get; set; }
        public string Category { get; set; }
        public Int64 CategoryID { get; set; }
        public string CardName { get; set; }

        public Int64 SAPMID { get; set; }
        public Int64 AvailablePoints { get; set; }

        public string CardUrl { get; set; }

        public string Discription { get; set; }
        public DateTime StatusUpdateDate { get; set; }

        public Int64 EmployeeID { get; set; }
        public string emailto { get; set; }
        public string emailsubject { get; set; }
        public string emailbody { get; set; }
    }
}
