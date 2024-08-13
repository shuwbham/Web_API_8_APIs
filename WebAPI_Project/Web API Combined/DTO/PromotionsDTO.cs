using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
    namespace Promotions.DTO
    {
        public class PromotionsDTO
        {
            public long Empcd { get; set; }
            public DateTime PromotionDate { get; set; }
            public string ServiceName { get; set; }
            public string Designame { get; set; }
        }

    }
