using Academia.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Domain.Models
{
    public class Pessoa : Base
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public ICollection<PessoaEndereco> PessoasEnderecos { get; set; } = new List<PessoaEndereco>();
    }
}
