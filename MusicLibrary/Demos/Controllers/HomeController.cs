using Demos.Models;
using MusicTheorySDK.Core;
using MusicTheorySDK.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demos.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Western Classical Music";

            string allNotes = "C CSharp D DSharp E F FSharp G GSharp A ASharp B";
            string majorIntervals = "2 2 1 2 2 2 1";
            string naturalMinorIntervals = "2 1 2 2 1 2 2";
            string[] allNoteNames = allNotes.Split(new char[] { ',', ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            List<List<ScaleModel>> allScales = new List<List<ScaleModel>>();

            List<ScaleModel> majorScales = GetScales("Major", allNoteNames, majorIntervals);
            ViewBag.MajorIntervals = majorIntervals;
            allScales.Add(majorScales);

            List<ScaleModel> naturalMinorScales = GetScales("Minor", allNoteNames, naturalMinorIntervals);
            ViewBag.NaturalMinorIntervals = naturalMinorIntervals;
            allScales.Add(naturalMinorScales);

            return View(allScales);
        }

        private List<ScaleModel> GetScales(string scaleName, string[] allNoteNames, string intervalRepresentation)
        {
            List<Interval> intervals = IntervalFactory.CreateIntervals(intervalRepresentation);
            List<ScaleModel> scaleModels = new List<ScaleModel>();

            foreach (string noteName in allNoteNames)
            {
                Notes note;
                if (Enum.TryParse<Notes>(noteName, out note))
                {
                    Note rootNote = new Note(note);
                    Scale scale = new Scale(rootNote, intervals);
                    ScaleModel scaleModel = new ScaleModel();
                    scaleModel.Name = String.Format("{0} {1}", note.GetDescription<Notes>(), scaleName);
                    scaleModel.Notes = scale.Display;
                    scaleModel.Intervals = intervalRepresentation;
                    scaleModels.Add(scaleModel);
                }
            }

            return scaleModels;
        }
    }
}
