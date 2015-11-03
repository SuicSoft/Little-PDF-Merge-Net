using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SuicSoft.LittlesPDFMerge.Windows
{
    class ViewModel
    {
        public ViewModel()
        {
            NetworkChange.NetworkAvailabilityChanged += NetworkChange_NetworkAvailabilityChanged;
        }
        public bool isavalible = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
        void NetworkChange_NetworkAvailabilityChanged(object sender, NetworkAvailabilityEventArgs e)
        {
            isavalible = e.IsAvailable;
            mOpenSupportWebsiteCommand.RaiseCanExecuteChanged();
            OpenSupportWebsiteCommand.RaiseCanExecuteChanged();
        }
        /// <summary>
        /// Command for opening a website.
        /// </summary>
        public DelegateCommand<string> OpenSupportWebsiteCommand
        {
            get
            {
                mOpenSupportWebsiteCommand = mOpenSupportWebsiteCommand == null ? new DelegateCommand<string>(OpenWebsite, CanAccessWeb) : mOpenSupportWebsiteCommand;
                return mOpenSupportWebsiteCommand;
            }
        }
        private DelegateCommand<string> mOpenSupportWebsiteCommand;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        public bool CanAccessWeb(string url)
        {
            try
            {
                using (Ping ping = new Ping()) return isavalible ? ping.Send(new Uri((string)url).Host).Status == IPStatus.Success ? true : false : false;
            }
            catch { return false; }
        }
        private void OpenWebsite(string url)
        {
            new Thread(new System.Threading.ThreadStart(delegate()
                 {
                     System.Diagnostics.Process.Start(url as string);
                 })).Start();
        }
    }
}
