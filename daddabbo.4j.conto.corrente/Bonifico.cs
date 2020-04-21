using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace daddabbo._4j.conto.corrente
{
    public class Bonifico
    {
        Banca banca;
        string iban_mittente;
        string iban_destinatario;
        ContoCorrente conto_mittente;
        ContoCorrente conto_destinatario;
        DateTime dataTransazione;

        /// <summary>
        /// Costruttore Bonifico
        /// </summary>
        /// <param name="iban_mittente">Iban del mittente del bonifico</param>
        /// <param name="iban_destinatario">Iban del destinatario del bonifico</param>
        public Bonifico(Banca banca, string iban_mittente, string iban_destinatario)
        {
            this.banca = banca;
            this.iban_mittente = iban_mittente;
            this.iban_destinatario = iban_destinatario;
        }

        public void EffettuaBonifico(double importo)
        {
            /* Ottieni i 2 conti corrente dalla banca e sottrai saldo al mittente e 
             * aggiungi al destinatario l'importo */

            conto_mittente = banca.getConto(iban_mittente);
            conto_destinatario = banca.getConto(iban_destinatario);

            conto_mittente.Preleva(importo);
            conto_destinatario.IncrementaSaldo(importo);
            conto_destinatario.DecrementaMovimenti();
            dataTransazione = DateTime.Now;
        }
    }
}