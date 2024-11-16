using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Web;

namespace BibliotekarzBlazor.Pages;

public partial class Home
{
    string cos1;
    private int count = 0;

    [Parameter]
    public int Id { get; set; }

    [Parameter]
    public string CosInnego { get; set; }

    Dictionary<string, object> AdditionalAttributes;

    protected override void OnInitialized()
    {
        AdditionalAttributes = new Dictionary<string, object>
        {
            ["Id"] = "Logos 2",
            ["alt"] = "A logo of dotnet"
        };

        for (int i = 0; i < 5; i++)
        {
            AdditionalAttributes.Add("attribute_" + i, i);
        }

        Uri currentUri = new Uri(navigation.Uri);
        var parameters = HttpUtility.ParseQueryString(currentUri.Query);

        cos1 = parameters["cos1"];
    }
    private void IncrementCount(MouseEventArgs e)
    {
        count++;
    }
    private void NavigateToUrl(MouseEventArgs e)
    {
        navigation.NavigateTo("/counter");
    }
    private void NavigateToAbsoluteUrl(MouseEventArgs e)
    {
        navigation.NavigateTo("https://google.com");
    }
    private void NavigateWithReplaceHistory(MouseEventArgs e)
    {
        navigation.NavigateTo("/counter",false, true);
    }
}