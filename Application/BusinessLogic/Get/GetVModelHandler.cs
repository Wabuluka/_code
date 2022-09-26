using application.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace application.BusinessLogic.Get
{
    public class GetVModelHandler : IRequestHandler<GetVModelRequest, List<ModelResponse>>
    {
        private readonly IVerificationRepo _verificationRepo;
        public GetVModelHandler(IVerificationRepo verificcationRepo)
        {
            _verificationRepo = verificcationRepo;
        }
        public async Task<List<ModelResponse>> Handle(GetVModelRequest request, CancellationToken cancellationToken)
        {
            var results = await _verificationRepo.GetAllAsync(request, cancellationToken);

            var response = results.Select(c => new ModelResponse
            {
                FirstName = c.FirstName,
                MiddleName = c.MiddleName,
                ReferenceId = c.ReferenceId,
                NIN = c.NIN,
                CreatedAt = c.CreatedAt,
                Gender = c.Gender,
                status = c.status,
                PhoneNumber = c.PhoneNumber,
                ProcessedAt = c.ProcessedAt,
                ErrorCode = c.ErrorCode,
                ErrorMessage = c.ErrorMessage,
            }).ToList();

            return response;
        }
    }
}
