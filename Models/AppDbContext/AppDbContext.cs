using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TyeBank.Models.Entities;
using TyeBank.Models.StoredProcedureResponses;
using TyeBank.Models.ViewModels;

namespace TyeBank.Models.AppDbContext;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Salary> Salaries { get; set; }

    public virtual DbSet<User> Users { get; set; }







    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=TYENUC-PC;Initial Catalog=TyeBank;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.ToTable("Department");

            entity.Property(e => e.DepartmentId).ValueGeneratedNever();
            entity.Property(e => e.DepartmentName).HasMaxLength(250);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("Employee");

            entity.Property(e => e.EmployeeId).ValueGeneratedNever();
            entity.Property(e => e.EmployeeStatus).HasMaxLength(50);

            entity.HasOne(d => d.EmployeeDepartment).WithMany(p => p.Employees)
                .HasForeignKey(d => d.EmployeeDepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_Department");

            entity.HasOne(d => d.EmployeePosition).WithMany(p => p.Employees)
                .HasForeignKey(d => d.EmployeePositionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_Position");

            entity.HasOne(d => d.EmployeeSalary).WithMany(p => p.Employees)
                .HasForeignKey(d => d.EmployeeSalaryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_Salary");

            entity.HasOne(d => d.EmployeeSuperiorUser).WithMany(p => p.EmployeeEmployeeSuperiorUsers)
                .HasForeignKey(d => d.EmployeeSuperiorUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_User1");

            entity.HasOne(d => d.EmployeeUser).WithMany(p => p.EmployeeEmployeeUsers)
                .HasForeignKey(d => d.EmployeeUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_User");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.ToTable("Position");

            entity.Property(e => e.PositionId).ValueGeneratedNever();
            entity.Property(e => e.PositionName).HasMaxLength(250);
        });

        modelBuilder.Entity<Salary>(entity =>
        {
            entity.ToTable("Salary");

            entity.Property(e => e.SalaryId).ValueGeneratedNever();
            entity.Property(e => e.SalaryAmount).HasColumnType("decimal(6, 0)");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.UserName).HasMaxLength(100);
            entity.Property(e => e.UserPasswordHash).HasMaxLength(255);
            entity.Property(e => e.UserEmail).HasMaxLength(50);
            entity.Property(e => e.UserTelephoneNumber).HasMaxLength(50);
            entity.Property(e => e.UserGender);
            entity.Property(e => e.UserBirthDate).HasColumnType("date");
            entity.Property(e => e.UserTckno).HasMaxLength(11).HasColumnName("UserTCKNo");
            entity.Property(e => e.UserFirstName).HasMaxLength(50);
            entity.Property(e => e.UserLastName).HasMaxLength(50);
            entity.Property(e => e.UserRegistrationDate).HasColumnType("date");
            entity.Property(e => e.UserLastLogin).HasColumnType("datetime");
        });

        modelBuilder.Entity<SP_LoginResponse>().HasNoKey();




        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);



    public IEnumerable<T> CallStoredProcedure<T>(string storedProcedureName, params (string name, object value)[] parameters) where T : class
    {
        var parameterNames = parameters.Select(p => $"@{p.name}");
        var parameterString = string.Join(", ", parameterNames);

        var queryString = $"EXEC {storedProcedureName} {parameterString}";

        var result = Set<T>().FromSqlRaw(queryString, parameters.Select(p => new SqlParameter($"@{p.name}", p.value)).ToArray());

        return result;
    }

}
