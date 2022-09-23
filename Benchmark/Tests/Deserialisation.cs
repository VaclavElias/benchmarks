using System.Net.Http.Json;
using System.Text.Json;

namespace Benchmark.Tests;

[MemoryDiagnoser]
public class Deserialisation
{
    [Benchmark]
    public async Task ReadAsByteArrayAsync()
    {
        var content = await GetResponseMessage().Content.ReadAsByteArrayAsync();

        var result = JsonSerializer.Deserialize<ChangeResponse>(content);
    }

    [Benchmark]
    public void ReadAsStream()
    {
        var content = GetResponseMessage().Content.ReadAsStream();

        var result = JsonSerializer.Deserialize<ChangeResponse>(content);
    }

    [Benchmark]
    public async Task ReadAsStream2Async()
    {
        var content = GetResponseMessage().Content.ReadAsStream();

        var result = await JsonSerializer.DeserializeAsync<ChangeResponse>(content);
    }

    [Benchmark]
    public async Task ReadAsStringAsync()
    {
        var content = await GetResponseMessage().Content.ReadAsStringAsync();

        var result = JsonSerializer.Deserialize<ChangeResponse>(content);
    }

    [Benchmark]
    public async Task ReadAsStreamAsync()
    {
        var content = await GetResponseMessage().Content.ReadAsStreamAsync();

        var result = JsonSerializer.Deserialize<ChangeResponse>(content);
    }

    [Benchmark]
    public async Task ReadAsStreamAsync2()
    {
        var content = await GetResponseMessage().Content.ReadAsStreamAsync();

        var result = await JsonSerializer.DeserializeAsync<ChangeResponse>(content);
    }

    [Benchmark]
    public async Task ReadFromJsonAsync()
    {
        var content = await GetResponseMessage().Content.ReadFromJsonAsync<ChangeResponse>();
    }

    private HttpResponseMessage GetResponseMessage() => new()
    {
        Content = new StringContent("{\"changedEntityType\":\"PlacementChangeRequest\",\"changedEntityId\":392,\"changeType\":\"INSERT\",\"data\":{\"requestingUser\":{\"id\":570872},\"approvingUser\":{\"id\":570872},\"requestStatus\":\"Approved\",\"requestType\":\"Original\",\"placement\":{\"id\":7260},\"status\":\"Approved\",\"reportTo\":null,\"employmentType\":\"Contract\",\"salary\":0.0,\"fee\":0,\"salaryUnit\":\"Hourly\",\"employeeType\":\"W2\",\"dateApproved\":1663966018967,\"dateBegin\":1663578000000,\"dateEnd\":1663491600000,\"payRate\":42.0,\"clientBillRate\":80,\"overtimeRate\":63,\"customPayRate3\":null,\"customPayRate10\":0.0,\"customText1\":\"Normal\",\"customText2\":null,\"customText4\":null,\"customText5\":null,\"customText6\":\"No\",\"customText7\":null,\"customText8\":\"New\",\"customText14\":null,\"customText19\":null,\"customText34\":\"Twenty TS\",\"customText38\":null,\"customText39\":\"1 week\",\"customText40\":\"1 week\",\"customText41\":\"No\",\"customText44\":\"NA\",\"correlatedCustomText2\":\"Non-EU\",\"correlatedCustomText3\":\"USD\",\"correlatedCustomText4\":\"Both (Hybrid work schedule)\",\"correlatedCustomText5\":\"1\",\"correlatedCustomText10\":\"USD\",\"billingFrequency\":\"Weekly\",\"billingClientContact\":{\"id\":625271},\"statementClientContact\":{\"id\":625271},\"requestCustomDate1\":1663966018967}}")
    };
}
