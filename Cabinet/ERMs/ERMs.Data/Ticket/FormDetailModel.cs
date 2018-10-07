using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERMs.Data
{
    public class FormDetailModel
    {
        public string FullNameOffer { get; set; }
        public int YearOffer { get; set; }

        public string FullName { get; set; }

        public DateTime? BirthDate { get; set; }

        public string PID { get; set; }

        public string Relationship { get; set; }

        public string Route { get; set; }

        public string Base { get; set; }
    }
}
