using System.Text;
using System.Text.Json;

namespace RfidAccessControl.Desktop;

public partial class MainPage : ContentPage
{
    private static readonly HttpClient httpClient = new HttpClient();

    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnScanClicked(object sender, EventArgs e)
    {
        string tagId = TagIdEntry.Text?.Trim() ?? string.Empty;

        if (string.IsNullOrEmpty(tagId))
        {
            ResultLabel.Text = "Please enter or scan a Tag ID!";
            ResultLabel.TextColor = Colors.Orange;
            return;
        }

        ResultLabel.Text = "Processing scan...";
        ResultLabel.TextColor = Colors.Gray;

        try
        {
            var payload = new { tagId = tagId };
            var json = JsonSerializer.Serialize(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Make request to local C# Web API
            var response = await httpClient.PostAsync("http://localhost:5236/api/access/scan", content);

            // FIX: response.Content.ReadAsStringAsync()
            string responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                using var doc = JsonDocument.Parse(responseBody);
                bool granted = doc.RootElement.GetProperty("granted").GetBoolean();
                string message = doc.RootElement.GetProperty("message").GetString() ?? "No message";

                if (granted)
                {
                    ResultLabel.Text = $"✅ {message}";
                    ResultLabel.TextColor = Colors.Green;
                }
                else
                {
                    ResultLabel.Text = $"❌ Access Denied: {message}";
                    ResultLabel.TextColor = Colors.Red;
                }
            }
            else
            {
                ResultLabel.Text = $"⚠️ Server error: {response.StatusCode}";
                ResultLabel.TextColor = Colors.Orange;
            }
        }
        catch (Exception ex)
        {
            ResultLabel.Text = $"❌ Connection Error: {ex.Message}";
            ResultLabel.TextColor = Colors.Red;
        }
    }
}