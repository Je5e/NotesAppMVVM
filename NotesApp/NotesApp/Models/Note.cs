using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace NotesApp.Models
{
    [Table("T_Notes")]
    public class Note
    {
        //una clase tiene miembros,y uno de ellos 
        //son propiedades.
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        
      [Unique]
        public string Text { get; set;}
        public DateTime Date { get; set;}
    }
}
