using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Text;
using NotesApp.Models;
using Xamarin.Forms;

namespace NotesApp.ViewModels
{
  public  class NotesPageViewModel:BaseViewModel
    {
        //private  readonly NoteDatabase database;

        private List<Note> Notes_BF;
        public List<Note> Notes
        {
            get { return Notes_BF; }
            set
            {
                Notes_BF = value;
                OnPropertyChanged();
            }
        }
     
        public Note NotaSeleccionada { get; set; }

        public Command NoteAddedCommand { get; set; }

        public NotesPageViewModel()
        {

            Notes = GetAllNotes();

            NoteAddedCommand = new Command(Navigate);

        }

      

        private List<Note> GetAllNotes()
        {
          var  database = new NoteDatabase
                (FileAccessHelper.GetLocalFilePath("Notes.db3"));

            var NotesFromDB = database.ReadNotes();
            return new List<Note>(NotesFromDB);
        }

        private void Navigate()
        {
            var entryNotePage = new NotesApp.Views.NoteEntryPage();
            entryNotePage.OnNoteAdded = OnNoteAdded;
            App.Current.MainPage.Navigation.PushAsync(entryNotePage);
        }

        private void OnNoteAdded(object sender, Note e)
        {
            Notes = GetAllNotes();
        }
    }
}
