using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackendAPI.Models
{
    public class CustomerAccount
    {
        public string Id { get; set; }
        public string AccountType { get; set; }
        public int Balance { get; set; }
        public int InterestRate { get; set; }

        public string BranchId { get; set; }

        public Branch Branch { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}