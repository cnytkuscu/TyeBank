namespace TyeBank.Models.Entities;

public partial class Employee
{
    public Guid EmployeeId { get; set; }

    public Guid EmployeeDepartmentId { get; set; }

    public Guid EmployeeSalaryId { get; set; }

    public Guid EmployeePositionId { get; set; }

    public string EmployeeStatus { get; set; } = null!;

    public Guid EmployeeUserId { get; set; }

    public Guid EmployeeSuperiorUserId { get; set; }

    public virtual Department EmployeeDepartment { get; set; } = null!;

    public virtual Position EmployeePosition { get; set; } = null!;

    public virtual Salary EmployeeSalary { get; set; } = null!;

    public virtual User EmployeeSuperiorUser { get; set; } = null!;

    public virtual User EmployeeUser { get; set; } = null!;
}
