﻿namespace mvc_for_angular.frontend.client_app.src.app.ViewModels
{
    public class RegistrationResponse
    {
        public bool success {  get; set; }
        public IEnumerable<string> errors { get; set; }

    }
}
