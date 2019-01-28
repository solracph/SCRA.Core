using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCRA.Data.Clinical.Entities
{
    public class MeasureEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MeasureId { get; set; }

        public string Description { get; set; }

        public virtual ICollection<RuleMeasureEntity> RuleMeasure { get; set; }
    }
}
