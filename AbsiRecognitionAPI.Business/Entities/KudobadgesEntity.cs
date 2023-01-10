using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticWebAPI.Business.Entities
{
    public class KudobadgesEntity
    {
        public Int64 ID { get; set; }
        public Int64 CategoryID { get; set; }
        public string BadgeName { get; set; }
        public string Description { get; set; }
        public string BadgeURL { get; set; }
        public bool? Status { get; set; }
        public string Category { get; set; }
        public string TemplateName { get; set; }
        public string TemplateURL { get; set; }
    }
}
