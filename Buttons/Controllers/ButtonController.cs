using Buttons.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Buttons.Controllers
{
    public class ButtonController : Controller
    {
        // GET: Button
       static List<ButtonModel> buttons = new List<ButtonModel>();      //static'i kaldır değişimi gör
       
        Random r = new Random();
        public ButtonController()
        {
            if (buttons.Count == 0)
            {
                for (int i = 0; i < 25; i++)
                {
                    if (r.Next(10) % 2 == 0)
                    {
                        buttons.Add(new ButtonModel(true,false));   //Açılışta flag olmayacak bu yüzden false.
                    }
                    else
                    {
                        buttons.Add(new ButtonModel(false,false));
                    }
                    //buttons[0].Flagged=true;
                }
            }
        }
        public ActionResult Index()
        {
          
            return View("Index",buttons);
        }
        public ActionResult HandleButtonClick(string mine)  //We are expecting a value to come back called mine so that is the string that will be submitted from the form.
        {
            int number = int.Parse(mine);
            if (!buttons[number].Flagged)
            {
                buttons[number].State = !buttons[number].State; //Only change the state of the button clicked if the flagged proprty is false
            }
           
            return View("Index", buttons);
        }
        public ActionResult OnRightButtonClick(string mine)
        {
            int mineNumber = Int32.Parse(mine);
            buttons[mineNumber].Flagged = !buttons[mineNumber].Flagged;
            return View("Index", buttons);
        }
    }
}