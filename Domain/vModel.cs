using System;

namespace Domain
{
    public class vModel
    {
        public Guid Id { get; set; }
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

    public enum Status
    {
        Active = 1,
        Pending = 2,
        NotVeried = 3,
    }

    public enum Gender
    {
        Male = 1,
        Female = 2,
    }
}
