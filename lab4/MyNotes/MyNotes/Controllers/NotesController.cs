using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyNotes.Data.Implementations;
using MyNotes.Data.Interfaces;
using MyNotes.Data.Models;

namespace MyNotes.Controllers
{
    public class NotesController : Controller
    {
        private INotesStorage _iNotesStorage;
        public NotesController(INotesStorage iNotesStorage)
        {
            _iNotesStorage = iNotesStorage;
            NotesStorage notesStorage = new NotesStorage();
            notesStorage.OpenNotes("Storage/Notes.json");
        }
        [HttpGet("notes/list")]
        public JsonResult List()
        {
            return Json(_iNotesStorage.GetNotes());
        }
        [HttpPost("note/add")]
        public async Task<StatusCodeResult> Add()
        {
            Note note = new Note();
            StreamReader sr = new StreamReader(Request.Body);            
            note.text = await sr.ReadToEndAsync();
            _iNotesStorage.AddNote(note);
            return Ok();
        }
    }
}