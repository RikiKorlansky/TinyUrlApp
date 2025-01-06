using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyUrlApp.Domain.Entities
{
    public class UrlPool
    {
        public Guid Id { get; set; }
        public string ShortUrlCode { get; set; } = null!;
        public string? LongUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsUsed { get; set; } = false;
    }
}
