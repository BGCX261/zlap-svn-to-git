<%@ Application Language="C#" %>

<script runat="server">
    
    void Application_BeginRequest(object sender, EventArgs e)
    {
        //Lấy về url để xử lý. Chủ yếu phục vụ cho link detail product:
        try
        {
            string url = Request.Url.ToString().ToLower();
            if (url.Contains("-dp-") && (url.Contains(".aspx") || url.Contains(".html")))
            {
                //string id = url.Substring(url.LastIndexOf('/')).Replace("/", "");
                int index = url.LastIndexOf("-dp-");
                string subvalue = "";
                if (index >= 0)
                {
                    subvalue = url.Substring(index + 4, url.Length - 1 - index - 4);
                }
                //url.Substring(url.LastIndexOf("-dp-"), url.Length - 1);
                //url.Substring(
                string[] arr = new string[] { "", "" };
                if (subvalue.Length > 0)
                {
                    arr = subvalue.Split('.');
                }
                //id = arr[arr.Length - 2];
                Context.RewritePath("~/Default.aspx?menu=dp&id=" + arr[0], true);
            }
            else if (url.Contains("-dpda-") && (url.Contains(".aspx") || url.Contains(".html")))
            {
                //string id = url.Substring(url.LastIndexOf('/')).Replace("/", "");
                int index = url.LastIndexOf("-dpda-");
                string subvalue = "";
                if (index >= 0)
                {
                    subvalue = url.Substring(index + 6, url.Length - 1 - index - 6);
                }
                //url.Substring(url.LastIndexOf("-dp-"), url.Length - 1);
                //url.Substring(
                string[] arr = new string[] { "", "" };
                if (subvalue.Length > 0)
                {
                    arr = subvalue.Split('.');
                }
                //id = arr[arr.Length - 2];
                Context.RewritePath("~/Default.aspx?menu=dpda&id=" + arr[0], true);
            }else if (url.Contains("-dc-") && (url.Contains(".aspx") || url.Contains(".html")))
            {
                //string id = url.Substring(url.LastIndexOf('/')).Replace("/", "");
                int index = url.LastIndexOf("-dc-");
                string subvalue = "";
                if (index >= 0)
                {
                    subvalue = url.Substring(index + 4, url.Length - 1 - index - 4);
                }
                //url.Substring(url.LastIndexOf("-dp-"), url.Length - 1);
                //url.Substring(
                string[] arr = new string[] { "", "" };
                if (subvalue.Length > 0)
                {
                    arr = subvalue.Split('.');
                }
                //id = arr[arr.Length - 2];
                Context.RewritePath("~/Default.aspx?menu=dc&id=" + arr[0], true);
            }
            else if (url.Contains("?menu") && url.Contains(".html"))
            {
                string[] arr = new string[] { "", "" };
                arr = url.Split('?');
                Context.RewritePath("~/default.aspx?" + arr[1], true);
            }
            else if (url.Contains(".html"))
            {
                Context.RewritePath("~/default.aspx", true);
            }
        }
        catch
        {
            Context.RewritePath("~/default.aspx");
        }
    }
    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup
        Application["numberonline"] = 0;

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started
        try
        {
            int num_online = int.Parse(Application["numberonline"].ToString());
            num_online++;
            Application["numberonline"] = num_online;
        }
        catch (Exception ex)
        {
            Console.Write(ex.ToString());
        }
    }

    void Session_End(object sender, EventArgs e) 
    {
        try
        {
            int num_online = (int)Application["numberonline"];
            if (num_online > 0)
            {
                num_online--;
            }
            Application["numberonline"] = num_online;
        }
        catch
        {
        }
    }
</script>
