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

        public string EffettuaBonifico(double importo)
        {
            /* Ottieni i 2 conti corrente dalla banca e sottrai saldo al mittente e 
             * aggiungi al destinatario l'importo */
            string mittente;

            conto_mittente = banca.getConto(iban_mittente);
            conto_destinatario = banca.getConto(iban_destinatario);

            mittente = conto_mittente.Preleva(importo);
            if (mittente == "Hai prelevato con successo")
            {
                conto_destinatario.Bonifico(importo);
                dataTransazione = DateTime.Now;
                Movimento movimentoDest = new Movimento(DateTime.Now, "bonifico ricevuto", importo, conto_destinatario.Intestatario);
                Movimento movimentoMitt = new Movimento(DateTime.Now, "bonifico effettuato", importo, conto_mittente.Intestatario);
                banca.AddMovimento(movimentoDest);
                banca.AddMovimento(movimentoMitt);
                return "Bonifico effettuato con successo";
            } else
            {
                return "Il saldo del mittente è minore dell'importo";
            }
           
        }
    }
}