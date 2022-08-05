using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcard
{
    internal class Card
    {
        public string _Difficulty { get; set; }
        public string _EnglishWord { get; set; }
        public string _GermanWord { get; set; }
        
        public Card(string gerWord, string engWord)
        {
            this._GermanWord = gerWord;
            this._EnglishWord = engWord;
        }

    }
}
