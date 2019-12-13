using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    [Serializable]
    public class LocoData
    {
        [DisplayName("Уникальный код секции")]
        public int loco_id { get; set; }
        [DisplayName("Код серии локомотива")]
        public int type_loco_id { get; set; }
        [DisplayName("Дата в секундах")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public int timestamp { get; set; }
        [DisplayName("Обороты коленчатого вала дизеля")]
        public int rpm_diesel { get; set; }
        [DisplayName("Мощность главного генератора")]
        public int power_generator { get; set; }
        [DisplayName("Позиция контроллера машиниста")]
        public int poz_kont_sec { get; set; }
    }
}
