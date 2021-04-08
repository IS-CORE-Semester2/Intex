//using Intex.Models;
using Intex.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intex.Controllers
{
    //Only allow authorized ADMINS to access actions in this controller
    [Authorize(Roles = "Admin")]
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly ILogger<AdministrationController> logger;

        public AdministrationController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, ILogger<AdministrationController> logger)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.logger = logger;
        }

        //post request to delete a user from the DB
        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id)
        {
            //get the user that we want to delete from the DB
            var user = await userManager.FindByIdAsync(id);

            //send an error page if the user doesn't exist
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return View("NotFound");
            }

            //use an async method to delete the selected user from the DB 
            else
            {
                var result = await userManager.DeleteAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListUsers");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View("ListUsers");
            }
        }

        //Get Request to edit the roles a specific user is part of
        [HttpGet]
        public async Task<IActionResult> ManageUserRoles(string userId)
        {
            //Get the userId that was passed through the route
            ViewBag.userId = userId;

            //get the user from the DB based on the Id
            var user = await userManager.FindByIdAsync(userId);

            //send custom error page if null
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return View("NotFound");
            }

            //make a list and store it in "model"
            var model = new List<UserRolesViewModel>();

            //loop through each role that a user has and put it in the "model" object
            foreach (var role in roleManager.Roles)
            {
                var userRolesViewModel = new UserRolesViewModel
                {
                    RoleId = role.Id,
                    RoleName = role.Name
                };

                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    userRolesViewModel.IsSelected = true;
                }
                else
                {
                    userRolesViewModel.IsSelected = false;
                }

                model.Add(userRolesViewModel);
            }

            return View(model);
        }

        //post action to update the roles (checked or unchecked) of a specific user
        [HttpPost]
        public async Task<IActionResult> ManageUserRoles(List<UserRolesViewModel> model, string userId)
        {
            //get the user from the DB based on Id
            var user = await userManager.FindByIdAsync(userId);

            //send error page if null
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return View("NotFound");
            }

            //get list of all roles that the User selected belongs to
            var roles = await userManager.GetRolesAsync(user);

            //remove ALL roles from the user. Even if they are meant to keep them. They will be added back later on
            var result = await userManager.RemoveFromRolesAsync(user, roles);

            //error message for end user to see if errors happen when trying to remove roles from user
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot remove user existing roles");
                return View(model);
            }

            //add the specific roles that the user needs to have on their account
            result = await userManager.AddToRolesAsync(user, model.Where(x => x.IsSelected).Select(y => y.RoleName));

            //error in case any roles cannot be added
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot add selected roles to user");
                return View(model);
            }

            //send back the edit user page for the user that was already selected
            return RedirectToAction("EditUser", new { Id = userId });
        }

        //get request to list all users
        [HttpGet]
        public IActionResult ListUsers()
        {
            var users = userManager.Users;
            return View(users);
        }

        //get request to edit a specific user
        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            //get the selected user from the database by his/her Id
            var user = await userManager.FindByIdAsync(id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return View("NotFound");
            }

            //returns list of all claims and all roles of the user that is passed as a parameter
            var userClaims = await userManager.GetClaimsAsync(user);
            var userRoles = await userManager.GetRolesAsync(user);

            //prepare a model to send to the next page. Model will hold properties about the user you are editing
            var model = new EditUserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                Claims = userClaims.Select(c => c.Value).ToList(),
                Roles = userRoles
            };

            return View(model);
        }

        //Post request to edit the user that the user was previously editing
        [HttpPost]
        public async Task<IActionResult> EditUser(EditUserViewModel model)
        {
            //get the user based on his Id from the DB
            var user = await userManager.FindByIdAsync(model.Id);

            //Send an error page is something is wrong
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {model.Id} cannot be found";
                return View("NotFound");
            }

            //update the user's information in the DB
            else
            {
                user.Email = model.Email;
                user.UserName = model.UserName;

                var result = await userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListUsers");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(model);
            }
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

        //Post request to delete a role from the DB
        [HttpPost]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = await roleManager.FindByIdAsync(id);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {id} cannot be found";
                return View("NotFound");
            }
            else
            {
                //create custom error message for DB errors
                try
                {
                    var result = await roleManager.DeleteAsync(role);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("ListRoles");
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                    return View("ListRoles");
                }

                //log error and send custom error validation
                catch(DbUpdateException ex)
                {
                    logger.LogError($"Error deleting role {ex}");

                    ViewBag.ErrorTitle = $"{role.Name} role is in use";
                    ViewBag.ErrorMessage = $"{role.Name} role cannot be deleted as there are users in this role. If you want to delete this role, please remove the users from the role and then try to delete";
                    return View("Error");
                }

            }
        }

    }
}
