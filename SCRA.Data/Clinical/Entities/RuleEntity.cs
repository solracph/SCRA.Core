using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCRA.Data.Clinical.Entities
{
    public class RuleEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RuleId { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }


        public virtual ICollection<RuleSegmentEntity> RuleSegment { get; set; }

        public virtual ICollection<RuleContractEntity> RuleContract { get; set; }

        public virtual ICollection<RulePbpEntity> RulePbp { get; set; }

        public virtual ICollection<RuleTinEntity> RuleTin { get; set; }

        public virtual ICollection<RuleMeasureEntity> RuleMeasure { get; set; }

        public virtual ICollection<RuleApplicationEntity> RuleApplication { get; set; }

        public ICollection<UserRuleEntity> UserRule { get; set; }
    }
}
