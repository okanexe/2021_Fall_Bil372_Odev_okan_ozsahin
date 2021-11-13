using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinTicket.Util
{
    public class FormValidator
    {
        /// <summary>
        /// Form control validation
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public static bool Validate(List<Control> items, ErrorProvider errorProvider)
        {
            int _unpassed = default(int);

            foreach (var item in items)
            {
                if (item.GetType().Name.Equals("TextBox"))
                {
                    if (string.IsNullOrEmpty(((TextBox)item).Text))
                    {
                        item.Focus();
                        errorProvider.SetError(item, "Zorunlu alan");
                        _unpassed++;
                    }
                }
                else if (item.GetType().Name.Equals("ComboBox"))
                {
                    if (((ComboBox)item).SelectedValue == null
                        || Convert.ToInt32(((ComboBox)item).SelectedValue) == 0
                        || Convert.ToInt32(((ComboBox)item).SelectedValue) == -1)
                    {
                        item.Focus();
                        errorProvider.SetError(item, "Zorunlu alan");
                        _unpassed++;
                    }
                }
            }

            if (_unpassed > 0)
            {
                return false;
            }

            return true;
        }
    }
}
