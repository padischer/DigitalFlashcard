using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirtableApiClient;

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

		public void UpdateCard(Fields input, string cardID)
		{
			using (AirtableBase airtableBase = new AirtableBase(_appKey, _baseId))
			{
				Task<AirtableCreateUpdateReplaceRecordResponse> task = airtableBase.UpdateRecord(_cardTableName, input, cardID);
				var response = task.Result;

				if (!response.Success)
				{
					string errorMessage = String.Empty;
					if (response.AirtableApiError is AirtableApiException)
					{
						errorMessage = response.AirtableApiError.ErrorMessage;
						if (response.AirtableApiError is AirtableInvalidRequestException)
						{
							errorMessage += "\nDetailed error message: ";
							errorMessage += response.AirtableApiError.DetailedErrorMessage;
						}
						else
						{
							errorMessage = "Unknown error";
						}
					}
				}
			}
		}

		public void UpdateSaveState(string tableName, Fields input)
		{
			using (AirtableBase airtableBase = new AirtableBase(_appKey, _baseId))
			{
				Task<AirtableCreateUpdateReplaceRecordResponse> task = airtableBase.UpdateRecord(_saveStateTableName, input, _saveStateID);
				var response = task.Result;

				if (!response.Success)
				{
					string errorMessage = String.Empty;
					if (response.AirtableApiError is AirtableApiException)
					{
						errorMessage = response.AirtableApiError.ErrorMessage;
						if (response.AirtableApiError is AirtableInvalidRequestException)
						{
							errorMessage += "\nDetailed error message: ";
							errorMessage += response.AirtableApiError.DetailedErrorMessage;
						}
						else
						{
							errorMessage = "Unknown error";
						}
					}
				}
			}
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
							errorMessage += "\nDetailed error message: ";
							errorMessage += response.AirtableApiError.DetailedErrorMessage;
						}
						else
						{
							errorMessage = "Unknown error";
						}
					}

					// Report errorMessage
				}
			}
		}

		public void UpdateALlCards(IdFields[] idFields)
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
					AirtableRecord[] records = response.Records;
					// Do something with the updated records.
				}
			}
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

		private async Task GetRecordTask(string tableName, string idOfRecord)
        {
			_entity = new AirtableRecord();
			using (AirtableBase airtableBase = new AirtableBase(_appKey, _baseId))
			{
				Task<AirtableRetrieveRecordResponse> task = airtableBase.RetrieveRecord(tableName, idOfRecord);
				var response = await task;
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

                }
			}
		}

		public async void CreateRecord(string tableName, Fields record)
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
		
		private AirtableRecord GetRecord(string tableName, string id)
        {
			_entity = new AirtableRecord();
			var task = GetRecordTask(tableName, id);
			task.Wait();
			return _entity;
        }

		public int[] GetSaveState()
        {
			GetRecord("SaveState", _saveStateID);

			int[] saveState = new int[3];
			for (int i = 0; i < _entity.Fields.Count; i++)
            {
				saveState[i] = Int32.Parse(_entity.Fields.ElementAt(i).ToString());
            }
			return saveState;
		}

		public List<Card> GetAllCards(string tableName)
		{
			List<AirtableRecord> recordList = ReadAllRecords(tableName);
			CardBox.Difficulties difficulty = CardBox.Difficulties.Basic;
			string wordToTranslate = string.Empty;
			string translation = string.Empty;
			int slot = 1;
			List<Card> cards = new List<Card>();
			foreach (AirtableRecord record in recordList)
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
							Enum.TryParse<CardBox.Difficulties>(field.Value.ToString(), out difficulty);
							break;

						case "Slot":
							slot = Int32.Parse(field.Value.ToString());
							break;
					}
				}

				//if (_primaryLanguage != CardBox.Languages.German)
				//{
				//	string tempSave = wordToTranslate;
				//	wordToTranslate = translation;
				//	translation = tempSave;
				//}

				cards.Add(new Card(wordToTranslate, translation, slot, difficulty, record.Id));
			}
			return cards;
		}
	}
}
