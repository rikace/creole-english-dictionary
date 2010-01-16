using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.IO;
using System.Globalization;

namespace Haiti
{

    public enum Language { English, Creole }

    public partial class Default : System.Web.UI.Page
    {

        private Language _inputLanguage = Language.Creole;
        private Language _outputLanguage = Language.English;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void SwitchLanguage(object sender, EventArgs e)
        {
            RadioButtonList list = (RadioButtonList)sender;
            if (list.SelectedValue == "1")
            {
                _inputLanguage = Language.English;
                _outputLanguage = Language.Creole;

                InputFlag.ImageUrl = "~/images/flags/usa.jpg";
                OutputFlag.ImageUrl = "~/images/flags/haiti.jpg";

                TranslateButton.Text = "Translate";
            }
            else
            {
                _inputLanguage = Language.Creole;
                _outputLanguage = Language.English;

                InputFlag.ImageUrl = "~/images/flags/haiti.jpg";
                OutputFlag.ImageUrl = "~/images/flags/usa.jpg";

                TranslateButton.Text = "Tradwi";
            }
        }

        

        protected void Translate_OnClick(object sender, EventArgs e)
        {
            String[] input = InputText.Text.Trim().Split(' ');
            
            String statistics = String.Empty;

            Translator translator = new Translator(Server.MapPath("~/resources/E2KDictionary.xml"),_inputLanguage, _outputLanguage);
            translator.UnknownText = "unknown ";
            OutputText.Text = translator.Translate(input, out statistics);

            Statistics.Text = statistics;
        }


    }
}
