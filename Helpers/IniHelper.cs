using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Text;

namespace WPFNavigation.Helpers
{

    //See https://www.codeproject.com/Articles/1966/An-INI-file-handling-class-using-C

    /// <summary>
    /// Create a New INI file to store or load data
    /// </summary>
    public class IniHelper
        {
            public string path;

            [DllImport("kernel32")]
            private static extern long WritePrivateProfileString(string section,
                string key, string val, string filePath);
            [DllImport("kernel32")]
            private static extern int GetPrivateProfileString(string section,
                     string key, string def, StringBuilder retVal,
                int size, string filePath);

            /// <summary>
            /// INIFile Constructor.
            /// </summary>
            /// <PARAM name="INIPath"></PARAM>
            public IniHelper(string INIPath)
            {
                path = INIPath;
            }
        /// <summary>
        /// Write Data to the INI File
        /// </summary>
        /// <PARAM name="Section"></PARAM>
        /// The name of the section to which the string will be copied. 
        /// <PARAM name="Key"></PARAM>
        /// The name of the key to be associated with a string.
        /// <PARAM name="Value"></PARAM>
        /// A null-terminated string to be written to the file. If this parameter is NULL, the key pointed to by the Key parameter is deleted.
        public void IniWriteValue(string Section, string Key, string Value)
            {
                WritePrivateProfileString(Section, Key, Value, this.path);
            }

        /// <summary>
        /// Read Data Value From the Ini File
        /// </summary>
        /// <PARAM name="Section"></PARAM>
        /// The name of the section containing the key name. 
        /// <PARAM name="Key"></PARAM>
        /// The name of the key whose associated string is to be retrieved.
        /// <PARAM name="Path"></PARAM>
        /// The path to the ini file.
        /// <returns></returns>
        public string IniReadValue(string Section, string Key)
            {
                StringBuilder temp = new StringBuilder(255);
                int i = GetPrivateProfileString(Section, Key, "", temp,
                                                255, this.path);
                return temp.ToString();

            }
        }
    }

