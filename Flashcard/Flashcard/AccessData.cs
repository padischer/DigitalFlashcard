using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirtableApiClient;
using static Flashcard.CardBox;

namespace Flashcard
{
    internal class AccessData
    {

		private AirtableRecord _entity;
		private readonly string _baseId = "appeI57le2itTZ5OB";
		private readonly string _appKey = "keyRRvdduRcmmFRuY";
		private const string _saveStateID = "reciz8CK3CwjtINCY";
		private const string _saveStateTableName = "SaveState";
		private const string _cardTableName = "Card";
		private const string _slotText = "Slot";
		private const string _slotIndexText = "SlotIndex";
		private const string _germanWordText = "GermanWord";
		private const string _englishWordText = "EnglishWord";
		private const string _baseText = "basis";
		private const string _difficultyText = "Difficulty";
		private const string _primaryLanguageText = "PrimaryLanguage";
		private const string _unkownErrorText = "Unkown error";
		private const string _detailedErrorText = "\nDetailed error message: ";

        public void CreateCard(string gerWord, string engWord, string difficultyString)
        {
            Difficulties difficulty;
            if (difficultyString == _baseText)
            {
                difficulty = CardBox.Difficulties.Basic;
            }
            else
            {
                difficulty = CardBox.Difficulties.Advanced;
            }

            Fields cardData = new Fields();
            cardData.AddField(_germanWordText, gerWord);
            cardData.AddField(_englishWordText, engWord);
            cardData.AddField(_difficultyText, difficulty);
            cardData.AddField(_slotText, 0);

            CreateRecord(_cardTableName, cardData);
        }

        public void UpdateCard(string gerWord, string engWord, string difficulty, string cardID) 
		{
            int difficultyNumber;
            Fields cardData = new Fields();

            if (difficulty == _baseText)
            {
                difficultyNumber = 0;
            }
            else
            {
                difficultyNumber = 1;
            }

            cardData.AddField(_germanWordText, gerWord);
            cardData.AddField(_englishWordText, engWord);
            cardData.AddField(_difficultyText, difficultyNumber);

            UpdateRecord(cardData, cardID, _cardTableName);	
		}

        public void UpdateAllCards(IdFields[] idFields)
        {
            using (AirtableBase airtableBase = new AirtableBase(_appKey, _baseId))
            {
                Task<AirtableCreateUpdateReplaceMultipleRecordsResponse> task = airtableBase.UpdateMultipleRecords(_cardTableName, idFields);
                var response = task.Result;
                if (!response.Success)
                {
                    string errorMessage = null;
                    if (response.AirtableApiError is AirtableApiException)
                    {
                        errorMessage = response.AirtableApiError.ErrorMessage;
                        if (response.AirtableApiError is AirtableInvalidRequestException)
                        {
                            errorMessage += "\nDetailed error message: ";
                            errorMessage += response.AirtableApiError.DetailedErrorMessage;
                        }
                    }
                    else
                    {
                        errorMessage = "Unknown error";
                    }
                    // Report errorMessage
                }
                else
                {

                }
            }
        }

        public void UpdateCardSlot(CardBox.Slots slot, string cardID)
        {
            Fields cardData = new Fields();
            cardData.AddField(_slotText, slot);
            UpdateRecord(cardData, cardID, _cardTableName);
        }


		public void UpdateSaveState(CardBox.Slots slot, CardBox.Languages primaryLanguage, CardBox.Difficulties difficulty)
		{
			Fields saveStateData = new Fields();
			saveStateData.AddField(_slotIndexText, slot);
			saveStateData.AddField(_primaryLanguageText, primaryLanguage);
			saveStateData.AddField(_difficultyText, difficulty);

			using (AirtableBase airtableBase = new AirtableBase(_appKey, _baseId))
			{
				Task<AirtableCreateUpdateReplaceRecordResponse> task = airtableBase.UpdateRecord(_saveStateTableName, saveStateData, _saveStateID);
				var response = task.Result;

				if (!response.Success)
				{
					string errorMessage = String.Empty;
					if (response.AirtableApiError is AirtableApiException)
					{
						errorMessage = response.AirtableApiError.ErrorMessage;
						if (response.AirtableApiError is AirtableInvalidRequestException)
						{
							errorMessage += _detailedErrorText;
							errorMessage += response.AirtableApiError.DetailedErrorMessage;
						}
						else
						{
							errorMessage = _unkownErrorText;
						}
					}
				}
			}
		}

        public void ResetAllCardSlots(List<Card> cardList)
        {
            int count = 0;
            for (int j = 0; j < cardList.Count / 10; j++)
            {
                count = ResetSlotOfCertainCards(10, ref count, cardList);
            }

            int restOfCardsCount = cardList.Count % 10;

            if (restOfCardsCount != 0)
            {
                ResetSlotOfCertainCards(restOfCardsCount, ref count, cardList);

            }
        }

        private int ResetSlotOfCertainCards(int amount, ref int indexOfCardList, List<Card> cardList)
        {
            IdFields[] idFields = new IdFields[amount];
            int maxIterations = indexOfCardList;
            for (int i = indexOfCardList; i < maxIterations + amount; i++)
            {
                idFields[i - maxIterations] = new IdFields(cardList[i].ID);
                idFields[i - maxIterations].AddField(_slotText, 0);
                indexOfCardList++;
            }

            UpdateAllCards(idFields);
            return indexOfCardList;
        }

