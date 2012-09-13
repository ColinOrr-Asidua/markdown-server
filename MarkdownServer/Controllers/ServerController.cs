using MarkdownSharp;
using System.Web.Mvc;

namespace MarkdownServer.Controllers
{
    public class ServerController : Controller
    {
        //
        // GET: /path_to_markdown.md

        public ActionResult Serve(string path)
        {
            var mappedPath = Server.MapPath("~/App_Data/" + path);

            //  Transform the markdown
            var transformer = new Markdown();
            var markdown = System.IO.File.ReadAllText(mappedPath);
            var html = transformer.Transform(markdown);

            ViewBag.Title = path;
            return View((object)html);
        }
    }
}
