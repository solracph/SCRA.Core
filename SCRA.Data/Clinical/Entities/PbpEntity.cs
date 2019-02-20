using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCRA.Data.Clinical.Entities
{
    public class PbpEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PbpId { get; set; }

        public string Description { get; set; }

        public ICollection<ContractPbpEntity> ContractPbp { get; set; }

    }
}
