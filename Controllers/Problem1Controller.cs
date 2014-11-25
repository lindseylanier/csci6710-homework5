using csci6710_homework5.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Web;
using System.Web.Mvc;

namespace csci6710_homework5.Controllers
{
    public class Problem1Controller : Controller
    {
        // GET: Problem1
        public ActionResult Index(string searchString)
        {
            ISBNModel isbnModel = new ISBNModel();
            if (!String.IsNullOrEmpty(searchString))
            {
                try
                {
                    //Test ISBN: 0596002815, 0849948487
                    var client = new WebClient();
                    string data = client.DownloadString(string.Format("http://xisbn.worldcat.org/webservices/xid/isbn/{0}?method=getMetadata&format=json&fl=*", searchString));

                    JObject results = JObject.Parse(data);
                    if((string)results["stat"] == "ok")
                    {
                        foreach (var result in results["list"])
                        {                        
                            isbnModel.title = (string)result["title"];
                            isbnModel.edition = (string)result["ed"];
                            isbnModel.publication_year = (string)result["year"];
                        }
 
                        ViewBag.ISBN = isbnModel;
                    }
                    else
                    {
                        ViewBag.Error = "Title not found.";
                    }
                }
                catch (System.Runtime.Serialization.SerializationException e)
                {
                    ViewBag.Error = "Title not found.";
                }
            }

            return View(isbnModel);
        }

        // GET: /Problem1/Welcome/
        public string Welcome()
        {
            return "This is my Welcome message";
        }

        
    }
}