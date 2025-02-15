using Academia.Domain.Entity;
using System.ComponentModel.DataAnnotations;

namespace Academia.Domain.Models;

public class Aparelho : Base
{
    
    public string NomeAparelho { get; set; }
    public string DescricaoAparelho { get; set; }
    AcademiaAparelho AcademiaAparelho { get; set; }
}
