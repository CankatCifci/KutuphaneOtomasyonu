    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public class EmanetIslemleri
    {
        private List<Emanet> emanetler;

        public EmanetIslemleri()
        {
            emanetler = new List<Emanet>();
        }

        public void KitapEmanetEt(Uye uye, Kitap kitap)
        {
            // Emanet edilecek kitabın mevcut olup olmadığını kontrol etmek için gerekli kod buraya eklenebilir

            Emanet emanet = new Emanet();
            emanet.Uye = uye;
            emanet.Kitap = kitap;
            emanetler.Add(emanet);
        }

        public void KitapIadeEt(int emanetId)
        {
            Emanet emanet = emanetler.Find(e => e.EmanetId == emanetId);
            if (emanet != null)
            {
                emanet.IadeTarihi = DateTime.Now;
            }
            else
            {
                throw new Exception("Emanet bulunamadı.");
            }
        }
    }
}