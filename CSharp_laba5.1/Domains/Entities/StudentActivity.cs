using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CSharp_laba5._1.Domains.Entities
{
    public class StudentActivity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Заполните id студента")]
        public int StudentId { get; set; }

        public Student Student { get; set; }

        [Required(ErrorMessage = "Заполните id студенческой группы")]
        public int ActivityId { get; set; }

        public Activity Activity { get; set; }
    }
}
