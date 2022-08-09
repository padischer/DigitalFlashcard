using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcard
{
    internal class CardBox
    {
        public List<Slot> SlotList { get; private set; }
        public Slot Slot1 { get; private set; }
        public Slot Slot2 { get; private set; }
        public Slot Slot3 { get; private set; }
        private int _currentSlotIndex;
        private Card _currentCard;
        

        //constructor reading input data and putting into 
        public CardBox(string dataSource)
        {
            SetClassVariables();

            string[] fileInputData = System.IO.File.ReadAllLines(dataSource);

            for (int i = 0; i < fileInputData.Length; i++)
            {
                string[] dataLine = fileInputData[i].Split(",");
                SlotList[0].CardList.Add(new Card(dataLine[0], dataLine[1]));
            }
            _currentSlotIndex = 0;
        }

        public void SetClassVariables()
        {
            SlotList = new List<Slot>();
            Slot1 = new Slot();
            Slot1.SlotID = 1;
            Slot1.CardList = new List<Card>();
            SlotList.Add(Slot1);

            Slot2 = new Slot();
            Slot2.SlotID = 2;
            Slot2.CardList = new List<Card>();
            SlotList.Add(Slot2);

            Slot1 = new Slot();
            Slot1.SlotID = 3;
            Slot1.CardList = new List<Card>();
            SlotList.Add(Slot1);
        }

        //returning all translations from current Slot
        public string[] ShowPossibleTranslations()
        {
            List<Card> currentCardList = SlotList[_currentSlotIndex].CardList;
            string[] translationList = new string[currentCardList.Count];
            for(int i = 0; i < currentCardList.Count;i++)
            {
                translationList[i] = currentCardList[i].Translation;
            }
            return translationList;
        }

        //returning a random german word from current Slot
        public string SelectRandomWordToTranslate()
        {
            Random rnd = new Random();
            _currentCard = SlotList[_currentSlotIndex].CardList[rnd.Next(0, SlotList[_currentSlotIndex].CardList.Count)];
            return _currentCard.WordToTranslate;
        }

        //checking wether the translation of the user was correct or not and moving the Card to another Slot and printing a message
        public string VerifyTranslation(string input)
        {
            if(_currentCard.VerityTranslation(input))
            {
                if(_currentSlotIndex != 2)
                {
                    SlotList[_currentSlotIndex].CardList.Remove(_currentCard);
                    _currentSlotIndex++;
                    SlotList[_currentSlotIndex].CardList.Add(_currentCard);
                    _currentSlotIndex--;
                }
                return "Korrekt";
            }
            else
            {
                if(_currentSlotIndex != 0)
                {
                    SlotList[_currentSlotIndex].CardList.Remove(_currentCard);
                    _currentSlotIndex--;
                    SlotList[_currentSlotIndex].CardList.Add(_currentCard);
                    _currentSlotIndex++;
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
            foreach(Slot slot in SlotList)
            {
                foreach (Card card in slot.CardList)
                {
                    card.SwitchLanguage();
                }
            }
        }
    }
}
