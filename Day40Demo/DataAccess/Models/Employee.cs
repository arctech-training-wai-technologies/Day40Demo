using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day40Demo.DataAccess.Models;

[Table(nameof(Employee), Schema = "master")]
public class Employee
{
    [Key]
    public int Id { get; set; }

    [Column(TypeName = "varchar(100)")]
    public string FirstName { get; set; }

    [Column(TypeName = "varchar(100)")]
    public string LastName { get; set; }

    [Column(TypeName = "date")]
    public DateTime DateOfBirth { get; set; }

    [Column(TypeName = "varchar(100)")]
    public string Email { get; set; }

    [Column(TypeName = "varchar(20)")]
    public string Phone { get; set; }
}