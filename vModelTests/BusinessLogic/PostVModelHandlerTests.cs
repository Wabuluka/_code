using application.BusinessLogic;
using application.BusinessLogic.Post;
using application.Interfaces;
using Domain;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace vModelTests.BusinessLogic
{
    public class PostVModelHandlerTests
    {
        private readonly Mock<IVerificationRepo> _commandRepository;
        private readonly PostVModelHandler _handler;
        private readonly PostVModelRequest _request;
        private readonly Model _model;

        public PostVModelHandlerTests()
        {
            _commandRepository = new Mock<IVerificationRepo>();

            _handler = new PostVModelHandler(
                _commandRepository.Object);

            _request = new PostVModelRequest
            {
                ReferenceId = Guid.NewGuid().ToString(),
                NIN = "CM12345678TYUI",
                PhoneNumber = "256706700953",
                FirstName = "Wabuluka",
                MiddleName = "Davies",
                Surname = "Ronnie",
                Gender = Gender.Female

            };

            _model = new Model
            {
                ReferenceId = _request.ReferenceId,
                NIN = _request.NIN,
                PhoneNumber = _request.PhoneNumber,
                FirstName = _request.FirstName,
                MiddleName = _request.MiddleName,
                Surname = _request.Surname,
                Gender = _request.Gender
            };

            _commandRepository.Setup(d => d.PostVerification(It.IsAny<vModel>(),
               It.IsAny<CancellationToken>()));

        }

        [Fact]
        public async Task Handler_ShouldNotThrowException()
        {
            await _handler.Handle(_request, It.IsAny<CancellationToken>());
        }

        [Fact]
        public async Task Handler_PostsVerificationsInDatabase()
        {
            await _handler.Handle(_request, It.IsAny<CancellationToken>());

            _commandRepository.Verify(s => s.PostVerification(It.IsAny<vModel>(), It.IsAny<CancellationToken>()));
        }
    }
}
