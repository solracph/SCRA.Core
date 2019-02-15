using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCRA.Data.Clinical.Entities
{
    public class ContractEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContractId { get; set; }

        public string Description { get; set; }

        public virtual ICollection<RuleContractEntity> RuleContract { get; set; }

        public virtual ICollection<RulePbpEntity> RulePbp { get; set; }
    }
}
