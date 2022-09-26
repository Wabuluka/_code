using Domain;
using MediatR;

namespace application.BusinessLogic.Post
{
    public class PostVModelRequest : IRequest<Model>
    {
        public string ReferenceId { get; set; }
        public string NIN { get; set; }
        public string PhoneNumber { get; set; }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Surname { get; set; }
        public Gender Gender { get; set; }
    }
}
