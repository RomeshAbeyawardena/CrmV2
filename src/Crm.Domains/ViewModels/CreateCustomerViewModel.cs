using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.Domains.ViewModels
{
    public class CreateCustomerViewModel : CustomerViewModel
    {
        [Required]
        public override string EmailAddress { get => base.EmailAddress; set => base.EmailAddress = value; }

        [Required]
        public override string FirstName { get => base.FirstName; set => base.FirstName = value; }

        [Required]
        public override string LastName { get => base.LastName; set => base.LastName = value; }
    }
}
