using Academia.Domain.Entity;

namespace Academia.Domain.Models;

public class Aparelho : Base
{
    public string Name { get; set; }
    public Academia? Academia { get; set; }
}
