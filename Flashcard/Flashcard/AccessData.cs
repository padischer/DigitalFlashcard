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

		private List<AirtableRecord> _data;
		private AirtableRecord _entity;
		private readonly string _baseId = "appeI57le2itTZ5OB";
		private readonly string _appKey = "keyRRvdduRcmmFRuY";
		private const string _saveStateID = "reciz8CK3CwjtINCY";
		private const string _saveStateTableName = "SaveState";
		public async void UpdateSaveState(string tableName, Fields input)
        {
			using (AirtableBase airtableBase = new AirtableBase(_appKey, _baseId))
			{
				Task<AirtableCreateUpdateReplaceRecordResponse> task = airtableBase.UpdateRecord(_saveStateTableName, input, _saveStateID);
				var response = await task;
				 
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

		private async Task GetAllRecordsTask(string tableName)
		{
			string errorMessage = String.Empty;
			var records = new List<AirtableRecord>();
			using (AirtableBase airtableBase = new AirtableBase(_appKey, _baseId))
			{
					Task<AirtableListRecordsResponse> task = airtableBase.ListRecords(tableName);
					AirtableListRecordsResponse response = await task;

					if (response.Success)
					{
						_data.AddRange(response.Records.ToList());
					}
					else if (response.AirtableApiError is AirtableApiException)
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
			}

			
		}

		private async Task GetRecordTask(string tableName, string idOfRecord)
        {
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
		

		public AirtableRecord GetRecord(string tableName, string id)
        {
			_entity = new AirtableRecord();
			var task = GetRecordTask(tableName, id);
			task.Wait();
			return _entity;
        }

		public List<AirtableRecord> GetAllRecords(string tableName)
		{
			_data = new List<AirtableRecord>();
			var task = GetAllRecordsTask(tableName);
			task.Wait();
			return _data;
		}
	}
}
