using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmulationProcessing.dbmodels
{
    [Table("AccessProviders")]
    class AccessProvider
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int User_id { get; set; }

        [ForeignKey("Provider")]
        public int Provider_id { get; set; }

        public virtual User User { get; set; }

        public virtual Provider Provider { get; set; }
    }
}
