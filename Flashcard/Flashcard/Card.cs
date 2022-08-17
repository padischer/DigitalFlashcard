using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcard
{
    public class Card
    {
        public CardBox.Difficulties Difficulty { get; private set; }
        public CardBox.Languages PrimaryLanguage { get; private set; }
        public string WordToTranslate { get; private set; }
        public string Translation { get; private set; }
        public string ID { get; private set; }
        public int SlotID { get; set; }
        //constructor setting German and Englisch word of Card
        public Card(string wordToTranslate, string translation, int slot, CardBox.Difficulties difficulty, string iD = "")
        {
            WordToTranslate = wordToTranslate;
            Translation = translation;
            SlotID = slot;
            Difficulty = difficulty;
            ID = iD;
            PrimaryLanguage = CardBox.Languages.German;
        }

        public void SwitchLanguage()
        {
            string tempSave = WordToTranslate;
            WordToTranslate = Translation;
            Translation = tempSave;
            if(PrimaryLanguage == CardBox.Languages.German)
            {
                PrimaryLanguage = CardBox.Languages.English;
            }
            else
            {
                PrimaryLanguage = CardBox.Languages.German;
            }
        }

        public bool VerifyTranslation(string input)
        {
            return input == Translation;
        }
    }
}
