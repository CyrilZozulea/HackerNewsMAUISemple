using HackerNewsMAUISemple.Firebase;
using HackerNewsMAUISemple.Firebase.Models;

namespace HackerNewsMAUISemple.Pages.Details;

public partial class StoryDetails : ContentPage
{
    IFirebaseManager firebaseManager;

    public StoryDetails(ItemSource item, IFirebaseManager firebaseManager)
	{
		InitializeComponent();

        BindingContext = item;
        this.firebaseManager = firebaseManager;

        if (App.IsWindows())
        {
            ContentGrid.ColumnDefinitions = new ColumnDefinitionCollection
            {
                new ColumnDefinition { Width = new GridLength(4, GridUnitType.Star) },
                new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
            };
        }
        else
        {
            ContentGrid.RowDefinitions = new RowDefinitionCollection
            {
                new RowDefinition { Height = new GridLength(300, GridUnitType.Absolute) },
                new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }
            };
        }

        if (item.kids != null)
            comments.Text = $"View commensts - {item.kids.Count()}";
        else
            comments.IsVisible = false;

        if (string.IsNullOrEmpty(item.url))
        {
            show_url.IsVisible = false;
            emptyUrl.IsVisible = true;
        }
    }

    async void ShowCommends(object obj, EventArgs e)
    {
        await Navigation.PushAsync(new CommentsDetails(firebaseManager, ((ItemSource)BindingContext).kids));
    }
}