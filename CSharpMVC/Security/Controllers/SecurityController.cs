using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Security.Models;

namespace Security.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SecurityController:Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public SecurityController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Userbeheer()
        {
            var alleUsers = userManager.Users;
            return View(alleUsers);
        }

        public IActionResult Rolebeheer()
        {
            var alleRoles = roleManager.Roles;
            return View(alleRoles);
        }

        public async Task<IActionResult> VerwijderUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> VerwijderUserDoorvoeren(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user != null)
                await userManager.DeleteAsync(user);
            return RedirectToAction(nameof(Userbeheer));
        }

        public async Task<IActionResult> UserDetails(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            ViewBag.userid = id;
            ViewBag.username = user.UserName;
            var roleNamesVoorUser = await userManager.GetRolesAsync(user);
            return View(roleNamesVoorUser);
        }

        public async Task<IActionResult> VerwijderRoleForMember(string userid, string rolenaam)
        {
            var user = await userManager.FindByIdAsync(userid);
            ViewBag.Role = rolenaam;
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> VerwijderenRoleForMemberDoorvoeren(string userid, string rolename)
        {
            var user = await userManager.FindByIdAsync(userid);
            if (user != null)
                await userManager.RemoveFromRoleAsync(user, rolename);
            return RedirectToAction(nameof(UserDetails), new { id = userid });
        }

        public async Task<IActionResult> VerwijderRole(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            return View(role);
        }

        [HttpPost]
        public async Task<IActionResult> VerwijderRoleDoorvoeren(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            if (role != null)
                await roleManager.DeleteAsync(role);
            return RedirectToAction("Rolebeheer");
        }

        public async Task<IActionResult> RoleDetails(string rolename)
        {
            RoleDetailsViewModel vm = new RoleDetailsViewModel
            {
                RoleName = rolename,
                UsersUitRole = new List<string>(),
                SelectUser = new List<SelectListItem>()
            };

            foreach (var user in userManager.Users)
                if (await userManager.IsInRoleAsync(user, rolename))
                    vm.UsersUitRole.Add(user.UserName);
                else
                    vm.SelectUser.Add(new SelectListItem { Text = user.UserName, Value = user.UserName });

            return View(vm);
        }

        public async Task<IActionResult> VerwijderMemberFromRole(string usernaam, string rolename)
        {
            var user = await userManager.FindByNameAsync(rolename);
            ViewBag.Role = rolename;
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> VerwijderMemberFromRoleDoorvoeren(string userid, string rolename)
        {
            var user = await userManager.FindByIdAsync(userid);
            await userManager.RemoveFromRoleAsync(user, rolename);
            return RedirectToAction(nameof(RoleDetails),
            new { rolename = rolename });
        }

        [HttpPost]
        public async Task<IActionResult> MemberToevoegen(string rolename, string SelectedUser)
        {
            var user = await userManager.FindByNameAsync(SelectedUser);
            if (user != null)
                await userManager.AddToRoleAsync(user, rolename);
            return RedirectToAction(nameof(RoleDetails),
            new { rolename = rolename });
        }

        [HttpGet]
        public IActionResult RoleToevoegen()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RoleToevoegen(IdentityRole role)
        {
            if (this.ModelState.IsValid)
            {
                await roleManager.CreateAsync(role);
                return RedirectToAction(nameof(Rolebeheer));
            }
            else
                return View(role);
        }
    }
}
