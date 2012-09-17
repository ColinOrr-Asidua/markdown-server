using MarkdownDeep;
using MarkdownServer.Models;
using Microsoft.Web.Administration;
using System.IO;
using System.Linq;
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

            if (path.EndsWith(".md"))
            {
                //  Load the document
                var document = new Document
                {
                    Path  = path,
                    Title = retrieveTitle(path),
                    Html  = transformMarkdown(mappedPath),
                };

                //  Add the navigation links
                var directoryIndex = directory.Length + 1;  //  Used to strip off the root directory
                foreach (var link in Directory.GetFiles(directory, "*.md"))
                {
                    var relativeLink = link.Substring(directoryIndex, link.Length - directoryIndex);
                    document.Navigation.Add(relativeLink, retrieveTitle(relativeLink));
                }

                return View(document);
            }
            else
            {
                //  Serve the file directly
                var mimeType = lookupMimeType(Path.GetExtension(path));
                return File(mappedPath, mimeType);
            }
        }

        #region Helper Methods
        /// <summary>
        /// Retrieves the title for the file at a given path.
        /// </summary>
        private static string retrieveTitle(string path)
        {
            //  Remove the file extension and any non-alphabetic characters from the start
            var fileName = Path.GetFileNameWithoutExtension(path);
            return Regex.Replace(fileName, @"^[^A-z]*", "");
        }

        /// <summary>
        /// Loads and transforms a Markdown file into HTML.
        /// </summary>
        private static string transformMarkdown(string mappedPath)
        {
            var transformer = new Markdown
            {
                AutoHeadingIDs = true,
                ExtraMode      = true,
            };

            var markdown = System.IO.File.ReadAllText(mappedPath);
            return transformer.Transform(markdown);
        }

        /// <summary>
        /// Looks up a MIME type for a given extension.
        /// </summary>
        private static string lookupMimeType(string extension)
        {
            using (var serverManager = new ServerManager())
            {
                var mimeType = "application/octet-stream";

                //  Lookup IIS for the MIME type
                var mimeMap = serverManager
                    .GetApplicationHostConfiguration()
                    .GetSection("system.webServer/staticContent")
                    .GetCollection();

                var mapping = mimeMap.FirstOrDefault(a => a["fileExtension"] as string == extension);
                if (mapping != null) mimeType = (string)mapping["mimeType"];
                return mimeType;
            }
        }

        #endregion
    }
}
