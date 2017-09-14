using HappyMVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HappyMVC.Controllers
{
    public class FileController : Controller
    {
        // GET: File
        public ActionResult Index()
        {
            string[] filenames = Directory.GetFiles(Server.MapPath("~\\TextFiles"));
            List<string> files = new List<string>();
            List<Info> info = new List<Info>();

            foreach (var file in filenames)
            {
                files.Add(Path.GetFileNameWithoutExtension(file));

                var information = new Info();
                information.Path = file;
                information.Name = Path.GetFileNameWithoutExtension(file);
                info.Add(information);
            }
            

            return View(info);
        }

        public ActionResult Content(string id)
        {
            var filename =  "~\\TextFiles\\" + id + ".txt";
            Info fileinfo = new Info();
            fileinfo.Name = id;
            string path = "\\TextFiles\\" + id + ".txt";
            fileinfo.Path =Server.MapPath(path);

            //Read the file as one string.
            System.IO.StreamReader myFile = new System.IO.StreamReader(fileinfo.Path);
            string myString = myFile.ReadToEnd();
            myFile.Close();
            fileinfo.Content = myString;

            return View(fileinfo);
        }

    }
}