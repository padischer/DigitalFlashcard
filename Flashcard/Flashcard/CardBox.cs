using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirtableApiClient;

namespace Flashcard
{
    internal class CardBox
    {
        private int _currentSlotIndex = 0;
        private Card _currentCard;
        private string _primaryLanguage = "german";
        private List<Card> CardList = new List<Card>();
        private string _currentDifficulty = "basis";
        private AccessData accessData = new AccessData();

        //constructor reading input data and putting into 
        public CardBox()
        {
            List<AirtableRecord> dataSource = accessData.GetData();

            List<string> data = new List<string>();
            
            foreach (AirtableRecord record in dataSource)
            {
                foreach(var field in record.Fields)
                {
                    data.Add(field.Value.ToString());
                }
            }
            string[] fileInputData = data.ToArray();


            for (int i = 0; i < fileInputData.Length; i=i+3)
            {
                string[] dataLine = {fileInputData[i], fileInputData[i+1], fileInputData[i+2]};
                CardList.Add(new Card(dataLine[2], dataLine[1], 1, dataLine[0]));
            }
        }


        //returning all translations from current Slot
        public string[] GetPossibleTranslations()
        {
            List<Card> possibleCards = GetCurrentCards();
            return possibleCards.Select(c => c.Translation).ToArray();
        }


        public List<Card> GetCurrentCards()
        {
            List<Card> cardsFromCurrentSlot = CardList.Where(c => c.SlotID == _currentSlotIndex + 1).ToList();
            return cardsFromCurrentSlot.Where(c => c.Difficulty == _currentDifficulty).ToList();
        }

        //returning a random german word from current Slot
        public string SelectRandomWordToTranslate()
        {
            if (GetCurrentCards().Where(c => c.SlotID == _currentSlotIndex+1).ToList().Count > 0)
            {
                Random rnd = new Random();
                _currentCard = GetCurrentCards()[rnd.Next(0, GetCurrentCards().Count)];
                return _currentCard.WordToTranslate;
            }
            else
            {
                return "";
            }
        }

        //checking wether the translation of the user was correct or not and moving the Card to another Slot and printing a message
        public string VerifyTranslation(string input)
        {
            if(_currentCard.VerityTranslation(input))
            {
                if(_currentSlotIndex != 2)
                {
                    _currentCard.SlotID++;
                }
                return "Korrekt";
            }
            else
            {
                if(_currentSlotIndex != 0)
                {
                    _currentCard.SlotID--;
                }
                return "Falsch! " + _currentCard.Translation + " wäre richtig gewesen";
            }        
        }

        //changing current Slotnumber
        public void SwitchSlot(int slotNumber)
        {
            _currentSlotIndex = slotNumber-1;
        }

        //switching cardtext between ger->eng and eng->ger
        public void SwitchAllCardLanguage()
        {
            foreach(Card card in CardList)
            {
                card.SwitchLanguage();
            }

            if(_primaryLanguage == "german")
            {
                _primaryLanguage = "english";
            }
            else
            {
                _primaryLanguage = "german";
            }
        }

        public void AddNewCard(string gerWord, string engWord, string difficulty)
        {
            if(_primaryLanguage == "german")
            {
                CardList.Add(new Card(gerWord, engWord, 1, difficulty));
            }
            else
            {
                CardList.Add(new Card(engWord, gerWord, 1, difficulty));
            }
        }
        
        public void SwitchDifficulty()
        {
            if(_currentDifficulty == "basis")
            {
                _currentDifficulty = "erweitert";
            }
            else
            {
                _currentDifficulty = "basis";
            }
        }

        public void PostNewCard(string germanWord, string translation, string difficulty)
        {
            Fields cardData = new Fields();
            
            cardData.AddField("GermanWord", germanWord);
            cardData.AddField("EnglishWord", translation);
            cardData.AddField("Difficulty", difficulty);
         
            accessData.PostData(cardData);
        }
        /*
        public string[] GetSaveState()
        {
            string[] saveState = new string[3];
            saveState[0] = _currentSlotIndex.ToString() + ",";
            saveState[1] =
        }
        */
    }
}
