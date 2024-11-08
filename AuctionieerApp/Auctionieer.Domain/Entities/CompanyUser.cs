using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionService.Domain.Entities
{
    public class CompanyUser : User
    {
        public string? CertificateOfIncorporation { get; set; }
        public string? SCUML { get; set; }
    }
}
