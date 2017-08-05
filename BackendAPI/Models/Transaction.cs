using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackendAPI.Models
{
    public class Transaction
    {
        public string Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public int TransactionAmount { get; set; }
        public string TransactionType { get; set; }
        public string Description { get; set; }

        public CustomerAccount CustomerAccount { get; set; }
    }
}