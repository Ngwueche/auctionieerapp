using AuctionService.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace AuctionService.Domain.Entities;

public class User : IdentityUser, IAuditable
{
    // Role and Account Details
    public bool IsCollector { get; set; }      // If true, user is a Collector (buyer)
    public bool IsSeller { get; set; }         // If true, user is a Seller

    // Profile Information
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? ProfileImageUrl { get; set; } // URL for the profile picture
    public string AddressId { get; set; }
    public Address Address { get; set; }

    // Financial Screening Status
    public bool IsFinanciallyApproved { get; set; } // Whether user has passed financial screening
    public DateTime? FinancialScreeningDate { get; set; } // Date of last financial screening
    public string FinancialScore { get; set; } // Optional: Score or rating if available
    public string FinancialDocumentsUrl { get; set; } // Link to uploaded financial documents
    // Seller-Specific Information
    public ICollection<Car> CarsListed { get; set; } = new List<Car>(); // Cars listed for auction (only for Sellers)

    // Collector-Specific Information
    public ICollection<Bid> BidsPlaced { get; set; } = new List<Bid>(); // Bids made by the Collector
    public string PreferredCarBrands { get; set; } // Stores Collector’s preferred car brands
    public decimal MaxBidLimit { get; set; } // Optional: Maximum bid amount set by Collector

    // Notification Preferences
    public bool ReceiveAuctionNotifications { get; set; } = true; // Opt-in for notifications
    public bool ReceiveBidNotifications { get; set; } = true; // Opt-in for bid-related notifications

    // Referral Feature
    public string ReferralCode { get; set; } // Unique code for each user
    public string? ReferredById { get; set; } // The user who referred this user
    public User ReferredBy { get; set; }
    public ICollection<User> Referrals { get; set; } = new List<User>(); // Users referred by this user

    // Optional fields for referral-based incentives
    public int ReferralCount { get; set; } = 0; // Tracks the number of users referred
    public int ReferralPoints { get; set; } = 0; // Points earned from referrals
    // Timestamps
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset DateModified { get; set; }
    // Soft Delete
    public bool IsActive { get; set; } = true; // Status to check if the user is active

}
