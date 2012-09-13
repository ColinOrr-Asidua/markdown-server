using MarkdownServer.Models;
using MarkdownSharp;
using System.IO;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace MarkdownServer.Controllers
{
    public class ServerController : Controller
    {
        //
        // GET: /path_to_markdown.md

        public ActionResult Serve(string path)
        {
            var directory = Server.MapPath("~/App_Data");
            var mappedPath = Path.Combine(directory, path);
            
            //  Transform the markdown
            var transformer = new Markdown();
            var markdown = System.IO.File.ReadAllText(mappedPath);
            var html = transformer.Transform(markdown);

            //  Load the document's metadata
            var document = new Document
            {
                Path  = path,
                Title = retrieveTitle(path),
                Html  = html,
            };

            //  Add the navigation links
            var directoryIndex = directory.Length + 1;  //  Used to strip off the root directory
            foreach (var link in Directory.GetFiles(directory))
            {
                var relativeLink = link.Substring(directoryIndex, link.Length - directoryIndex);
                document.Navigation.Add(relativeLink, retrieveTitle(relativeLink));
            }

            return View(document);
        }

        /// <summary>
        /// Retrieves the title for the file at a given path.
        /// </summary>
        private static string retrieveTitle(string path)
        {
            //  Remove the file extension and any non-alphabetic characters from the start
            var fileName = Path.GetFileNameWithoutExtension(path);
            return Regex.Replace(fileName, @"^[^A-z]*", "");
        }
    }
}
