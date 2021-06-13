using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evolent.Data;

using EvolentEHI.Model;

namespace EvolentEHI.IBL
{
    /// <summary>
    ///  Contact repository which having all CRUD operation which impletment interface IContact. reposotory pattern for
    /// </summary>
   public class ContactRepo: IContactRepo
    {
        private EvolentEHIEntities DbEntitiesObj;
        public ContactRepo()
        {
            DbEntitiesObj = new EvolentEHIEntities();
        }

        public void AddContact(ContactModel ContactModelObj)
        {
            
            tblContactInfo objcontact = new tblContactInfo()
            {
                FirstName = ContactModelObj.FirstName,
                LastName = ContactModelObj.LastName,
                Email = ContactModelObj.Email,
                PhoneNumber = ContactModelObj.PhoneNumber,
                Status = true                
            };

            DbEntitiesObj.tblContactInfoes.Add(objcontact);
            DbEntitiesObj.SaveChanges();
        }

        public void DeleteContact(int ContactId)
        {
            var contactrecord = DbEntitiesObj.tblContactInfoes.Where(x => x.ContactId == ContactId).FirstOrDefault();
            if(contactrecord!=null)
            {
                contactrecord.Status = false;
                DbEntitiesObj.SaveChanges();
            }
        }

        public IEnumerable<ContactModel> GetAllContact()
        {

            return (from contactobj in DbEntitiesObj.tblContactInfoes
                   where contactobj.Status == true
                   select new ContactModel()
                   {
                       ContactId = contactobj.ContactId,
                       FirstName = contactobj.FirstName,
                       LastName = contactobj.LastName,
                       Email = contactobj.Email,
                       PhoneNumber = contactobj.PhoneNumber

                   }).ToList();          
        }

        public ContactModel GetContactById(int ContactId)
        {

            return (from contactobj in DbEntitiesObj.tblContactInfoes
                    where contactobj.ContactId == ContactId
                    select new ContactModel()
                    {
                        ContactId = contactobj.ContactId,
                        FirstName = contactobj.FirstName,
                        LastName = contactobj.LastName,
                        Email = contactobj.Email,
                        PhoneNumber = contactobj.PhoneNumber

                    }).FirstOrDefault();
        }

        public void UpdateContact(ContactModel Contact)
        {
            var contactrecord = DbEntitiesObj.tblContactInfoes.Where(x => x.ContactId == Contact.ContactId).FirstOrDefault();

            if(contactrecord!=null)
            {
                contactrecord.FirstName = Contact.FirstName;
                contactrecord.LastName = Contact.LastName;
                contactrecord.Email = Contact.Email;
                contactrecord.PhoneNumber = Contact.PhoneNumber;

                DbEntitiesObj.SaveChanges();
            }           
            
        }
    }
}
