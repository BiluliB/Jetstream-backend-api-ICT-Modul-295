using JetstreamApi.Common;
using JetstreamApi.Data;
using JetstreamApi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JetstreamApi.Services
{
    public class AssignService : IAssignService
    {
        private readonly ApplicationDbContext _context;

        public AssignService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AssignServiceRequestToUser(int serviceRequestId, int userId, string? currentUserName)
        {
            var serviceRequest = await _context.ServiceRequests.FindAsync(serviceRequestId);
            var currentUser = await _context.Users.FirstOrDefaultAsync(u => u.UserName == currentUserName);

            if (serviceRequest == null || currentUser == null)
            {
                throw new KeyNotFoundException("ServiceRequest oder Benutzer nicht gefunden.");
            }

            // Zusätzliche Logik basierend auf dem aktuellen Benutzer
            if (currentUserName != null && serviceRequest.UserId == currentUser.Id && currentUser.Role != Roles.ADMIN)
            {
                throw new UnauthorizedAccessException("Sie haben keine Berechtigung, diesen Auftrag neu zuzuweisen. Bitte kontaktieren Sie einen Administrator.");
            }

            serviceRequest.UserId = userId;
            await _context.SaveChangesAsync();
        }

        public async Task AssignServiceRequestToUser(int serviceRequestId, int userId)
        {
            var serviceRequest = await _context.ServiceRequests.FindAsync(serviceRequestId);

            if (serviceRequest == null)
            {
                throw new KeyNotFoundException($"ServiceRequest mit der ID {serviceRequestId} wurde nicht gefunden.");
            }

            serviceRequest.UserId = userId;
            await _context.SaveChangesAsync();
        }
    }


}
