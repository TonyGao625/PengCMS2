using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.XPath;
using Umbraco.Web.Mvc;

namespace My.Controllers
{
    public class ContactSurfaceController:SurfaceController
    {
        public ActionResult ShowForm()
        {
            ContactModel myModel=new ContactModel();
            //var listOfGenders =new List<SelectListItem>();
            //XPathNodeIterator iterator = umbraco.library.GetPreValues(1081);
            //iterator.MoveNext();
            //XPathNodeIterator preValues = iterator.Current.SelectChildren("preValue", "");
            //while (preValues.MoveNext())
            //{
            //    string preValue = preValues.Current.Value;
            //    listOfGenders.Add(new SelectListItem
            //    {
            //        Text=preValue,
            //        Value=preValue
            //    });
               
            //}
            //myModel.ListOfGenders = listOfGenders;
            return PartialView("ContactForm", myModel);
        }

        public ActionResult HandleFormPost(ContactModel model)
        {
            var newComment = Services.ContentService.CreateContent(model.Id + "" + model.Name, CurrentPage.Id, "ContactFormula");
            newComment.SetValue("email",model.Email);
            newComment.SetValue("contactName", model.Name);
            newComment.SetValue("contactmessage", model.Message);
            Services.ContentService.SaveAndPublishWithStatus(newComment);
            return RedirectToCurrentUmbracoPage();
        }
    }
}

