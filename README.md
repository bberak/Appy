Appy
====================

Repository for holding Appy - quick desktop apps for web developers! Like PhoneGap, but for the desktop.

# Read This!

* I have not provided a license for this work as of yet (mainly out of laziness).
* If you would like to use this tool for commercial purposes just get in touch with me.
* I will put up a more detailed guide with code-walkthroughs shortly.

# What's the point of all this?

* Build your desktop apps using the MVC pattern. Allows for better testability and maintainability.
* Allow designers to transfer their web development skills to the desktop.
* Develop fluent user interfaces using HTML, CSS and JavaScript rather than WPF (XAML) and WinForms.

# How To Start

* Build the solution in VS 2012 or <a href="https://www.dropbox.com/s/248qgbdx0780wou/Appy-0.9.0.zip" target="_blank">download the binaries here</a>. Ensure that your platform config is set to x86 if buidling!
* Run the 'Appy' project or Appy.exe (if you downloaded the binaries).
* Follow the prompts to bootstrap a new project or compile an existing project.

# Developing Your App

* Make changes to the contents of the Site folder - this is basically an HTML5 website and will make up your UI.
* Make changes to the Code folder - this is the logic of your app. Feel free to add more of your own Nancy modules. The <a href="https://github.com/NancyFx/Nancy/wiki/Documentation" target="_blank">Nancy wiki</a> is a great place to learn how to code you backend API using Nancy.
* PS. when creating new 'Module' classes - you must import the Nancy namespace ('using Nancy;').

# Apologies

* I know this is such a poor guide.. I promise to publish something comprehensive very soon. However, if you need help now, <a href="mailto:bberak@gmail.com">send me an email</a> and I will get back to you ASAP.

# Special Thanks

* <a href="https://github.com/cefsharp/CefSharp">The CefSharp Team</a>
* <a href="https://github.com/NancyFx/Nancy">The Nancy Project</a>
