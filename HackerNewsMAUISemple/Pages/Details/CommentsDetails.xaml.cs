using HackerNewsMAUISemple.Content;
using HackerNewsMAUISemple.Firebase;

namespace HackerNewsMAUISemple.Pages.Details;

public partial class CommentsDetails : ContentPage
{
	public CommentsDetails(IFirebaseManager firebaseManager, IEnumerable<long> comments)
	{
		InitializeComponent();
        Content = new CommentsCollectionView(firebaseManager, comments);
    }
}