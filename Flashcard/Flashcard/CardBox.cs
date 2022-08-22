using System;
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
        private Card _currentCard;
        private List<Card> _cardList = new List<Card>();
        private AccessData _dataManager = new AccessData();
        private const string _cardText = "Card";
        private const string _basisText = "basis";
        private const string _slotText = "Slot";
        private const string _difficultyText = "Difficulty";
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
        public CardBox()
        {
            SlotCount = 3;
            _cardList = _dataManager.GetAllCards(_cardText);
            InitializeSaveState();
            
            
        }

        public void InitializeSaveState()
        {
            int[] saveState = _dataManager.GetSaveState();
            _currentSlotIndex = saveState[0];
            Enum.TryParse<Difficulties>(saveState[1].ToString(), out _currentDifficulty);
        }

        public List<Card> GetAllCards()
        {
            List<Card> newCards = _dataManager.GetAllCards(_cardText);
            if(_currentPrimaryLanguage == CardBox.Languages.English)
            {
                foreach(Card card in newCards)
                {
                    card.SwitchLanguage();
                }
            }

            return newCards;
        }

        //returning all translations from current Slot
        public string[] GetPossibleTranslations()
        {
            List<Card> possibleCards = GetCurrentCards();
            return possibleCards.Select(c => c.Translation).ToArray();
        }


        public List<Card> GetCurrentCards()
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
                _currentCard = GetCurrentCards()[rnd.Next(0, GetCurrentCards().Count)];
                return _currentCard;
            }
            else
            {
                return null;
            }
        }

        //checking wether the translation of the user was correct or not and moving the Card to another Slot and printing a message
        public string VerifyTranslation(string input)
        {
            if(_currentCard.VerifyTranslation(input))
            {
                if(_currentSlotIndex != 2)
                {
                    _currentCard.SlotID++;
                    UpdateCard(_currentCard.SlotID, _currentCard.ID);
                }
                return "Korrekt";
            }
            else
            {
                if(_currentSlotIndex != 0)
                {
                    _currentCard.SlotID--;
                    UpdateCard(_currentCard.SlotID, _currentCard.ID);
                }
                return "Falsch! " + _currentCard.Translation + " wäre richtig gewesen";
            }

            
        }

        public void SwitchSlot(int slotNumber)
        {
            if(slotNumber > 0 && slotNumber <= SlotCount)
            {
                _currentSlotIndex = slotNumber - 1;
            }            
        }
        
        //switching cardtext between ger->eng and eng->ger
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
            PostNewCardToDB(gerWord, engWord, difficultyString);
        }


        private void PostNewCardToDB(string germanWord, string translation, string difficulty)
        {
            int difficultyNumber;
            Fields cardData = new Fields();

            if (difficulty == _basisText)
            {
                difficultyNumber = 0;
            }
            else
            {
                difficultyNumber = 1;
            }

            cardData.AddField("GermanWord", germanWord);
            cardData.AddField("EnglishWord", translation);
            cardData.AddField(_difficultyText, difficultyNumber);
            cardData.AddField(_slotText, 1);

            _dataManager.CreateRecord(_cardText, cardData);
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

        

        public void UpdateSaveState()
        {
            Fields saveStateData = new Fields();
            int slot = _currentSlotIndex;

            saveStateData.AddField("SlotIndex", slot);
            saveStateData.AddField("PrimaryLanguage", _currentPrimaryLanguage);
            saveStateData.AddField(_difficultyText, _currentDifficulty);
            
            _dataManager.UpdateSaveState("SaveState", saveStateData);
        }

        public void UpdateCard(int slot, string cardID)
        {
            Fields cardData = new Fields();
            cardData.AddField(_slotText, slot);
            _dataManager.UpdateCard(cardData, cardID);
        }

        public int GetCurrentSlotIndex()
        {
            return _currentSlotIndex;
        }

        public Difficulties GetCurrentDifficulty()
        {
            return _currentDifficulty;
        }
        
        public Languages GetPrimaryLanguage()
        {
            return _currentPrimaryLanguage;
        }

        public void ResetAllCardSlots()
        {
            int count = 0;
            for (int j = 0; j<_cardList.Count/10;j++)
            {
                IdFields[] idFields = new IdFields[10];
                int maxIterations = count;
                for (int i = count; i < maxIterations+10; i++)
                {
                    idFields[i-maxIterations] = new IdFields(_cardList[i].ID);
                    idFields[i-maxIterations].AddField("Slot", 1);
                    count++;
                }

                _dataManager.UpdateALlCards(idFields);
            }

            _cardList = GetAllCards();
        }

        public List<Card> GetCardList()
        {
            return _cardList;
        }
    }
}
