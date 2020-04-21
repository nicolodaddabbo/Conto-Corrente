using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace daddabbo._4j.conto.corrente
{
    public class Intestatario
    {
        public string Nome { get; set; } // Nome dell'intestatario
        public string Cf { get; set; } // Codice Fiscale dell'intestatario
        public string Telefono { get; set; } // Numero di telefono dell'intestatario
        public string Mail { get; set; } // Mail dell'intestatario
        public string Indirizzo { get; set; } // Indirizzo dell'intestatario
        public DateTime DataNascita { get; set; } // Data di nascita dell'intestatario
        public List<ContoCorrente> Conto { get; set; } // c/c dell'intestatario

        /// <summary>
        /// Costruttore Intestatario
        /// </summary>
        /// <param name="nome">Nome dell'intestatario</param>
        /// <param name="cf">Codice Fiscale dell'intestatario</param>
        /// <param name="telefono">Numero di telefono dell'intestatario</param>
        /// <param name="mail">Mail dell'intestatario</param>
        /// <param name="indirizzo">Indirizzo dell'intestatario</param>
        /// <param name="dataNascita">Data di nascita dell'intestatario</param>
        public Intestatario(string nome, string cf, string telefono, string mail, string indirizzo, DateTime dataNascita)
        {
            this.Nome = nome;
            this.Cf = cf;
            this.Telefono = telefono;
            this.Mail = mail;
            this.Indirizzo = indirizzo;
            this.DataNascita = dataNascita;
            Conto = new List<ContoCorrente>();
        }

        /// <summary>
        /// Assegna al cliente il conto corrente
        /// </summary>
        /// <param name="c">Conto da assegnare</param>
        public void AddConto(ContoCorrente c)
        {
            Conto.Add(c);
        }
    }
}
