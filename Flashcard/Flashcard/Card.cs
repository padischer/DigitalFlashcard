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
        public string WordToTranslate { get; private set; }
        public string Translation { get; private set; }
        public int SlotID { get; set; }
        //constructor setting German and Englisch word of Card
        public Card(string wordToTranslate, string translation, int slot, string difficulty)
        {
            WordToTranslate = wordToTranslate;
            Translation = translation;
            SlotID = slot;
            Difficulty = difficulty;
        }

        public void SwitchLanguage()
        {
            string tempSave = WordToTranslate;
            WordToTranslate = Translation;
            Translation = tempSave;
        }

        public bool VerityTranslation(string input)
        {
            return input == Translation;
        }
    }
}
