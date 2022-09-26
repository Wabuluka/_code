using application.Interfaces;
using Domain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace application.BusinessLogic.Post
{
    public class PostVModelHandler : IRequestHandler<PostVModelRequest, ModelResponse>
    {
        private readonly IVerificationRepo _verificationRepo;

        public PostVModelHandler(IVerificationRepo verificationRepo)
        {
            _verificationRepo = verificationRepo;
        }
        public async Task<ModelResponse> Handle(PostVModelRequest request, CancellationToken cancellationToken)
        {

            var vModelToSave = new vModel
            {
                FirstName = request.FirstName,
                MiddleName = request.MiddleName,
                Surname = request.Surname,
                Gender = request.Gender,
                PhoneNumber = request.PhoneNumber,
                NIN = request.NIN,
                status = Status.Active,
                ReferenceId = request.ReferenceId,
                ProcessedAt = DateTime.Now,
                CreatedAt = DateTime.Now,
            };

            await _verificationRepo.PostVerification(vModelToSave, cancellationToken);

            var response = new ModelResponse
            {
                FirstName = request.FirstName,
                MiddleName = request.MiddleName,
                Surname = request.Surname,
                Gender = request.Gender,
                PhoneNumber = request.PhoneNumber,
                NIN = request.NIN,
                status = Status.Active,
                ReferenceId = request.ReferenceId,
                CreatedAt = DateTime.Now,
            };

            return response;
        }

    }
}
