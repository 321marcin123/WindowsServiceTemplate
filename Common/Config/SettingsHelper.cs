using System;
using System.Xml.XPath;

namespace Common.Config
{
    public class SettingsHelper : ISettingsHelper
    {
        public readonly string SettingsFilePath = AppDomain.CurrentDomain.BaseDirectory + "/Config/Settings.xml";

        private readonly string Root = @"/appSettings/";

        // code stolen from stackoverflow https://stackoverflow.com/questions/46490262/what-is-better-practice-here-when-its-about-to-repeat-same-code-multiple-times
        public string ReadValue(string pstrValueToRead)
        {
            try
            {
                var doc = new XPathDocument(SettingsFilePath);
                var nav = doc.CreateNavigator();

                var expr = nav.Compile(Root + pstrValueToRead);
                var iterator = nav.Select(expr);

                // Iterate on the node set
                while (iterator.MoveNext())
                {
                    return iterator.Current.Value;
                }

                return string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }


    }
}
