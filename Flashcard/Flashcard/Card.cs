using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcard
{
    internal class Card
    {
        public string Difficulty { get; set; }
        public string EnglishWord { get; set; }
        public string GermanWord { get; set; }
        
        public Card(string gerWord, string engWord)
        {
            GermanWord = gerWord;
            EnglishWord = engWord;
        }

    }
}
