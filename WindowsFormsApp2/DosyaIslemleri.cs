using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace WindowsFormsApp2
{
    public static class DosyaIslemleri
    {
        public static void NesneYaz<T>(string dosyaAdi, T nesne)
        {
            // Mevcut JSON dosyasının içeriğini oku
            List<T> mevcutListe = NesneOku<List<T>>(dosyaAdi);

            // Eğer mevcut dosya yoksa veya içeriği boşsa yeni bir liste oluştur
            if (mevcutListe == null)
            {
                mevcutListe = new List<T>();
            }

            // Yeni öğeyi listeye ekle
            mevcutListe.Add(nesne);

            // Yeni listeyi JSON formatına çevirerek dosyaya yaz
            string json = JsonConvert.SerializeObject(mevcutListe);
            File.WriteAllText(dosyaAdi, json);
        }

        public static T NesneOku<T>(string dosyaAdi)
        {
            string json = File.ReadAllText(dosyaAdi);
            T nesne = JsonConvert.DeserializeObject<T>(json);
            return nesne;
        }
    }

}
