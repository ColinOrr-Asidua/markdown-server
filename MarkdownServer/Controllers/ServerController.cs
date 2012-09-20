using MarkdownDeep;
using MarkdownServer.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace MarkdownServer.Controllers
{
    public class ServerController : Controller
    {
        #region Fields
        /// <summary>
        /// Defines the extensions that are supported by the server.
        /// </summary>
        private readonly string[] EXTENSIONS = new [] { "md", "feature" };

        #endregion

        //
        // GET: /path_to_markdown.md

        public ActionResult Serve(string path)
        {
            if (path == null) path = links.First();
            var mappedPath = Path.Combine(directory, path);
            var extension  = Path.GetExtension(path).TrimStart('.');

            if (EXTENSIONS.Contains(extension))
            {
                //  Load the document metadata
                var document = new Document
                {
                    Path       = path,
                    Title      = retrieveTitle(path),
                    Navigation = buildNavigation(),
                };

                //  Generate the HTML
                switch (extension)
                {
                    case "md" : document.Html = transformMarkdown(mappedPath);          break;
                    default   : document.Html = System.IO.File.ReadAllText(mappedPath); break;
                }

                return View(extension, document);
            }
            else
            {
                //  Serve the file directly
                var mimeType = lookupMimeType(Path.GetExtension(path));
                return File(mappedPath, mimeType);
            }
        }

        #region Helper Properties
        /// <summary>
        /// Gets the root directory of the content.
        /// </summary>
        private string directory
        {
            get { return Server.MapPath("~/App_Data"); }
        }

        /// <summary>
        /// Gets the top-level files to be used as links.
        /// </summary>
        private IEnumerable<string> links
        {
            get
            {
                return from file in Directory.GetFiles(directory)
                       where EXTENSIONS.Contains(Path.GetExtension(file).TrimStart('.'))
                       select Path.GetFileName(file);
            }
        }
        
        #endregion

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
        /// Builds the navigation links.
        /// </summary>
        private IDictionary<string, string> buildNavigation()
        {
            var navigation = new Dictionary<string, string>();

            //  Add the navigation links
            foreach (var link in links)
            {
                navigation.Add(link, retrieveTitle(link));
            }

            return navigation;
        }

        /// <summary>
        /// Looks up a MIME type for a given extension.
        /// </summary>
        private static string lookupMimeType(string extension)
        {
            //  Just use a default MIME type for now
            return "application/octet-stream";
        }

        #endregion
    }
}
