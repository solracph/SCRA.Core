using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCRA.Data.Clinical.Entities
{
    public class TinEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TinId { get; set; }

        public string Description { get; set; }

        public virtual ICollection<RuleTinEntity> RuleTin { get; set; }
    }
}
