using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCRA.Data.Clinical.Entities
{
    public class RuleApplicationEntity
    {
        public int ApplicationId { get; set; }
        public ApplicationEntity Application { get; set; }

        public int RuleId { get; set; }
        public RuleEntity Rule { get; set; }
    }
}
