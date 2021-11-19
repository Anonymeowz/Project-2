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
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            string mainconn = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "SELECT * FROM [dbo].[Images]";
            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            sqlconn.Open();
            SqlDataAdapter sda = new SqlDataAdapter(sqlcomm);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            List<DisplayClass> listdisp = new List<DisplayClass>();

            foreach (DataRow data in ds.Tables[0].Rows)
            {
                listdisp.Add(new DisplayClass
                {
                    ImageLink = Convert.ToString(data["ImageLink"]),
                    ImageName = Convert.ToString(data["ImageName"]),
                    ImageGeo = Convert.ToString(data["ImageGeo"]),
                    ImageDesc = Convert.ToString(data["ImageDesc"])

                });
            }

            sqlconn.Close();

            return View(listdisp);
        }

        public ActionResult About()
        {
            return View();
        }

        [Authorize]
        public ActionResult Contact()
        {
            string mainconn = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "SELECT * FROM [dbo].[Friend]";
            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            sqlconn.Open();
            SqlDataAdapter sda = new SqlDataAdapter(sqlcomm);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            List<FriendClass> list = new List<FriendClass>();

            foreach (DataRow data in ds.Tables[0].Rows)
            {
                if (User.Identity.GetUserName() == Convert.ToString(data["Username"]))
                {
                    list.Add(new FriendClass
                    {
                        Friendname = Convert.ToString(data["Friendname"])
                    });
                }
            }
            sqlconn.Close();

            return View(list);
        }

        [Authorize]
        public ActionResult Requesting()
        {
            return View();
        }

    }
}