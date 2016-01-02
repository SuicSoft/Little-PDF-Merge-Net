
# Little's PDF Merge

[![Join the chat at https://gitter.im/SuicSoft/Little-PDF-Merge](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/SuicSoft/Little-PDF-Merge?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

Free , as fast as a running 🐕 dog ,and open source PDF merger with support for multiple platforms
![Screenshot of Little's PDF Merge](web/lpm.PNG)

Free to use, distrubute and modify 
**You can't sell this, and remove all '*SuicSoft*' stuff if you're using it **

**NO COPYING OF OUR USER INTERFACE IS ALLOWED, IF YOU WANT TO MAKE A MATERIAL DESIGN WINDOWS PROGRAM, CHECK OUT MATERIAL-DESIGN-IN-XAML-TOOLKIT, AND USE IT YOURSELF**
(keep the dog if you like!) - read more in [**LICENSE.md**](License.md) 
<!---Replace developer with correct branch--->
<!---Appveyor build status--->
[![Build status](https://ci.appveyor.com/api/projects/status/79qcnkt3rxxboays?svg=true)](https://ci.appveyor.com/project/SuicSoft/little-pdf-merge)
# SuicSoft. Better Software. Happier PCs
SuicSoft's great **FREEWARE** are **badware** free (free from those annoying stuff...you know)
We've got great PDF Mergers, System Speederupers and Tweakers! Just come to our website! (we don't have much traffic!)
and download the great **GOODWARE**

#Oh! And if you want to see, here's the dog we were talking about!

![The cute and cuddly dog](https://raw.githubusercontent.com/SuicSoft/SuicSoft-Art/master/Suici/Suici%20(Original).png)

I'm Suici. Say that like Sooky. I'm not as popular as Android, Duo or the Octocat, But I'm on the web!
What Am I? I'm a dog, bearded collie puppy! - And I was drawn in Fresh Paint for the Logo - But I'm real!

#How to install this build
The developer branch is updated daily or at least a few times a week.
To install, run the setup.exe file in releases folder . It should be installed on your pc and will be updated each day.

#How do I build it from the source.
It is very easy to do on Windows (tested on Windows 10). To do it, open a git shell and type
```
git clone https://github.com/suicsoft/little-pdf-merge.git
edit the code and stuff here if needed
cd little-pdf-merge
./build.bat
```
You should have a shortcut to Little's PDF Merge on your desktop.
Do not delete the cloned repo because the exe used to run Little's PDF Merge is stored in it.
#How do I use Little's PDF Merge Core
LPM.Core (Little's PDF Merge Core) is a free and open source pdf merger library for C#.NET, VB.NET and other .NET programming languages.

For c#.
```cs
 using (SuicSoft.LittleSoft.LittlesPDFMerge.Core.Combiner comb = new SuicSoft.LittleSoft.LittlesPDFMerge.Core.Combiner())
                    {
                        comb.OutputPath = "youroutputpath";
                        comb.AddFile(System.IO.File.ReadAllBytes("somepath"), null); //Replace null with password as a byte array if needed
                        comb.AddFile(System.IO.File.ReadAllBytes("somepath"), null); //Replace null with password as a byte array if needed
                    }
```

