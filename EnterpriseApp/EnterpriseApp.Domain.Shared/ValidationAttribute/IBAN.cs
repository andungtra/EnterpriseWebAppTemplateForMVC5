using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseApp.Domain.Shared.ValidationAttribute
{
    public class IBAN : System.ComponentModel.DataAnnotations.ValidationAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool IsValid(object value)
        {
            bool result = false;

            string strValue = value as string;

            strValue = strValue.ToUpper(); //IN ORDER TO COPE WITH THE REGEX BELOW

            if (String.IsNullOrEmpty(strValue))
            {
                result = false;
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(strValue, "^[A-Z0-9]"))
            {
                strValue = strValue.Replace(" ", String.Empty);
                string bank = strValue.Substring(4, strValue.Length - 4) + strValue.Substring(0, 4);

                int asciiShift = 55;

                StringBuilder sb = new StringBuilder();

                foreach (char c in bank)
                {
                    int v;

                    if (Char.IsLetter(c))
                    {
                        v = c - asciiShift;
                    }
                    else
                    {
                        v = int.Parse(c.ToString());
                    }
                    sb.Append(v);
                }

                string checkSumString = sb.ToString();

                int checksum = int.Parse(checkSumString.Substring(0, 1));
                for (int i = 1; i < checkSumString.Length; i++)
                {
                    int v = int.Parse(checkSumString.Substring(i, 1));
                    checksum *= 10;
                    checksum += v;
                    checksum %= 97;
                }
                result = (checksum == 1);
            }
            else
            {
                result = false;
            }

            return result;
        }

    }

}
