using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionService.Domain.Entities
{
    public class AuditTrail : BaseEntity, IAuditable
    {
        public string IPAdress { get; set; }
        public string MachineName { get; set; }
        public string Email { get; set; }
        public string Action { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset DateModified { get; set; }
    }
}
