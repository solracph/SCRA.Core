using SCRA.Data.Clinical.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class UserApplicationEntity
{
    public int UserId { get; set; }
    public UserEntity User { get; set; }

    public int ApplicationId { get; set; }
    public ApplicationEntity Application { get; set; }
}
