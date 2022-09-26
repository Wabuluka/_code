using Domain;
using MediatR;
using System;
using System.Collections.Generic;

namespace application.BusinessLogic.Get
{
    public class GetVModelRequest : IRequest<List<ModelResponse>>
    {
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }

        public Gender[]? Gender { get; set; }

        public Status[]? status { get; set; }
    }
}
