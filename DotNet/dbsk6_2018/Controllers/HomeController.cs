using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dbsk6_2018.Models;

namespace dbsk6_2018.Controllers
{
    public class HomeController : Controller
    {
        private StudentsModel sm = new StudentsModel();
        private StudyProgramModel sp = new StudyProgramModel();

        public IActionResult Index()
        {
            ViewBag.AllStudyProgramsTable = sp.GetAllStudyPrograms();
            return View();
        }

        //
        // GET: /Home/SearchStudents/{name}?studyProgram={studyProgram}

        public IActionResult SearchStudents(string name, string studyProgram)
        {
            ViewBag.SearchResults = sm.SearchStudents(name, studyProgram);
            return View();
        }
    }
}
