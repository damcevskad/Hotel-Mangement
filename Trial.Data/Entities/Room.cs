using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Room
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int Id { get; set; }

    [Required]
    public int Number { get; set; }

    [Required]
    public int Floor { get; set; }

    [Required]
    public string Type { get; set; }
}
