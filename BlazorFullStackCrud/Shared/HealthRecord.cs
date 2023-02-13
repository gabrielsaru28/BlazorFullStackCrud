using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorFullStackCrud.Shared
{
    public class HealthRecord
    {
        public int PatientId { get; set; }

        public string PatientName { get; set; } = string.Empty;

        public string MedicalHistory { get; set; } = string.Empty;

        public string Medications { get; set; } = string.Empty;

        public Allergies? Allergies { get; set; }

        public int AllergyId { get; set; }

    }
}
