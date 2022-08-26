using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcard
{
    public class Card
    {
        public string WordToTranslate { get; private set; }
        public string Translation { get; private set; }
        public CardBox.Difficulties Difficulty { get; private set; }
        public CardBox.Languages PrimaryLanguage { get; private set; }
        
        
        public string DifficultyText
        {
            get
            {
                return Difficulty == 0 ? "basis" : "erweitert";
            }
        }

        public string ID { get; set; }
        public CardBox.Slots Slot { get; set; }
        //constructor setting German and Englisch word of Card
        public Card(string wordToTranslate, string translation, CardBox.Slots slot, CardBox.Difficulties difficulty, string iD = "")
        {
            WordToTranslate = wordToTranslate;
            Translation = translation;
            Slot = slot;
            Difficulty = difficulty;
            ID = iD;
            PrimaryLanguage = CardBox.Languages.German;
        }



        public void Update(string wordToTranslate, string translation, CardBox.Difficulties difficulty)
        {
            WordToTranslate = wordToTranslate;
            Translation = translation;
            Difficulty = difficulty;
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

        public string GetGermanWord()
        {
            if(PrimaryLanguage == CardBox.Languages.German)
            {
                return WordToTranslate;
            }
            else
            {
                return Translation;
            }
        }
        
        public string GetEnglishWord()
        {
            if(PrimaryLanguage == CardBox.Languages.English)
            {
                return WordToTranslate;
            }
            else
            {
                return Translation;
            }
        }

    }
}
