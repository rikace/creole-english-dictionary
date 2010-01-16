using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Net;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using Haiti;

namespace WebApplication1
{
    public partial class _Default : System.Web.UI.Page
    {
        Translator _translator;

        protected void Page_Load(object sender, EventArgs e)
        {
            _translator = new Translator(Server.MapPath("~/resources/E2KDictionary.xml"), Language.Creole, Language.English);
            
            if (Page.IsPostBack)
            {
                WebClient client = new WebClient();
                byte[] byteData = client.DownloadData(this.txtUrl.Text);
                string xmlData = Encoding.UTF8.GetString(byteData);

                Regex rex = new Regex("<(.|\n)*?>");
                MatchCollection matches = rex.Matches(xmlData);

                //assumption: page starts with an html tag
                StringBuilder sb = new StringBuilder();
                int textStart = 0;
                bool omitContents = false;  //omit contents of tags like script, etc.
                foreach (Match m in matches)
                {
                    if (textStart > 0 && !omitContents)
                    {
                        string text = xmlData.Substring(textStart, m.Index - textStart);
                        text = Translate(text);
                        sb.Append(text);
                    }
                    string htmlTag = xmlData.Substring(m.Index, m.Length);
                    omitContents = OmitTagContents(htmlTag);
                    sb.Append(htmlTag);  //add the html tag itself
                    textStart = m.Index + m.Length;
                }


                litContent.Text = sb.ToString();
            }

        }

        static string[] omitTags = new string[] { "script", "meta", "link" };

        string omitUntilTag = null;
        private bool OmitTagContents(string htmlTag)
        {
            //if we're waiting for an end tag, look for it.
            if (null != omitUntilTag)
            {
                if (htmlTag.StartsWith("</") && htmlTag.Contains(omitUntilTag))
                    return false;
                else
                    return true;
            }

            //otherwise, determine if we should start skipping content.
            if (htmlTag.Contains("</") || htmlTag.Contains("/>")) return false;
            foreach (string tag in omitTags)
            {
                if (htmlTag.StartsWith("<" + tag, StringComparison.CurrentCultureIgnoreCase))
                {
                    if (!htmlTag.EndsWith("/>"))
                        omitUntilTag = tag;
                    return true;
                }
            }
            return false;
        }

        private string Translate(string text)
        {
            Regex r = new Regex(@"([\w]+\s+)");
            String[] tokey = r.Split(text);

            StringBuilder sb = new StringBuilder();
            foreach (string token in tokey)
            {
                string word = token.Trim();
                if (word.Length > 0)
                {
                    //translate this.
                    sb.Append(TranslateWord(word));
                    if (text.EndsWith(" ")) sb.Append(' ');
                }
                else
                {
                    sb.Append(token);
                }
            }

            return sb.ToString();
        }

        string status; 
        string TranslateWord(string word)
        {
            //translated an array of words (with one element)
            string translatedWord = _translator.Translate(new string[] { HttpUtility.HtmlDecode(word) }, out status);

            //if we returned empty, the word was not found.
            if (string.IsNullOrEmpty(translatedWord))
            {
                return word;
            }
            else
            {
                return "<b>"+translatedWord+"</b>";
            }
        }


        protected void GoButtonHandler(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {
                //
            }
        }


    }
}
