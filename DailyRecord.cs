using System;

namespace GunlukTakipSistemi
{
    public class DailyRecord
    {
        public string? Mood { get; set; }
        public string? Note { get; set; }
        public double SleepHour { get; set; }
        public int WalkMinute { get; set; }
        public int Score { get; set; }
        public DateTime Date { get; set; }

        // Constructor
        public DailyRecord(string mood, string note, double sleepHour, int walkMinute, int score)
        {
            Mood = mood;
            Note = note;
            SleepHour = sleepHour;
            WalkMinute = walkMinute;
            Score = score;
            Date = DateTime.Now;
        }

        // Yorum oluşturma
        public string YorumAl()
        {
            string yorum = "";

            if (SleepHour < 6)
                yorum += "Bugün biraz az uyumuşsun.\n";
            else
                yorum += "İyi uyumuşsun. Umarım dinlenmişsindir.\n";

            if (WalkMinute > 20)
                yorum += "Bugün hareket etmişsin.\n";
            else
                yorum += "Sağlığın için hareket etmelisin.\n";

            if (Score >= 7)
                yorum += "Genel olarak iyi bir gün olmuş. Tebrikler!\n";
            else if (Score >= 4)
                yorum += "Orta seviyede bir gün olmuş.\n";
            else
                yorum += "Kötü bir gün geçirmişsin ama yarın yeniden başlayabilirsin.\n";

            return yorum;
        }

        // Dosyaya yazılacak format
        public string ToFileText()
        {
            string text = "";

            text += "Tarih: " + Date + "\n";
            text += "Ruh Hali: " + Mood + "\n";
            text += "Not: " + Note + "\n";
            text += "Uyku Saati: " + SleepHour + "\n";
            text += "Yürüyüş Dakikası: " + WalkMinute + "\n";
            text += "Gün Puanı: " + Score + "\n";
            text += "Yorum:\n" + YorumAl();
            text += "------------------------------\n";

            return text;
        }
    }
}