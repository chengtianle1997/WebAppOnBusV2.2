using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppOnBus
{
    /// <summary>
    /// Summary description for ActionHandler
    /// </summary>
    public class ActionHandler : IHttpHandler
    {
        public static bool SwitchOn = false;

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            string action = context.Request.Params["action"].ToLower(); 
            switch(action)
            {
                case "startcamera":
                    StartCamera(context);
                    break;
            }
        }

        public void StartCamera(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Clear();
            if (SwitchOn)
            {
                SwitchOn = false;
                context.Response.Write(true);
            }
            else if (!SwitchOn)
            {
                SwitchOn = true;
                context.Response.Write(false);
            }
            context.Response.End();
            
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}