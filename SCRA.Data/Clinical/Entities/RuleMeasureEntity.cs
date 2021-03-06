﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCRA.Data.Clinical.Entities
{
    public class RuleMeasureEntity
    {
        public int RuleId { get; set; }
        public RuleEntity Rule { get; set; }

        public int MeasureId { get; set; }
        public MeasureEntity Measure { get; set; }
    }
}
