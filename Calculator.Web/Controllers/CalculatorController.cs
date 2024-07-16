using Microsoft.AspNetCore.Mvc;
using Calculator.Business;
using Calculator.Common.Dto;
using System.Globalization;
using Calculator.Common.Dto;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Calculator.Web.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly CalculatorService _calculatorService;

        public CalculatorController()
        {
            _calculatorService = new CalculatorService();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new AddDto1());  // AddDto'yu view'a gönderir
        }

        [HttpPost]
        public IActionResult Index(AddDto1 model, string operation)
        {
            if (operation == "clear")
            {
                ModelState.Clear();  // Clear butonunu çalıştıracak olan fonksiyon
                return View(new AddDto1());
            }

          


            Result result = null;

            try
            {
                switch (operation.ToLower())
                {
                    case "add":
                        result = _calculatorService.Add(model);
                        break;
                    case "sub":
                        result = _calculatorService.Subtract(model);  // Seçeceğimiz operatör durumları
                        break;
                    case "mul":
                        result = _calculatorService.Multiply(model);
                        break;
                    case "div":
                        result = _calculatorService.Divide(model);
                        break;
                    default:
                        ModelState.AddModelError("", "Geçersiz işlem.");
                        return View(model);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }

            if (result != null)
            {
                model.Result = result.Value;
                ViewBag.Result = result.Value;

                // İşlem geçmişine ekleme
              
            }

            return View(model);
        }
    }
}