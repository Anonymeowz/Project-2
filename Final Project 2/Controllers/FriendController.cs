using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System.Linq;
using Final_Project_2.Models;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNet.Identity;

namespace Final_Project_2.Controllers
{
    public class FriendController : Controller
    {
        // GET: Friend
        public ActionResult Contact()
        {
            return View();
        }
    }
}