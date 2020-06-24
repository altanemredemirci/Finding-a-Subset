using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alt_Kume_Bulma
{
    class Program
    {
        static void Main(string[] args)
        {
            int kumetoplami = 0;
            #region klavyedenKüme
            Console.WriteLine("Kümenin Eleman Sayısını Giriniz:");
            int es = Convert.ToInt32(Console.ReadLine());
            var kume = new string[es];
            for (int i = 0; i < es; i++)
            {
                Console.WriteLine(String.Format("{0}.Eleman : ", i+1));
                string eleman = Console.ReadLine();
                kume[i] = eleman;
                kumetoplami += Convert.ToInt32(eleman);
            }
            #endregion
            //Yunus Ünsal
            //var _kume = "1,2,3,4,5,6,7,8,9,10,11,12";
            //var kume = _kume.Split(',');
            var altkume = AltKumeBul(kume);

            var sayi = AltkToplam(altkume);
            Console.WriteLine("Küme toplamı {0} olan altküme sayısı: {1}",kumetoplami,sayi);
            
            Console.ReadKey();
        }

        private static int AltkToplam(List<string> altkume)
        {
            string[,] altk = new string[4, altkume.Count];
            int adet = 0;
            foreach (var v in altkume)
            {
                if (v != "")
                {
                    int toplam = 0;
                    var temp = v.Split(',');
                    var l = temp.Length;
                    toplam += temp.Sum(s => Convert.ToInt32(s));
                    if (toplam == 50)
                    {
                        adet++;
                    }
                }
            }
            return adet;
        }

        private static List<string> AltKumeBul(string[] kume)
        {
            int es = kume.Length;
            int aks = AksHesap(es);
            List<string> t = new List<string>();
            string[,] altkume = new string[es, aks];
            t.Add("");
            int enbuyukaltkume = 0;
            foreach (var s in kume)
            {
                int x = t.Count();
                for (int y = 0; y < x; y++)
                {
                    if (y == 0)
                    {
                        Console.WriteLine("{" + t[y] + s + "}");
                        t.Add(t[y] + s);
                    }
                    else
                    {
                        Console.WriteLine("{" + t[y] + "," + s + "}");
                        t.Add(t[y] + "," + s);
                    }
                }
            }
            
            
            //var l = temp.Length;
            //toplam += temp.Sum(s => Convert.ToInt32(s));
            for (int i = 1; i < t.Count; i++)
            {
                int elemantoplami = 0;
                var temp = t[i].Split(',');
                elemantoplami += temp.Sum(s => Convert.ToInt32(s));
                
                if (enbuyukaltkume < elemantoplami)
                {
                    enbuyukaltkume = elemantoplami;
                }
            }
           
            Console.WriteLine("Enbuyuk:"+enbuyukaltkume);
            return t;
        }
        private static int AksHesap(int es)
        {
            return (int)Math.Pow(2, es);
        }
    }
}
