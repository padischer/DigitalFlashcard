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
        public string WordToTranslate { get; set; }
        public string Translation { get; set; }
        
        //constructor setting German and Englisch word of Card
        public Card(string gerWord, string engWord)
        {
            WordToTranslate = gerWord;
            Translation = engWord;
        }

        public void SwitchLanguage()
        {
            string tempSave = WordToTranslate;
            WordToTranslate = Translation;
            Translation = tempSave;
        }

        public bool VerityTranslation(string input)
        {
            if (input == Translation)
            {
                return true;
            }
            else return false;
        }
    }
}
