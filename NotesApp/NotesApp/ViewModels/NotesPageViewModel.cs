using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using NotesApp.Models;
using Xamarin.Forms;

namespace NotesApp.ViewModels
{
  public  class NotesPageViewModel
    {
         //private  readonly NoteDatabase database;
        public List<Note> Notes { get; set; }

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
