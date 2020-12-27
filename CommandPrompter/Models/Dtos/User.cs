using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPrompter.Models.Dtos
{
    public class User
    {
        public string Username { get; set; }
        public double Contributes { get; set; }
        public string Email { get; set; }
        public DateTime? RegisterTime { get; set; }
    }
}
