//=======================================================================================
// Copyright © daenet GmbH Frankfurt am Main, University of Applied Sciences Frankfurt am Main
//
// LICENSED UNDER THE APACHE LICENSE, VERSION 2.0 (THE "LICENSE"); YOU MAY NOT USE THESE
// FILES EXCEPT IN COMPLIANCE WITH THE LICENSE. YOU MAY OBTAIN A COPY OF THE LICENSE AT
// http://www.apache.org/licenses/LICENSE-2.0
// UNLESS REQUIRED BY APPLICABLE LAW OR AGREED TO IN WRITING, SOFTWARE DISTRIBUTED UNDER THE
// LICENSE IS DISTRIBUTED ON AN "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED. SEE THE LICENSE FOR THE SPECIFIC LANGUAGE GOVERNING
// PERMISSIONS AND LIMITATIONS UNDER THE LICENSE.
//=======================================================================================

using System;
using System.IO;
using System.Xml.Linq;

namespace Daenet.Integration
{
    public static class SettingsProvider
    {
        public static string Key
        {
            get
            {
                return GetXmlElementValue("key");
            }
        }

        public static string Secret
        {
            get
            {
                return GetXmlElementValue("secret");
            }
        }

        public static string Username
        {
            get
            {
                return GetXmlElementValue("username");
            }
        }

        public static string Password
        {
            get
            {
                return GetXmlElementValue("password");
            }
        }

        public static string CallbackUrl
        {
            get
            {
                return GetXmlElementValue("callbackurl");
            }
        }

        private static string GetXmlElementValue(string elementName)
        {
            if (!File.Exists("secrets.xml"))
            {
                throw new Exception("Rename secrets.xml.sample to secrets.xml and enter your secrets in the file.");
            }

            return XDocument.Load("secrets.xml").Element("root").Element(elementName).Value;
        }
    }
}
