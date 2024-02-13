using HackerNewsMAUISemple.Content;
using HackerNewsMAUISemple.Firebase;

namespace HackerNewsMAUISemple.Pages.Main;

public partial class JobStories : ContentPage
{
	public JobStories(IFirebaseManager firebaseManager)
	{
		InitializeComponent();

        Title = "Hecker news | Job stories";
        Content = new StoriesCollectionView(firebaseManager, StoriesType.JobStories);
    }
}