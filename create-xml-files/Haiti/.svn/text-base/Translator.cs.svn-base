using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.IO;
using System.Text;

namespace Haiti
{
    public class Translator
    {

        XmlDocument _xmlDoc;
        private XmlNodeList _nodeList;

        private Language _inputLanguage;
        private Language _outputLanguage;

        public string UnknownText { get; set; }


        /// <summary>
        /// Build the Translator
        /// Note: The output language really isn't used at this time.
        /// </summary>
        /// <param name="server"></param>
        /// <param name="InputLanguage"></param>
        /// <param name="OutputLanguage"></param>
        public Translator(string dictionaryFilePath, Language InputLanguage, Language OutputLanguage)
        {

            _inputLanguage = InputLanguage;
            _outputLanguage = OutputLanguage;
            
            // Open the XML file
            XmlDocument _xmlDoc = new XmlDocument();
            _xmlDoc.Load(File.OpenText(dictionaryFilePath));

            switch (_inputLanguage)
            {
                case Language.Creole:
                    _nodeList = _xmlDoc.SelectNodes("Dictionaries//DicK2E//Term");
                    break;
                case Language.English:
                    _nodeList = _xmlDoc.SelectNodes("Dictionaries//DicE2K//Term");
                    break;
                default:
                    _nodeList = _xmlDoc.SelectNodes("Dictionaries//DicK2E//Term");
                    break;
            }

        }

        /// <summary>
        /// Translate a block of text
        /// </summary>
        /// <param name="input">Array of strings containing the words to translate.</param>
        /// <param name="statistics">Statistics on the success (mainly for testing)</param>
        /// <returns>Translated string</returns>
        public String Translate(String[] input, out String statistics)
        {
            String output = String.Empty;

            int total = 0;
            int translated = 0;

            // Translate
            foreach (String s in input)
            {
                total++;

                String o = String.Empty;
                if (TranslateWord(_nodeList, s, out o))
                {
                    translated++;
                }

                if (o == String.Empty && !String.IsNullOrEmpty(UnknownText))
                    o = UnknownText;

                output += o;
            }

            decimal percent = (translated * 100 / total);

            statistics = String.Format("Translated {0} of {1} words.  {2} percent complete.", translated.ToString(), total.ToString(), percent.ToString());
            return output;
        }

        //private Byte CharComparer(char value)
        //{
        //    // char[] specialChars = new char[] { 'è', 'ò' };
        //    return (byte)value;
        //}

        /// <summary>
        /// Translate individual words and return a true/false status indicating the success.
        /// </summary>
        /// <param name="nodeList">List of XML nodes</param>
        /// <param name="inputWord">word to translate</param>
        /// <param name="outputWord">translated word</param>
        /// <returns></returns>
        public bool TranslateWord(XmlNodeList nodeList, string inputWord, out string outputWord)
        {

            // Drop a bunch of characters that cause the matching to fail.
            inputWord = inputWord.Replace('.', ' ');
            inputWord = inputWord.Replace(',', ' ');

            outputWord = String.Empty;
            var comparer = new CharsComparer();
            var charsArr = inputWord.ToCharArray();

            // Replace the accent marks in the input strings using byte-level comparison and replacement
            // so that the accent marks do not inhibit the translation.
            if (charsArr.Contains('è', comparer))
                inputWord = inputWord.Replace('è', 'è');
            if (charsArr.Contains('ò', comparer))
                inputWord = inputWord.Replace('ò', 'ò');

            // Look up each word and find the translation
            foreach (XmlNode node in nodeList)
            {
                if (node.Attributes["word"].Value.ToString().Trim().ToLower().Equals(inputWord.ToLower().Trim(), StringComparison.CurrentCultureIgnoreCase))
                {
                    outputWord = node.FirstChild.InnerText.ToString() + ' ';
                    return true;
                }
            }

            return false;
        }

    }
}
