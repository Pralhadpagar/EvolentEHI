using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvolentEHI.Model;
namespace EvolentEHI.IBL
{
    /// <summary>
    ///  interface of contact , declaration of all crud operations
    /// </summary>
   public interface IContactRepo
    {
        IEnumerable<ContactModel> GetAllContact();

        void AddContact(ContactModel ContactModelObj);

        void UpdateContact(ContactModel ContactId);

        void DeleteContact(int ContactId);

        ContactModel GetContactById(int ContactId);

    }
}
