using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCRA.Data.Clinical.Entities
{
    public class RulePbpEntity
    {
        public int RuleId { get; set; }
        public RuleEntity Rule { get; set; }

        public int PbpId { get; set; }
        public PbpEntity Pbp { get; set; }
    }
}
