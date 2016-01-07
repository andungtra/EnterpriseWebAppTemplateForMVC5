using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseApp.Domain.Log.ValueObject
{
    public enum ProcessType
    {

        [Display(Name = "ProcessType_INSERT", ResourceType = typeof(Resources))]
        INSERT = 10,

        [Display(Name = "ProcessType_UPDATE", ResourceType = typeof(Resources))]
        UPDATE = 20,

        [Display(Name = "ProcessType_DELETE", ResourceType = typeof(Resources))]
        DELETE = 30

    }

    public class HelperEnumProcessType
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public static string GetDisplayAttribute(ProcessType enumValue)
        {
            DisplayAttribute result = (DisplayAttribute)typeof(ProcessType).GetMember(enumValue.ToString())
                   .First()
                   .GetCustomAttributes(typeof(DisplayAttribute), false)
                   .First();

            return Resources.ResourceManager.GetString(result.Name);
        }

    }

}
