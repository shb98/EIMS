﻿namespace Host.IIS.Models
{
    public class AccountChangePasswordModel
    {
        public string LoginEmail { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}