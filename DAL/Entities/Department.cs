using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCRUD.DAL.Entities;

[Table("departments")]
[Index("DeptName", Name = "departments_dept_name_key", IsUnique = true)]
public partial class Department
{
    [Key]
    [Column("dept_no")]
    [StringLength(4)]
    public string DeptNo { get; set; } = null!;

    [Column("dept_name")]
    [StringLength(40)]
    public string DeptName { get; set; } = null!;

    [InverseProperty("DeptNoNavigation")]
    public virtual ICollection<DeptEmp> DeptEmps { get; set; } = new List<DeptEmp>();

    [InverseProperty("DeptNoNavigation")]
    public virtual ICollection<DeptManager> DeptManagers { get; set; } = new List<DeptManager>();
}
