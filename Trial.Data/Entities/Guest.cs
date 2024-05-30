using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Guest
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(200)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(400)]
    public string LastName { get; set; }

    [Required]
    public DateTime DOB { get; set; }

    [Required]
    [StringLength(600)]
    public string Address { get; set; }

    [Required]
    public string Nationality { get; set; }

    [Required]
    public DateTime CheckInDate { get; set; }

    [Required]
    public DateTime CheckOutDate { get; set; }

    [Required]
    public int RoomId { get; set; }
}
