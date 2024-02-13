using HackerNewsMAUISemple.Firebase;
using HackerNewsMAUISemple.Firebase.Models;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace HackerNewsMAUISemple.Content;

public partial class CommentsCollectionView : ContentView
{
	private IEnumerable<long> Comments { get; set; }

    private IFirebaseManager firebaseManager;
    private ObservableCollection<ItemSource> CollectionViewItems = new ObservableCollection<ItemSource>();

    public CommentsCollectionView(IFirebaseManager firebaseManager, IEnumerable<long> Comments)
	{
		InitializeComponent();

		this.Comments = Comments;
        this.firebaseManager = firebaseManager;

        collection.ItemsSource = CollectionViewItems;
        LoadItems();
    }

    async void LoadItems()
    {
        foreach (long item in Comments)
        {
            var item_response = await firebaseManager.GetItem(item);

            if (item_response.ErrorCode.Equals(ErrorCode.OK))
            {
                if (!string.IsNullOrEmpty(item_response.Item.text))
                    item_response.Item.text = Regex.Replace(System.Web.HttpUtility.HtmlDecode(item_response.Item.text), @"<[^>]*>", string.Empty);

                CollectionViewItems.Add(item_response.Item);
            }

            if (CollectionViewItems.Count == 10)
            {
                Indicator.IsRunning = false;
                collection.IsVisible = true;
            }
        }

        Indicator.IsRunning = false;
        collection.IsVisible = true;
    }
}