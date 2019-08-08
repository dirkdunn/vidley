using System;
using System.Collections.Generic;
using Vidly.Models;
using System.Linq;
using System.Web;

namespace Vidly.ViewModels
{
    public class CustomerFormViewModel
    {
        // IEnumerable is just a basic enumeration that allows you to loop over it,
        // unlike a list that provides extra functionality to that enumeration.
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}