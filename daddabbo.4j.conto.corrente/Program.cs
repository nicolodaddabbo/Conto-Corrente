using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace daddabbo._4j.conto.corrente
{
    class Program
    {
        static void Main(string[] args)
        {
            // CAMBIA PROPERTIES CHE NON DEVONO ESSERE PUBLIC
            // CAMBIA BONIFICO
            Console.WriteLine("\n-----------------------------------------------------------");
            Console.WriteLine("\nProgetto Conto Corrente");
            Console.WriteLine("Sviluppato da Nicolò D'Addabbo, Dennis Dong e Fabio De Luna");
            Console.WriteLine("\n-----------------------------------------------------------\n");

            /***CREAZIONE BANCA***/

            Console.Write("\nInserire nome banca: ");
            string nBanca = Console.ReadLine();

            Console.Write("\nInserire indirizzo banca: ");
            string iBanca = Console.ReadLine();

            Banca banca = new Banca(nBanca, iBanca); // Banca

            /***INSERIMENTO DATI***/

            int selezione = StampaMenu();
            while(selezione != 99)
            { 
                switch (selezione)
                {
                    case 1:
                        ModificaBanca(banca);
                        break;
                    case 2:
                        InserisciIntestatario(banca);
                        break;
                    case 3:
                        ModificaIntestatario(banca);
                        break;
                    case 4:
                        StampaMovimenti(banca);
                        break;
                    case 5:
                        EseguiBonifico(banca);
                        break;
                    case 6:
                        EseguiVersamento(banca);
                        break;
                    case 7:
                        EseguiPrelievo(banca);
                        break;
                    case 8:
                        Console.WriteLine("\n------------------------------");
                        Console.WriteLine("Elenco clienti della banca " + banca.Nome);
                        foreach(ContoCorrente _conto in banca.conti)
                        {
                            Console.WriteLine(_conto.Intestatario.Nome + " IBAN: " + _conto.Iban);
                        }
                        Console.WriteLine("------------------------------\n");
                        break;
                    case 9:
                        Console.WriteLine("Nome banca: " + banca.Nome + "\nIndirizzo banca: " + banca.Indirizzo);
                        break;
                    case 10:
                        Console.Write("Inserire IBAN del conto da verficare: ");
                        string ibanVerficare = Console.ReadLine();
                        bool ibanTrovato = false;
                        foreach (ContoCorrente c in banca.conti)
                        {
                            if(c.Iban == ibanVerficare)
                            {
                                ibanTrovato = true;
                                Console.WriteLine("\n------------------------------\n");
                                Console.WriteLine("Il saldo del conto " + ibanVerficare + " è di: " + c.getSaldo());
                                Console.WriteLine("\n------------------------------\n");
                            }
                        }
                        if (ibanTrovato == false)
                        {
                            Console.WriteLine("IBAN non trovato");
                        }
                        break;
                    case 11:
                        AddContoAggiuntivo(banca);
                        break;
                }
                selezione = StampaMenu();
            }
            Console.WriteLine("Per terminare il programma premere un qualunque tasto...");      
            Console.ReadKey();
        }

        public static int StampaMenu()
        {
            int selezione = 0;

            do
            {
                try
                {
                    Console.WriteLine("\n------------------------------");
                    Console.WriteLine("1 - Modifica info banca");
                    Console.WriteLine("2 - Inserisci intestatario");
                    Console.WriteLine("3 - Modififca intestatario");
                    Console.WriteLine("4 - Stampa movimenti");
                    Console.WriteLine("5 - Effettua bonifico");
                    Console.WriteLine("6 - Effettua versamento");
                    Console.WriteLine("7 - Effettua prelievo");
                    Console.WriteLine("8 - Stampa clienti");
                    Console.WriteLine("9 - Stampa info banca");
                    Console.WriteLine("10 - Stampa saldo conto");
                    Console.WriteLine("11 - Aggiungi nuovo conto a cliente");
                    Console.WriteLine("\n99 - Esci");
                    Console.WriteLine("------------------------------\n");
                    Console.Write("Selezione > ");
                    selezione = int.Parse(Console.ReadLine());
                    Console.WriteLine("\n");
                }
                catch
                {
                    Console.WriteLine("Errore di inserimento");
                    selezione = 0;
                }
            } while (selezione != 1 && selezione != 2 && selezione != 3 && selezione != 4 && selezione != 5 && selezione != 6 && selezione != 7 && selezione != 8 && selezione != 9 && selezione != 10 && selezione != 11 && selezione != 99);

            return selezione;
        }

        public static void ModificaBanca(Banca banca)
        {
            int selezione = 0;

            while (selezione != 1 && selezione != 2 && selezione != 99)
            {
                try
                {
                    Console.WriteLine("\n------------------------------");
                    Console.WriteLine("1 - Modifica nome");
                    Console.WriteLine("2 - Modifica indirizzo");
                    Console.WriteLine("\n99 - Indietro");
                    Console.WriteLine("------------------------------\n");
                    Console.Write("Selezione > ");
                    selezione = int.Parse(Console.ReadLine());
                    Console.WriteLine("\n");

                }
                catch
                {
                    Console.WriteLine("Errore di inserimento");
                    selezione = 0;
                }
            }

            switch (selezione)
            {
                case 1:
                    Console.Write("Inserisci nome: ");
                    banca.Nome = Console.ReadLine();
                    Console.WriteLine("Nome modificato");
                    break;
                case 2:
                    Console.Write("Inserisci indirizzo: ");
                    banca.Indirizzo = Console.ReadLine();
                    Console.WriteLine("Indirizzo modificato");
                    break;
                case 99:
                    break;
            }
        }

        public static void InserisciIntestatario(Banca banca)
        {
            Random iban_casuale = new Random();
            string nome, cf, telefono, mail, indirizzo;
            DateTime dataNascita = new DateTime();

            Console.Write("\nInserisci nome: ");
            nome = Console.ReadLine().ToString();

            Console.Write("\nInserisci codice fiscale: ");
            cf = Console.ReadLine().ToString();

            Console.Write("\nInserisci numero di telefono: ");
            telefono = Console.ReadLine().ToString();

            Console.Write("\nInserisci mail: ");
            mail = Console.ReadLine().ToString();

            Console.Write("\nInserisci indirizzo: ");
            indirizzo = Console.ReadLine().ToString();

            bool errore = true;
            while (errore == true)
            {
                try
                {
                    string[] data;

                    Console.Write("\nInserisci data di nascita (anno/mese/giorno): ");
                    data = Console.ReadLine().ToString().Split('/');

                    dataNascita = new DateTime(int.Parse(data[0]), int.Parse(data[1]), int.Parse(data[2]));
                    errore = false;     
                }
                catch
                {
                    errore = true;
                    Console.WriteLine("Errore nell'inserimento dei dati");
                }
            }

            Intestatario intestatario = new Intestatario(nome, cf, telefono, mail, indirizzo, dataNascita);
            Console.WriteLine("[*] Intestatario inserito correttamente...");
            banca.AddCliente(intestatario);

            int movimentiGratis = -1;
            do
            {
                try
                {
                    Console.Write("\nInserire numero massimo di movimenti gratuiti: ");
                    movimentiGratis = int.Parse(Console.ReadLine());
                    if(movimentiGratis < 0)
                    {
                        Console.WriteLine("Inserire un numero positivo");
                    }
                }
                catch
                {
                    Console.WriteLine("Errore nell'inserimento dei dati");
                    movimentiGratis = -1;
                }
            } while (movimentiGratis < 0);

            double aggiuntivoMovimenti = -1;
            do
            {
                try
                {
                    Console.Write("\nInserire valore da aggiungere in caso si superino i movimenti gratuiti: ");
                    aggiuntivoMovimenti = double.Parse(Console.ReadLine());
                    if (aggiuntivoMovimenti < 0)
                    {
                        Console.WriteLine("Inserire un numero positivo");
                    }
                }
                catch
                {
                    Console.WriteLine("Errore nell'inserimento dei dati");
                    aggiuntivoMovimenti = -1;
                }
            } while (movimentiGratis < 0);

            string risp;
            do
            {
                Console.Write("Vuoi creare un conto online? (si/no) ");
                risp = Console.ReadLine().ToLower();

                if(risp == "si" || risp == "sì")
                {
                    double maxPrelievo = -1;

                    do
                    {
                        Console.Write("Inserire cifra massima prelevabile: ");
                        maxPrelievo = double.Parse(Console.ReadLine());
                        if(maxPrelievo < 0)
                        {
                            Console.WriteLine("Inserire un valore positivo");
                        }
                    } while (maxPrelievo < 0);
                    
                    Console.WriteLine("[+] Creazione conto online...");
                    ContoCorrente contoOnline = new ContoOnLine(intestatario, movimentiGratis, "IT39" + iban_casuale.Next(10000, 1000000), banca, maxPrelievo, aggiuntivoMovimenti);
                    Console.WriteLine("[*] Conto corrente creato con numero massimo di movimenti pari a 100, un prelievo massimo di 2500 e con iban: " + contoOnline.Iban + "\n\n");
                } else if (risp == "no")
                {
                    Console.WriteLine("[+] Creazione del conto...");

                    ContoCorrente conto = new ContoCorrente(intestatario, movimentiGratis, "IT39" + iban_casuale.Next(10000, 1000000), banca, aggiuntivoMovimenti);
                    banca.AddConto(conto);

                    Console.WriteLine("[*] Conto corrente creato con numero massimo di movimenti pari a 100 e con iban: " + conto.Iban + "\n\n");
                }
                else
                {
                    Console.WriteLine("\nErrore, valore inserito non valido\n");
                }
                
            } while (risp != "si" && risp != "sì" && risp != "no");
           
        }

        public static void ModificaIntestatario(Banca banca)
        {
            string iban = "", nome, cf, telefono, mail, indirizzo;
            DateTime dataNascita = new DateTime();
            Intestatario intestatario = new Intestatario("", "", "", "", "", DateTime.Now);

            Console.WriteLine("Inserisci IBAN del cliente da modificare: ");
            string ibanIntestatario = Console.ReadLine();

            foreach(ContoCorrente i in banca.conti)
            {
                if (i.Iban == ibanIntestatario)
                {
                    iban = i.Iban;
                    intestatario = i.Intestatario;
                }
            }

            if(iban == "")
            {
                Console.WriteLine("Il cliente non è presente");
            }
            else
            {
                Console.WriteLine("[+] Inserire dati cliente...\n");
                Console.Write("\nInserisci nome: ");
                nome = Console.ReadLine();

                Console.Write("\nInserisci codice fiscale: ");
                cf = Console.ReadLine();

                Console.Write("\nInserisci numero di telefono: ");
                telefono = Console.ReadLine();

                Console.WriteLine("\nInserisci mail: ");
                mail = Console.ReadLine();

                Console.Write("\nInserisci indirizzo: ");
                indirizzo = Console.ReadLine();

                bool errore = true;
                while (errore == true)
                {
                    try
                    {
                        string[] data;

                        Console.Write("\nInserisci data di nascita (anno/mese/giorno): ");
                        data = Console.ReadLine().ToString().Split('/');

                        dataNascita = new DateTime(int.Parse(data[0]), int.Parse(data[1]), int.Parse(data[2]));
                        errore = false;
                    }
                    catch
                    {
                        errore = true;
                        Console.WriteLine("Errore nell'inserimento dei dati");
                    }
                }

                intestatario.Nome = nome;
                intestatario.Cf = cf;
                intestatario.Indirizzo = indirizzo;
                intestatario.Mail = mail;
                intestatario.Telefono = telefono;
                intestatario.DataNascita = dataNascita;
            }
            Console.WriteLine("[*] Intestatario modificato correttamente");
        }

        public static void StampaMovimenti(Banca banca)
        {
            int selezione = 0;

            while(selezione != 99)
            {
                do
                {
                    try
                    {
                        Console.WriteLine("\n------------------------------");
                        Console.WriteLine("1 - Stampa movimenti di un dato giorno");
                        Console.WriteLine("2 - Stampa movimenti di un dato cliente");
                        Console.WriteLine("3 - Stampa movimenti di un dato cliente in un dato giorno");
                        Console.WriteLine("\n99 - Indietro");
                        Console.WriteLine("------------------------------\n");
                        Console.Write("Selezione > ");
                        selezione = int.Parse(Console.ReadLine());
                        if (selezione != 1 && selezione != 2 && selezione != 3 && selezione != 99)
                        {
                            Console.WriteLine("Errore nell'inserimento dei dati");
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Errore nell'inserimento dei dati");
                        selezione = 0;
                    }
                    
                } while (selezione != 1 && selezione != 2 && selezione != 3 && selezione != 99);

                switch (selezione)
                {
                    case 1:
                        DateTime data = new DateTime();
                        bool errore = true;
                        while (errore == true)
                        {
                            try
                            {
                                string[] sdata;

                                Console.Write("\nInserisci data (anno/mese/giorno): ");
                                sdata = Console.ReadLine().ToString().Split('/');

                                data = new DateTime(int.Parse(sdata[0]), int.Parse(sdata[1]), int.Parse(sdata[2]));
                                errore = false;
                            }
                            catch
                            {
                                errore = true;
                                Console.WriteLine("Errore nell'inserimento dei dati");
                            }
                        }

                        Console.WriteLine(banca.GetMovimento(data));
                        break;

                    case 2:
                        string iban;
                        bool trovato = false;
                        Console.WriteLine("Inserire IBAN del cliente da cercare: ");
                        iban = Console.ReadLine();
                        Intestatario intestatario = new Intestatario("", "", "", "", "", DateTime.Now);
                        foreach(ContoCorrente i in banca.conti)
                        {
                            if(i.Iban == iban)
                            {
                                intestatario = i.Intestatario;
                                trovato = true;
                            }
                        }

                        if (trovato)
                        {
                            Console.WriteLine(banca.GetMovimento(intestatario));
                        }
                        else
                        {
                            Console.WriteLine("Cliente non trovato");
                        }
                        break;

                    case 3:
                        DateTime data2 = new DateTime();
                        bool errore2 = true;
                        while (errore2 == true)
                        {
                            try
                            {
                                string[] sdata;

                                Console.Write("\nInserisci data (anno/mese/giorno): ");
                                sdata = Console.ReadLine().ToString().Split('/');

                                data = new DateTime(int.Parse(sdata[0]), int.Parse(sdata[1]), int.Parse(sdata[2]));
                                errore = false;
                            }
                            catch
                            {
                                errore = true;
                                Console.WriteLine("Errore nell'inserimento dei dati");
                            }
                        }

                        string iban2;
                        bool trovato2 = false;
                        Console.WriteLine("Inserire IBAN del cliente da cercare: ");
                        iban2 = Console.ReadLine();
                        Intestatario intestatario2 = new Intestatario("", "", "", "", "", DateTime.Now);
                        foreach (ContoCorrente i in banca.conti)
                        {
                            if (i.Iban == iban2)
                            {
                                intestatario2 = i.Intestatario;
                                trovato2 = true;
                            }
                        }

                        if (trovato2)
                        {
                            Console.WriteLine(banca.GetMovimento(data2, intestatario2));
                        }
                        else
                        {
                            Console.WriteLine("Cliente non trovato");
                        }
                        break;
                }
            }
        }

        public static void EseguiBonifico(Banca banca)
        {
            bool trovato = false;
            Console.Write("\nInserire IBAN mittente: ");
            string ibanMittente = Console.ReadLine();
                 
            foreach(ContoCorrente c in banca.conti)
            {
                if (c.Iban == ibanMittente)
                {
                    trovato = true;
                }
            }

            if (trovato)
            {
                trovato = false;
                Console.Write("\nInserire IBAN destinatario: ");
                string ibanDestinatario = Console.ReadLine().ToString();
                string risBonifico;
                foreach (ContoCorrente c in banca.conti)
                {
                    if (c.Iban == ibanDestinatario)
                    {
                        trovato = true;
                    }
                }
                if (trovato)
                {
                    Bonifico bonifico = new Bonifico(banca, ibanMittente, ibanDestinatario);
                    double importo = 0;
                    do
                    {
                        Console.Write("\nInserire importo bonifico: ");
                        importo = double.Parse(Console.ReadLine().ToString());
                    } while (importo < 0);

                    risBonifico = bonifico.EffettuaBonifico(importo);

                    if(risBonifico == "Bonifico effettuato con successo")
                    {
                        Console.WriteLine("Bonifico dal valore di " + importo + " euro effettuato all'ora " + DateTime.Now);
                    }
                    else
                    {
                        Console.WriteLine("Errore il tuo saldo è minore del prelievo richiesto");
                    }
                    
                }
                else
                {
                    Console.WriteLine("IBAN destinatario non trovato");
                    Console.Write("\nVuoi Creare un nuovo conto corrente? (si/no) ");
                    string risp = Console.ReadLine().ToLower();

                    if(risp == "si" || risp == "sì")
                    {
                        InserisciIntestatario(banca);
                    }
                }
            }
            else
            {
                Console.WriteLine("IBAN mittente non trovato");
                Console.Write("\nVuoi Creare un nuovo conto corrente? (si/no) ");
                string risp = Console.ReadLine().ToLower();

                if (risp == "si" || risp == "sì")
                {
                    InserisciIntestatario(banca);
                }
            }

        }

        public static void EseguiVersamento(Banca banca)
        {
            Console.Write("Inserire IBAN conto: ");
            string iban = Console.ReadLine();

            ContoCorrente conto = banca.getConto(iban);

            Console.Write("Inserire importo versamento: ");
            double importo = double.Parse(Console.ReadLine());

            conto.Versamento(importo);
            Console.WriteLine("Versamento di " + importo + " euro effettuato");
        }

        public static void EseguiPrelievo(Banca banca)
        {
            Console.Write("Inserire IBAN conto: ");
            string iban = Console.ReadLine();

            ContoCorrente conto = banca.getConto(iban);

            Console.Write("Inserire importo prelievo: ");
            double importo = double.Parse(Console.ReadLine());

            string risultatoPrelievo = conto.Preleva(importo);

            if (risultatoPrelievo != "Hai prelevato con successo")
            {
                Console.WriteLine("Errore il tuo saldo è minore del prelievo richiesto");
            }
            else
            {
                Console.WriteLine("Prelievo di " + importo + " euro effettuato");
            }   
        }

        public static void AddContoAggiuntivo(Banca banca)
        {
            bool trovato = false;
            Random iban_casuale = new Random();
            Console.Write("\nInserire codice fiscale cliente: ");
            Intestatario cliente = new Intestatario("", "", "", "", "", DateTime.Now);
            string cf = Console.ReadLine();

            foreach (Intestatario c in banca.clienti)
            {
                if (c.Cf == cf)
                {
                    trovato = true;
                    cliente = c;
                }
            }

            if (trovato)
            {
                string risposta = "";
                do
                {
                    Console.WriteLine("Vuoi aggiungere un conto online? (si/no)");
                    risposta = Console.ReadLine().ToLower();
                    if (risposta != "si" && risposta != "sì" && risposta != "no")
                    {
                        Console.WriteLine("Errore nell'inserimento dati");
                    }
                } while (risposta != "si" && risposta != "sì" && risposta != "no");

                int movimentiGratis = -1;
                do
                {
                    try
                    {
                        Console.Write("\nInserire numero massimo di movimenti gratuiti: ");
                        movimentiGratis = int.Parse(Console.ReadLine());
                        if (movimentiGratis < 0)
                        {
                            Console.WriteLine("Inserire un numero positivo");
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Errore nell'inserimento dei dati");
                        movimentiGratis = -1;
                    }
                } while (movimentiGratis < 0);

                double aggiuntivoMovimenti = -1;
                do
                {
                    try
                    {
                        Console.Write("\nInserire valore da aggiungere in caso si superino i movimenti gratuiti: ");
                        aggiuntivoMovimenti = double.Parse(Console.ReadLine());
                        if (aggiuntivoMovimenti < 0)
                        {
                            Console.WriteLine("Inserire un numero positivo");
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Errore nell'inserimento dei dati");
                        aggiuntivoMovimenti = -1;
                    }
                } while (movimentiGratis < 0);

                if (risposta == "no")
                {
                    Console.WriteLine("Creazione del conto...");
                    ContoCorrente conto = new ContoCorrente(cliente, movimentiGratis, "IT39" + iban_casuale.Next(10000, 1000000), banca, aggiuntivoMovimenti);
                    banca.AddConto(conto);
                    cliente.AddConto(conto);

                    Console.WriteLine("Conto corrente creato con numero massimo di movimenti pari a 100 e con iban: " + conto.Iban + "\n\n");
                } else
                {
                    double maxPrelievo = -1;

                    do
                    {
                        Console.Write("Inserire cifra massima prelevabile: ");
                        maxPrelievo = double.Parse(Console.ReadLine());
                        if (maxPrelievo < 0)
                        {
                            Console.WriteLine("Inserire un valore positivo");
                        }
                    } while (maxPrelievo < 0);
                    Console.WriteLine("Creazione conto online...");
                    ContoCorrente contoOnline = new ContoOnLine(cliente, movimentiGratis, "IT39" + iban_casuale.Next(10000, 1000000), banca, maxPrelievo, aggiuntivoMovimenti);
                    Console.WriteLine("Conto corrente creato con numero massimo di movimenti pari a 100, un prelievo massimo di 2500 e con iban: " + contoOnline.Iban + "\n\n");
                }
            }
            else
            {
                string risposta = "";
                do
                {
                    Console.WriteLine("Cliente non trovato, vuoi inserirlo? (si/no)");
                    risposta = Console.ReadLine().ToLower();
                } while (risposta != "si" && risposta != "sì" || risposta != "no");
                
                if(risposta != "no")
                {
                    InserisciIntestatario(banca);
                }
            }
        }
    }
}