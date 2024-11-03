namespace AuctionService.Domain.Entities;

public class Bid : BaseEntity, IAuditable
{
    public decimal Amount { get; set; }                   // Bid amount

    // Foreign Key to the car
    public string CarId { get; set; }                        // Reference to the Car
    public Car Car { get; set; }

    // Foreign Key to the collector
    public string BidderId { get; set; }               // Reference to AppUser (Collector)
    public User Bidder { get; set; }

    // Timestamps
    public DateTime BidDate { get; set; } = DateTime.UtcNow; // Time bid was placed
    public bool IsWinningBid { get; set; }                // True if this is the current highest bid
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset DateModified { get; set; }
}