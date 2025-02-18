using U4_S2_D2.Models;

namespace U4_S2_D2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\r\n============ CV PERSONALE ============");
            Console.WriteLine("\r\nInserire i propri dati personali:");
            Console.WriteLine("\r\nNome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("\r\nCognome: ");
            string cognome = Console.ReadLine();
            Console.WriteLine("\r\nTelefono: ");
            string telefono = Console.ReadLine();
            Console.WriteLine("\r\nEmail: ");
            string email = Console.ReadLine();
            while (!IsValidEmail(email))
            {
                Console.WriteLine("Email non valida. Riprovare: ");
                email = Console.ReadLine();
            }

            static bool IsValidEmail(string email)
            {
                try
                {
                    var addr = new System.Net.Mail.MailAddress(email);
                    return addr.Address == email;
                }
                catch
                {
                    return false;
                }
            }

            InformazioniPersonali informazioni = new InformazioniPersonali
            {
                Nome = nome,
                Cognome = cognome,
                Telefono = telefono,
                Email = email
            };

            List<Studi> listaStudi = new List<Studi>();

        StartStudi:
            Console.WriteLine("\r\nInserire le informazioni relative agli studi:");
            Console.WriteLine("\r\nQualifica: ");
            string qualifica = Console.ReadLine();
            Console.WriteLine("\r\nIstituto: ");
            string istituto = Console.ReadLine();
            Console.WriteLine("\r\nTipo: ");
            string tipo = Console.ReadLine();
            Console.WriteLine("\r\nData di inizio: ");
            DateTime dataInizio;
            while (!DateTime.TryParse(Console.ReadLine(), out dataInizio))
            {
                Console.WriteLine("Data non valida. Riprovare: ");
            }
            Console.WriteLine("\r\nData di fine: ");
            DateTime dataFine;
            while (!DateTime.TryParse(Console.ReadLine(), out dataFine))
            {
                Console.WriteLine("Data non valida. Riprovare: ");
            }

            Studi studi = new Studi
            {
                Qualifica = qualifica,
                Istituto = istituto,
                Tipo = tipo,
                DataInizio = dataInizio,
                DataFine = dataFine
            };

            listaStudi.Add(studi);

        ContinuareStudi:
            Console.WriteLine("Altri studi da inserire? (s/n)");
            string risposta = Console.ReadLine();
            if (risposta == "s")
            {
                goto StartStudi;
            }
            else if (risposta != "s" && risposta != "n")
            {
                Console.WriteLine("Risposta non valida. Riprovare.");
                goto ContinuareStudi;
            }

            List<Impiego> listaImpieghi = new List<Impiego>();

        StartEsperienze:
            Console.WriteLine("\r\nInserire le informazioni relative alle esperienze lavorative:");
            Console.WriteLine("\r\nAzienda: ");
            string azienda = Console.ReadLine();
            Console.WriteLine("\r\nJobTitle: ");
            string jobTitle = Console.ReadLine();
            Console.WriteLine("\r\nData di inizio: ");
            DateTime dataInizioLavoro;
            while (!DateTime.TryParse(Console.ReadLine(), out dataInizioLavoro))
            {
                Console.WriteLine("Data non valida. Riprovare: ");
            }
            Console.WriteLine("\r\nData di fine: ");
            DateTime dataFineLavoro;
            while (!DateTime.TryParse(Console.ReadLine(), out dataFineLavoro))
            {
                Console.WriteLine("Data non valida. Riprovare: ");
            }
            Console.WriteLine("\r\nDescrizione: ");
            string descrizione = Console.ReadLine();
            Console.WriteLine("\r\nCompiti: ");
            string compiti = Console.ReadLine();

            Esperienza esperienza = new Esperienza
            {
                Azienda = azienda,
                JobTitle = jobTitle,
                DataInizio = dataInizioLavoro,
                DataFine = dataFineLavoro,
                Descrizione = descrizione,
                Compiti = compiti
            };


            Impiego impiego = new Impiego
            {
                Esperienza = esperienza
            };

            listaImpieghi.Add(impiego);

        ContinuareEsperienze:
            Console.WriteLine("Altre esperienze lavorative da inserire? (s/n)");
            string risposta2 = Console.ReadLine();
            if (risposta2 == "s")
            {
                goto StartEsperienze;
            }
            else if (risposta2 != "s" && risposta2 != "n")
            {
                Console.WriteLine("Risposta non valida. Riprovare.");
                goto ContinuareEsperienze;
            }
            Console.WriteLine("\r\nPremere un tasto per proseguire e visualizzare il proprio CV compilato");
            Console.WriteLine($"CV di {nome} {cognome}");
            Console.WriteLine("\r\n++++ INIZIO Informazioni Personali ++++" +
                $"\r\n\r\nNome: {informazioni.Nome}" +
                $"\r\nCognome: {informazioni.Cognome}" +
                $"\r\nTelefono: {informazioni.Telefono}" +
                $"\r\nEmail: {informazioni.Email}" +
                "\r\n\r\n++++ FINE Informazioni Personali ++++");
            Console.WriteLine("\r\n++++ INIZIO Studi e Formazione++++");
            foreach (var item in listaStudi)
            {
                Console.WriteLine($"\r\nQualifica: {item.Qualifica}" +
                    $"\r\nIstituto: {item.Istituto}" +
                    $"\r\nTipo: {item.Tipo}" +
                    $"\r\nData di inizio: {item.DataInizio:MM/yyyy}" +
                    $"\r\nData di fine: {item.DataFine:MM/yyyy}");
            }
            Console.WriteLine("\r\n++++ FINE Studi e Formazione ++++");
            Console.WriteLine("\r\n++++ INIZIO Esperienze professionali ++++");
            foreach (var item in listaImpieghi)
            {
                Console.WriteLine($"\r\nAzienda: {item.Esperienza.Azienda}" +
                    $"\r\nJobTitle: {item.Esperienza.JobTitle}" +
                    $"\r\nData di inizio: {item.Esperienza.DataInizio:MM/yyyy}" +
                    $"\r\nData di fine: {item.Esperienza.DataFine:MM/yyyy}" +
                    $"\r\nDescrizione: {item.Esperienza.Descrizione}" +
                    $"\r\nCompiti: {item.Esperienza.Compiti}");
            }
            Console.WriteLine("\r\n++++ FINE Esperienze professionali ++++");
        }
    }
}
