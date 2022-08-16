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
        public int _currentSlotIndex = 0;
        public Languages _primaryLanguage = Languages.German;
        public Difficulties _currentDifficulty = Difficulties.Basic;
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
                    if (field.Key == "Slot")
                    {
                        _currentSlotIndex = Int32.Parse(field.Value.ToString());
                    }
                    if (field.Key == "PrimaryLanguage")
                    {
                        Enum.TryParse<Languages>(field.Value.ToString(), out _primaryLanguage);
                    }
                    if (field.Key == "Difficulty")
                    {
                        Enum.TryParse<Difficulties>(field.Value.ToString(), out _currentDifficulty);
                    }
                }
            }
            List<AirtableRecord> dataSource = _dataManager.GetAllRecords("Card");
            List<string> data = new List<string>();
            Difficulties difficulty = Difficulties.Basic;
            string wordToTranslate = string.Empty;
            string translation = string.Empty;
            int slot = 1;
            string iD = String.Empty;
            foreach (AirtableRecord record in dataSource)
            {
                foreach(var field in record.Fields)
                {
                    if (field.Key == "GermanWord")
                    {
                        wordToTranslate = field.Value.ToString();
                    }
                    if (field.Key == "EnglishWord")
                    {
                        translation = field.Value.ToString();
                    }
                    if (field.Key == "Slot")
                    {
                        slot = Int32.Parse(field.Value.ToString());
                    }
                    if (field.Key == "Difficulty")
                    {
                        Enum.TryParse<Difficulties>(field.Value.ToString(), out difficulty);
                    } 
                }
                iD = record.Id;
                if (_primaryLanguage != Languages.German)
                {
                    string tempSave = wordToTranslate;
                    wordToTranslate = translation;
                    translation = tempSave;
                }

                _cardList.Add(new Card(wordToTranslate, translation, slot, difficulty, iD));
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

        public void AddNewCard(string gerWord, string engWord, string difficultyNumber)
        {

            Difficulties difficulty = Difficulties.Basic;
            Enum.TryParse<Difficulties>(difficultyNumber.ToString(), out difficulty);

            if(_primaryLanguage == Languages.German)
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
            Fields cardData = new Fields();
            
            cardData.AddField("GermanWord", germanWord);
            cardData.AddField("EnglishWord", translation);
            cardData.AddField("Difficulty", difficulty);
            cardData.AddField("Slot", "1");
         
            _dataManager.CreateRecord("Card", cardData);
        }

        public void UpdateSaveState()
        {
            
            Fields saveStateData = new Fields();
            int slot = _currentSlotIndex + 1;
            saveStateData.AddField("Slot", slot);
            saveStateData.AddField("PrimaryLanguage", _primaryLanguage);
            saveStateData.AddField("Difficulty", _currentDifficulty);
            
            _dataManager.UpdateSaveState("SaveState", saveStateData);
        }
    }
}
