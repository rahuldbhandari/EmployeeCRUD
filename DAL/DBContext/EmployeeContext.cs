using System;
using System.Collections.Generic;
using EmployeeCRUD.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCRUD.DAL.DBContext;

public partial class EmployeeContext : DbContext
{
    public EmployeeContext()
    {
    }

    public EmployeeContext(DbContextOptions<EmployeeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CurrentDeptEmp> CurrentDeptEmps { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<DeptEmp> DeptEmps { get; set; }

    public virtual DbSet<DeptEmpLatestDate> DeptEmpLatestDates { get; set; }

    public virtual DbSet<DeptManager> DeptManagers { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Salary> Salaries { get; set; }

    public virtual DbSet<Title> Titles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Name=ConnectionStrings:EmployeeCRUD");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CurrentDeptEmp>(entity =>
        {
            entity.ToView("current_dept_emp");

            entity.Property(e => e.DeptNo).IsFixedLength();
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DeptNo).HasName("departments_pkey");

            entity.Property(e => e.DeptNo).IsFixedLength();
        });

        modelBuilder.Entity<DeptEmp>(entity =>
        {
            entity.HasKey(e => new { e.EmpNo, e.DeptNo }).HasName("dept_emp_pkey");

            entity.Property(e => e.DeptNo).IsFixedLength();

            entity.HasOne(d => d.DeptNoNavigation).WithMany(p => p.DeptEmps).HasConstraintName("dept_emp_dept_no_fkey");

            entity.HasOne(d => d.EmpNoNavigation).WithMany(p => p.DeptEmps).HasConstraintName("dept_emp_emp_no_fkey");
        });

        modelBuilder.Entity<DeptEmpLatestDate>(entity =>
        {
            entity.ToView("dept_emp_latest_date");
        });

        modelBuilder.Entity<DeptManager>(entity =>
        {
            entity.HasKey(e => new { e.EmpNo, e.DeptNo }).HasName("dept_manager_pkey");

            entity.Property(e => e.DeptNo).IsFixedLength();

            entity.HasOne(d => d.DeptNoNavigation).WithMany(p => p.DeptManagers).HasConstraintName("dept_manager_dept_no_fkey");

            entity.HasOne(d => d.EmpNoNavigation).WithMany(p => p.DeptManagers).HasConstraintName("dept_manager_emp_no_fkey");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmpNo).HasName("employees_pkey");

            entity.Property(e => e.EmpNo).HasIdentityOptions(500000L, null, null, null, null, null);
        });

        modelBuilder.Entity<Salary>(entity =>
        {
            entity.HasKey(e => new { e.EmpNo, e.FromDate }).HasName("salaries_pkey");

            entity.HasOne(d => d.EmpNoNavigation).WithMany(p => p.Salaries).HasConstraintName("salaries_emp_no_fkey");
        });

        modelBuilder.Entity<Title>(entity =>
        {
            entity.HasKey(e => new { e.EmpNo, e.Title1, e.FromDate }).HasName("titles_pkey");

            entity.HasOne(d => d.EmpNoNavigation).WithMany(p => p.Titles).HasConstraintName("titles_emp_no_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
