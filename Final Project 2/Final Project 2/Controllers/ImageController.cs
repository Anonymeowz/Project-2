using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Final_Project_2.Models;

namespace Final_Project_2.Controllers
{
    public class ImageController : Controller
    {
        [HttpPost]
        public ActionResult Add(Image imageModel)
        {
            string fileName = Path.GetFileNameWithoutExtension(imageModel.ImageFile.FileName);
            string extension = Path.GetExtension(imageModel.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            imageModel.ImageLink = "~/Images/" + fileName;
            fileName = Path.Combine(Server.MapPath("~Images"), fileName);

            imageModel.ImageFile.SaveAs(fileName);
            using (Entities3 db = new Entities3())
            {
                db.Images.Add(imageModel);
                db.SaveChanges();
            }
            ModelState.Clear();
            return View();
        }

        [HttpGet]
        public ActionResult View(int id)
        {
            Image imageModel = new Image();

            using (Entities3 db = new Entities3())
            {
                imageModel = db.Images.Where(x => x.ImageID == id).FirstOrDefault();
            }

            return View(imageModel);
        }
    }
}