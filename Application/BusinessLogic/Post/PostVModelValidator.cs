using application.BusinessLogic.Post;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Application.BusinessLogic.Post
{
    public class PostVModelValidator : AbstractValidator<PostVModelRequest>
    {
        public PostVModelValidator()
        {
            RuleFor(x => x.ReferenceId)
                .NotEmpty()
                .WithMessage("ReferenceId can not be empty")
                .WithErrorCode("PostVModelRequest.ReferenceId.Empty");

            RuleFor(x => x.NIN)
                .NotEmpty()
                .WithMessage("NIN can not be empty")
                .WithErrorCode("PostVModelRequest.NIN.Empty")
                .Must(IsNinValid)
                .WithMessage(x => $"NIN {x.NIN} provided is not Valid");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .WithMessage("PhoneNumber can not be empty")
                .WithErrorCode("PostVModelRequest.PhoneNumber.Empty")
                .Must(IsPhoneNumberValid)
                .WithMessage(x => $"Phone Number {x.PhoneNumber} provided is not Valid");
        }

        public bool IsNinValid(string? Nin)
        {
            var regex = new Regex(@"^(CM|CF|PF|PM|NF|NM|AF|AM)(?=.*[A-Za-z])(?=.*\d)[A-Za-z0-9]{12}$");
            var match = regex.Match(Nin);
            if (!match.Success)
            {
                return false;
            }

            return true;
        }

        public bool IsPhoneNumberValid(string phoneNumber)
        {
            return phoneNumber.Length == 12;
        }
    }
}
