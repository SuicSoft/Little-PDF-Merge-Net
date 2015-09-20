using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace SuicSoft.LittlesPDFMerge.Windows
{
    class PDFItem
    {
        public PDFItem(string _path, SecureString _password)
        {
            path = _path;
            password = _password;
        }

        public string path { get; set; }
        public SecureString password { get; set; }

    }
}
