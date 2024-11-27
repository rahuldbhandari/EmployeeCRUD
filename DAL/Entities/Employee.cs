using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCRUD.DAL.Entities;

[Table("employees")]
public partial class Employee
{
    [Key]
    [Column("emp_no")]
    public int EmpNo { get; set; }

    [Column("birth_date")]
    public DateOnly BirthDate { get; set; }

    [Column("first_name")]
    [StringLength(14)]
    public string FirstName { get; set; } = null!;

    [Column("last_name")]
    [StringLength(16)]
    public string LastName { get; set; } = null!;

    [Column("gender")]
    [MaxLength(1)]
    public char Gender { get; set; }

    [Column("hire_date")]
    public DateOnly HireDate { get; set; }

    [InverseProperty("EmpNoNavigation")]
    public virtual ICollection<DeptEmp> DeptEmps { get; set; } = new List<DeptEmp>();

    [InverseProperty("EmpNoNavigation")]
    public virtual ICollection<DeptManager> DeptManagers { get; set; } = new List<DeptManager>();

    [InverseProperty("EmpNoNavigation")]
    public virtual ICollection<Salary> Salaries { get; set; } = new List<Salary>();

    [InverseProperty("EmpNoNavigation")]
    public virtual ICollection<Title> Titles { get; set; } = new List<Title>();
}
