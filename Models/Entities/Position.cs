namespace TyeBank.Models.Entities;

public partial class Position
{
    public Guid PositionId { get; set; }

    public string? PositionName { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
