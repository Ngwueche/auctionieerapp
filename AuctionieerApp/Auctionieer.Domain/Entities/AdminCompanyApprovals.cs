using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionService.Domain.Entities
{
    public class AdminCompanyApprovals : BaseEntity, IAuditable
    {
        public ICollection<CompanyUser> CompanyUsers { get; set; }
        public ICollection<AdminUser> AdminUsers { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset DateModified { get; set; }
    }
}
