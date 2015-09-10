using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading.Tasks;
namespace SuicSoft.LittlesPDFMerge.Windows
{
    public static class Extension
    {
        /// <summary>
        /// Don't show this message again dialog.
        /// </summary>
        /// <param name="title">The title</param>
        /// <param name="message">The Message</param>
        /// <param name="id">A id that can be any string</param>
        /// <returns></returns>
        public static async Task<MessageDialogResult> DonNotShowAgainDialog(this MetroWindow win, string title, string message, string id)
        {
            const string regpath = "Software\\SuicSoft\\LittlePDFMerge"; //Example : Software\\Company\ProductName.
            //Open registry key for editing and reading.
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(regpath, true))
            {
                //Check if do not show this again has been clicked before
                if ((int)key.GetValue(id, 0) == 0)
                {
                    //Show message to user.
                    MessageDialogResult result = await win.ShowMessageAsync(title, message, MessageDialogStyle.AffirmativeAndNegativeAndSingleAuxiliary, new MetroDialogSettings { FirstAuxiliaryButtonText = "Don't show again", ColorScheme = MetroDialogColorScheme.Accented });
                    if (result == MessageDialogResult.FirstAuxiliary)
                    {
                        //Don't show again
                        key.SetValue(id, 1);
                        //Return ok button
                        return MessageDialogResult.Affirmative;
                    }
                    return result;
                }
                //Return ok button
                return MessageDialogResult.Affirmative;
            }
        }
        public static IEnumerable<T> MoveUp<T>(this IEnumerable<T> enumerable, int itemIndex)
        {
            int i = 0;

            IEnumerator<T> enumerator = enumerable.GetEnumerator();
            while (enumerator.MoveNext())
            {
                i++;

                if (itemIndex.Equals(i))
                {
                    T previous = enumerator.Current;

                    if (enumerator.MoveNext())
                    {
                        yield return enumerator.Current;
                    }

                    yield return previous;

                    break;
                }

                yield return enumerator.Current;
            }

            while (enumerator.MoveNext())
            {
                yield return enumerator.Current;
            }
        }
        public static IEnumerable<T> MoveDown<T>(this IEnumerable<T> enumerable, int itemIndex)
        {
            int i = 0;

            IEnumerator<T> enumerator = enumerable.GetEnumerator();
            while (enumerator.MoveNext())
            {
                i--;

                if (itemIndex.Equals(i))
                {
                    T previous = enumerator.Current;

                    if (enumerator.MoveNext())
                    {
                        yield return enumerator.Current;
                    }

                    yield return previous;

                    break;
                }

                yield return enumerator.Current;
            }

            while (enumerator.MoveNext())
            {
                yield return enumerator.Current;
            }
        }

        public static TValue GetValueOrDefault<TKey, TValue>
    (this IDictionary<TKey, TValue> dictionary,
     TKey key,
     TValue defaultValue)
        {
            TValue value;
            return dictionary.TryGetValue(key, out value) ? value : defaultValue;
        }

        public static TValue GetValueOrDefault<TKey, TValue>
            (this IDictionary<TKey, TValue> dictionary,
             TKey key,
             Func<TValue> defaultValueProvider)
        {
            TValue value;
            return dictionary.TryGetValue(key, out value) ? value
                 : defaultValueProvider();
        }
        public static string ToUnsecureString(this SecureString securePassword)
        {
            if (securePassword == null)
                return "";

            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(securePassword);
                return Marshal.PtrToStringUni(unmanagedString);
            }

            finally
            {
                Marshal.ZeroFreeBSTR(unmanagedString);
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        public static SecureString ToSecureString(this string source)
        {
            if (string.IsNullOrWhiteSpace(source))
                return null;
            else
            {
                SecureString Result = new SecureString();
                foreach (char c in source.ToCharArray())
                    Result.AppendChar(c);
                return Result;
            }
        }
    }
}
