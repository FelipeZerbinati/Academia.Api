using Academia.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Domain.Models
{
    public class PessoaEndereco : Base
    {
        public Guid PessoaId { get; set; }

        public Guid EnderecoId { get; set; }
    }
}
