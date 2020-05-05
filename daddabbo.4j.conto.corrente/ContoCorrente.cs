using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace daddabbo._4j.conto.corrente
{
    /// <summary>
    /// Classe Conto Corrente.
    /// </summary>
    public class ContoCorrente
    {
        public Intestatario Intestatario { get; } // Intestatario del conto
        protected int NMovimenti;// Numero movimenti effettuati
        protected int maxMovimenti; // Numero massimo di movimenti gratuiti
        protected double saldo; // Soldi depositati sul conto
        private double aggiuntivoMovimento;
        public string Iban { get; set; } // IBAN del conto corrente
        public Banca Banca { get; set; }

        /// <summary>
        /// Costruttore c/c
        /// </summary>
        /// <param name="intestatario">Intestatario del conto</param>
        /// <param name="maxMovimenti">Numero massimo di movimenti gratuiti</param>
        /// <param name="iban">IBAN del conto corrente</param>
        public ContoCorrente(Intestatario intestatario, int maxMovimenti, string iban, Banca banca, double aggiuntivoMovimento)
        {
            this.Intestatario = intestatario;
            this.maxMovimenti = maxMovimenti;
            this.Iban = iban;
            saldo = 0;
            this.Banca = banca;
            this.aggiuntivoMovimento = aggiuntivoMovimento;
        }

        /// <summary>
        /// Metodo per prelevare dal conto corrente
        /// </summary>
        /// <param name="x">Importo del prelievo</param>
        public string Preleva(double x)        
        {
            /* se il valore di nMovimenti è minore di maxMovimenti,
             * assegna a saldo il valore di saldo meno il parametro x
             * altrimenti assegna a saldo il valore di
             * saldo meno il parametro x e meno 0,50,
             * infine il metodo incrementa di uno
             * il numero di movimenti ossia l’attributo nMovimenti */

            if (x > saldo)
            {
                return "Errore il tuo saldo è minore del prelievo richiesto";
            }
            else
            {
                if (NMovimenti < maxMovimenti)
                {
                    saldo = saldo - x;
                    Movimento movimento = new Movimento(DateTime.Now, "prelievo", x, Intestatario);
                    Banca.AddMovimento(movimento);
                    NMovimenti++;
                    return "Hai prelevato con successo";
                }
                else
                {
                    saldo = saldo - x - 0.50;
                    Movimento movimento = new Movimento(DateTime.Now, "prelievo", x - 0.50, Intestatario);
                    Banca.AddMovimento(movimento);
                    NMovimenti++;
                    return "Hai prelevato con successo";
                }    
            }
        }

        /// <summary>
        /// Metodo per incrementare il saldo di x
        /// </summary>
        /// <param name="x">Importo da versare</param>
        public void Versamento(double x)
        {
            // Versamento
            saldo = saldo + x;
            NMovimenti++;
            Movimento movimento = new Movimento(DateTime.Now, "versamento", x, Intestatario);
            Banca.AddMovimento(movimento);
        }

        /// <summary>
        /// Incrementa il saldo in seguito a un bonifico
        /// </summary>
        /// <param name="x">Importo del bonifico</param>
        public void Bonifico(double x)
        {
            saldo = saldo + x;
        }

        public double getSaldo()
        {
            return saldo;
        }
    }
}
