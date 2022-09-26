using application.BusinessLogic;
using application.BusinessLogic.Get;
using application.Interfaces;
using Database;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace database.Repository
{
    public class VerificationRepo : IVerificationRepo
    {
        private readonly ApplicationDbContext _context;

        public VerificationRepo(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<List<vModel>> GetAllAsync(GetVModelRequest request, CancellationToken cancellationToken)
        {
            IQueryable<vModel> query = _context.vModels;

            if (request.From != null)
            {
                query = query.Where(z => z.CreatedAt >= request.From.Value);
            }

            if (request.To != null)
            {
                query = query.Where(w => w.CreatedAt <= request.To.Value);
            }

            if (request.status != null && request.status.Any())
            {
                query = query.Where(d => request.status.Contains(d.status));
            }

            if (request.Gender != null && request.Gender.Any())
            {
                query = query.Where(dw => request.Gender.Contains(dw.Gender));
            }

            var res = await query
                .AsNoTracking()
                .OrderByDescending(c => c.CreatedAt)
                .ToListAsync();

            return res;
        }

        public async Task PostVerification(vModel vModel, CancellationToken cancellationToken)
        {           
            await _context.AddAsync(vModel);

            await _context.SaveChangesAsync();
        }
    }
}
