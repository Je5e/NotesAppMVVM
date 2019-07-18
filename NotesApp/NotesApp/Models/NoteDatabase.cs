using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace NotesApp.Models
{
   public class NoteDatabase
    {
        //crear la base de datos.
        readonly SQLiteConnection Database;
        //escribir datos a la base de datos
        //leer datos desde la base de datos
        //actializar datos de la bd
        //eliminar registros de la bd.
        public string MessageStatus { get; set; }
        //elconstructor de la clase de notedatebase
        public NoteDatabase(string dbPath)
        {
           
            Database = new SQLiteConnection(dbPath);

            //Creamos una tabla llamada Note,en la bd
            Database.CreateTable<Note>();
        }

        //CRUD
        //Para agregar una nueva entidad a la bd.
        //lo hacemos con un metodo.
        public int CreatetNote(Note noteToInsert)
        {
            int Result = 0;
            try
            {
                Result = Database.Insert(noteToInsert);
                MessageStatus = $"Filas afectadas:{Result}, Note Id:{noteToInsert.ID}";
            }
            catch (Exception ex)
            {
                MessageStatus = $"Hubo un error al registrar la nota.{ex.Message}";
                throw new Exception(MessageStatus);
            }
            return Result;

           
        }
        //para leer todos los registros de la tabla T_Notes
        public List<Note>ReadNotes()
        {
            return Database.Table<Note>().ToList();
        }
        //para eliminar un registro de la bd
        public int DeleteNote(Note noteToDelete)
        {
            return Database.Delete(noteToDelete);
        }
        //para actualizar un registro de la bd

        public int UpdateNote(Note noteToUpdate)
        {
            return Database.Update(noteToUpdate);
        }

        //PARA LEER UNA ENTIDAD DE LA BD.
        public Note ReadNote(int ID)
        { //select*from T_Notes Where ID==@
            return Database.Table<Note>()
                .Where(n => n.ID == ID).FirstOrDefault();
        }

    }
}
