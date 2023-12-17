namespace TyeBank.Models.Entities;

public partial class Department
{
    public Guid DepartmentId { get; set; }

    public string DepartmentName { get; set; } = null!;

    public Guid DepartmentManagerUserId { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
