﻿namespace UserManagement.Application.Auth.Requests
{
    public class SignInRequest
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
