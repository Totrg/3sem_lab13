using TodoSQLite.Data;
using TodoSQLite.Models;

namespace TodoSQLite.Views;

[QueryProperty("Item", "Item")]
public partial class LaboratoryItemPage : ContentPage
{
	Laboratory item;
	public Laboratory Item
	{
		get => BindingContext as Laboratory;
		set => BindingContext = value;
	}
    LaborotoryDatabase database;
    public LaboratoryItemPage(LaborotoryDatabase labBase)
    {
        InitializeComponent();
        database = labBase;
    }

    async void OnSaveClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(Item.Name))
        {
            await DisplayAlert("Name Required", "Please enter a name for the item.", "OK");
            return;
        }

        await database.SaveItemAsync(Item);
        await Shell.Current.GoToAsync("..");
    }

    async void OnDeleteClicked(object sender, EventArgs e)
    {
        if (Item.ID == 0)
            return;
        await database.DeleteItemAsync(Item);
        await Shell.Current.GoToAsync("..");
    }

    async void OnCancelClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}