using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace desafio_ruby_on_rails.Models
{
    public class Cnab{
        public int Id { get; set; }
        public Transacao Transacao { get; set; }
          public int TransacaoId { get; set; }
        public int Tipo { get; set;}
        public string Data { get; set; }
        public double Valor { get; set; }
        public string Cpf { get; set; }
        public string Cartao { get; set; } 
        public string Hora { get; set; }
        public string DonoLoja { get; set; }
        public string NomeLoja { get; set; } 
    }
}