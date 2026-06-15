using Microsoft.AspNetCore.Mvc.Rendering;

namespace Security.Models
{
    public class RoleDetailsViewModel
    {
        public string RoleName { get; set; }
        public ICollection<string> UsersUitRole { get; set; }
        public List<SelectListItem> SelectUser { get; set; }
        public string SelectedUser { get; set; }
    }
}
