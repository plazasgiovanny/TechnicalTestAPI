using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TechnicalTestAPI.Entities
{
    public class SELLER
    {
        [Key]
        public int CODE { get; set; }

        [Required]
        public string NAME { get; set; }
        [Required]
        public string LAST_NAME { get; set; }

        [Required]
        public string DOCUMENT { get; set; }
        
        public int CITY_ID { get; set; }

        public CITY CITies { get; set; }
    }
}
