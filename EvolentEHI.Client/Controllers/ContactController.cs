using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using EvolentEHI.Model;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;

namespace EvolentEHI.Client.Controllers
{
    /// <summary>
    /// controller of contact having all CRUD operations.
    /// </summary>
    public class ContactController : Controller
    {
        HttpClient webapiclient;
        public ContactController()
        {
            webapiclient = new HttpClient();
            webapiclient.BaseAddress = new Uri("http://localhost:53100/api/");
            webapiclient.DefaultRequestHeaders.Clear();
            webapiclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
       
        public ActionResult Index()
        {
            IEnumerable<ContactModel> contactlist;
            var response = webapiclient.GetAsync(webapiclient.BaseAddress + "Contact").Result;
            
            if (response.IsSuccessStatusCode)
            {
                contactlist = response.Content.ReadAsAsync<IEnumerable<ContactModel>>().Result;
                
                return View(contactlist);
            }
            else
            {
                return View("~/Views/Shared/Error.cshtml");
            }

        }

        public ActionResult CreateContact()
        {
            return View(new ContactModel());
        }

        [HttpPost]
        public ActionResult CreateContact(ContactModel contact)
        {
            // check validation state of model. this is server side validation. we can do it through client side through scrpting in views html
            if (ModelState.IsValid)
            {

                var response = webapiclient.PostAsJsonAsync<ContactModel>(webapiclient.BaseAddress + "Contact", contact);
                response.Wait();                
                return RedirectToAction("Index");
                
            }
            else
            {
                return View("CreateContact");

            }
        }
        public ActionResult EditContact(int id)
        {
            ContactModel model = new ContactModel();
            var response = webapiclient.GetAsync(webapiclient.BaseAddress + "/Contact/" + id).Result;
            string data = response.Content.ReadAsStringAsync().Result;
            model = JsonConvert.DeserializeObject<ContactModel>(data);
            return View("CreateContact", model);
        }

        [HttpPost]
        public ActionResult EditContact(ContactModel contact)
        {
            if (ModelState.IsValid)
            {
                var post = webapiclient.PutAsJsonAsync<ContactModel>(webapiclient.BaseAddress + "Contact", contact);
                post.Wait();
                return RedirectToAction("Index");
            }
            else
            {
                return View("CreateContact", contact);
            }
        }
      
        public ActionResult DeleteContact(int id)
        {
            var response = webapiclient.DeleteAsync(webapiclient.BaseAddress + "/Contact/" + id).Result;            
            return RedirectToAction("Index");
        }

        }
}