using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day40Demo.DataAccess.Models;

[Table(nameof(LeaveRequest), Schema = "deductions")]
public class LeaveRequest
{
    [Key]
    public int Id { get; set; }
    
    public int EmployeeRefId { get; set; }

    [ForeignKey(nameof(EmployeeRefId))]
    public Employee Employee { get; set; }

    [Column(TypeName = "date")]
    public DateTime LeaveFrom { get; set; }

    [Column(TypeName = "date")]
    public DateTime LeaveTo { get; set; }
}