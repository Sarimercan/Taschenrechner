using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taschenrechner.Daten;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace Taschenrechner
{
    internal class GSO_Taschenrechner_App
    {
        private TaschenrechnerContext dbContext = new TaschenrechnerContext();

        public void AppStart()
        {
            string opiton;
            do
            {
                Console.Clear();
                Console.WirteLine("Menü\n");
                Console.WirteLine("1. Registrieren");
                Console.WirteLine("2. Anmelden");
                Console.WirteLine("3. Rechnung");
                Console.Write("Bitte wähle eine Option: ");

                option = Console.ReadLine();

                switch
                {
                    case "1":
                        Registrieren();
                        break;
                    case "2":
                        Anmelden();
                        break;
                    case "3":
                        Rechnung();
                        break;
                    default:
                        Console.WriteLine("Ungültige Eingabe. Bitte erneut eingeben.");
                        Console.ReadKey();
                        break;
                }
            } while (true);
        }
        public void Registrieren()
        {
            string benutzername = "";
            string passwort = "";
            double zahl1 = 0;
            double zahl2 = 0;
            double ergebnis = 0;
            string operation = "";
            string vorherigeOperationen = "";

            Console.Write("Regestrieren");
            Console.Write("");
            Console.Write("Gib einen Benutzernamen ein: ");
            benutzername = Console.ReadLine();
            Console.Write("Gib ein Passwort ein: ");
            passwort = Console.ReadLine();

            Benutzer neuerUser = new Benutzer
            {
                Benutzername = benutzername,
                Passwort = passwort,
            }

        }
        public async void Anmelden()
        {
            Console.Write("Anmelden");
            Console.Write("");
            Console.Write("Gib deinen Benutzernamen ein: ");
            string eingabeBenutzername = Console.ReadLine();
            Console.Write("Gib dein Passwort ein: ");
            string eingabePasswort = Console.ReadLine();

            if (eingabeBenutzername == benutzername && eingabePasswort == passwort)
            {
                Console.WriteLine("Anmeldung erfolgreich!");
            }
            else
            {
                Console.WriteLine("Anmeldung fehlgeschlagen. Bitte versuche es erneut.");
            }
        }

        public void Rechnung()
        { 
            Console.WriteLine("Vorherige Operationen: " + vorherigeOperationen);
            Console.Write("Gib die erste Zahl ein: ");
            zahl1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Gib den Operator (+, -, *, /) ein: ");
            operation = Console.ReadLine();
            Console.Write("Gib die zweite Zahl ein: ");
            zahl2 = Convert.ToDouble(Console.ReadLine());

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
                        continue;
                    }
                    ergebnis = zahl1 / zahl2;
                    break;
                default:
                    Console.WriteLine("Fehler: Ungültiger Operator.");
                break;
            }

                // Zeigt Ergebnis an 
            Console.WriteLine("Ergebnis: " + ergebnis);
            vorherigeOperationen += zahl1 + " " + operation + " " + zahl2 + " = " + ergebnis + "\n";

            // Beende das Programm, wenn der Benutzer 1 drückt
            Console.Write("Drücke 1 um das Programm zu beenden oder eine andere Taste um fortzufahren: ");
            if (Console.ReadKey().Key == ConsoleKey.D1)
            {
                break;
            }             
        }
    }
}
