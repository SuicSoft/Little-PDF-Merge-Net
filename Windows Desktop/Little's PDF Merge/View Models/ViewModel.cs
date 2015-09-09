using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SuicSoft.LittlesPDFMerge.Windows
{
    class ViewModel
    {
        /// <summary>
        /// Command for opening a website.
        /// </summary>
        public ICommand OpenSupportWebsiteCommand
        {
            get
            {
                if (mOpenSupportWebsiteCommand == null)
                    mOpenSupportWebsiteCommand = new RelayCommand<object>(OpenWebsite);

                return mOpenSupportWebsiteCommand;
            }
        }
        private RelayCommand<object> mOpenSupportWebsiteCommand;

        private void OpenWebsite(object url)
        {
            System.Diagnostics.Process.Start(url as string);
        }
    }
}
