using AuctionService.Data.Context;
using AuctionService.Domain.Constants;
using AuctionService.Domain.Entities;
using Bogus;
using Microsoft.AspNetCore.Identity;
using System.Collections;
using Microsoft.Extensions.Configuration;

namespace AuctionService.Data.Seeder;

public class DbSeederGenerator
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<User> _userManager;
    private readonly IConfiguration _configuration;

    public DbSeederGenerator(ApplicationDbContext context, UserManager<User> userManager, IConfiguration configuration)
    {
        _context = context;
        _userManager = userManager;
        _configuration = configuration;
    }

    public async Task Run()
    {
        await SeedUsers();
        await SeedCars();
        SeedBids();
        await _context.SaveChangesAsync();
    }

    private async Task<IEnumerable<User>> SeedUsers(string role = RoleConstants.User)
    {
        var faker = new Faker("en");

        var users = new Faker<User>()
            .RuleFor(u => u.Id, f => Ulid.NewUlid(DateTime.UtcNow).ToString())
            .RuleFor(u => u.UserName, f => f.Internet.UserName())
            .RuleFor(u => u.Email, f => f.Internet.Email())
            .RuleFor(u => u.FirstName, f => f.Name.FirstName())
            .RuleFor(u => u.LastName, f => f.Name.LastName())
            .RuleFor(u => u.ProfileImageUrl, f => f.Internet.Avatar())
            .RuleFor(u => u.IsFinanciallyApproved, f => f.Random.Bool())
            .RuleFor(u => u.PreferredCarBrands, f => f.Vehicle.Manufacturer())
            .RuleFor(u => u.MaxBidLimit, f => f.Finance.Amount(50000, 1000000))
            .RuleFor(u => u.ReceiveAuctionNotifications, f => f.Random.Bool())
            .RuleFor(u => u.ReceiveBidNotifications, f => f.Random.Bool())
            .RuleFor(u => u.ReferralCode, f => f.Random.AlphaNumeric(6).ToUpper())
            .Generate(10); // Generate 10 users
        foreach (var user in users)
        {
            await _userManager.CreateAsync(user, "Password@123");
            await _userManager.AddToRoleAsync(user, role);
            await _context.Users.AddAsync(user);
        }

        await _context.SaveChangesAsync();
        return users;
    }
    private async Task<IEnumerable<Car>> SeedCars()
    {
        var faker = new Faker("en");
        var users = await SeedUsers();
        var cars = new Faker<Car>()
        .RuleFor(c => c.Id, f => Ulid.NewUlid().ToString())
        .RuleFor(c => c.Make, f => f.Vehicle.Manufacturer())
        .RuleFor(c => c.Model, f => f.Vehicle.Model())
        .RuleFor(c => c.Year, f => f.Date.Past(10).Year)
        .RuleFor(c => c.Description, f => f.Lorem.Paragraph())
        .RuleFor(c => c.StartingPrice, f => f.Finance.Amount(30000, 1000000))
        .RuleFor(c => c.IsActive, f => true)
        .RuleFor(c => c.SellerId, f => f.PickRandom(users.First().Id))// Associate with random user
        .Generate(15); // Generate 15 cars

        _context.Cars.AddRange(cars);
        return cars;
    }
    private  void SeedBids()
    {
        var faker = new Faker("en");
        var carIds = _context.Cars.Select(c => c.Id).ToList();
        var userIds = _context.Users.Select(u => u.Id.ToString()).ToList();
        var bids = new Faker<Bid>()
            .RuleFor(b => b.Id, f => Ulid.NewUlid().ToString())
            .RuleFor(b => b.Amount, f => f.Finance.Amount(35000, 200000))
            .RuleFor(b => b.BidDate, f => f.Date.Recent())
            .RuleFor(b => b.CarId, f => f.PickRandom(carIds))
            .RuleFor(b => b.BidderId, f => f.PickRandom(userIds))
            .Generate(20); // Generate 20 bids

        _context.Bids.AddRange(bids);
        
    }
}