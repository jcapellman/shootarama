﻿using System;

namespace shootarama.DB.Tables
{
    public class Games : BaseTable
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime LastSaveDate { get; set; }
    }
}