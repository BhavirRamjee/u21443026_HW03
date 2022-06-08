using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using u21443026_HW03FINALFINAL.Models;


namespace u21443026_HW03FINALFINAL.Controllers
{
    public class VideosController : Controller
    {
        // GET: Videos
        public ActionResult Index()
        {
            //Fetch the Video within folder
            string[] filePaths = Directory.GetFiles(Server.MapPath("~/UploadedFiles/Videos/"));

            //Copy video name to the Model collection
            List<FileModel> files = new List<FileModel>();

            foreach (string filePath in filePaths)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(filePath) });
            }
            return View(files);
        }

        public FileResult DownloadFile(string DownloadVideoName) //Method to download the video
        {
            string path = Server.MapPath("~/UploadedFiles/Videos/") + DownloadVideoName; //Checks the mapPath to download the video from the correct folder

            byte[] bytes = System.IO.File.ReadAllBytes(path);

            return File(bytes, "application/octet-stream", DownloadVideoName); //Alows for downloading of video attatchments with an unknown file type.
        }

        public ActionResult Delete(string DeleteVideo) //Method to delete a video from the list
        {
            string path = Server.MapPath("~/UploadedFiles/Videos/") + DeleteVideo;  //Deletes the video from the desired location
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            System.IO.File.Delete(path);

            return RedirectToAction("Index");
        }
    }
}