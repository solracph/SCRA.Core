

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCRA.Data.Clinical.Entities
{
    public class RuleTinEntity
    {
        public int RuleId { get; set; }
        public RuleEntity Rule { get; set; }

        public int TinId { get; set; }
        public TinEntity Tin { get; set; }
    }
}
