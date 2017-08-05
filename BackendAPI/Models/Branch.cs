using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackendAPI.Models
{
    public class Branch
    {
        public string Id { get; set; }
        public string BranchName { get; set; }
        public string District { get; set; }
        public string Tole { get; set; }
        public int WardNo { get; set; }
        public double Longitude { get; set; }
        public double Lattitude { get; set; }
        public string Phone { get; set; }
    }
}