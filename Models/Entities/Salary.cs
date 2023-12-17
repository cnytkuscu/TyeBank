namespace TyeBank.Models.Entities;

public partial class Salary
{
    public Guid SalaryId { get; set; }

    public decimal? SalaryAmount { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
