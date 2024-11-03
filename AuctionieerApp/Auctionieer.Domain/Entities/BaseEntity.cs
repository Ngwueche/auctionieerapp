using System.ComponentModel.DataAnnotations;

namespace AuctionService.Domain.Entities;

public class BaseEntity
{
    [Key]public string Id { get; set; } = Ulid.NewUlid(DateTime.UtcNow).ToString();
}