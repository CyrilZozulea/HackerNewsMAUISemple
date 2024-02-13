using HackerNewsMAUISemple.Content;
using HackerNewsMAUISemple.Firebase;

namespace HackerNewsMAUISemple.Pages.Main;

public partial class AskStories : ContentPage
{
	public AskStories(IFirebaseManager firebaseManager)
	{
		InitializeComponent();

        Title = "Hecker news | Ask stories";
        Content = new StoriesCollectionView(firebaseManager, StoriesType.AskStories);
    }
}