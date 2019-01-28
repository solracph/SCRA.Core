using System;
using System.Collections.Generic;

namespace SCRA.Framework.Models.Clinical
{
    public class Pbp
    {
        public int PbpId { get; set; }

        public string Description { get; set; }

        public ICollection<Contract> Contracts { get; set; }
    }
}
