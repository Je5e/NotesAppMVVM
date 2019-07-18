using NotesApp.Models;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NotesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotesPage : ContentPage
    {
        public NotesPage()
        {
            InitializeComponent();
            BindingContext = new ViewModels.NotesPageViewModel();
        }
        void OnNoteAddedClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NoteEntryPage());
        }

        void OnListViewItemSelect(object sender, SelectedItemChangedEventArgs e)
        {
            
            Note NoteSelected = (Note)e.SelectedItem;
            Navigation.PushAsync(new NoteEntryPage(NoteSelected));
        }
       



    }
}