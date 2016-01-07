using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseApp.Domain.Log.ValueObject
{
    public enum ExceptionLogLevel
    {

        [Display(Name = "ExceptionLogLevel_DEBUG", ResourceType = typeof(Resources))]
        DEBUG = 10,

        [Display(Name = "ExceptionLogLevel_WARNING", ResourceType = typeof(Resources))]
        WARNING = 20,

        [Display(Name = "ExceptionLogLevel_INFO", ResourceType = typeof(Resources))]
        INFO = 30,

        [Display(Name = "ExceptionLogLevel_ERROR", ResourceType = typeof(Resources))]
        ERROR = 40,

        [Display(Name = "ExceptionLogLevel_FATAL", ResourceType = typeof(Resources))]
        FATAL = 50

    }

    public class HelperEnumExceptionLogLevel
    {

        public static string GetDisplayAttribute(ExceptionLogLevel enumValue)
        {
            DisplayAttribute result = (DisplayAttribute)typeof(ExceptionLogLevel).GetMember(enumValue.ToString())
                   .First()
                   .GetCustomAttributes(typeof(DisplayAttribute), false)
                   .First();

            return Resources.ResourceManager.GetString(result.Name);
        }

    }
}
