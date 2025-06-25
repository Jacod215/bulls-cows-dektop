using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace byky_korowa
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Byk_korowa manager = new Byk_korowa();
            manager.dane_gry();
            while (Byk_korowa.peremoga != 4)
            {
                manager.otrzymania_danych();
                manager.wyznaczienie();
                manager.wyszwietlienie();
            }
            Console.WriteLine("Вітаю ви виграли !!!!!");
            Console.ReadKey();
         }

    }
    class Byk_korowa
    {
        int czyslo = 0;
        int[] czyslo_tabl = new int[4];
        int p = 1;
        Random r = new Random();
        public static int peremoga = 0;
        int korowy = 0;
        int[] byky = new int [4];
        public void otrzymania_danych()
        {
            int k;
            do
            {
                Console.WriteLine(" ");
                Console.WriteLine("Подай число чотирьох цифрове : ");
                czyslo = Convert.ToInt32(Console.ReadLine());
                if (czyslo > 1000 & czyslo < 10000)
                {
                    p++;
                }
                for (int i = 0; i < 4; i++)
                {
                    czyslo_tabl[i] = czyslo;
                }
                for (k = 0; k < 4; k++)
                {
                    if (k == 0)
                    {
                        czyslo_tabl[k] = czyslo / 1000;
                    }
                    else if (k == 1)
                    {
                        int czyslo_2 =( czyslo/100)%10 ;
                        czyslo_tabl[k] = czyslo_2;
                    }
                    else if (k == 2)
                    {
                        int czyslo_3 = (czyslo % 100) / 10;
                        czyslo_tabl[k] = czyslo_3;
                    }
                    else if (k == 3)
                    {
                        czyslo_tabl[k] = czyslo % 10;
                    }
                }

            } while (p == 1);

        }
        public void dane_gry()
        {
            do
            {
                byky= Enumerable.Range(0, 10) // Числа 0-9
                                    .OrderBy(x => r.Next())
                                    .OrderBy(x => r.Next())
                                    .OrderBy(x => r.Next())
                                    .OrderBy(x => r.Next())// Перемішуємо
                                    .Take(4) // Беремо перші 4
                                    .ToArray();
            }
            while (byky[0] == 0);

        }
        public void wyznaczienie()
        {
            int i = 0;
            peremoga = 0; korowy = 0;
            for (i = 0; i < 4; i++)
            {
                if (byky[i] == czyslo_tabl[i]) { peremoga++; }
                else if (byky.Contains(czyslo_tabl[i])) { korowy++; }
            }
        }
        public void wyszwietlienie()
        {
            if (korowy > 0 || peremoga > 0)
                Console.WriteLine("в числі є {0} коров і {1} биків ", korowy, peremoga);
            else Console.WriteLine("немає ні биків, ні коров");
            
        }
    }
}
