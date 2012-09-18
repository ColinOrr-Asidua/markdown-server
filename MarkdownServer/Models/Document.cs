using System.Collections.Generic;

namespace MarkdownServer.Models
{
    /// <summary>
    /// Represents a document to be served.
    /// </summary>
    public class Document
    {
        /// <summary>
        /// Gets or sets the relative path to the document on the server.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Gets or sets the human-friendly title of the document.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the HTML of the document to be served.
        /// </summary>
        public string Html { get; set; }

        /// <summary>
        /// Gets or sets a list of links to other available documents, indexed by their relative paths.
        /// </summary>
        public IDictionary<string,string> Navigation { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Document()
        {
            Navigation = new Dictionary<string, string>();
        }
    }
}