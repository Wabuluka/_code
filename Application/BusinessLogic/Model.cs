using Domain;
using System;

namespace application.BusinessLogic
{
    public class Model
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Surname { get; set; }
        public Gender Gender { get; set; }
        public string NIN { get; set; }
        public Status status { get; set; }
        public string PhoneNumber { get; set; }
        public string ReferenceId { get; set; }
        public DateTime ProcessedAt { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
