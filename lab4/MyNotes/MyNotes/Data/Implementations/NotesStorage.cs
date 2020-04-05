using MyNotes.Data.Interfaces;
using MyNotes.Data.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MyNotes.Data.Implementations
{
    public class NotesStorage : INotesStorage
    {
        private static string notesPath;
        public void OpenNotes(string path)
        {
            notesPath = path;
            if (!File.Exists(notesPath))
            {
                using (StreamWriter sw = new StreamWriter(notesPath))
                {
                    sw.WriteLine("[]");
                }
            }
        }
        public IEnumerable<Note> GetNotes()
        {
            List<Note> notes = new List<Note> { };
            using (StreamReader sr = new StreamReader(notesPath))
            {
                notes = JsonConvert.DeserializeObject<List<Note>>(sr.ReadToEnd());
            }
            return notes;
        }
        public void AddNote(Note note)
        {
            List<Note> notes = GetNotes().ToList();
            notes.Add(note);
            string json = JsonConvert.SerializeObject(notes);
            File.WriteAllText(notesPath, json);
        }
    }
}

