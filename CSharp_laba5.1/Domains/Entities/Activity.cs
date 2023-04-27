using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CSharp_laba5._1.Domains.Entities
{
    public class Activity : Abstract
    {
        [Required(ErrorMessage = "Заполните название студенческой группы")]
        public override string Name { get; set; }
        public ICollection<StudentActivity> StudentActivities { get; set; }
    }
}
