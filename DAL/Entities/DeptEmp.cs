using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCRUD.DAL.Entities;

[PrimaryKey("EmpNo", "DeptNo")]
[Table("dept_emp")]
public partial class DeptEmp
{
    [Key]
    [Column("emp_no")]
    public int EmpNo { get; set; }

    [Key]
    [Column("dept_no")]
    [StringLength(4)]
    public string DeptNo { get; set; } = null!;

    [Column("from_date")]
    public DateOnly FromDate { get; set; }

    [Column("to_date")]
    public DateOnly ToDate { get; set; }

    [ForeignKey("DeptNo")]
    [InverseProperty("DeptEmps")]
    public virtual Department DeptNoNavigation { get; set; } = null!;

    [ForeignKey("EmpNo")]
    [InverseProperty("DeptEmps")]
    public virtual Employee EmpNoNavigation { get; set; } = null!;
}
