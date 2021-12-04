using Microsoft.AspNetCore.Identity;
using System;

namespace KutuphaneOtomasyonu.Models
{
    public class AppRole : IdentityRole<Guid>
    {
        public DateTime OlusturulmaTarihi { get; set; }
    }
}
