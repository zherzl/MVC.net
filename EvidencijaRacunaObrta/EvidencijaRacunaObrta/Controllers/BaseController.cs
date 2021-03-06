﻿using EvidencijaRacunaObrta.Models;
using EvidencijaRacunaObrta.Models.ObrtModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EvidencijaRacunaObrta.Controllers
{
    public class BaseController : Controller
    {

        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public int CurrentUserId { get { return int.Parse(User.Identity.GetUserId()); } }



        public List<string> GetCurrentUserRoles()
        {
            List<string> rolesRes = new List<string>();
            var roles = UserManager.GetRolesAsync(CurrentUserId);

            foreach (var item in roles.Result)
            {
                rolesRes.Add(item);
            }

            return rolesRes;
        }

        public EvidencijaContext db;
        public BaseController()
        {
            db = new EvidencijaContext();
        }

        public void DisplayError(string error)
        {
            ViewBag.error = error;
        }
    }

}