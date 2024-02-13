using HackerNewsMAUISemple.Content;
using HackerNewsMAUISemple.Firebase;

namespace HackerNewsMAUISemple.Pages.Main;

public partial class NewStories : ContentPage
{
	public NewStories(IFirebaseManager firebaseManager)
	{
		InitializeComponent();

        Title = "Hecker news | New stories";
        Content = new StoriesCollectionView(firebaseManager, StoriesType.NewStories);
    }
}