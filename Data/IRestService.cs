using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiAppBazaSportiva.Models;
namespace MauiAppBazaSportiva.Data
{
    public interface IRestService
    {
        Task<List<Member>> RefreshDataAsync();
        Task SaveMemberAsync(Member item, bool isNewItem);
        Task DeleteMemberAsync(Member item);
        Task<List<Court>> GetCourtsAsync();
        Task SaveCourtAsync(Court item, bool isNewItem);
        Task DeleteCourtAsync(Court item);

        Task<List<Trainer>> GetTrainersAsync();
        Task SaveTrainerAsync(Trainer item, bool isNewItem);
        Task DeleteTrainerAsync(Trainer item);

        Task<List<Review>> GetReviewsAsync();
        Task SaveReviewAsync(Review item, bool isNewItem);
        Task DeleteReviewAsync(Review item);

        Task<List<Reservation>> GetReservationsAsync();
        Task SaveReservationAsync(Reservation item, bool isNewItem);
        Task DeleteReservationAsync(Reservation item);
        Task<List<Membership>> GetMembershipsAsync();
        Task SaveMembershipAsync(Membership item, bool isNewItem);
        Task DeleteMembershipAsync(Membership item);
    }
}
