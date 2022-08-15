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

		private List<AirtableRecord> data = new List<AirtableRecord>();
		private readonly string baseId = "appeI57le2itTZ5OB";
		private readonly string appKey = "keyRRvdduRcmmFRuY";

		private async Task GetAllCardsTask()
		{
			string offset = null;
			string errorMessage = null;
			var records = new List<AirtableRecord>();
			using (AirtableBase airtableBase = new AirtableBase(appKey, baseId))
			{
				do
				{
					Task<AirtableListRecordsResponse> task = airtableBase.ListRecords("Projects");
					AirtableListRecordsResponse response = await task;

					if (response.Success)
					{
						data.AddRange(response.Records.ToList());
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

		private async void CreateCardTask(Fields recordInput)
        {
			string offset = null;
			string errorMessage = null;
			var records = new List<AirtableRecord>();
			using (AirtableBase airtableBase = new AirtableBase(appKey, baseId))
			{
				Task<AirtableCreateUpdateReplaceRecordResponse> task = airtableBase.CreateRecord("Projects", recordInput, false);
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

		public List<AirtableRecord> GetAllCards()
		{
			var a = GetAllCardsTask();
			a.Wait();
			return data;
		}

		public void CreateCard(Fields input)
        {
			CreateCardTask(input);
        }
	}
}
