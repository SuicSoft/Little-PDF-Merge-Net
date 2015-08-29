<head>
<style type="text/css">.csharpcode, .csharpcode pre
{
	font-size: 13.3333px;
	font-width: 400;
	color: black;
	font-family: "Courier New";
}
.csharpcode pre { margin: 0px; }
.csharpcode .comment { color: #008000; }
.csharpcode .comment2 { color: #808080; }
.csharpcode .type { color: #2B91AF; }
.csharpcode .keyword { color: #0000FF; }
.csharpcode .string { color: #A31515; }
.csharpcode .preproc { color: #0000FF; }
</style>
</head>
# Little-s-PDF-Merge
Free , open source and fast PDF merger using Google Material Design, WPF and C# .Net
<img src="https://raw.githubusercontent.com/SuicSoft/Little-PDF-Merge/master/lpm.PNG"></img>
Free to use, distrubute and modify. You can't sell this, and remove all '<i>SuicSoft</i>' stuff if you're using it on you're site
(keep the dog if you like!) - read more in <b>LICENSE.txt</b>

# SuicSoft. Better Software. Happier PCs
SuicSoft's great <b>FREEWARE</b> are <b>badware</b> free (free from those annoying stuff...you know)
We've got great PDF Mergers, System Speederupers and Tweakers! Just come to our website! (we don't have much traffic!)
and download the great <b>GOODWARE</b> 

#Oh! And if you want to see, here's the dog we were talking about!

<img src="https://c5bd2f1cb6c7712ee5b2eecc4ca962b0fb517791.googledrive.com/host/0B08cCnnU-zt-V3R0OTR1WlBpdVk/My%20Dog.png">
</img>

I'm Suici. Say that like Sooky. I'm not as popular as Android, Duo or the Octocat, But I'm on the web!
What Am I? I'm a dog, bearded collie puppy! - And I was drawn in Fresh Paint for the Logo - But I'm real!

#How do I use Little's PDF Merge Core
LPM.Core (Little's PDF Merge Core) is a free and open source pdf merger library for C#.NET, VB.NET and other .NET programming languages.

For c#.
<div class='csharpcode'>Code:<pre style='border:1px dashed #CCCCCC;overflow-x:auto;overflow-y:hidden;background:#f0f0f0;padding:0px;color:#000000;text-align:left;line-height20px;color:#000000;word-wrap:normal;'> <span class='keyword'>using</span> (<span class='type'>Combiner</span> comb = <span class='keyword'>new</span> <span class='type'>Combiner</span>())
                    {
                        comb.OutputPath = <span class='string'>&quot;youroutputpath&quot;</span>;
                        comb.AddFile(System.IO.<span class='type'>File</span>.ReadAllBytes(<span class='string'>&quot;somepath&quot;</span>), <span class='keyword'>null</span>); <span class='comment'>//Replace null with password as a byte array if needed</span>
                        comb.AddFile(System.IO.<span class='type'>File</span>.ReadAllBytes(<span class='string'>&quot;somepath&quot;</span>), <span class='keyword'>null</span>); <span class='comment'>//Replace null with password as a byte array if needed</span>
                    }<!--[if IE]>

<![endif]--></pre></div>
