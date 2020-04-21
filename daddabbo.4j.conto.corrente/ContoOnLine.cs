namespace daddabbo._4j.conto.corrente
{
    public class ContoOnLine : ContoCorrente
    {
        double maxPrelievo; // Cifra massima che si può prelevare

        /// <summary>
        /// Costruttore del c/c online
        /// </summary>
        /// <param name="intestatario">Intestatario del conto</param>
        /// <param name="maxMovimenti">Numero massimo di movimenti gratuiti</param>
        /// <param name="iban">Iban del conto</param>
        /// <param name="maxPrelievo">Cifra massima prelevabile</param>
        public ContoOnLine(Intestatario intestatario, int maxMovimenti, string iban, Banca banca, double maxPrelievo) : base(intestatario, maxMovimenti, iban, banca)
        {
            this.maxPrelievo = maxPrelievo;
        }

        /// <summary>
        /// Metodo che controlla controlla se maxPrelievo 
        /// viene rispettato, e in tal caso richiama il
        /// metodo Prelievo della superclasse
        /// </summary>
        /// <param name="x">Importo del prelievo</param>
        public new void Preleva(double x)
        {
            /* se il parametro indicante la cifra da prelevare
             * è minore dell’attributo maxPrelievo 
             * richiama il metodo preleva della superclasse
             * altrimenti non fa nulla */
            
            if(x < maxPrelievo)
            {
                Preleva(x);
            }
        }
    }
}
