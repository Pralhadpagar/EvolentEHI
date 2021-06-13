using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvolentEHI.Data;
using EvolentEHI.IBL;
using EvolentEHI.Model;

namespace EvolentEHI.BL
{
   public class ContactRepo: IContactRepo
    {
        private EvolentEHIEntities DbEntitiesObj;
        public ContactRepo()
        {
            DbEntitiesObj = new EvolentEHIEntities();
        }

        public int AddContact(ContactModel ContactModelObj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ContactModel> GetAllContact()
        {
            IEnumerable<ContactModel> contactList = (from contactobj in DbEntitiesObj.tblContactInfoes
                                                     select new ContactModel()
                                                     {
                                                         ContactId = contactobj.ContactId,
                                                         FirstName = contactobj.FirstName,
                                                         LastName = contactobj.LastName,
                                                         Email = contactobj.Email,
                                                         PhoneNumber = (int)contactobj.PhoneNumber                                                         

                                                     }).ToList();

            return contactList;
        }

        public ContactModel GetContactById(int ContactId)
        {
            throw new NotImplementedException();
        }
    }
}
