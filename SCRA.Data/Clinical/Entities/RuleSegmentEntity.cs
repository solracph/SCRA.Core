using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCRA.Data.Clinical.Entities
{
    public class RuleSegmentEntity
    {
        public int RuleId { get; set; }
        public RuleEntity Rule { get; set; }

        public int SegmentId { get; set; }
        public SegmentEntity Segment { get; set; }
    }
}
