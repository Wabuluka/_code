using application.BusinessLogic.Post;
using Application.BusinessLogic.Post;
using FluentValidation.TestHelper;
using Xunit;

namespace vModelTests.BusinessLogic
{
    public class PostVModelValidatorTests
    {
        private PostVModelRequest _request;
        private PostVModelValidator _validator;

        public PostVModelValidatorTests()
        {
            _request = new PostVModelRequest();
            _validator = new PostVModelValidator();
        }

        [Fact()]
        public void Validator_ShouldHaveError_WhenReferenceIdIsEmpty()
        {
            _validator.ShouldHaveValidationErrorFor(x => x.ReferenceId, string.Empty)
                .WithErrorCode("PostVModelRequest.ReferenceId.Empty");
        }

        [Fact()]
        public void Validator_ShouldHaveError_WhenNINIsEmpty()
        {
            _validator.ShouldHaveValidationErrorFor(x => x.NIN, string.Empty)
                .WithErrorCode("PostVModelRequest.NIN.Empty");
        }

        [Fact()]
        public void Validator_ShouldHaveError_WhenPhoneNumberIsEmpty()
        {
            _validator.ShouldHaveValidationErrorFor(x => x.PhoneNumber, string.Empty)
                .WithErrorCode("PostVModelRequest.PhoneNumber.Empty");
        }
    }
}
