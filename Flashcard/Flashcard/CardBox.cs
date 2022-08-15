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
        private Languages _primaryLanguage = Languages.German;
        private List<Card> _cardList = new List<Card>();
        private Difficulties _currentDifficulty = Difficulties.Basic;
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
            List<AirtableRecord> dataSource = _dataManager.GetAllRecords("Card");

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
                Difficulties difficulty = Enum.Parse(Difficulties, dataLine[0]);

                _cardList.Add(new Card(dataLine[2], dataLine[1], 1, difficulty));
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
        1
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

        public void AddNewCard(string gerWord, string engWord, string difficulty)
        {
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
            if(_currentDifficulty == Difficulties.basic)
            {
                _currentDifficulty = Difficulties.advanced;
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
         
            _dataManager.CreateRecord("Card", cardData);
        }

        public void UpdateSaveState()
        {
            Fields saveStateData = new Fields();
            

            saveStateData.AddField("Slot", _currentSlotIndex+1);
            saveStateData.AddField("PrimaryLanguage", _primaryLanguage);
            saveStateData.AddField("Difficulty", _currentDifficulty);
            
            _dataManager.UpdateRecord("SaveState", "1", saveStateData);
        }
    }
}
