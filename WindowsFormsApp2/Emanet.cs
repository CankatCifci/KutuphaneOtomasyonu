using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public class Emanet
    {
        private static int _nextEmanetId = 1;

        public int EmanetId { get; private set; }
        public Kitap Kitap { get; set; }
        public Uye Uye { get; set; }
        public DateTime EmanetTarihi { get; set; }
        public DateTime? IadeTarihi { get; set; } // "?" işareti ile nullable yapıldı

        public int UyeId { get; set; } // Emaneti alan üyenin ID'si
        public int KitapId { get; set; } // Emanet edilen kitabın ID'si

        public string EkBilgi { get; set; } // Ek bilgi (isteğe bağlı)

        public Emanet()
        {
            EmanetId = _nextEmanetId++;
            Kitap = new Kitap();
            Uye = new Uye();
            EmanetTarihi = DateTime.Now;
            IadeTarihi = null;
        }
    }
}
    
