using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NotesApp.Models;
using System.IO;

namespace NotesApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NoteEntryPage : ContentPage
	{
        private readonly Note note=new Note();

        public NoteEntryPage(Note note)
        {
            this.note = note;
            InitializeComponent();
            EditorNote.Text = note.Text;
        }
		public NoteEntryPage ()
		{
            InitializeComponent();
        }

        void OnSaveButtonClicked(object sender, EventArgs e)
        {
           
            Note nuevaNota = new Note();
            nuevaNota.Text = EditorNote.Text;
            nuevaNota.Date = DateTime.UtcNow;
            //Guardarlo en la BD. crearNote de este metodo.
            NoteDatabase DataBase = new NoteDatabase
                (Path.Combine
                (Environment.GetFolderPath
                (Environment.SpecialFolder.LocalApplicationData), "Notes.db3"));
            try
            {
                int Result = DataBase.CreatetNote(nuevaNota);
                if (Result == 1)
                {
                    DisplayAlert("Aviso", DataBase.MessageStatus, "ok");
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", DataBase.MessageStatus, "Ok");
            }
            finally
            {
                Navigation.PopAsync();
            }
          
         
        }
        void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            NoteDatabase DataBase = new NoteDatabase
               (Path.Combine
               (Environment.GetFolderPath
               (Environment.SpecialFolder.LocalApplicationData), "Notes.db3"));

            int Result = DataBase.DeleteNote(note);
            if (Result == 1)
            {
                DisplayAlert("Aviso", $"Registro eliminado con éxito.ID:{note.ID}", "ok");
            }
            Navigation.PopAsync();
        }
    }
}