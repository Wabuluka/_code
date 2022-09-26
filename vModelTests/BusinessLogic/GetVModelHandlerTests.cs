using application.BusinessLogic.Get;
using application.Interfaces;
using Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace vModelTests.BusinessLogic
{
    public class GetVModelHandlerTests
    {
        private readonly Mock<IVerificationRepo> _repoMock;

        private readonly GetVModelRequest _request;

        private readonly GetVModelHandler _handler;
        private readonly List<vModel> _modelList;

        public GetVModelHandlerTests()
        {
            _repoMock = new Mock<IVerificationRepo>();

            _request = new GetVModelRequest
            {
                From = DateTime.Now,
                To = DateTime.Parse("1/1/2000")
            };

            _modelList = new List<vModel>
            {
                new vModel
                {
                    FirstName = "Wabuluka"
                },
                new vModel
                {
                    FirstName = "Boy"
                }
            };

            _handler = new GetVModelHandler(
                _repoMock.Object);

            _repoMock.Setup(z => z.GetAllAsync(It.IsAny<GetVModelRequest>(),
               It.IsAny<CancellationToken>()))
                .ReturnsAsync(_modelList);
        }

        [Fact]
        public async Task handler_ShouldNotThrowException()
        {
            await _handler.Handle(_request, It.IsAny<CancellationToken>());
        }


        [Fact]
        public async Task handler_ShouldQueryRepository()
        {
            await _handler.Handle(_request, It.IsAny<CancellationToken>());

            _repoMock.Verify(x => x.GetAllAsync(It.IsAny<GetVModelRequest>(),
                It.IsAny<CancellationToken>()));
        }


        [Fact]
        public async Task handler_ShouldReturnModels()
        {
            var response = await _handler.Handle(_request, It.IsAny<CancellationToken>());

            Assert.NotEmpty(response);
        }
    }
}
