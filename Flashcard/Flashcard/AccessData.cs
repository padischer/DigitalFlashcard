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


		
		private async Task ReturnGetDataTask()
		{
			string baseId = "appeI57le2itTZ5OB";
			string appKey = "keyRRvdduRcmmFRuY";

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

		private async Task ReturnSendDataTask(Fields recordInput)
        {
			string baseId = "appeI57le2itTZ5OB";
			string appKey = "keyRRvdduRcmmFRuY";

			string offset = null;
			string errorMessage = null;
			var records = new List<AirtableRecord>();
			using (AirtableBase airtableBase = new AirtableBase(appKey, baseId))
			{

				Task<AirtableCreateUpdateReplaceRecordResponse> task = airtableBase.CreateRecord("Projects", recordInput, true);
				AirtableCreateUpdateReplaceRecordResponse response = await task;

				if (!response.Success)
				{
					
					// Report errorMessage
				}
				else
				{
					var record = response.Record;
					// Do something with your created record.
				}
				}
		}

		public List<AirtableRecord> GetData()
		{
			var a = ReturnGetDataTask();
			a.Wait();
			return data;
		}

		public void PostData(Fields input)
        {
			var a = ReturnSendDataTask(input);
			a.Wait();
        }
	}
}
