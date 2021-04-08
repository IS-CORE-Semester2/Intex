//using Intex.Models;
using Intex.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intex.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> userManager;

        public AdministrationController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        //get request to create a new role
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        //post request to create a new role
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            //if create role form is filled out correctly, create a new role and send it to the database
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.RoleName
                };

                IdentityResult result = await roleManager.CreateAsync(identityRole);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles", "Administration");
                }
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        //Get request to list all created roles
        [HttpGet]
        public IActionResult ListRoles()
        {
            var roles = roleManager.Roles;
            return View(roles);
        }

        //get request to edit a single role that has already been created
        //also provide early framework to add/remove users from that single role
        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            //pull in the role based on the Id
            var role = await roleManager.FindByIdAsync(id);

            //send an error page if Id is blank
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {id} cannot be found";
                return View("NotFound");
            }

            //create a new model object based on the role Id and Name you pulled in
            var model = new EditRoleViewModel
            {
                Id = role.Id,
                RoleName = role.Name
            };

            //get a list of all users who are a part of the selected role
            foreach(var user in userManager.Users)
            {
                if(await userManager.IsInRoleAsync(user, role.Name))
                {
                    model.Users.Add(user.UserName);
                }
            }

            //send the role name and Id, AND the list of users in that role to the view
            return View(model);
        }

        //post request to edit the role 
        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleViewModel model)
        {
            //pull in the role
            var role = await roleManager.FindByIdAsync(model.Id);

            //send an error page if the role is null
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {model.Id} cannot be found";
                return View("NotFound");
            }

            //edit/update the selected role
            else
            {
                role.Name = model.RoleName;
                var result = await roleManager.UpdateAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles");
                }

                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }               
                return View(model);
            }
        }

        //get request to users in the role based on the selected role
        [HttpGet]
        public async Task<IActionResult> EditUsersInRole(string roleId)
        {
            //save the roleId to viewbag to avoid duplicate data in the next view
            ViewBag.roleId = roleId;

            var role = await roleManager.FindByIdAsync(roleId);

            //error message
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {roleId} cannot be found";
                return View("NotFound");
            }

            //create a new list of user emails which will have a check box next to them
            var model = new List<UserRoleViewModel>();

            //logic to handle creation of next page with checkboxes
            foreach (var user in userManager.Users)
            {
                var userRoleViewModel = new UserRoleViewModel
                {
                    UserId = user.Id,
                    UserName = user.UserName
                };

                //if the "isselected" in the DB is true, make the box checked
                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    userRoleViewModel.IsSelected = true;
                }
                //if the "isselected" in the DB is false, make the box not checked
                else
                {
                    userRoleViewModel.IsSelected = false;
                }

                //use that information you just compiled and add it to the model object
                model.Add(userRoleViewModel);
            }
            //send the view with emails and checkboxes for people who are part of a role
            return View(model);

        }

        //action to send user role update to database
        //handles changes in checked/not checked from the User Role page
        [HttpPost]
        public async Task<IActionResult> EditUsersInRole(List<UserRoleViewModel> model, string roleId)
        {            
            var role = await roleManager.FindByIdAsync(roleId);

            //error page if there is a problem with the role
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {roleId} cannot be found";
                return View("NotFound");
            }

            //loop through each user and find any changes in checked/not checked status
            for(int i = 0; i < model.Count; i++)
            {
                var user = await userManager.FindByIdAsync(model[i].UserId);

                IdentityResult result = null;

                //Make sure the user is not already part of the role. If not, add him to the role
                if (model[i].IsSelected && !(await userManager.IsInRoleAsync(user, role.Name)))
                {
                    result = await userManager.AddToRoleAsync(user, role.Name);
                }

                //if the user is not selected and is part of the role, we want to remove him from the role
                else if (!model[i].IsSelected && await userManager.IsInRoleAsync(user, role.Name))
                {
                    result = await userManager.RemoveFromRoleAsync(user, role.Name);
                }

                //if the user is or is not selected (and that isn't changing in this request), then do nothing
                else
                {
                    continue;
                }

                //if succeeded is true, we know that the if or the else if was successful
                //take one off the count and continue processing
                if (result.Succeeded)
                {
                    if (i < (model.Count - 1))
                        continue;
                    else
                        return RedirectToAction("EditRole", new { Id = roleId });
                }
            }

            //send a redirect to the "Edit Role" page for the user to start over after their changes are updated
            return RedirectToAction("EditRole", new { Id = roleId });
        }
    }
}
