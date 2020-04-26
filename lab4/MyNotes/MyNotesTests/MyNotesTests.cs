using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyNotes.Data.Implementations;
using MyNotes.Data.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MyNotesTests
{
    [TestClass]
    public class NotesStorageTests
    {
        NotesStorage notesStorage = new NotesStorage();
        string fileName = "Notes.json";
        [TestMethod]
        public void OpenNotes_NonExistingFile_CreatedFile()
        {          
            File.Delete(fileName);
            notesStorage.OpenNotes(fileName);
            Assert.AreEqual(true, File.Exists(fileName));
        }        
        [TestMethod]
        public void GetNotes_EmptyFile_EmptyListReturned()
        {
            File.Delete(fileName);
            notesStorage.OpenNotes(fileName);

            List<Note> notes = notesStorage.GetNotes().ToList();
            List<Note> reqNotes = new List<Note> { };
            CollectionAssert.AreEquivalent(reqNotes, notes);
        }
        [TestMethod]
        public void AddNote_NewNote_ListWithNewNoteReturned()
        {
            notesStorage.OpenNotes(fileName);

            string text = "привет мир!";
            Note newNote = new Note { text=text };

            List<Note> notesBefore = notesStorage.GetNotes().ToList<Note>();       

            notesStorage.AddNote(newNote);
            List<Note> notes = notesStorage.GetNotes().ToList<Note>();

            Assert.AreEqual(text, notes[notes.Count() - 1].text);
            Assert.AreEqual(notesBefore.Count() + 1, notes.Count());
        }        
    }
}
