using System.ComponentModel.DataAnnotations;

namespace JetstreamApi.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
    }
}
