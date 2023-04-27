using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CSharp_laba5._1.Domains.Entities
{
    public class Group: Abstract
    {
        [Required(ErrorMessage = "Заполните имя преподавателя")]
        public override string Name { get; set; }
        public ICollection<Student> Students { get; set; }
        public Group()
        {
            Students = new List<Student>();
        }
    }
}
