using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace eaDavetiye
{


    public class Program
    {
        public Program()
        {
            string empty = string.Empty;

            Console.ForegroundColor = ConsoleColor.Green;
            var t1 = new Thread(new ParameterizedThreadStart(Gonder));
            var t2 = new Thread(new ParameterizedThreadStart(Gonder));
            var t3 = new Thread(new ParameterizedThreadStart(Gonder));
            var t4 = new Thread(new ParameterizedThreadStart(Gonder));
            var t5 = new Thread(new ParameterizedThreadStart(Gonder));
            var t6 = new Thread(new ParameterizedThreadStart(Gonder));
            var t7 = new Thread(new ParameterizedThreadStart(Gonder));
            var t8 = new Thread(new ParameterizedThreadStart(Gonder));

            t1.Start(new Mesaj("Hayatlarımızı birleştirdiğimiz bu mutlu", 18, 2));
            t2.Start(new Mesaj("günümüzde sizleride aramızda", 24, 3));
            t3.Start(new Mesaj("görmekten onur duyacağız.", 26, 4));
            t4.Start(new Mesaj(".: Emre AYDEMİR & Hülya YETKİN :.", 23, 8));
            t5.Start(new Mesaj("YER    : Turizm Otelcilik Oteli Kuşadası/AYDIN", 1, 14));
            t6.Start(new Mesaj("ZAMAN  : 4 HAZİRAN 2011 - Cumartesi", 1, 15));
            t7.Start(new Mesaj("HARİTA : http://tinyurl.com/64mvo9s", 1, 16));
            t8.Start(new Mesaj("Haritayı açmak için : <H>, çıkmak için: <Q>", 1, 24));

            //Clipboard.SetText("http://tinyurl.com/64mvo9s");
            //new Bekle().Bekleyivir(8000.0);
            bool devam = true;

            do
            {
                if (t1.ThreadState == System.Threading.ThreadState.Stopped &&
                    t2.ThreadState == System.Threading.ThreadState.Stopped &&
                    t3.ThreadState == System.Threading.ThreadState.Stopped &&
                    t4.ThreadState == System.Threading.ThreadState.Stopped &&
                    t5.ThreadState == System.Threading.ThreadState.Stopped &&
                    t6.ThreadState == System.Threading.ThreadState.Stopped &&
                    t7.ThreadState == System.Threading.ThreadState.Stopped &&
                    t8.ThreadState == System.Threading.ThreadState.Stopped)
                    devam = false;

            } while (devam);


            do
            {
                Console.SetCursorPosition(48, 24);
                try
                {
                    empty = Console.ReadKey().KeyChar.ToString();
                }
                catch
                {
                }
                if (empty.ToUpper() == "H")
                {
                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    {
                        Process.Start("http://tinyurl.com/64mvo9s");
                    }
                    else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                    {
                        Process.Start("xdg-open", "http://tinyurl.com/64mvo9s");
                    }
                    else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                    {
                        Process.Start("open", "http://tinyurl.com/64mvo9s");
                    }
                    empty = "q";
                }
            }
            while (empty.ToUpper() != "Q");
        }

        public static void Main(string[] args)
        {
            Program p = new Program();
        }

        private void Gonder(object mesaj)
        {
            Animasyon animasyon = new Animasyon();
            Mesaj mesaj1 = mesaj as Mesaj;
            animasyon.yaz(mesaj1.msg, mesaj1.x, mesaj1.y);
        }
    }

    public class Animasyon
    {
        public void yaz(string yazi, int x, int y)
        {
            for (int length = yazi.Length; length > 0; --length)
                this.inceYaz(yazi[length - 1], x + length, y);
        }

        private void inceYaz(char c, int x, int y)
        {
            lock ("threadProcessBilmeyenInsan")
            {
                Bekleyivir(18.0);
                Console.SetCursorPosition(x, y);
                Console.Write(c);
            }
        }

        public void Bekleyivir(double milisaniye)
        {
            DateTime now = DateTime.Now;
            while ((DateTime.Now - now).TotalMilliseconds < milisaniye)
            {
                for (int i = 0; i < 800; i++)
                { }
            }
        }
    }



    public class Mesaj
    {
        public string msg { get; set; }

        public int x { get; set; }

        public int y { get; set; }

        public Mesaj(string msg, int x, int y)
        {
            this.msg = msg;
            this.x = x;
            this.y = y;
        }
    }
}
