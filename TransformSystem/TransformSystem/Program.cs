using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransformSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            /*define parameter*/
            var source1 = new List<Source1Class>();
            var source2 = new List<Source2Class>();
            var target = new List<OutputClass>();
            /*initial sample data*/
            InitialSource1(source1);
            InitialSource2(source2);
            /*transform from source to target*/
            foreach(var s1 in source1)
            {
                var t = new OutputClass();
                t.AccountCode = (s1.Identifier.Contains("|")) ? s1.Identifier.Substring(s1.Identifier.IndexOf('|') + 1) : s1.Identifier;
                t.Name = s1.Name;
                t.Type = Type1Conversion(s1.Type);
                t.OpenDate = s1.Opened;
                t.Currency = CurrencyConversion(s1.Currency);
                target.Add(t);
            }

            foreach(var s2 in source2)
            {
                var t = new OutputClass();
                t.AccountCode = s2.CustodianCode;
                t.Name = s2.Name;
                t.Type = s2.Type;
                t.Currency = CurrencyConversion(s2.Currency);
                target.Add(t);
            }

            /*print the target*/

            foreach(var t in target)
            {
                Console.WriteLine(t.AccountCode + t.Name + t.Type + t.OpenDate + t.Currency);
            }
            Console.ReadLine();
        }

        private static void InitialSource1(List<Source1Class> source1){
            Source1Class s1c1 = new Source1Class();
            s1c1.Currency = "CD";
            s1c1.Identifier = "123|AbcCode";
            s1c1.Name = "My Account1";
            s1c1.Opened = DateTime.Parse("01-01-2018");
            s1c1.Type = "2";
            source1.Add(s1c1);
            s1c1 = new Source1Class();
            s1c1.Currency = "US";
            s1c1.Identifier = "333|dddCode";
            s1c1.Name = "My Account2";
            s1c1.Opened = DateTime.Parse("12-01-2019");
            s1c1.Type = "3";
            source1.Add(s1c1);
        }
        private static void InitialSource2(List<Source2Class> source2)
        {
            Source2Class s1c1 = new Source2Class();
            s1c1.Currency = "C";
            s1c1.CustodianCode = "eftCode";
            s1c1.Name = "My Account3";
            s1c1.Type = "RRSP";
            source2.Add(s1c1);
            s1c1 = new Source2Class();
            s1c1.Currency = "U";
            s1c1.CustodianCode = "hjiCode";
            s1c1.Name = "My Account4";
            s1c1.Type = "Fund";
            source2.Add(s1c1);
        }
        private static string Type1Conversion(string type)
        {
            if(type == "1")
            {
                return "Trading";
            }else if (type == "2")
            {
                return "RRSP";
            }
            else if (type == "3")
            {
                return "RESP";
            }
            else if (type == "4")
            {
                return "Fund";
            }
            else
            {
                return "";
            }
        }
        private static string CurrencyConversion(string c)
        {
            if (c == "CD" || c == "C")
            {
                return "CAD";
            }
            else if (c == "US" || c == "U")
            {
                return "USD";
            }
            else
            {
                return "";
            }
        }
        public class Source1Class
        {
            public string Identifier;
            public string Name;
            public string Type;
            public DateTime Opened;
            public string Currency;
        }

        public class Source2Class
        {
            public string CustodianCode;
            public string Name;
            public string Type;
            public string Currency;
        }

        public class OutputClass
        {
            public string AccountCode;
            public string Name;
            public string Type;
            public DateTime OpenDate;
            public string Currency;
        }
    }
}
