using application.BusinessLogic;
using application.BusinessLogic.Get;
using Domain;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace application.Interfaces
{
    public interface IVerificationRepo
    {
        Task PostVerification(vModel vModel, CancellationToken cancellationToken);

        Task<List<vModel>> GetAllAsync(GetVModelRequest request, CancellationToken cancellationToken);

    }
}
