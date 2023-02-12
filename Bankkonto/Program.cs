//Uppgift 2-1:


//För att hantera sina konton har en bank i sitt datorsystem skapat klasserna Konto och Bank. Klassen konto används för att hantera ett konto medan klassen Bank hanterar bankens samtliga konton. Definiera klassen Konto och implementera dess metoder.

//Klassen ska ha följande attribut:

//nummer: kontonumret
//innehavare: kontoinnehavarens namn
//saldo: kontots saldo
//rantesats: räntesats för kontot
//Klassen ska ha följande metoder:

//konto: konstruktor
//skrivut: skriver ut samtliga attribut
//ge_nummer: returnerar kontonumret
//ranteutbetalning: beräknar räntan och adderar den till saldot
//Definiera klassen Bank och implementera dess metoder.

//Klassen ska ha följande attribut:

//konton: en lista med konton(använd klassen Konto ovan)
//antal_konton: antalet konton i arrayen
//Klassen ska ha följande metoder:

//Bank: konstruktor
//skriv_kontolista: skriver ut en lista med bankens samtliga konton (kontonummer, innehavare, saldo och räntesats)
//nytt_konto: lägger in ett nytt konto längst bak i arrayen
//ranteutbetalning: utbetalar ränta till samtliga konton
//sok_kontonr: söker efter ett givet kontonummer, som ska vara en parameter till metoden. Om kontot finns skriver metoden ut dess attribut på skärmen, annars skrivs ett meddelande ut om att kontot inte finns.
//Skriv också en metod som sorterar en Konto-list efter konto nummer.
//Till detta behövs det en meny, där användaren kan välja:

//Lägg in ett nytt konto
//Skriv ut kontolista
//Ränteutbetalning
//Sök efter konto
//Avsluta

//Rita klassdiagram och relation mellan båda klasserna.
using static Bank;
using System.Reflection.Metadata;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;
using System;

