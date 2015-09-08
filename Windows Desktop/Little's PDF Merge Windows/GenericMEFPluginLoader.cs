               /*++++++ooo++-                                                                                                                             |
             :++-```````````.+y/                                                                                                                          |
           .ys``````    ```````:s+`                                                                                                                       |
          .mo``.-``      `oyo/``.-ss-                                                                                                                     |
         .h+`.dh+y       `ydhN.````.+s/                                                                                                                   |
       `+h-```oss+        `-:.```````.:so`                                                                                                                |
      +d+.````````   `.`     ``````````.-+/-                                                                                                              |
    `yh-````````    oooo/     ````.:``````.:o/`                                                                                                           |
   .dh.`````````    .+:.`      ```oyy-``````.+y+`                                                                                                         |
  -my.````os.```  -/-h+:o.     `.+``/d+```````.oy.                                                                                                        |
 `ds.```.ysod/```  ./y+-`    ``-:`   .hy:```````.d                                 ...                                           `.......`                |
-do````.h+  -+y/.```-+-`````.:od      `+d+.``````N     .:+++++++++/                ://              `-/+++++++++.               -ooo+++++.   /++          |
do````.s:     shhs+/:::::/+syyyd        ./s+:..:od    .os+---------  `..`     ...  ...   ``.......  +so:--------`   ``......`   /ss.-----`...oso....      |
m-```:y.      oyyyyhyyyhhhhyyyyh+         `.//+//.    -ss:````````   -ss-     os+  /ss` -+ooooooo+` oso.```````    -+oooooooo/  /ss:ooooo.+ooossooo+`     |
d...+o` :-::::+ooooooooooosssssss///////`              :+o++++++oo/` -ss-     os+  /ss` oso```````  ./o+++++++o+-  oso`````/ss. /ss`````` ```oso````      |
/+++-   ////////////+++++++++++++ooooooo.               ````````.os+ -ss:     os+  /ss` os+           ````````/ss. os+     :ss. /ss`         oso          |
        ////////////+++++++++++++ooooooo.             `::::::::::os/ `+so:::::os+  /ss` +so:::::::` -:::::::::+so` +so:::::+so` /ss`         oso          |
        //:://////-++//+///+++++//++/+oo. `````       .++++++++++/-   `-/+++++++:  :++  `:++++++++` /++++++++++:`  `:+++++++/.  :++          /++          |
        +/-:/-/://-+/-/+::/+:+:+./+/-+oo.``````                                                                                                           |
        +/:::::-//./+-:+//-+:/:o:ooo:/oo-`````                                                                                                            |
        +++++++++++++++++++++oooooooooos-``                                                                                                               |
        +++++++++++++++++++++oooooooooos-                                                                                                                 |
        +++++++++++++++++++ooooooooooooo.                                                                                                                 |  
        /+++///++++++++++++++++++++++oo+`                                                                                                                 |
         .--`````````.s//o```````````.`                                                                                                                   |
         .-.         od  N-          .:                                                                                                                   |
        ./`          oy  N/          .N                                                                                                                   |
        oh           +y  ds         .d/                                                                                                                   |
        .my`         os  .m:      -sN/                                                                                                                    |
         `+d/       -m+   `sooo+oo/.                                                                                                                      |
            :ooossooy:                                                                                                                                    | 
__________________________________________________________________________________________________________________________________________________________| 

 *This file is part of Little's PDF Merge. An open source software
 -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
 | Contact Infomation                 | Program Infomation                              | Tools Used                                                    | Libs Used                         | Software Requirements    | Hardware Requirements |
 |  *Email : mailto:suiciwd@gmail.com |  *Name : SuicSoft LittleSoft Little's PDF Merge |  *Microsoft Visual Studio  *Microsoft Blend for Visual Studio |  *iTextSharp (iText .NET Port)    |  *Windows Vista or newer |  *1Ghz or faster CPU  |
 |  *Web : http://www.suicsoft.com    |  *Version : 2.2.1                               |  *Microsoft SDKs           *Microsoft .NET Framework 4.5      |  *Material Design In Xaml Toolkit |  *.NET Framework 4.5.1   |  *512mb RAM           |
 -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
 License.md is included with the Visual Studio Project ,installer and portable.
 The SuicSoft Open License (SOL)

 *Copyright (c) 2015 SuicSoft

 *SuicSoft Stuff is Names, Logos and Other Things which someone can identify as SuicSoft

 *You can't sell our code and software, and remove all SuicSoft stuff and if you're trying to just copy our UI - we'll BAN you from our website, Anyways if you like the UI check out Material-Design-in-XAML-Toolkit on Github, then use it yourself!

 *And Remember: NO USING OUR CODE IF YOU'RE USING IT IN A NON-OPEN SOURCE PROJECT

 *Keep the dog if you like! But if you do, say you found him on SuicSoft.com.

 *THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
 *INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
 *IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
 *WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace SuicSoft.LittleSoft.LittlesPDFMerge.Windows
{
    public class GenericMEFPluginLoader<T>
    {
        private CompositionContainer _Container;

        [ImportMany]
        public IEnumerable<T> Plugins
        {
            get;
            set;
        }

        public GenericMEFPluginLoader(string path)
        {
            DirectoryCatalog directoryCatalog = new DirectoryCatalog(path);

            //An aggregate catalog that combines multiple catalogs
            var catalog = new AggregateCatalog(directoryCatalog);

            // Create the CompositionContainer with all parts in the catalog (links Exports and Imports)
            _Container = new CompositionContainer(catalog);

            //Fill the imports of this object
            _Container.ComposeParts(this);
        }
    }
}
