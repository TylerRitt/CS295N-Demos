﻿using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MathQuiz4;

namespace MathQuiz4.Pages
{
    public class MathQuizModel : PageModel
    {
       [BindProperty]
        public MathQuiz Quiz { get; set; } // get is called before OnPost
        const string RAND_NUMBER_1 = "RandNumber1";
        const string RAND_NUMBER_2 = "RandNumber2";

        public void OnGet()
        {
            Quiz = new MathQuiz();
            HttpContext.Session.SetInt32(RAND_NUMBER_1, Quiz.Number1);
			HttpContext.Session.SetInt32(RAND_NUMBER_2, Quiz.Number2);
		}

        public IActionResult OnPost()
        {
            // The Quiz object was already created because MathQuiz is a bound property
            Quiz.Number1 = HttpContext.Session.GetInt32(RAND_NUMBER_1) ?? 0;
            Quiz.Number2 = HttpContext.Session.GetInt32(RAND_NUMBER_2) ?? 0;

            return Page();
        }
    }
}