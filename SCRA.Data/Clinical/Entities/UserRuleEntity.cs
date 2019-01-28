using SCRA.Data.Clinical.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class UserRuleEntity
{
    public int RuleId { get; set; }
    public RuleEntity Rule { get; set; }

    public int UserId { get; set; }
    public UserEntity User { get; set; }
}
