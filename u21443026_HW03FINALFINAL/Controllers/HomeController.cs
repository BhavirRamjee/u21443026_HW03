using System.Web;
using System.Web.Mvc;
using System.IO;

namespace u21443026_HW03FINALFINAL.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase files, string radiobutton) 
        {
            if (radiobutton == "Document") //Checks that the user has selected the "document" radiobutton
            {
                var fileName = Path.GetFileName(files.FileName); //This extracts only the file's name
                var path = Path.Combine(Server.MapPath("~/UploadedFiles/Files/"), fileName); //Stores the files inside "~/UploadedFiles/Files/" 
                files.SaveAs(path); //The chose default path for saving
            }

            else if (radiobutton == "Image") //Checks that the user has selected the "image" radiobutton
            {
                var fileName = Path.GetFileName(files.FileName); //This extracts only the file's name
                var path = Path.Combine(Server.MapPath("~/UploadedFiles/Images/"), fileName);  //Stores the files inside "~/UploadedFiles/Images/" 
                files.SaveAs(path); //The chose default path for saving
            }

            else if (radiobutton == "Video") //Checks that the user has selected the "video" radiobutton
            {
                var fileName = Path.GetFileName(files.FileName); //This extracts only the file's name
                var path = Path.Combine(Server.MapPath("~/UploadedFiles/Videos/"), fileName);  //Stores the files inside "~/UploadedFiles/Images/" 
                files.SaveAs(path); //The chose default path for saving
            }
            return RedirectToAction("Index");


        }
    }
}