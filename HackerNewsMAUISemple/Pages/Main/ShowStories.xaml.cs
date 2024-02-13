using HackerNewsMAUISemple.Content;
using HackerNewsMAUISemple.Firebase;

namespace HackerNewsMAUISemple.Pages.Main;

public partial class ShowStories : ContentPage
{
	public ShowStories(IFirebaseManager firebaseManager)
	{
		InitializeComponent();

        Title = "Hecker news | Show stories";
        Content = new StoriesCollectionView(firebaseManager, StoriesType.ShowStories);
    }
}