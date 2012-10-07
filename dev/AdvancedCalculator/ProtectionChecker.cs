using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AdvancedCalculator
{
    public static class ProtectionChecker
    {
        static bool m_checkProtectionDialogWorks;
        static bool m_isProtectionDisabled = false;
        
        public static bool CheckProtectionWithDialog()
        {
            if (m_checkProtectionDialogWorks)
                return true;

            m_checkProtectionDialogWorks = true;

            while (!CheckProtection())
            {
                DialogResult dialogResult = MessageBox.Show(null,
                    "A suitable WIBU_BOX entry wasn't found.\n\nYou can't work with the calculator without a key.\nPlease insert the key and press retry button.\nOr press cancel button to close the program.",
                    "Protection",
                    MessageBoxButtons.RetryCancel);
                if (dialogResult == DialogResult.Cancel)
                {
                    m_checkProtectionDialogWorks = false;
                    return false;
                }
            }

            m_checkProtectionDialogWorks = false;

            return true;
        }

        public static bool CheckProtection()
        {
            var keys = new int[] {
                101250
            };

            bool isKeyFound = false;
            if (m_isProtectionDisabled)
            {
                isKeyFound = true;
            }
            
            foreach (int key in keys)
            {
                if (ProtectionOK(key))
                {
                    isKeyFound = true;
                    break;
                }
            }
            return isKeyFound;
        }

        static private bool ProtectionOK(int usercode)
        {
            bool res = false;
            try
            {
                WIBUKEYLib.WibukeyClass wk = new WIBUKEYLib.WibukeyClass();
                if (wk != null)
                {
                    wk.SetBoxEntryForEncryption();
                    wk.WkBoxSimUsed = false;
                    wk.FirmCode = 619;
                    wk.UserCode = usercode;
                    wk.Encrypt();
                    res = wk.LastErrorCode == 0;
                }
            }
            catch (Exception)
            {
            }

            return res;
        }
    }
}
