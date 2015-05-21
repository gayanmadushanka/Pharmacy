using System.ComponentModel.DataAnnotations.Schema;

namespace Ccom.Pharmacy.DAL.Entity
{
    [Table("CategoryLog")]
    public partial class CategoryLog
    {
        public int CategoryLogID { get; set; }

        public int CategoryID { get; set; }

        public int LogID { get; set; }

        public  CategoryEntity Category { get; set; }

        public  LogEntity Log { get; set; }
    }
}
