Appy
====================

Repository for holding Appy - quick desktop apps for web developers! Like PhoneGap, but for the desktop.

# Read This!

* I have not provided a license for this work as of yet (mainly out of laziness).
* If you would like to use this tool for commercial purposes just get in touch with me.
* I will put up a more detailed guide with code-walkthroughs shortly.

# How To Start

* Build the solution in VS 2012 or <a href="https://www.dropbox.com/s/lclj040breddq4a/Appy.0.8.0.zip" target="_blank">download the binaries here</a>. Ensure that your platform config is set to x86 if buidling!
* Run the 'Appy' project or Appy.exe (if you downloaded the binaries).
* Follow the prompts to bootstrap a new project or compile an existing project.

# Developing Your App

* Make changes to the contents of the Site folder - this is basically an HTML5 website and will make up your UI.
* Make changes to the Code folder - this is the logic of your app. Feel free to add more of your own 'controller' classes (note: they don't have to inherit from Controller). In fact, add any class that you need - just make sure it is valid C# code.
* PS. when creating new 'controller' classes - you must import the Appy.Core namespace ('using Appy.Core;').

# Apologies

* I know this is such a poor guide.. I promise to publish something comprehensive very soon. However, if you need help now, send me an email and I will get back to you ASAP.

# Special Thanks

* <a href="https://github.com/chillitom/CefSharp">CefSharp by chillitom</a>
* <a href="https://github.com/Vodurden/Http-Multipart-Data-Parser">Http-Multipart-Data-Parser by Vodurden</a>
* <a href="https://github.com/Antaris/RazorEngine">RazorEngine by Antaris</a>
