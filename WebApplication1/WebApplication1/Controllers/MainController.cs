﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Database;
using WebApplication1.Infrastructure.AuthAbstract;
using WebApplication1.Models;

using Microsoft.Owin;
using System.Security.Claims;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI;
using System.Collections;
using System.Data;

namespace WebApplication1.Controllers
{
    public class MainController : Controller
    {
        private TimchurDatabaseEntities db = new TimchurDatabaseEntities();
        [Authorize]
        [AuthRestriections(Name = "/Main/ApproveMsg")]
        public ActionResult ApproveMsg()
        {
           
            return View();
        }
        // GET: Main
        [Authorize]
        [AuthRestriections(Name = "/Main/MainIndex")]
        public ActionResult MainIndex()
        {
          
            
            return View();
        }
        [Authorize]
        [AuthRestriections(Name = "/Main/TichurSuppCreate")]
        public ActionResult TichurSuppCreate()
        {
          
            return View();

        }

        [Authorize]
        [AuthRestriections(Name = "/Main/TichurExisting")]
        public ActionResult TichurExisting()
        {
          
            return View();

        }
        [Authorize]
        [AuthRestriections(Name = "/Main/MangUsers")]
        public ActionResult MangUsers()
        {

            db = new TimchurDatabaseEntities();
            List<Users> li = db.Users.OrderBy(s=>s.IDCardNumber).ToList();
            
                /** load from database user list **/
                /** transform loaded data into model fit for edit + present **/

                return View(li);
            
        }
        [Authorize]
        [AuthRestriections(Name = "/Main/MangSuppliers")]
        public ActionResult MangSuppliers()
        {
          
            return View();

        }

        [Authorize]
        [AuthRestriections(Name = "/Main/MangAuctions")]
        public ActionResult MangAuctions()
        {
        
            return View();

        }
        [Authorize]
        [AuthRestriections(Name = "/Main/MangClusters")]
        public ActionResult MangClusters()
        {
     
            return View();

        }
        [Authorize]
        [AuthRestriections(Name = "/Main/MangUnits")]
        public ActionResult MangUnits()
        {
           
            return View();

        }
        [Authorize]
        [AuthRestriections(Name = "/Main/UnAuthError")]
        public ActionResult UnAuthError()
        {
            return View();
        }
      
    }
}