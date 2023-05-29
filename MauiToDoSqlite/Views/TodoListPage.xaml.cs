using MauiToDoSqlite.Data;
using MauiToDoSqlite.Models;

namespace MauiToDoSqlite.Views;

public partial class TodoListPage : ContentPage
{
	public TodoListPage()
	{
		InitializeComponent();
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();
		TodoItemDatabase database = await TodoItemDatabase.Instance;
		listView.ItemsSource = await database.GetItemsAsync();
	}

	async void OnItemAdded(object sender, EventArgs eventArgs)
	{
		await Navigation.PushAsync(new TodoItemPage
		{
			BindingContext = new TodoItem()
		});
	}

	async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
	{
		if (e.SelectedItem != null)
		{
			await Navigation.PushAsync(new TodoItemPage
			{
				BindingContext = e.SelectedItem as TodoItem
			});
		}
	}
}