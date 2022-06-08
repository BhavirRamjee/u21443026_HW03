using System.Collections.Generic;
using System.Web.Mvc;
using System.IO;
using u21443026_HW03FINALFINAL.Models;


namespace u21443026_HW03FINALFINAL.Controllers
{
    public class FilesController : Controller
    {
        // GET: Files
        public ActionResult Index()
        {
            //Fetch the files within folder
            string[] filePaths = Directory.GetFiles(Server.MapPath("~/UploadedFiles/Files/"));

            //Copy files name to the Model collection
            List<FileModel> files = new List<FileModel>();

            foreach (string filePath in filePaths)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(filePath) });
            }
            return View(files);
        }

        public FileResult DownloadFile(string DownloadName) //Method to download the file
        {
            string path = Server.MapPath("~/UploadedFiles/Files/") + DownloadName; //Checks the mapPath to download the file from the correct folder

            byte[] bytes = System.IO.File.ReadAllBytes(path);

            return File(bytes, "application/octet-stream", DownloadName); //Alows for downloading of file attatchments with an unknown file type.
        }

        public ActionResult Delete(string DeleteFile) //Method to delete a file
        {
            string path = Server.MapPath("~/UploadedFiles/Files/") + DeleteFile; //Deletes the file from the desired location
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            System.IO.File.Delete(path);

            return RedirectToAction("Index");
        }
    }
}