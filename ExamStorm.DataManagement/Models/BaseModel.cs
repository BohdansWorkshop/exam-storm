using System;
using System.ComponentModel.DataAnnotations;

namespace ExamStorm.DataManager.Models
{
    public class BaseModel
    {
        [Key]
        public Guid Id { get; set; }
    }
}
