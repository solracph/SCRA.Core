using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCRA.Data.Clinical.Entities
{
    public class RuleContractEntity
    {
        public int RuleId { get; set; }
        public RuleEntity Rule { get; set; }

        public int ContractId { get; set; }
        public ContractEntity Contract { get; set; }
    }
}
