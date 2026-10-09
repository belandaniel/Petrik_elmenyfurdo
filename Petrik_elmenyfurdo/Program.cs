using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.AccessControl;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Petrik_elmenyfurdo
{
    internal class Program
    {
        static void MenuKiir()
        {
            Console.WriteLine("=== PETRIK ÉLMÉNYFÜRDŐ ===");
            Console.WriteLine();

            Console.WriteLine("1.) Belépőjegy vásárlása");
            Console.WriteLine("2.) Csúszdapark ellenőrzés");
            Console.WriteLine("3.) Éttermi kedvezmény kalkulátor");
            Console.WriteLine("4.) Napi bevétel");
            Console.WriteLine("5.) Kilépés");
            Console.Write("Választás: ");
        }

        static string JegyTipus(int eletkor)
        {
            if (eletkor <= 5)
            {
                return "Baba jegy";
            }
            else if (eletkor <= 13)
            {
                return "Gyerekjegy";
            }
            else if (eletkor <= 17)
            {
                return "Diákjegy";
            }
            else if (eletkor <= 64)
            {
                return "Felnőtjegy";
            }
            else
            {
                return "Nyugdíjas jegy";
            }
        }

        static int JegyAr(int eletkor)
        {
            if (eletkor <= 5)
            {
                return 0;
            }
            else if (eletkor <= 13)
            {
                return 1800;
            }
            else if (eletkor <= 17)
            {
                return 2400;
            }
            else if (eletkor <= 64)
            {
                return 3900;
            }
            else
            {
                return 2000;
            }
        }
        static void CsuszdaEllenorzes()
        {
            int csuszda = 0;
            int magassag = 0;
            Console.Clear();
            Console.WriteLine("=== CSZÚSZDAPARK ===");
            Console.WriteLine("1.) Mini Cszúszda");
            Console.WriteLine("2.) Kamikaze");
            Console.WriteLine("3.) Black Hole");
            Console.Write("Melyik csúszdát választod: ");
            
            try
            {
                csuszda = Convert.ToInt32(Console.ReadLine());
                Console.Write("Magasság: ");
                magassag = Convert.ToInt32(Console.ReadLine());
                switch (csuszda)
                {
                    case 1:
                        if (magassag>100)
                        {
                            Console.WriteLine("Használhatod a Mini Csúszdát!");
                        }
                        else
                        {
                            Console.WriteLine("Sajnos túl alacsony vagy ehez a csúszdához!");
                        }
                        break;
                    case 2:
                        if (magassag>140)
                        {
                            Console.WriteLine("Használhatod a Kamikaze Csúszdát!");
                        }
                        else
                        {
                            Console.WriteLine("Sajnos túl alacsony vagy ehez a csúszdához!");
                        }
                        break; 
                    case 3:
                        if (magassag > 120)
                        {
                            Console.WriteLine("Használhatod a Black Hole Csúszdát!");
                        }
                        else
                        {
                            Console.WriteLine("Sajnos túl alacsony vagy ehez a csúszdához!");
                        }
                        break;
                    default:
                        Console.WriteLine("Nincsen ilyen csúszda");
                        break;
                        
                }

            }
            catch
            {
                Console.WriteLine();

                Console.WriteLine("Hiba! Számot kell megadni!");
                Console.ReadLine();
            }
        }
        static void EttermiKedvezmenyKalkulator()
        {
            int kedvezmeny = 0;
            int osszeg = 0;
            Console.Clear();
            Console.WriteLine("=== ÉTTERMI KEDVEZMÉNY ===");
            Console.WriteLine("1.) Nincs kedvezmény");
            Console.WriteLine("2.) Diákkedvezmény - 15%");
            Console.WriteLine("3.) Családi kedvezmény - 20%");
            Console.Write("Eredeti Összeg: ");


            try
            {
                osszeg = Convert.ToInt32(Console.ReadLine());
                Console.Write("Kedvezmény: ");
                kedvezmeny = Convert.ToInt32(Console.ReadLine());
                if (kedvezmeny < 1|| kedvezmeny > 3)
                {
                    Console.WriteLine("Nincs ilyen kedvezménytípus!");
                }
                else
                {
                    int ar = KedvezmenyesAr(osszeg, kedvezmeny);
                    Console.WriteLine($"Fizetend: {ar}");
                }


            }
            catch
            {
                Console.WriteLine();

                Console.WriteLine("Hiba! Számot kell megadni!");
                Console.ReadLine();
            }

        }
        static int KedvezmenyesAr(int osszeg, int kedvezmeny)
        {
            if (kedvezmeny == 1)
            {
                return osszeg;

            }
            else if(kedvezmeny==2)
            {
                return osszeg - osszeg * 15 /100;
            }
            else
            {
                return osszeg - osszeg * 20 / 100;
            }
            
        }

        
        static void Main(string[] args)
        {
            int bevetel = 0;
            int valasztas = 0;
            do
            {
                Console.Clear();
                MenuKiir();
                try
                {
                    valasztas = Convert.ToInt32(Console.ReadLine());

                    switch (valasztas)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("=== JEGYVÁSÁRLÁS ===");
                            Console.WriteLine();

                            Console.Write("Hogy hívnak: ");
                            string nev = Console.ReadLine();

                            Console.Write("Életkor: ");
                            int eletkor = Convert.ToInt32(Console.ReadLine());

                            if (eletkor < 0 || eletkor > 120)
                            {
                                Console.WriteLine("Hibás életkor!");
                            }
                            else
                            {
                                string jegyTipus = JegyTipus(eletkor);
                                int ar = JegyAr(eletkor);

                                Console.WriteLine();
                                Console.WriteLine($"Szia {nev}! Jegytípus: {jegyTipus} Fizetendő: {ar}");

                                bevetel += ar;
                            }
                            Console.ReadLine();
                            break;

                        case 2:
                            Console.Clear();
                            CsuszdaEllenorzes();
                            Console.ReadLine();
                            break;
                        case 3:
                            Console.Clear();
                            EttermiKedvezmenyKalkulator();
                            Console.ReadLine();
                            break;
                        case 4:
                            Console.Clear();
                            Console.WriteLine("=== NAPI BEVÉTEL ===");
                            Console.WriteLine($"A fürdő mai bevétele: {bevetel}");
                            Console.ReadLine();
                            break;
                          
                    }

                }
                catch
                {
                    Console.WriteLine();

                    Console.WriteLine("Hiba! Számot kell megadni!");
                    Console.ReadLine();
                }

            } while (valasztas != 5);
        }
    }
}
    
