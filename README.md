
# Little-s-PDF-Merge
Free , open source and fast PDF merger using Google Material Design, WPF and C# .Net
<img src="https://raw.githubusercontent.com/SuicSoft/Little-PDF-Merge/master/web/lpm.PNG"></img>
Free to use, distrubute and modify. 
<b>You can't sell this, and remove all '<i>SuicSoft</i>' stuff if you're using it </b>

<b>NO COPYING OF OUR USER INTERFACE IS ALLOWED, IF YOU WANT TO MAKE A MATERIAL DESIGN WINDOWS PROGRAM, CHECK OUT MATERIAL-DESIGN-IN-XAML-TOOLKIT, AND USE IT YOURSELF</B>
(keep the dog if you like!) - read more in <b>LICENSE.md</b>

# SuicSoft. Better Software. Happier PCs
SuicSoft's great <b>FREEWARE</b> are <b>badware</b> free (free from those annoying stuff...you know)
We've got great PDF Mergers, System Speederupers and Tweakers! Just come to our website! (we don't have much traffic!)
and download the great <b>GOODWARE</b> 

#Oh! And if you want to see, here's the dog we were talking about!

<img src="https://raw.githubusercontent.com/SuicSoft/SuicSoft-Art/master/Suici/Suici%20(Original).png">
</img>

I'm Suici. Say that like Sooky. I'm not as popular as Android, Duo or the Octocat, But I'm on the web!
What Am I? I'm a dog, bearded collie puppy! - And I was drawn in Fresh Paint for the Logo - But I'm real!

#How do I use Little's PDF Merge Core
LPM.Core (Little's PDF Merge Core) is a free and open source pdf merger library for C#.NET, VB.NET and other .NET programming languages.

For c#.
```
 using (SuicSoft.LittleSoft.LittlesPDFMerge.Core.Combiner comb = new SuicSoft.LittleSoft.LittlesPDFMerge.Core.Combiner())
                    {
                        comb.OutputPath = "youroutputpath";
                        comb.AddFile(System.IO.File.ReadAllBytes("somepath"), null); //Replace null with password as a byte array if needed
                        comb.AddFile(System.IO.File.ReadAllBytes("somepath"), null); //Replace null with password as a byte array if needed
                    }
```

