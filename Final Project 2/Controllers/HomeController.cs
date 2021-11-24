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
        Entities3 db = new Entities3();

        [Authorize]
        public ActionResult Index()
        {
            Entities3 db = new Entities3();
            List<Image> ImageDetails = db.Images.ToList();
            List<UserImage> UIDetails = db.UserImages.ToList();
            List<AspNetUser> UserDetails = db.AspNetUsers.ToList();

            var multitable = from i in ImageDetails
                             join ui in UIDetails on i.ImageID equals ui.ImageID into table1
                             from ui in table1.DefaultIfEmpty()
                             join u in UserDetails on ui.UserID equals u.Id into table2
                             from u in table2.DefaultIfEmpty()
                             select new MultiClass { ImageDetails = i, UIDetails = ui, UserDetails = u };
            return View(multitable);
        }

        [Authorize]
        public ActionResult Contact()
        {
            Entities3 db = new Entities3();
            List<Friend> FriendDetails = db.Friends.ToList();
            List<AspNetUser> UserDetails = db.AspNetUsers.ToList();

            var multitable = from f in FriendDetails
                             join u in UserDetails on f.UserID equals u.Id into table1
                             from u in table1.DefaultIfEmpty()
                             select new FriendClass { FriendDetails = f, UserDetails = u };
            return View(multitable);
        }

        [Authorize]
        public ActionResult Requesting()
        {
            Entities3 db = new Entities3();
            List<Image> ImageDetails = db.Images.ToList();
            List<UserImage> UIDetails = db.UserImages.ToList();
            List<AspNetUser> UserDetails = db.AspNetUsers.ToList();

            var multitable = from i in ImageDetails
                             join ui in UIDetails on i.ImageID equals ui.ImageID into table1
                             from ui in table1.DefaultIfEmpty()
                             join u in UserDetails on ui.UserID equals u.Id into table2
                             from u in table2.DefaultIfEmpty()
                             select new MultiClass { ImageDetails = i, UIDetails = ui, UserDetails = u };
            return View(multitable);
        }

        [Authorize]
        public ActionResult Search(string searching)
        {
            return View(db.AspNetUsers.Where(Search => Search.UserName.Contains(searching) || searching == null).ToList());
        }

        public ActionResult About()
        {
            return View();
        }
    }
}

/*[Authorize]
public ActionResult Index(string searching)
{
    string mainconn = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
    SqlConnection sqlconn = new SqlConnection(mainconn);
    string sqlquery = "SELECT * FROM [dbo].[Images]";
    SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
    sqlconn.Open();
    SqlDataAdapter sda = new SqlDataAdapter(sqlcomm);
    DataSet ds = new DataSet();
    sda.Fill(ds);
    List<ImageClass> listdisp = new List<ImageClass>();

    foreach (DataRow data in ds.Tables[0].Rows)
    {
        listdisp.Add(new ImageClass
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
    string sqlquery = "SELECT UserName FROM [dbo].[Friend], [dbo].[AspNetUsers] WHERE AspNetUsers.Id = Friend.FriendId";
    SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
    sqlconn.Open();
    SqlDataAdapter sda = new SqlDataAdapter(sqlcomm);
    DataSet ds = new DataSet();
    sda.Fill(ds);
    List<FriendClass> list = new List<FriendClass>();

    foreach (DataRow data in ds.Tables[0].Rows)
    {
        if (User.Identity.GetUserId() == Convert.ToString(data[sqlquery]))
        {
            list.Add(new FriendClass
            {
                FriendID = Convert.ToString(data["FriendID"])
            });
        }
    }
    sqlconn.Close();

    return View(list);
}

[Authorize]
public ActionResult Requesting()
{
    string mainconn = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
    SqlConnection sqlconn = new SqlConnection(mainconn);
    string sqlquery = "SELECT * FROM [dbo].[Request]";
    SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
    sqlconn.Open();
    SqlDataAdapter sda = new SqlDataAdapter(sqlcomm);
    DataSet ds = new DataSet();
    sda.Fill(ds);
    List<RequestClass> list = new List<RequestClass>();

    foreach (DataRow data in ds.Tables[0].Rows)
    {
        if (User.Identity.GetUserName() == Convert.ToString(data["Username"]))
        {
            list.Add(new RequestClass
            {
                FriendID = Convert.ToString(data["Friend"])
            });
        }
    }
    sqlconn.Close();

    return View(list);
}

[Authorize]
public ActionResult Search()
{
    string mainconn = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
    SqlConnection sqlconn = new SqlConnection(mainconn);
    string sqlquery = "SELECT * FROM [dbo].[AspNetUsers] WHERE UserName LIKE '%search%'";
    SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
    sqlconn.Open();
    SqlDataAdapter sda = new SqlDataAdapter(sqlcomm);
    DataSet ds = new DataSet();
    sda.Fill(ds);
    List<FriendClass> list = new List<FriendClass>();

    foreach (DataRow data in ds.Tables[0].Rows)
    {
        if (User.Identity.GetUserName() != Convert.ToString(data[""]))
        {
            list.Add(new FriendClass
            {
                UserID = Convert.ToString(data[""])
            });
        }
    }
    sqlconn.Close();

    return View(list);
}*/