using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Web;
using BibliotekarzBlazor.Model;
using Microsoft.AspNetCore.Components.Forms;

namespace BibliotekarzBlazor.Pages;

public partial class Home
{
    private Person person { get; set; } = new Person();


    protected override void OnInitialized()
    {

    }

    private void AddPerson(EditContext context)
    {
    }
}