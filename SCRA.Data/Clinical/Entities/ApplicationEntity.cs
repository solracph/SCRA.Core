using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SCRA.Data.Clinical.Entities;

namespace SCRA.Data.Clinical.Entities
{
    public class ApplicationEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ApplicationId { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public ICollection<RuleApplicationEntity> RuleApplication { get; set; }

        public ICollection<UserApplicationEntity> UserApplication { get; set; }

    }
}
