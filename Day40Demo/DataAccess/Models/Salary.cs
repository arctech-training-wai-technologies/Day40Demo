using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day40Demo.DataAccess.Models;

[Table(nameof(Salary), Schema = "accounts")]
public class Salary
{
    [Key]
    public int Id { get; set; }

    public int EmployeeRefId { get; set; }

    [ForeignKey(nameof(EmployeeRefId))]
    public Employee Employee { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal Ctc { get; set; }

    [Column(TypeName = "decimal(6,2)")]
    public decimal VariableBonus { get; set; }
}