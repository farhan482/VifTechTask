using System.ComponentModel.DataAnnotations;

namespace VifTech.Domain.Entities.Base
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
