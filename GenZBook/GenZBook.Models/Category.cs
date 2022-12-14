using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GenZBook.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Tên thể loại")]
        public string Name { get; set; }
        [DisplayName("Thứ tự hiển thị")]
        [Range(1,100,ErrorMessage="Vui lòng chỉ nhập số từ 1 đến 100")]
        public int DisplayOrder { get; set; }
        public DateTime CreatedDatetime { get; set; } = DateTime.Now;
    }
}
