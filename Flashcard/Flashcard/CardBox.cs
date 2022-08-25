﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirtableApiClient;

namespace Flashcard
{
    public class CardBox
    {
        private int _currentSlotIndex = 1;
        public int SlotCount { get; private set; }
        private Languages _currentPrimaryLanguage;
        private Difficulties _currentDifficulty;
        public Card CurrentCard { get; private set; }
        private List<Card> _cardList = new List<Card>();
        private const string _basisText = "basis";

        public enum Languages
        {
            German = 0,
            English = 1
        }
        public enum Difficulties
        {
            Basic = 0,
            Advanced = 1
        }

        //constructor reading input data and putting into 
        public CardBox(int[] saveState, List<Card> cardList)
        {
            SlotCount = 3;
            _cardList = cardList;
            InitializeSaveState(saveState);
        }

        private void InitializeSaveState(int[] saveState)
        {
            _currentSlotIndex = saveState[0];
            Enum.TryParse<Languages>(saveState[1].ToString(), out _currentPrimaryLanguage);
            Enum.TryParse<Difficulties>(saveState[2].ToString(), out _currentDifficulty);
        }

        //returning all translations from current Slot
        public string[] GetPossibleTranslations()
        {
            List<Card> possibleCards = GetCurrentCards();
            return possibleCards.Select(c => c.Translation).ToArray();
        }


        private List<Card> GetCurrentCards()
        {
            List<Card> cardsFromCurrentSlot = _cardList.Where(c => c.SlotID == _currentSlotIndex + 1).ToList();
            return cardsFromCurrentSlot.Where(c => c.Difficulty == _currentDifficulty).ToList();
        }

        //statt nächstes Wort die nächste
        public Card SelectRandomCard()
        {
            if (GetCurrentCards().Where(c => c.SlotID == _currentSlotIndex+1).ToList().Count > 0)
            {
                Random rnd = new Random();
                CurrentCard = GetCurrentCards()[rnd.Next(0, GetCurrentCards().Count)];
                return CurrentCard;
            }
            else
            {
                return null;
            }
        }

        public void SetCurrentCard(Card card)
        {
            CurrentCard = card;
        }

        //checking wether the translation of the user was correct or not and moving the Card to another Slot and printing a message
        public bool VerifyTranslation(string input)
        {
            if(CurrentCard.VerifyTranslation(input))
            {
                if(_currentSlotIndex != 2)
                {
                    CurrentCard.SlotID++;
                }
                return true;
            }
            else
            {
                if(_currentSlotIndex != 0)
                {
                    CurrentCard.SlotID--;
                }
                return false;
            }

            
        }

        public void ResetAllCardSlots()
        {
            foreach (Card card in _cardList)
            {
                card.SlotID = 1;
            }
        }

        public void SwitchSlot(int slotNumber)
        {
            if(slotNumber > 0 && slotNumber <= SlotCount)
            {
                _currentSlotIndex = slotNumber - 1;
            }            
        }
        

        public void SwitchLanguage()
        {
            foreach(Card card in _cardList)
            {
                card.SwitchLanguage();
            }

            if (_currentPrimaryLanguage == Languages.German)
            {
                _currentPrimaryLanguage = Languages.English;
            }
            else
            {
                _currentPrimaryLanguage = Languages.German;
            }
        }

        public void AddNewCard(string gerWord, string engWord, string difficultyString)
        {
            Difficulties difficulty;
            if (difficultyString == _basisText)
            {
                difficulty = CardBox.Difficulties.Basic;
            }
            else
            {
                difficulty = CardBox.Difficulties.Advanced;
            }

            if (_currentPrimaryLanguage == Languages.German)
            {
                _cardList.Add(new Card(gerWord, engWord, 1, difficulty));
            }
            else
            {
                _cardList.Add(new Card(engWord, gerWord, 1, difficulty));
            }
        }


        public string GetCurrentDifficultyText()
        {
            if (_currentDifficulty == Difficulties.Basic)
            {
                return "basis";
            }
            else
            {
                return "erweitert";
            }
        }



        public void SwitchDifficulty()
        {
            if(_currentDifficulty == Difficulties.Basic)
            {
                _currentDifficulty = Difficulties.Advanced;
            }
            else
            {
                _currentDifficulty = Difficulties.Basic;
            }
        }

        

        public int[] GetSaveState()
        {
            int[] saveStateData = new int[3];

            saveStateData[0] = _currentSlotIndex;
            saveStateData[1] = (int)_currentPrimaryLanguage;
            saveStateData[2] = (int)_currentDifficulty;

            return saveStateData;
        }

        public int GetCurrentSlotIndex()
        {
            return _currentSlotIndex;
        }

        public Difficulties GetCurrentDifficulty()
        {
            return _currentDifficulty;
        }
        
        public Languages GetCurrentPrimaryLanguage()
        {
            return _currentPrimaryLanguage;
        }

        public string GetCurrentPrimaryLanguageText()
        {
            if (_currentPrimaryLanguage == Languages.German)
            {
                return "deu->eng";
            }
            else
            {
                return "eng->deu";
            }
        }

        public List<Card> GetCardList()
        {
            return _cardList;
        }
    }
}
