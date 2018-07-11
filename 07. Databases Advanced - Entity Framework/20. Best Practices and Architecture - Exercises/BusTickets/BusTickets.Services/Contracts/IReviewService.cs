using BusTickets.Models;

namespace BusTickets.Services.Contracts
{
    public interface IReviewService
    {
        Review GetReviewById(int id);

        Review[] GetReviewByBusCompanyId(int id);

        void AddReview(string content, float grade, BusCompany busCompany, Customer customer);
    }
}