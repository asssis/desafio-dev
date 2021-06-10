using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace desafio_dev.Models
{
    public class Cnab{
        public int Id { get; set; }
        public Transacao Transacao { get; set; }
        public int TransacaoId { get; set; }
        public int Tipo { get; set;} 
        public double Valor { get; set; }
        public string Cpf { get; set; }
        public string Cartao { get; set; } 
        public string DonoLoja { get; set; }
        public string NomeLoja { get; set; }

        public DateTime DataHora { get; set; }
        public void setDateTime(string data, string hora)
        {   
            DateTime tete = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now);
            DateTime datahora = DateTime.ParseExact( $"{data}:{hora}", "yyyyMMdd:HHmmss", System.Globalization.CultureInfo.InvariantCulture);
            this.DataHora = TimeZoneInfo.ConvertTimeToUtc(datahora);
        }
        public String Hora  
        {
            get { return this.DataHora.AddHours(-3).ToString("dd/MM/yyyy"); }    
        } 
        public String Data
        {
            get { return (this.DataHora.AddHours(-3).ToString("HH:mm:ss")); }    
        } 
        public String TipoTransacao{
            get 
            {
                switch (this.Tipo)
                {
                    case 1:
                        return "Débito	Entrada	+";
                    case 2:
                        return "Boleto	Saída	-"; 
                    case 3:
                        return "Financiamento	Saída	-"; 
                    case 4:
                        return "Crédito	Entrada	+"; 
                    case 5:
                        return "Recebimento Empréstimo	Entrada	+"; 
                    case 6:
                        return "Vendas	Entrada	+"; 
                    case 7:
                        return "Recebimento TED	Entrada	+"; 
                    case 8:
                        return "Recebimento DOC	Entrada	+"; 
                    case 9:
                        return "Aluguel"; 
                    default:
                        return "";
                }
            }
        }
    }
}