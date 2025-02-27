using Academia.Domain.Entity;

namespace Academia.Domain.Models
{
    public class Academia : Base
    {
        public string Name { get; set; }
        public ICollection<Aparelho>? Aparelhos { get; set; }
    }
}
