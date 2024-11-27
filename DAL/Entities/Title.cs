using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCRUD.DAL.Entities;

[PrimaryKey("EmpNo", "Title1", "FromDate")]
[Table("titles")]
public partial class Title
{
    [Key]
    [Column("emp_no")]
    public int EmpNo { get; set; }

    [Key]
    [Column("title")]
    [StringLength(50)]
    public string Title1 { get; set; } = null!;

    [Key]
    [Column("from_date")]
    public DateOnly FromDate { get; set; }

    [Column("to_date")]
    public DateOnly? ToDate { get; set; }

    [ForeignKey("EmpNo")]
    [InverseProperty("Titles")]
    public virtual Employee EmpNoNavigation { get; set; } = null!;
}
