using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionService.Domain.Entities
{
    public class Address : BaseEntity, IAuditable
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string? PostalCode { get; set; }

        public double? Longitude { get; set; }
        public double? Latitude { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset DateModified { get; set; }

        public override string ToString()
        {
            return $"{Street} {City} {State} {Country}";
        }
    }
}
