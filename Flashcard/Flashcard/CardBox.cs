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
        private Languages _primaryLanguage;
        private Difficulties _currentDifficulty;
        private Card _currentCard;
        private List<Card> _cardList = new List<Card>();
        private AccessData _dataManager = new AccessData();
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
            List<AirtableRecord> saveState = _dataManager.GetAllRecords("SaveState");
            foreach (AirtableRecord record in saveState)
            {
                foreach(var field in record.Fields){
                    switch (field.Key)
                    {
                        case "SlotIndex":
                            _currentSlotIndex = Int32.Parse(field.Value.ToString());
                        break;

                        case "PrimaryLanguage":
                            Enum.TryParse<Languages>(field.Value.ToString(), out _primaryLanguage);
                        break;

                        case "Difficulty":
                            Enum.TryParse<Difficulties>(field.Value.ToString(), out _currentDifficulty);
                        break;
                    }
                }
            }

            _cardList = GetAllCards();
            
        }

        public List<Card> GetAllCards()
        {
            List<AirtableRecord> dataSource = _dataManager.GetAllRecords("Card");
            Difficulties difficulty = Difficulties.Basic;
            string wordToTranslate = string.Empty;
            string translation = string.Empty;
            int slot = 1;
            string iD = String.Empty;
            List<Card> cards = new List<Card>();
            foreach (AirtableRecord record in dataSource)
            {
                foreach (var field in record.Fields)
                {
                    switch (field.Key)
                    {
                        case "GermanWord":
                            wordToTranslate = field.Value.ToString();
                            break;

                        case "EnglishWord":
                            translation = field.Value.ToString();
                            break;

                        case "Difficulty":
                            Enum.TryParse<Difficulties>(field.Value.ToString(), out difficulty);
                            break;

                        case "Slot":
                            slot = Int32.Parse(field.Value.ToString());
                            break;
                    }
                }

                iD = record.Id;

                if (_primaryLanguage != Languages.German)
                {
                    string tempSave = wordToTranslate;
                    wordToTranslate = translation;
                    translation = tempSave;
                }

                cards.Add(new Card(wordToTranslate, translation, slot, difficulty, iD));
            }
            return cards;
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

        //changing current Slotnumber
        public void SwitchSlot(int slotNumber)
        {
            _currentSlotIndex = slotNumber-1;
        }
        
        //switching cardtext between ger->eng and eng->ger
        public void SwitchLanguage()
        {
            foreach(Card card in _cardList)
            {
                card.SwitchLanguage();
            }

            if (_primaryLanguage == Languages.German)
            {
                _primaryLanguage = Languages.English;
            }
            else
            {
                _primaryLanguage = Languages.German;
            }
        }

        public void AddNewCard(string gerWord, string engWord, string difficultyString)
        {
            Difficulties difficulty;
            if (difficultyString == "basis")
            {
                difficulty = CardBox.Difficulties.Basic;
            }
            else
            {
                difficulty = CardBox.Difficulties.Advanced;
            }

            if (_primaryLanguage == Languages.German)
            {
                _cardList.Add(new Card(gerWord, engWord, 1, difficulty));
            }
            else
            {
                _cardList.Add(new Card(engWord, gerWord, 1, difficulty));
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

        public void PostNewCard(string germanWord, string translation, string difficulty)
        {
            int difficultyNumber;
            Fields cardData = new Fields();

            if(difficulty == "basis")
            {
                difficultyNumber = 0;
            }
            else
            {
                difficultyNumber = 1;
            }

            cardData.AddField("GermanWord", germanWord);
            cardData.AddField("EnglishWord", translation);
            cardData.AddField("Difficulty", difficultyNumber);
            cardData.AddField("Slot", "1");
         
            _dataManager.CreateRecord("Card", cardData);
        }

        public void UpdateSaveState()
        {
            Fields saveStateData = new Fields();
            int slot = _currentSlotIndex;

            saveStateData.AddField("SlotIndex", slot);
            saveStateData.AddField("PrimaryLanguage", _primaryLanguage);
            saveStateData.AddField("Difficulty", _currentDifficulty);
            
            _dataManager.UpdateSaveState("SaveState", saveStateData);
        }

        public void UpdateCard(int slot, string cardID)
        {
            Fields cardData = new Fields();
            cardData.AddField("Slot", slot);
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
            return _primaryLanguage;
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

        public void SetCardList(List<Card> cardList)
        {
            this._cardList = cardList;
        }
    }
}
