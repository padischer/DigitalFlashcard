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
        private string _currentDifficulty = "basis";

        //constructor reading input data and putting into 
        public CardBox(string dataSource)
        {

            string[] fileInputData = System.IO.File.ReadAllLines(dataSource);

            for (int i = 0; i < fileInputData.Length; i++)
            {
                string[] dataLine = fileInputData[i].Split(",",3);
                int test = dataLine.Length;
                int tmep = fileInputData.Length;
                CardList.Add(new Card(dataLine[0], dataLine[1], 1, dataLine[2]));
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

        public void WriteCardsToFile(string path)
        {
            string[] fileInput = new string[CardList.Count];

            for (int i = 0; i < CardList.Count; i++)
            {
                fileInput[i] = CardList[i].WordToTranslate + "," + CardList[i].Translation + "," + CardList[i].Difficulty;
            }

            System.IO.File.WriteAllLines(path, fileInput);
        }
        


    }
}
