using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;  // Required for Sqlite

#pragma warning disable CS8618

namespace BudgetTracker.Models
{
    public class User
    {
        // Properties
        // Id Annotations are required for Sqlite
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
