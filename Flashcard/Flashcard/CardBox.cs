using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcard
{
    internal class CardBox
    {
        private int _currentSlotIndex = 0;
        private Card _currentCard;
        private string _primaryLanguage = "german";
        private List<Card> CardList = new List<Card>();
        private string _currentDifficulty;

        //constructor reading input data and putting into 
        public CardBox(string dataSource)
        {

            string[] fileInputData = System.IO.File.ReadAllLines(dataSource);

            for (int i = 0; i < fileInputData.Length; i++)
            {
                string[] dataLine = fileInputData[i].Split(",");
                CardList.Add(new Card(dataLine[0], dataLine[1], 1));
            }
        }

        private List<Card> GetCurrentCards()
        {
            return CardList.Where(c => c.SlotID == _currentSlotIndex+1).ToList();
        }

        //returning all translations from current Slot
        public string[] GetPossibleTranslations()
        {
            return GetCurrentCards().Select(c => c.Translation).ToArray();
        }
        

        //returning a random german word from current Slot
        public string SelectRandomWordToTranslate()
        {
            if (CardList.Where(c => c.SlotID == _currentSlotIndex+1).ToList().Count > 0)
            {
                Random rnd = new Random();
                var reeee = GetCurrentCards().Count;
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

        public void AddNewCard(string gerWord, string engWord)
        {
            if(_primaryLanguage == "german")
            {
                CardList.Add(new Card(gerWord, engWord, 1));
            }
            else
            {
                CardList.Add(new Card(engWord, gerWord, 1));
            }
        }
        
        public void SwitcDifficulty()
        {
            if(_currentDifficulty == "basic")
            {
                _currentDifficulty = "advanced";
            }
            else
            {
                _currentDifficulty = "basic";
            }
        }
    }
}
