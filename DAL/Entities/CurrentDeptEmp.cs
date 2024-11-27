using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCRUD.DAL.Entities;

[Keyless]
public partial class CurrentDeptEmp
{
    [Column("emp_no")]
    public int? EmpNo { get; set; }

    [Column("dept_no")]
    [StringLength(4)]
    public string? DeptNo { get; set; }

    [Column("from_date")]
    public DateOnly? FromDate { get; set; }

    [Column("to_date")]
    public DateOnly? ToDate { get; set; }
}
