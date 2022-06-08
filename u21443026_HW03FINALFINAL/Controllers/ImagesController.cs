using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using u21443026_HW03FINALFINAL.Models;


namespace u21443026_HW03FINALFINAL.Controllers
{
    public class ImagesController : Controller
    {
        // GET: Images
        public ActionResult Index()
        {
            //Fetch the Image within folder
            string[] filePaths = Directory.GetFiles(Server.MapPath("~/UploadedFiles/Images/"));

            //Copy image name to the Model collection
            List<FileModel> files= new List<FileModel>();

            foreach (string filePath in filePaths)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(filePath) });
            }
            return View(files);
        }

        public FileResult DownloadFile(string DownloadImageName) //Method to download the image
        {
            string path = Server.MapPath("~/UploadedFiles/Images/") + DownloadImageName;  //Checks the mapPath to download the image from the correct folder

            byte[] bytes = System.IO.File.ReadAllBytes(path);

            return File(bytes, "application/octet-stream", DownloadImageName); //Alows for downloading of image attatchments with an unknown file type.
        }

        public ActionResult Delete(string DeleteImage) //Method to delete an image from the list
        {
            string path = Server.MapPath("~/UploadedFiles/Images/") + DeleteImage; //Deletes the image from the desired location
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            System.IO.File.Delete(path);

            return RedirectToAction("Index");
        }
    }
}