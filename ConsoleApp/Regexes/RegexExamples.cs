using System.Text.RegularExpressions;
using ConsoleApp.TextSearch;

namespace ConsoleApp.Regexes
{
    public class RegexExamples
    {
        string text =
            "Lorem Ipsum is simply dummy text of the printing and typesetting industry." +
            " Lorem Ipsum has been the industry's standard dummy text ever since the 1500s," +
            " when an unknown printer took a galley of type and scrambled it to make a type specimen book.\r\n" +
            " It has survived not only five centuries, but also the leap into \"electronic typesetting\", remaining essentially unchanged." +
            " It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages," +
            " and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum." +
            "- Kalle Anka, kalle.anka@mail.com, 555-345673";

        
        public void Run()
        {
            //Find first occurence of exact match
            var exact = new Regex(@"Kalle");

            exact.Match(text).Dump();
            "------".Dump();
            
            //Match a word beginning with a capital letter
            //Character classes or Character Set
            //gr[ae]y to match either gray or grey.
            var filter = new Regex(@"[A-Z]\w+");

            filter.IsMatch(text).Dump();
            
            "-----".Dump();
            
            filter.Match(text).Dump();

            "------".Dump();
            
            foreach (Match match in filter.Matches(text))
            {
                match.Value.Dump();
            }

            "------".Dump();
            
            //Backreferences
            var bfilter = new Regex(@"(Lorem).*\1");
            bfilter.Match(text).Dump();
            
            "------".Dump();
            
            //lookaheads and lookbehinds
            // is preceded by a " that is not captured (lookbehind)
            // a non-greedy captured group. It's non-greedy to stop at the first "
            // and is followed by a " that is not captured (lookahead).
            //Regular Expression to find a string included between two characters while EXCLUDING the delimiters
            var bfilter2 = new Regex("(?<=\")(.*?)(?=\")");
            bfilter2.Match(text).Dump();

            "------".Dump();
            
            //Replace regex
            var bfilter3 = new Regex("[A-Z]");
            bfilter3.Replace(text, "X").Dump();
            bfilter3.Replace(text, x => x.Value.ToLower()).Dump();
            
            "------".Dump();
             
            //Validate
            //Check if a number is a swedish phone number
            //	^(([+]\d{2}[ ][1-9]\d{0,2}[ ])|([0]\d{1,3}[-]))((\d{2}([ ]\d{2}){2})|(\d{3}([ ]\d{3})*([ ]\d{2})+))$
            //Pass +46 8 123 456 78|||08-123 456 78|||0123-456 78
            //Fail 	+46 08-123 456 78|||08 123 456 78|||0123 456 78
            //var phoneValidation = new Regex(@"^(([+]\d{2}[ ][1-9]\d{0,2}[ ])|([0]\d{1,3}[-]))((\d{2}([ ]\d{2}){2})|(\d{3}([ ]\d{3})*([ ]\d{2})+))$");
        }
    }
}