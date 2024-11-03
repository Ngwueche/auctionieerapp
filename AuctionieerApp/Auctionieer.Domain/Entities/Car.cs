using AuctionService.Domain.Entities;

namespace AuctionService.Domain.Entities;

public class Car :BaseEntity, IAuditable
{
    public string Make { get; set; }      // Car Make (e.g., Ferrari, Rolls-Royce)
    public string Model { get; set; }     // Car Model (e.g., Phantom, LaFerrari)
    public int Year { get; set; }  // Manufacturing Year
    public decimal StartingPrice { get; set; }// Starting auction price
    public decimal CurrentPrice { get; set; } // Current highest bid price
    public DateTime AuctionStartTime { get; set; }// Auction start time
    public DateTime AuctionEndTime { get; set; }  // Auction end time
    public bool IsSold { get; set; }      // Status of car (sold or not)
    public bool IsActive { get; set; }      // Status of car (Active or invalidated)

    // Foreign Key to the seller
    public string SellerId { get; set; }  // Reference to AppUser (Seller)
    public User Seller { get; set; }

    // Car Details
    public string Description { get; set; }   // Detailed description of the car
    public ICollection<string> ImageUrls { get; set; } = new List<string>(); // URLs for car images
    public string EngineType { get; set; } // Engine details (e.g., V12)
    public string Transmission { get; set; }  // Transmission type (e.g., Automatic)
    public string ExteriorColor { get; set; } // Exterior color
    public string InteriorColor { get; set; } // Interior color
    public int Mileage { get; set; }  // Mileage (in km or miles)

    // Bids placed on this car
    public ICollection<Bid> Bids { get; set; } = new List<Bid>(); // Collection of bids for this car

    // Timestamps
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset DateModified { get; set; } 
}