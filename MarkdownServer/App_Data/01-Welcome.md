Welcome to the Markdown Server
==============================

This is a simple [ASP.NET MVC][1] application that serves up [Markdown][2] (powered 
by [MarkdownDeep][3]).  Visit the [features](02-Features.md) section to find out 
what's new and what's next.

Markdown
--------
[Markdown][2] is a lightweight markup language, originally created by John Gruber 
and Aaron Swartz:

> Markdown is a text-to-HTML conversion tool for web writers. Markdown allows you to 
> write using an easy-to-read, easy-to-write plain text format, then convert it to 
> structurally valid XHTML (or HTML).

The syntax is focussed on being as readable as possible, so ideally it should be
publishable as-is, as plain text, without looking like it’s been marked up with tags 
or formatting instructions:

    A First Level Header
    ====================

    A Second Level Header
    ---------------------

    Now is the time for all *good men* to come to
    the aid of their country. This is just a regular 
    paragraph with emphasis on the text "good men".

See the [Markdown Website][4] for a full details about the syntax.  The server also
supports [Markdown Extra][8] syntax.

We love Markdown, so does [GitHub][5] and [Stack Overflow][6].  We intend to use a 
lot more of it in the future.

Managing Content
----------------
To add content to the server, simply place your Markdown files (\*.md) in the 
*App_Data* folder of the website.

### Navigation

The server will scan the *App_Data* folder and add a link in the main navigation
menu for each file it finds.  

The links are ordered alphabetically.  If you wish to impose some explit ordering,
then you can add extra numbers to the start of the file names:

    /App_Data/01 - Welcome.md
    /App_Data/02 - Features.md

The server will place the links in the correct order, but will strip any 
non-alphabetic characters from the start of the file names in the navigation menu.

**Note:** The server will support subfolders, however, only Markdown files found in 
the root of *App_Data* will be added to the navigation menu.  So you'll have to 
provide links explitly in your Markdown documentation if you wish to use subfolders.

### Document Outlines

The server will automatically add an HTML5 document outline for each document. Here
is a good [article][7] that explains the document outlining algorithm.

### Branding

To change the name of the server, edit the *SiteTitle* setting in 
**Branding/branding.config**:

    <setting name="SiteTitle" serializeAs="String"><value>My Site</value> </setting>

You can also provide an alternate **Branding/favicon.ico** which will appear in the
navigation bar and website icon.

[1]: http://www.asp.net/mvc/mvc4
[2]: http://daringfireball.net/projects/markdown
[3]: http://www.toptensoftware.com/markdowndeep
[4]: http://daringfireball.net/projects/markdown/syntax
[5]: http://github.github.com/github-flavored-markdown
[6]: http://stackoverflow.com/editing-help
[7]: http://coding.smashingmagazine.com/2011/08/16/html5-and-the-document-outlining-algorithm
[8]: http://michelf.ca/projects/php-markdown/extra