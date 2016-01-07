using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseApp.Domain.Shared.ValidationAttribute
{
    public class TCIdentityNo : System.ComponentModel.DataAnnotations.ValidationAttribute
    {

        public override bool IsValid(object value)
        {
            bool result = false;

            string strValue = value as string;

            if (!string.IsNullOrEmpty(strValue))
            {
                string sPattern = "(^[1-9]{1}\\d{10}$)";

                if (System.Text.RegularExpressions.Regex.IsMatch(strValue, sPattern))
                {
                    int len = strValue.Length;

                    // TC Kimlik No
                    if (len == 11)
                    {

                        //T.C. Kimlik numarasının her karakterini tek tek ayırıp
                        //char dizisine atıyoruz .
                        char[] rakam = strValue.ToCharArray();

                        //Ve tek hanelerin toplamını buluyoruz .
                        //1. ,3. ,5. ,7. ve 9. hanelerin toplamı .
                        int tektoplam = int.Parse(rakam[0].ToString()) + int.Parse(rakam[2].ToString())
                        + int.Parse(rakam[4].ToString()) + int.Parse(rakam[6].ToString()) + int.Parse(rakam[8].ToString());


                        //Daha sonra aynı şekilde çif hanelerin toplamını buluyoruz.
                        //2. , 4. ,6. ve 8. hanelerin toplamı .
                        int cifttoplam = int.Parse(rakam[1].ToString()) + int.Parse(rakam[3].ToString())
                        + int.Parse(rakam[5].ToString()) + int.Parse(rakam[7].ToString());


                        //Daha sonra 10. rakamı bulmak için tek hanelerin toplamını 7 ile çarpıp..
                        //Çift hanelilerin toplamını çıkarıyoruz .
                        // Ve bu sonucun 10 ile bölümünden kalan bize T.C. kimlik numarasının 10. hanesini veriyor.
                        int onuncurakam = (((tektoplam * 7) - cifttoplam) % 10);

                        //11.hane için ise 10 haneyi topluyoruz ve 10 ile bölümünden kalan,
                        // bize 11. haneyi veriyor .
                        int onbirincirakam = ((tektoplam + cifttoplam + onuncurakam) % 10);


                        if (onuncurakam == Int32.Parse(rakam[9].ToString()) &&
                              onbirincirakam == Int32.Parse(rakam[10].ToString()))
                        {
                            result = true;
                        }
                        else
                        {
                            result = false;
                        }
                    }
                    else
                    {
                        result = false;
                    }
                }
                else
                {
                    result = false;
                }


            }

            return result;
        }

    }

}
