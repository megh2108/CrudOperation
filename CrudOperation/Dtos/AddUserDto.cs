using System.ComponentModel.DataAnnotations;

namespace CrudOperation.Dtos
{
    public class AddUserDto
    {
       
        [Required]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }
    }
}
