using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechnicalTestAPI.Entities
{
    public class CITY
    {
        [Key]
        public int CODE { get; set; }
        [Required]
        public string DESCRIPTION { get; set; }

       public ICollection<SELLER> SELLERs { get; set; }

    }
}
