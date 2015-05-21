using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ccom.Pharmacy.DAL.Entity
{
    [Table("Category")]
    public class CategoryEntity
    {
        public CategoryEntity()
        {
            CategoryLogs = new HashSet<CategoryLog>();
        }

        [Key]
        public int CategoryID { get; set; }

        [Required]
        [StringLength(64)]
        public string CategoryName { get; set; }

        public  ICollection<CategoryLog> CategoryLogs { get; set; }
    }
}
