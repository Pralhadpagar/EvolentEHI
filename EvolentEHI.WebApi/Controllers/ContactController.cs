using Autofac;
using EvolentEHI.IBL;
using EvolentEHI.Model;
using EvolentEHI.WebApi.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace EvolentEHI.WebApi.Controllers
{     
    /// <summary>
    /// Api controller which retrive and update data to database and provide to client.
    /// </summary>
    public class ContactController : ApiController
    {
        //dependency injection through autofac
         private IContactRepo _contactRepo;

        public ContactController(IContactRepo contactRepo)
        {
            // inject Icontact repo in constructor
            _contactRepo = contactRepo;
           
        }        

        [HttpGet]
        [Route("api/Contact")]
        public IEnumerable<ContactModel> Get()
        {         
            return _contactRepo.GetAllContact();
        }             
        public IHttpActionResult GetContactById(int id)
        {
            ContactModel contact = null;
            contact = _contactRepo.GetContactById(id);
            return Ok(contact);
        }

        [HttpPost]
        [Route("api/Contact")]        
        public IHttpActionResult Post(ContactModel model)
        {
           _contactRepo.AddContact(model);
           return Ok();

        }

        [HttpPut]
        [Route("api/Contact")]
        public IHttpActionResult Put(ContactModel contact)
        {
            _contactRepo.UpdateContact(contact);
            return Ok();
        }
       
        public IHttpActionResult Delete(int id)
        {
            _contactRepo.DeleteContact(id);
            return Ok();
        }
    }
}