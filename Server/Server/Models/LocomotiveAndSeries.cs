using System.ComponentModel;

namespace Server.Models
{
    public class LocomotiveAndSeries
    {
        [DisplayName("Номер локомотива")]
        public string num_loco { get; set; }
        [DisplayName("Номер секции")]
        public string num_sec { get; set; }
        [DisplayName("Код серии локомотива")]
        public int type_loco_id { get; set; }
        [DisplayName("Номер серии")]
        public string num { get; set; }
        [DisplayName("Наименование серии")]
        public string name { get; set; }
    }
}
