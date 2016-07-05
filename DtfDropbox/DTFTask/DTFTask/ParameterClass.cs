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
using System.Collections;
using System.Collections.Generic;

namespace Daenet.Integration
{

    

    public class ParameterClass
	{
		private SortedDictionary<string,string> paramsData;
		public ParameterClass ()
		{
			paramsData = new SortedDictionary<string, string> ();
		}

		public void addParam(string key, string val){
			paramsData [key] = val;
		}

		public byte[] getParamStream(){
			string resultString = "";
			foreach(KeyValuePair<string, string> entry in paramsData)
			{
				if(resultString != "")
				{
					resultString += "&";
				}
				resultString += entry.Key + "=" + entry.Value; 
			}
			return GetBytes(resultString);
		}

		public string getParamStreamString(){
			string resultString = "";
			foreach(KeyValuePair<string, string> entry in paramsData)
			{
				if(resultString != "")
				{
					resultString += "&";
				}
				resultString += entry.Key + "=" + entry.Value; 
			}
			return resultString;
		}

		private static byte[] GetBytes(string str)
		{
			byte[] bytes = new byte[str.Length * sizeof(char)];
			System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
			return bytes;
		}
	}

}

