using Academia.Domain.Entity;

namespace Academia.Domain.Models
{
    public class Academia : Base
    {
        public string Nome { get; set; }
        public string AnoFundacao { get; set; }
        public AcademiaAparelho AcademiaAparelho { get; set; }

    }
}
