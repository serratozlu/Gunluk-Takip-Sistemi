using System;
using System.IO;

namespace GunlukTakipSistemi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string filePath = "gunluk.txt";
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine();
                Console.WriteLine("GÜNLÜK RUH HALİ VE AKTİVİTE TAKİP SİSTEMİ");
                Console.WriteLine("------------------------------------------");

                Console.WriteLine("1. Günlük Kaydı Ekle");
                Console.WriteLine("2. Eski Kayıtları Göster");
                Console.WriteLine("3. Çıkış");
                Console.Write("Seçiminiz: ");

                string secim = Console.ReadLine() ?? "";

                if (secim == "1")
                {
                    Console.Write("Bugünkü ruh halin: ");
                    string mood = Console.ReadLine() ?? "";

                    Console.Write("Bugün için kısa notun: ");
                    string note = Console.ReadLine() ?? "";

                    Console.Write("Bugün kaç saat uyudun: ");
                    double sleepHour = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Bugün kaç dakika yürüdün: ");
                    int walkMinute = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Bugüne 1-10 arası puan ver: ");
                    int score = Convert.ToInt32(Console.ReadLine());

                    DailyRecord record = new DailyRecord(mood, note, sleepHour, walkMinute, score);
                    File.AppendAllText(filePath, record.ToFileText());

                    Console.WriteLine();
                    Console.WriteLine("Kayıt başarıyla eklendi.");
                    Console.WriteLine("Günün yorumu:");
                    Console.WriteLine(record.YorumAl());
                }
                else if (secim == "2")
                {
                    if (File.Exists(filePath))
                    {
                        string records = File.ReadAllText(filePath);
                        Console.WriteLine();
                        Console.WriteLine(records);
                    }
                    else
                    {
                        Console.WriteLine("Henüz kayıt bulunmuyor.");
                    }
                }
                else if (secim == "3")
                {
                    isRunning = false;
                    Console.WriteLine("Program kapatılıyor...");
                }
                else
                {
                    Console.WriteLine("Geçersiz seçim yaptınız.");
                }
            }
        }
    }
}