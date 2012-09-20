Markdown Server
===============

This is a simple [ASP.NET MVC][1] application that serves up [Markdown][2] (powered by [MarkdownSharp][3]).

Getting Started
---------------
Install [Git][4], [Iron Ruby][5] and **Visual Studio 2012** on your machine (a development VM is available on the Asidua VM library).
Then run the following commands:

    # Download the code
    git clone https://github.com/ColinOrr-Asidua/markdown-server.git
    
    # Download the build tools
    igem install rake
    igem install albacore
    
    # Build the web application
    cd markdown-server
    rake

**Note**: the application can also be built and run from Visual Studio (*MarkdownServer.sln*).

To add extra content, simply place your Markdown files (\*.md) in the *App_Data* folder.  Visit the [features](markdown-server/blob/master/MarkdownServer/App_Data/02-Features.md) section to find out what's new and what's next.

[1]: http://www.asp.net/mvc/mvc4
[2]: http://daringfireball.net/projects/markdown
[3]: http://code.google.com/p/markdownsharp
[4]: https://help.github.com/articles/set-up-git
[5]: http://www.ironruby.net