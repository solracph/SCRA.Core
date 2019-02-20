
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCRA.Data.Clinical.Entities
{
    public class RulePbpEntity
    {
        public int RuleId { get; set; }
        public RuleEntity Rule { get; set; }

        public int ContractPBPId { get; set; }
        public ContractPbpEntity ContractPbp { get; set; }
    }
}
