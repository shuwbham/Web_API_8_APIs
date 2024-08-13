using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trainings.DTO
{
    public class RNAppTrainingsDTO
    {
        public string Empcd { get; set; }
        public string TrngTopic { get; set; }
        public string TrngInstitute { get; set; }
        public DateTime? TrngDtFrom { get; set; }
        public DateTime? TrngDtTo { get; set; }
    }
}