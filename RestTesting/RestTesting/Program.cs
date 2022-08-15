using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Linq;
using System.Threading.Tasks;
using AirtableApiClient;





public class Program
{
	
	public static void Main(String[] args)
    {
		var a = DoStuff();
		a.Wait();
    }
	public static async Task DoStuff()
	{
		string baseId = "appeI57le2itTZ5OB";
		string appKey = "keyRRvdduRcmmFRuY";

		string offset = null;
		string errorMessage = null;
		var records = new List<AirtableRecord>();
		using (AirtableBase airtableBase = new AirtableBase(appKey, baseId))
		{


			//
			// Use 'offset' and 'pageSize' to specify the records that you want
			// to retrieve.
			// Only use a 'do while' loop if you want to get multiple pages
			// of records.
			//

			do
			{
				Task<AirtableListRecordsResponse> task = airtableBase.ListRecords("Projects");

				AirtableListRecordsResponse response = await task;

				if (response.Success)
				{
					records.AddRange(response.Records.ToList());
					offset = response.Offset;
					foreach (var f in records)
					{
						foreach (var r in f.Fields)
						{
							Console.WriteLine(r.Value.ToString());
							Console.WriteLine("- "+ r.Key);
						}
					}
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

		if (!string.IsNullOrEmpty(errorMessage))
		{
			// Error reporting
		}
		else
		{
			// Do something with the retrieved 'records' and the 'offset'
			// for the next page of the record list.
		}
	}
}