using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcard
{
    internal class Card
    {
        public string _difficulty { get; set; }
        public string _englishWord { get; set; }
        public string _germanWord { get; set; }
        
        public Card(string gerWord, string engWord)
        {
            this._germanWord = gerWord;
            this._englishWord = engWord;
        }

    }
}
