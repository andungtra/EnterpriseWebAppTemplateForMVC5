using EnterpriseApp.Domain.Shared.Helper;
using EnterpriseApp.Presentation.Web.Helper;
using RazorEngine;
using RazorEngine.Templating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnterpriseApp.Presentation.Web.ViewModel.Account
{
    public class WelcomeEmailViewModel : TemplateBase, IEmailViewModel
    {

        public IHelperContext Context { get; set; }

        public string SiteBaseUrl { get; set; }

        public string MessageSubject { get; set; }

        public string MessageBody { get; set; }

        public string Email { get; set; }

        public string ActivationUrl { get; set; }

        public WelcomeEmailViewModel(IHelperContext context)
        {
            this.Context = context;

            this.SiteBaseUrl = this.Context.GetSiteBaseFullUrl();
        }


        public string GenerateHTML()
        {
            string layout = System.IO.File.ReadAllText(
                this.Context.GetSiteServerMapPath() + "Views/Shared/EmailTemplates/_Layout.cshtml"
            );

            string template = System.IO.File.ReadAllText(
                this.Context.GetSiteServerMapPath() + "Views/Shared/EmailTemplates/AccountWelcome.cshtml"
            );

            Engine.Razor.AddTemplate("EmailLayout", layout);

            string result = Engine.Razor.RunCompile(template, "AccountWelcome", typeof(WelcomeEmailViewModel), this);

            return result;
        }

    }

}