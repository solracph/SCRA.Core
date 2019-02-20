using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCRA.Data.Clinical.Entities
{
    public class ContractPbpEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContractPbpId { get; set; }

        public int ContractId { get; set; }
        public ContractEntity Contract { get; set; }

        public int PbpId { get; set; }
        public PbpEntity Pbp { get; set; }
    }
}
