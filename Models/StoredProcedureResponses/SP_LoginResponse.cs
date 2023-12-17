using TyeBank.Models.Base_Models;

namespace TyeBank.Models.StoredProcedureResponses
{
    public class SP_LoginResponse : SPResponse
    {
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserTelephoneNumber { get; set; }
        public bool UserGender { get; set; }
        public DateOnly? UserBirthDate { get; set; }
        public string UserTCKNo { get; set; } // Will be masked
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public DateTime? UserLastLogin { get; set; }
    }
}
