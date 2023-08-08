namespace ToDo
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Dictionary<int, string> takimUyeleri = new Dictionary<int, string>()
            {
                {1, "Yusuf" },
                {2, "Yunus" },
                {3, "Hakan" }
            };

            List<Kart> todoKolonu = new List<Kart>();
            todoKolonu.Add(new Kart { Baslik = "Baslik1", Buyukluk = Buyukluk.M, Icerik = "Içerik1", Kisi = "Yusuf" });
            todoKolonu.Add(new Kart { Baslik = "Baslik2", Buyukluk = Buyukluk.S, Icerik = "Içerik2", Kisi = "Yunus" });
            todoKolonu.Add(new Kart { Baslik = "Baslik1", Buyukluk = Buyukluk.M, Icerik = "Içerik3", Kisi = "Hakan" });

            List<Kart> inProgressKolonu = new List<Kart>();
            List<Kart> doneKolonu = new List<Kart>();


            Console.WriteLine("Lütfen yapmak istediğiniz islemi seçiniz? ");
            Console.WriteLine("(1) Board Listelemek\n (2) Board'a Kart Eklemek \n(3) Board'dan Kart Silmek\n (4) Kart Tasımak");

            string secim = Console.ReadLine();

            if (secim == "1")
            {
                Console.WriteLine("TODO Line");
                Console.WriteLine("************************");
                foreach (Kart kart in todoKolonu)
                {
                    Console.WriteLine("Baslık: " + kart.Baslik);
                    Console.WriteLine("Içerik: " + kart.Icerik);
                    Console.WriteLine("Atanan Kisi: " + kart.Kisi);
                    Console.WriteLine("Büyüklük: " + kart.Buyukluk);
                    Console.WriteLine("-");


                }



                Console.WriteLine();
                Console.WriteLine("IN PROGRESS Line");
                Console.WriteLine("**************************");
                foreach (Kart kart in inProgressKolonu)
                {
                    Console.WriteLine("Baslık: " + kart.Baslik);
                    Console.WriteLine("Içerik: " + kart.Icerik);
                    Console.WriteLine("Atanan Kisi: " + kart.Kisi);
                    Console.WriteLine("Büyüklük: " + kart.Buyukluk);
                    Console.WriteLine("-");
                }

                Console.WriteLine();

                Console.WriteLine("DONE Line");
                Console.WriteLine("**************************");
                foreach (Kart kart in doneKolonu)
                {
                    Console.WriteLine("Baslık: " + kart.Baslik);
                    Console.WriteLine("Içerik: " + kart.Icerik);
                    Console.WriteLine("Atanan Kisi: " + kart.Kisi);
                    Console.WriteLine("Büyüklük: " + kart.Buyukluk);
                    Console.WriteLine("-");
                }
            }

            else if (secim == "2")
            {
                Kart yeniKart = new Kart();
                Console.WriteLine("Baslık Giriniz: ");
                yeniKart.Baslik = Console.ReadLine();
                Console.WriteLine("Içerik Giriniz: ");
                yeniKart.Icerik = Console.ReadLine();
                Console.WriteLine("Büyüklük Seçiniz ---> XS(1), S(2), M(3), L(4), XL(5) : ");
                int yapilanSecim = Convert.ToInt32(Console.ReadLine());
                if (Enum.IsDefined(typeof(Buyukluk), yapilanSecim))
                {
                    yeniKart.Buyukluk = (Buyukluk)yapilanSecim;
                }
                else
                {
                    Console.WriteLine("Hatalı seçim yaptınız.");
                }

            }

            else if (secim == "3")
            {
                Console.WriteLine("Öncelikle silmek istediğiniz kartı seçmeniz gerekiyor.\nLütfen kart baslığını yazınız: ");
                string baslik = Console.ReadLine();

                bool kartSilme = false;

                for (int i = 0; i < todoKolonu.Count; i++)
                {
                    if (todoKolonu[i].Baslik == baslik)
                    {
                        todoKolonu.RemoveAt(i);
                        kartSilme = true;
                        break;
                    }
                }

                if (!kartSilme)
                {
                    for (int i = 0; i < inProgressKolonu.Count; i++)
                    {
                        if (inProgressKolonu[i].Baslik == baslik)
                        {
                            inProgressKolonu.RemoveAt(i);
                            kartSilme = true;
                            break;
                        }
                    }
                }
                if (!kartSilme)
                {
                    for (int i = 0; i < doneKolonu.Count; i++)
                    {
                        if (doneKolonu[i].Baslik == baslik)
                        {
                            doneKolonu.RemoveAt(i);
                            kartSilme = true;
                            break;
                        }
                    }
                }

                if (kartSilme)
                {
                    Console.WriteLine("Kart basarıyla silindi.");
                }
                else
                {
                    Console.WriteLine("Aradığınız kriterlere uygun kart board'da bulunamadı. ");
                }

                Console.WriteLine();

            }


        }
    }
}