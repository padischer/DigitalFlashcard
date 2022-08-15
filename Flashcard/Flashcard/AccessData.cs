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

		private List<AirtableRecord> _data = new List<AirtableRecord>();
		private AirtableRecord _entity = new AirtableRecord();
		private readonly string _baseId = "appeI57le2itTZ5OB";
		private readonly string _appKey = "keyRRvdduRcmmFRuY";

		public async void DeleteRecord(string table, string idOfRecord)
        {
			using (AirtableBase airtableBase = new AirtableBase(_appKey, _baseId))
			{
				Task<AirtableDeleteRecordResponse> task = airtableBase.DeleteRecord(table, idOfRecord);
				var response = await task;
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

		private async Task GetAllRecordsTask(string table)
		{
			string offset = null;
			string errorMessage = null;
			var records = new List<AirtableRecord>();
			using (AirtableBase airtableBase = new AirtableBase(_appKey, _baseId))
			{
				do
				{
					Task<AirtableListRecordsResponse> task = airtableBase.ListRecords(table);
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
						break;
					}
					else
					{
						errorMessage = "Unknown error";
						break;
					}
				} while (offset != null);
			}

			
		}

		private async Task GetRecordTask(string table, string idOfRecord)
        {
			using (AirtableBase airtableBase = new AirtableBase(_appKey, _baseId))
			{
				Task<AirtableRetrieveRecordResponse> task = airtableBase.RetrieveRecord(table, idOfRecord);
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
					_entity = response.Record;
				}
			}
		}

		public async void CreateSaveState(string table, Fields saveStateInput)
        {
			string offset = null;
			string errorMessage = null;
			var records = new List<AirtableRecord>();
			using (AirtableBase airtableBase = new AirtableBase(_appKey, _baseId))
			{
				Task<AirtableCreateUpdateReplaceRecordResponse> task = airtableBase.CreateRecord(table, saveStateInput, false);
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
					// Report errorMessage
				}
				else
				{
					var record = response.Record;
					// Do something with your created record.
				}
			}
		}

		public async void CreateRecord(string table, Fields recordInput)
        {
			string offset = null;
			string errorMessage = null;
			var records = new List<AirtableRecord>();
			using (AirtableBase airtableBase = new AirtableBase(_appKey, _baseId))
			{
				Task<AirtableCreateUpdateReplaceRecordResponse> task = airtableBase.CreateRecord(table, recordInput, false);
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
				else
				{
					var record = response.Record;
				}
			}
		}


		

		public AirtableRecord GetRecord(string table, string id)
        {
			var task = GetRecordTask(table, id);
			task.Wait();
			return _entity;
        }

		public List<AirtableRecord> GetAllRecords(string table)
		{
			var task = GetAllRecordsTask(table);
			task.Wait();
			return _data;
		}

	}
}
