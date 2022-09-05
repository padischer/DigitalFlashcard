using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirtableApiClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Flashcard
{
    public class CardBox
    {
        private Slots _currentSlot;
        public int SlotCount { get; private set; }
        private Languages _currentPrimaryLanguage;
        private Difficulties _currentDifficulty;
        public Card CurrentCard { get; private set; }
        private List<Card> _cardList = new List<Card>();
        private const string _basicText = "basis";

        public enum Slots
        {
            FirstSlot = 0,
            SecondSlot = 1,
            ThirdSlot = 2,
        }
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
        public CardBox(Slots slot, Languages primaryLanguage, Difficulties difficulty, List<Card> cardList)
        {
            SlotCount = 3;
            _cardList = cardList;
            InitializeSaveState(slot, primaryLanguage, difficulty);
        }

        private void InitializeSaveState(Slots slot, Languages primaryLanguage, Difficulties difficulty)
        {
            _currentSlot = slot;
            _currentPrimaryLanguage = primaryLanguage;
            _currentDifficulty = difficulty;
        }

        //returning all translations from current Slot
        public string[] GetPossibleTranslations()
        {
            List<Card> possibleCards = GetCurrentCards();
            return possibleCards.Select(c => c.Translation).ToArray();
        }


        private List<Card> GetCurrentCards()
        {
            List<Card> cardsFromCurrentSlot = _cardList.Where(c => c.Slot == _currentSlot).ToList();
            return cardsFromCurrentSlot.Where(c => c.Difficulty == _currentDifficulty).ToList();
        }

        //statt nächstes Wort die nächste
        public Card SelectRandomCard()
        {
            if (GetCurrentCards().Where(c => c.Slot == _currentSlot).ToList().Count > 0)
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
            if (CurrentCard.VerifyTranslation(input))
            {
                if (_currentSlot != Slots.ThirdSlot)
                {
                    CurrentCard.Slot++;
                }
                return true;
            }
            else
            {
                if (_currentSlot != Slots.FirstSlot)
                {
                    CurrentCard.Slot--;
                }
                return false;
            }
        }

        public void ResetAllCardSlots()
        {
            foreach (Card card in _cardList)
            {
                card.Slot = Slots.FirstSlot;
            }
        }

        public void SwitchSlot(Slots newSlot)
        {
            
            if(newSlot >= Slots.FirstSlot && newSlot <= Slots.ThirdSlot)
            {
                _currentSlot = newSlot;
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
            if (difficultyString == _basicText)
            {
                difficulty = CardBox.Difficulties.Basic;
            }
            else
            {
                difficulty = CardBox.Difficulties.Advanced;
            }

            if (_currentPrimaryLanguage == Languages.German)
            {
                _cardList.Add(new Card(gerWord, engWord, Slots.FirstSlot, difficulty));
            }
            else
            {
                _cardList.Add(new Card(engWord, gerWord, Slots.FirstSlot, difficulty));
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

        public Tuple<CardBox.Slots, CardBox.Languages, CardBox.Difficulties> GetSaveState()
        {
            return Tuple.Create(_currentSlot, _currentPrimaryLanguage, _currentDifficulty);
        }

        public Slots GetCurrentSlot()
        {
            return _currentSlot;
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
