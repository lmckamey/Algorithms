using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars01
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Text.RegularExpressions;

    public class PhoneDir
    {
        public class PhoneInfo
        {
            public string number;
            public string name;
            public string address;
        }

        public static string[] extraChars =
          {
        ",", ":", ";", "$", "_", "?", "!", "/", "*"
    };

        public static string Phone(string strng, string num)
        {
            List<PhoneInfo> directory = new List<PhoneInfo>();
            ParseDir(strng, directory);
            var filteredDir = directory.Where(p => { return p.number.Equals(num); });
            if (filteredDir.Count() == 0) return "Error => Not found: " + num;
            if (filteredDir.Count() > 1) return "Error => Too many people: " + num;
            PhoneInfo pi = filteredDir.ElementAt(0);
            return "Phone => " + pi.number + ", Name => " + pi.name + ", Address => " + pi.address;
        }

        public static void ParseDir(string strng, List<PhoneInfo> dir)
        {
            char[] delim = { '\n' };
            string[] entires = strng.Split(delim, StringSplitOptions.RemoveEmptyEntries);
            Regex numReg = new Regex(@"\+\d{1,2}\-\d{3,}-\d{3,}-\d{4,}");
            Regex nameReg = new Regex(@"<.*>");
            Regex spaceReg = new Regex(@"[ ]{2,}");

            for (int i = 0; i < entires.Length; ++i)
            {
                Match match;
                PhoneInfo info = new PhoneInfo();
                string s = entires[i];

                match = numReg.Match(s);
                s = s.Remove(match.Index, match.Length);
                info.number = match.Value.Substring(1);

                match = nameReg.Match(s);
                s = s.Remove(match.Index, match.Length);
                info.name = match.Value.Substring(1, match.Value.Length - 2);

                foreach (string ss in extraChars)
                {
                    s = s.Replace(ss, " ");
                }
                s = spaceReg.Replace(s, " ").Trim();
                info.address = s;

                dir.Add(info);
            }
        }
    }

}
