using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities;

public class BaseEntity
{
    [Key, Required]
    public int Id { get; set; }
}
