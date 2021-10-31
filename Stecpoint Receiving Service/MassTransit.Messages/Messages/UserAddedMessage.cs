﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MassTransit.Messages
{
    public class UserAddedMessage
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}