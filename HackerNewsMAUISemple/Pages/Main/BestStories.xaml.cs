using HackerNewsMAUISemple.Content;
using HackerNewsMAUISemple.Firebase;

namespace HackerNewsMAUISemple.Pages.Main;

public partial class BestStories : ContentPage
{
	public BestStories(IFirebaseManager firebaseManager)
	{
		InitializeComponent();

        Title = "Hecker news | Best stories";
        Content = new StoriesCollectionView(firebaseManager, StoriesType.BestStories);
    }
}