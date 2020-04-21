using System;
using System.Collections.Generic;

namespace daddabbo._4j.conto.corrente
{
    /// <summary>
    /// Classe Banca
    /// </summary>
    public class Banca
    {
        public string Nome { get; set; } // Nome banca
        public string Indirizzo { get; set; } // Indirizzo banca
        public List<ContoCorrente> conti { get; set; } // Lista di conti corrente
        public List<Intestatario> clienti { get; set; } // Lista di clienti
        List<Movimento> movimenti_effettuati; // Lista di movimenti effettuati

        /// <summary>
        /// Costruttore banca
        /// </summary>
        /// <param name="nome">Nome banca</param>
        /// <param name="indirizzo">Indirizzo banca</param>
        public Banca(string nome, string indirizzo)
        {
            conti = new List<ContoCorrente>();
            clienti = new List<Intestatario>();
            movimenti_effettuati = new List<Movimento>();
            this.Nome = nome;
            this.Indirizzo = indirizzo;
        }

        /// <summary>
        /// Aggiunge alla lista dei c/c della banca il conto c
        /// </summary>
        /// <param name="c">Conto da aggiungere</param>
        public void AddConto(ContoCorrente c)
        {
            conti.Add(c);
        }

        /// <summary>
        /// Aggiunge alla lista dei clienti della banca il cliente i
        /// </summary>
        /// <param name="i">Cliente da aggiungere</param>
        public void AddCliente(Intestatario i)
        {
            clienti.Add(i);
        }

        /// <summary>
        /// Individua un c/c dato un iban
        /// </summary>
        /// <param name="iban">Iban conto da cercare</param>
        /// <returns>Conto corrente con l'iban indicato come parametro se non lo trova
        /// restituisce un conto con iban uguale a 0</returns>
        public ContoCorrente getConto(string iban)
        {
            foreach (ContoCorrente c in conti)
            {
                if(c.Iban == iban)
                {
                    return c;
                }
            }
            return new ContoCorrente(new Intestatario("Errore", "Errore", "Errore", "Errore", "Errore", DateTime.Now), 0, "0", new Banca("Errore","Errore"));
        }

        /// <summary>
        /// Dato un intestatario e una data ritorna i movimenti effettuati da quel cliente in quel giorno
        /// </summary>
        /// <param name="data">Data del movimento</param>
        /// <param name="intestatario">Intestatario del movimento</param>
        /// <returns>Ritorna i movimenti effettuati da un dato cliente in un dato giorno</returns>
        public string GetMovimento(DateTime data, Intestatario intestatario)
        {
            string risultato = "";

            foreach (Movimento m in movimenti_effettuati)
            {
                if (m.intestatario == intestatario && m.DataOraMovimento == data)
                {
                    risultato = risultato + "\n------------------------------";
                    risultato = risultato + "\nIntestatario: " + m.intestatario.Nome + "\nData e ora movimento: " + m.DataOraMovimento + "\nImporto movimento: " + m.importo + " euro" + "\nTipo movimento: " + m.tipoMovimento;
                    risultato = risultato + "\n------------------------------";
                }
            }

            if (risultato == "")
            {
                return "Nessuna transazione presente per quel giorno";
            }
            else
            {
                return risultato;
            }
        }

        /// <summary>
        /// Ritorna tutti i movimenti effettuati in un dato giorno
        /// </summary>
        /// <param name="data">Data dei movimenti</param>
        /// <returns>Ritorna i movimenti di un dato giorno</returns>
        public string GetMovimento(DateTime data)
        {
            string risultato = "";

            foreach (Movimento m in movimenti_effettuati)
            {
                if (m.DataOraMovimento.Date == data)
                {
                    risultato = risultato + "\n------------------------------";
                    risultato = risultato + "\nIntestatario: " + m.intestatario.Nome + "\nData e ora movimento: " + m.DataOraMovimento + "\nImporto movimento: " + m.importo + " euro" + "\nTipo movimento: " + m.tipoMovimento;
                    risultato = risultato + "\n------------------------------";
                }
            }

            if (risultato == "")
            {
                return "Nessuna transazione presente per quel giorno";
            }
            else
            {
                return risultato;
            }
        }

        /// <summary>
        /// Ritorna tutti i movimenti di un intestatario
        /// </summary>
        /// <param name="intestatario">Intestatario da cercare</param>
        /// <returns>Ritorna tutti i movimenti di un intestatario</returns>
        public string GetMovimento(Intestatario intestatario)
        {
            string risultato = "";

            foreach (Movimento m in movimenti_effettuati)
            {
                if (m.intestatario == intestatario)
                {
                    risultato = risultato + "\n------------------------------";
                    risultato = risultato + "\nIntestatario: " + m.intestatario.Nome + "\nData e ora movimento: " + m.DataOraMovimento + "\nImporto movimento: " + m.importo + " euro" + "\nTipo movimento: " + m.tipoMovimento;
                    risultato = risultato + "\n------------------------------";
                }
            }

            if (risultato == "")
            {
                return "Nessuna transazione effettuata da quell'intestatario";
            }
            else
            {
                return risultato;
            }
        }

        public void AddMovimento(Movimento m)
        {
            movimenti_effettuati.Add(m);
        }
    }
}
