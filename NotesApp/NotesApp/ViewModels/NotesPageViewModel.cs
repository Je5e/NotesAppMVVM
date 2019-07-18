using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using NotesApp.Models;

namespace NotesApp.ViewModels
{
  public  class NotesPageViewModel
    {
         private  readonly NoteDatabase database;
        public List<Note> Notes { get; set; }

        public NotesPageViewModel()
        {
             database = new NoteDatabase
                (FileAccessHelper.GetLocalFilePath("Notes.db3"));

            var NotesFromDB = database.ReadNotes();

            Notes = new List<Note>(NotesFromDB);
            
        }

    }
}
