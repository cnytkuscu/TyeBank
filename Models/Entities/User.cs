using System.ComponentModel.DataAnnotations.Schema;

namespace TyeBank.Models.Entities;

public partial class User
{
    public Guid UserId { get; set; }

    public string? UserName { get; set; }

    public string? UserPasswordHash { get; set; }

    public string? UserEmail { get; set; }

    public string? UserTelephoneNumber { get; set; }

    public byte? UserGender { get; set; }
    public DateOnly? UserBirthDate { get; set; }

    public string? UserTckno { get; set; }

    public string? UserFirstName { get; set; }

    public string? UserLastName { get; set; }

    public DateOnly? UserRegistrationDate { get; set; }

    public DateTime? UserLastLogin { get; set; }

    public virtual ICollection<Employee> EmployeeEmployeeSuperiorUsers { get; set; } = new List<Employee>();

    public virtual ICollection<Employee> EmployeeEmployeeUsers { get; set; } = new List<Employee>();
}
