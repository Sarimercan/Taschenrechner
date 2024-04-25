using Taschenrechner.Daten;
using Microsoft.EntityFrameworkCore;

namespace Taschenrechner
{
    internal class GSO_Taschenrechner_App
    {
        internal static Benutzer aktueller_user = new Benutzer();

        private TaschenrechnerContext dbContext = new TaschenrechnerContext();

        public void AppStart()
        {
            string option;
            do
            {
                Console.Clear();
                Console.WriteLine("Menü\n");
                Console.WriteLine("1. Registrieren");
                Console.WriteLine("2. Anmelden");
                Console.Write("\nBitte wähle eine Option: ");

                option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Registrieren();
                        break;
                    case "2":
                        Anmelden();
                        break;
                    case "exit":
                        return;
                    default:
                        Console.WriteLine("Ungültige Eingabe. Bitte erneut eingeben.");
                        Console.ReadKey();
                        break;
                }
            } while (true);
        }
        public async void Registrieren()
        {
            string benutzername = "";
            string passwort = "";

            Console.Clear();
            Console.WriteLine("Regestrieren\n");
            Console.Write("Gib einen Benutzernamen ein: ");
            benutzername = Console.ReadLine();
            Console.Write("Gib ein Passwort ein: ");
            passwort = Console.ReadLine();

            Benutzer neuerUser = new Benutzer
            {
                Benutzername = benutzername,
                Passwort = passwort,
            };

            dbContext.Users.Add(neuerUser);
            await dbContext.SaveChangesAsync();

            Console.WriteLine("Du wurdest Erfolgreich angemeldet!");
            Console.ReadKey();
            Rechnung();
        }
        public async void Anmelden()
        {
            Console.Clear();
            Console.WriteLine("Anmelden");

            string eingabeBenutzername;
            string eingabePasswort;

            do
            {
                Console.Write("Gib deinen Benutzernamen ein: ");
                eingabeBenutzername = Console.ReadLine();
                aktueller_user = await dbContext.Users.FirstOrDefaultAsync(u => u.Benutzername == eingabeBenutzername);

                if (aktueller_user == null)
                {
                    Console.WriteLine("Ungültiger Benutzername. Bitte versuche es erneut.");
                    Console.ReadKey();
                }
            } while (aktueller_user == null);

            bool passwortRichtig = false;

            do
            {
                Console.Write("Gib dein Passwort ein: ");
                eingabePasswort = Console.ReadLine();
                if (aktueller_user.Passwort == eingabePasswort)
                {
                    passwortRichtig = true;
                }
                else
                {
                    Console.WriteLine("Anmeldung fehlgeschlagen. Bitte versuche es erneut.");
                    Console.ReadKey();
                }
            } while (!passwortRichtig);

            Console.WriteLine("Anmeldung erfolgreich!");
            Console.ReadKey();
            Rechnung();
        }
        public async void Rechnung()
        {
            double ergebnis = 0;
            Console.Clear();
            Console.WriteLine("Rechung\n");
            Console.Write("Gib die erste Zahl ein: ");
            double zahl1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Gib den Operator (+, -, *, /) ein: ");
            string operation = Console.ReadLine();
            Console.Write("Gib die zweite Zahl ein: ");
            double zahl2 = Convert.ToDouble(Console.ReadLine());

            // Rechnung
            switch (operation)
            {
                case "+":
                    ergebnis = zahl1 + zahl2;
                    break;
                case "-":
                    ergebnis = zahl1 - zahl2;
                    break;
                case "*":
                    ergebnis = zahl1* zahl2;
                    break;
                case "/":
                    if (zahl2 == 0)
                    {
                        Console.WriteLine("Fehler: Division durch Null ist nicht erlaubt.");
                        Console.ReadKey();
                    }
                    ergebnis = zahl1 / zahl2;
                    break;
                default:
                    Console.WriteLine("Fehler: Ungültiger Operator.");
                break;
            }
           
            Console.WriteLine($"Ergebnis: {ergebnis}");

            Rechnung neueRechnung = new Rechnung
            {
                Zahl = zahl1,
                Zahl2 = zahl2,
                Ergebnis = ergebnis,
                Operation = operation
            };

            dbContext.Rechnungen.Add(neueRechnung);
            await dbContext.SaveChangesAsync();

            Console.ReadKey();
            AppStart();
        }
    }
}
