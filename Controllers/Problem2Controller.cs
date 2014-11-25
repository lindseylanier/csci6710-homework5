using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.SessionState;
using System.Web.Http;


namespace csci6710_homework5.Controllers
{
    // http://stackoverflow.com/questions/21999409/web-api-2-session

    public class Problem2Controller : ApiController
    {
        HttpSessionState session = HttpContext.Current.Session;
        public int calculator = 0;        

        // GET: return the value of the calculator
        public int Get()
        {
            if(session["calc"] != null)
            {
                return (int)session["calc"];
            }
            else
            {
                session["calc"] = 0;
                return (int)session["calc"];
            }
            
        }

        // POST: Set calculator equal to the parameter value
        public int Post([FromUri]int num)
        {
            if (session["calc"] != null)
            {
                session["calc"] = num;
                return (int)session["calc"];
            }
            else
            {
                session["calc"] = num;
                return (int)session["calc"];
            }
        }

        // POST: Add the parameter value to the current value of calculator
        public int Add([FromUri]int num)
        {
            if (session["calc"] != null)
            {
                session["calc"] = (int)session["calc"] + num;
                return (int)session["calc"];
            }
            else
            {
                session["calc"] = 0 + num;
                return (int)session["calc"];
            }
        }

        // POST: Multiply the parameter value to the current value of calculator
        public int Times([FromUri]int num)
        {
            if (session["calc"] != null)
            {
                session["calc"] = (int)session["calc"] * num;
                return (int)session["calc"];
            }
            else
            {
                session["calc"] = 0 + num;
                return (int)session["calc"];
            }
        }

        // DELETE: Set calculator back to 0
        public int Delete()
        {
            if (session["calc"] != null)
            {
                session["calc"] = 0;
                return (int)session["calc"];
            }
            else
            {
                session["calc"] = 0;
                return (int)session["calc"];
            }
        }

    }
}
