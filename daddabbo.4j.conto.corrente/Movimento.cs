using System;

namespace daddabbo._4j.conto.corrente
{
    public class Movimento
    {
        public DateTime DataOraMovimento { get; } // Data e ora del movimento effettuato
        public string tipoMovimento { get; } // Tipo di movimento effettuato (prelievo o versamento)
        public double importo { get; } // Importo del movimento
        public Intestatario intestatario { get; } // Intestatario del movimento

        /// <summary>
        /// Costruttore Movimento
        /// </summary>
        /// <param name="DataOraMovimento">Data e ora del movimento effettuato</param>
        /// <param name="tipoMovimento">Tipo di movimento effettuato (prelievo o versamento)</param>
        /// <param name="importo">Importo del movimento</param>
        /// <param name="intestatario">Intestatario del movimento</param>
        public Movimento(DateTime DataOraMovimento, string tipoMovimento, double importo, Intestatario intestatario)
        {
            this.DataOraMovimento = DataOraMovimento;
            this.tipoMovimento = tipoMovimento;
            this.importo = importo;
            this.intestatario = intestatario;
        }
    }
}
