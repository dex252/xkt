using System.ComponentModel;

namespace Server.Models {
    public class Shablon
    {
        [DisplayName("Код серии локомотива")]
        public int type_loco_id { get; set; }
        [DisplayName("Название шаблона")]
        public string name { get; set; }
        [DisplayName("Характеристики шаблона (передача, мин/макс вращение, мин/макс мощность)")]
        public int[,,] characteristic { get; set; }
        [DisplayName("Коэффициенты сети")]
        public string json { get; set; }

        public Shablon()
        {
            characteristic = new int[6, 2, 2];
        }
    }

}