public class Bank
{
    public static void Main()
    {
        Welcome();
        var konton = Konton();
        BankMeny(konton);
    }
    public class Konto
    {
        public int kontonr { get; set; }
        public string innehavare { get; set; }
        public int saldo { get; set; }
        public int räntesats { get; set; }
        public Konto(int kontonr2, string innehavare2, int saldo2, int räntesats2)
        {
            kontonr = kontonr2;
            innehavare = innehavare2;
            saldo = saldo2;
            räntesats = räntesats2;
        }
       
    }
    public static List<Konto> Konton()
    {
        var kontoList = new List<Konto>();
 
        return kontoList;
    }
    //bubblesort for sorting by "kontonr"
    public static void SortList(List<Konto> kontoList)
    {
       
            int n = kontoList.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (kontoList[j].kontonr > kontoList[j + 1].kontonr)
                    {
                        Konto temp = kontoList[j];
                        kontoList[j] = kontoList[j + 1];
                        kontoList[j + 1] = temp;
                    }
                }
            }
        

    }
    //function for "Antal_Konton". Can also be done with konton.count
    public static void CountAccounts(List<Konto> kontoList)
    {
        int n = 0;
        foreach (Konto konto in kontoList)
        {
            
            n++;
        }
        Console.WriteLine($"\nDet finns {n} konton i listan.");
    }
    public static void Welcome()
    {
        Console.WriteLine("Välkommen till SEBs kontohanterare. Klicka på den första bokstaven för menyn du vill komma åt.");
    }
    public static void BankMeny(List<Konto> kontoList)
    {
       
        //switch menu, most efficient way to organize a console menu
        //changed name from "Sok_kontonr" to "Hitta konto" because of switch menu selection
        while (true)
        {
            Console.WriteLine("[L]ägg in ett nytt konto"); 
            Console.WriteLine("[S]kriv ut kontolista"); 
            Console.WriteLine("[R]änteutbetalning");
            Console.WriteLine("[H]itta ett konto"); 
            Console.WriteLine("[A]vsluta");
            //makes both upper and lower case enter the menu
            char menu = char.ToLower(Console.ReadKey().KeyChar);
            
            switch (menu)
            {
                
                case 'l':
                    var kontonr = 0;
                    var saldo = 0;
                    var innehavare = "";
                    var räntesats = 0;
                    Console.Clear();
                    Console.WriteLine("Här kan du lägga in ett nytt konto.");
                    void Nytt_Konto()
                    {
                        
                        
                   
                        Console.Write("\nAnge kontonr: ");

                        //only allow numbers for kontonr
                        while (!int.TryParse(Console.ReadLine(), out kontonr))
                        {
                            Console.WriteLine("\nEnbart siffror är tillåtna som kontonummer. Ange kontonummer: ");

                        }

                        Console.Write("Ange kontots innehavare: ");
                        innehavare = Console.ReadLine();
                        //doesn't allow empty input, but everything else is OK. Hard to make a Regex for names, as people can write with apostrophes, swedish letters and more.
                        while (innehavare == "")
                        {
                            Console.WriteLine("\nDu måste ange ett värde. Ange kontots innehavare: ");
                            innehavare = Console.ReadLine();
                        }
                        //only allow numbers for saldo
                        Console.Write("Ange kontots saldo: ");
                        while (!int.TryParse(Console.ReadLine(), out saldo))
                        {
                            Console.WriteLine("\nEnbart siffror är tillåtna som saldo. Ange saldo: ");
                        }
                        //only allow numbers for räntesats
                        Console.Write("Ange kontots räntesats: ");
                        while (!int.TryParse(Console.ReadLine(), out räntesats))
                        {
                            Console.WriteLine("\nEnbart siffror är tillåtna som räntesats. Till exempel 1 för 1%. Ange räntesats: ");
                        }
                        Console.Clear();
                        

                        kontoList.Add(new Konto(kontonr, innehavare, saldo, räntesats));
                        Console.WriteLine($"Nytt konto tillagt med värden: \nKontonr: {kontonr}\nInnehavare: {innehavare}\nSaldo: {saldo} SEK\nRäntesats: {räntesats}%\n");
                    }
                    Nytt_Konto();

                    //function for specific console writeline shortening down code
                    CWLKonto();
                    var keyK = Console.ReadKey().Key;
                    //if user press K, do function again. if user press X go back to switch menu
                    while (keyK != ConsoleKey.X || keyK == ConsoleKey.K)
                    {
                        if (keyK == ConsoleKey.K)
                            Nytt_Konto();
                        CWLKonto();
                        keyK = Console.ReadKey().Key;
                        Console.Clear();

                    }
                    
                    Console.Clear();

                    
                    break;      
                    
                   

                case 's':

                    Console.Clear();
                    Console.WriteLine("Kontolistan skrivs ut och sorteras....");
                    //sort list by account number before printing it out 
                    SortList(kontoList);
                    //printing out how many accounts there are
                    CountAccounts(kontoList);
                    
                    foreach (var konto in kontoList)
                    {
                        Console.WriteLine($"\nKontonr: {konto.kontonr}\nInnehavare: {konto.innehavare}\nSaldo: {konto.saldo} SEK\nRäntesats: {konto.räntesats}%");
                    }
                    //if user press X, go back to main menu. If user press something else, inform them to press X
                    CWLPressX();
                    while (Console.ReadKey().Key != ConsoleKey.X)
                    {
                        CWLPressX();
                    }
                    Console.Clear();
                    break;
                    
                        

                case 'r':
                    Console.Clear();
                    Console.WriteLine("Ränteutbetalningsmeny");
                    //function for paying out interest
                    void RänteUtbetalning()
                    {
                        
                        
                        double ränta = 0;

                        double saldoEfRänta = 0;
                       

                        foreach (var konto in kontoList)
                        {
                            ränta = konto.räntesats;
                            //converting user input to percentage interest
                            saldoEfRänta = konto.saldo * (1 + (ränta / 100));

                            //setting the new account balance to the list and converting from double to int
                            konto.saldo = (int)saldoEfRänta;
                            Console.WriteLine($"Det nya saldot för kontonummer {konto.kontonr} är: {konto.saldo} SEK");
                        }
                    }
                    RänteUtbetalning();

                    CWLInterest();
                    var keyR = Console.ReadKey().Key;
                    //if user press R, add the interest again. if user press X, go to main menu. if user press anything else, inform user.
                    while (keyR != ConsoleKey.X || keyR == ConsoleKey.R)
                    {
                        if (keyR == ConsoleKey.R)
                            RänteUtbetalning();

                        CWLInterest();
                        keyR = Console.ReadKey().Key;

                    }
                  
                    Console.Clear();


                    break;

                case 'h':
                    Console.Clear();
                    Console.WriteLine("\nHär kan du söka efter ett specifikt konto");
                    //function for task "sok_kontonr", searching for values in "kontonr"
                    void HittaKonto()
                    {
                        Console.Write("Ange kontonummer att söka efter: ");
                        
                        int.TryParse(Console.ReadLine(), out int hittaKontonr);
                        int result = LinSok(hittaKontonr);
                        if (result == -1)
                            Console.WriteLine($"Kontonumret {hittaKontonr} hittades inte.");
                        else

                            Console.WriteLine($"Sökningen resulterade i följande konto(n): ");
                        foreach (var konto in kontoList)
                        {
                            if (hittaKontonr == konto.kontonr)
                            {
                                Console.WriteLine($"\nKontonr: {konto.kontonr}\nInnehavare: {konto.innehavare}\nSaldo: {konto.saldo} SEK");
                            }
                        }
                    }
                    HittaKonto();
                    CWLFindAccount();
                    var keyH = Console.ReadKey().Key;
                    //if user press H, find another account. if user press X, go to switch menu. If user press something else, inform user.
                    while (keyH != ConsoleKey.X || keyH == ConsoleKey.H)
                    {
                        if (keyH == ConsoleKey.H)
                            HittaKonto();

                       CWLFindAccount();
                        keyH = Console.ReadKey().Key;

                    }
                    Console.Clear();
                    

                    break;

                case 'a':

                    //goodbye message and informing that program is exiting in 10 seconds
                    Console.Clear();
                    Console.WriteLine("Tack för att du använder SEB.se för att hantera dina bankkonton.\nVi önskar dig en trevlig dag!\n\nProgrammet stängs av om 10 sekunder.");
                    Thread.Sleep(10000);
                    Environment.Exit(0);
                    
                 break;
                    //if user press incorrect switch chooser, inform user and go back to switch menu
                default:
                    Console.Clear();
                    Console.WriteLine("Du kan endast ange första bokstaven av menyerna för att välja.\n");
                    break;
            }
            
           //function for finding account number and returning index
            int LinSok(int hittaKontonr)
            {
                int index = 0;
                

                foreach (var konto in kontoList)
                {
                    if (hittaKontonr == konto.kontonr)
                    {
                        return index;
                    }
                    index++;
                }
                return -1;

            }
            //functions for specific console writelines that I use twice, shortening down the code
            void CWLKonto()
            {
                Console.WriteLine("\nAnge 'X' för att gå tillbaka till menyn, eller 'K' för att lägga till ytterligare ett konto.");
            }
            void CWLPressX()
            {
                Console.WriteLine("\nAnge 'X' för att gå tillbaka till menyn.");
            }
            void CWLInterest()
            {
                Console.WriteLine("\nAnge 'X' för att gå tillbaka till menyn, eller 'R' för att betala ut ränta på nytt.");
            }
            void CWLFindAccount()
            {
                Console.WriteLine("\nAnge 'X' för att gå tillbaka till menyn, eller 'H' för att söka efter ett till konto.");
            }
        }
    }
}