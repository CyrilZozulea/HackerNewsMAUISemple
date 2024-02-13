using HackerNewsMAUISemple.Content;
using HackerNewsMAUISemple.Firebase;

namespace HackerNewsMAUISemple.Pages.Main;

public partial class TopStories : ContentPage
{
    public TopStories(IFirebaseManager firebaseManager)
	{
		InitializeComponent();

		Title = "Hecker news | Top stories";
		Content = new StoriesCollectionView(firebaseManager, StoriesType.TopStories);
    }
}