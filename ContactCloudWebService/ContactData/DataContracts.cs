using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace ContactData
{
   [DataContract(Namespace = "")]
   public class Contact
   {
      [DataMember(Order = 1)]
      public int Id;
      [DataMember(Order = 2)]
      public string FirstName;
      [DataMember(Order = 3)]
      public string LastName;
      [DataMember(Order = 4)]
      public string Email;
   }

   [CollectionDataContract(Name = "ContactList", Namespace = "")]
   public class ContactList : List<Contact>
   {
   }
}