        public void DeleteCard(string recordID)
        {
			using (AirtableBase airtableBase = new AirtableBase(_appKey, _baseId))
			{
				Task<AirtableDeleteRecordResponse> task = airtableBase.DeleteRecord(_cardTableName, recordID);
				var response = task.Result;
				if (!response.Success)
				{
					string errorMessage = null;
					if (response.AirtableApiError is AirtableApiException)
					{
						errorMessage = response.AirtableApiError.ErrorMessage;
						if (response.AirtableApiError is AirtableInvalidRequestException)
						{
							errorMessage += _detailedErrorText;
							errorMessage += response.AirtableApiError.DetailedErrorMessage;
						}
						else
						{
							errorMessage = _unkownErrorText;
						}
					}

					// Report errorMessage
				}
			}
		}

        

		private async void CreateRecord(string tableName, Fields record)
        {
			string offset = null;
			string errorMessage = null;
			var records = new List<AirtableRecord>();
			using (AirtableBase airtableBase = new AirtableBase(_appKey, _baseId))
			{
				Task<AirtableCreateUpdateReplaceRecordResponse> task = airtableBase.CreateRecord(tableName, record, true);
				AirtableCreateUpdateReplaceRecordResponse response = await task;

				if (!response.Success)
				{
					if (response.AirtableApiError is AirtableApiException)
					{
						errorMessage = response.AirtableApiError.ErrorMessage;
					}
					else
					{
						errorMessage = "Unknown error";
					}
				}
			}
		}
		

		public Tuple<Slots, Languages, Difficulties> GetSaveState()
        {
			
			GetRecord(_saveStateTableName, _saveStateID);
            
            Difficulties difficulty = Difficulties.Basic;
            Languages language = Languages.German;
            Slots slot = Slots.FirstSlot;
			foreach(var field in _entity.Fields)
            {
				switch (field.Key)
				{
					case _slotIndexText:
                        Enum.TryParse(field.Value.ToString(), out slot);
						break;

                    case _primaryLanguageText:
                        Enum.TryParse(field.Value.ToString(), out language);
                        break;

                    case _difficultyText:
                        Enum.TryParse(field.Value.ToString(), out difficulty);
                        break;


                    
                }
                
            }
            
            return Tuple.Create(slot, language, difficulty);
        }

		public List<Card> GetAllCards()
		{
			List<AirtableRecord> recordList = ReadAllRecords(_cardTableName);
			CardBox.Difficulties difficulty = CardBox.Difficulties.Basic;
			string wordToTranslate = string.Empty;
			string translation = string.Empty;
			Slots slot = Slots.FirstSlot;
			List<Card> cards = new List<Card>();
			foreach (AirtableRecord record in recordList)
			{
				foreach (var field in record.Fields)
				{
					switch (field.Key)
					{
						case _germanWordText:
							wordToTranslate = field.Value.ToString();
							break;

						case _englishWordText:
							translation = field.Value.ToString();
							break;

						case _difficultyText:
							Enum.TryParse(field.Value.ToString(), out difficulty);
							break;

						case _slotText:
                            Enum.TryParse(field.Value.ToString(), out slot);
                            break;
					}
				}


				cards.Add(new Card(wordToTranslate, translation, slot, difficulty, record.Id));
			}
			return cards;
		}

        private List<AirtableRecord> ReadAllRecords(string tableName)
        {
            string errorMessage = String.Empty;
            List<AirtableRecord> data = new List<AirtableRecord>();
            var records = new List<AirtableRecord>();
            using (AirtableBase airtableBase = new AirtableBase(_appKey, _baseId))
            {
                Task<AirtableListRecordsResponse> task = airtableBase.ListRecords(tableName);
                AirtableListRecordsResponse response = task.Result;

                if (response.Success)
                {
                    data.AddRange(response.Records.ToList());
                    return data;
                }
                else if (response.AirtableApiError is AirtableApiException)
                {
                    errorMessage = response.AirtableApiError.ErrorMessage;
                    if (response.AirtableApiError is AirtableInvalidRequestException)
                    {
                        errorMessage += "\nDetailed error message: ";
                        errorMessage += response.AirtableApiError.DetailedErrorMessage;
                    }
                    return null;
                }
                else
                {
                    errorMessage = "Unknown error";
                    return null;
                }
            }
        }

        private void GetRecord(string tableName, string idOfRecord)
        {
            _entity = new AirtableRecord();
            using (AirtableBase airtableBase = new AirtableBase(_appKey, _baseId))
            {
                Task<AirtableRetrieveRecordResponse> task = airtableBase.RetrieveRecord(tableName, idOfRecord);
                var response = task.Result;
                if (!response.Success)
                {
                    string errorMessage = null;
                    if (response.AirtableApiError is AirtableApiException)
                    {
                        errorMessage = response.AirtableApiError.ErrorMessage;
                    }
                    else
                    {
                        errorMessage = "Unknown error";
                    }
                }
                else
                {
                    _entity = response.Record;
                }
            }
        }

        private async void UpdateRecord(Fields input, string recordID, string tableName)
        {
            using (AirtableBase airtableBase = new AirtableBase(_appKey, _baseId))
            {
                Task<AirtableCreateUpdateReplaceRecordResponse> task = airtableBase.UpdateRecord(tableName, input, recordID);
                var response = await task;

                if (!response.Success)
                {
                    string errorMessage = String.Empty;
                    if (response.AirtableApiError is AirtableApiException)
                    {
                        errorMessage = response.AirtableApiError.ErrorMessage;
                        if (response.AirtableApiError is AirtableInvalidRequestException)
                        {
                            errorMessage += _detailedErrorText;
                            errorMessage += response.AirtableApiError.DetailedErrorMessage;
                        }
                        else
                        {
                            errorMessage = _unkownErrorText;
                        }
                    }
                }
            }
        }
        
	}
}
