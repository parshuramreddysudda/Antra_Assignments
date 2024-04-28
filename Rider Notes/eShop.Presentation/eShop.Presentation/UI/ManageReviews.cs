using eShop.Core;
using eShop.Infrastructure.Repositories;

namespace eShop.Presentation.UI;

public class ManageReviews
{
    public ReviewRepository _reviewRepository = new ReviewRepository();

    public void AddReview()
    {
        Review review = new Review();
        Console.WriteLine("Enter Review ID");
        review.Id = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter ProductID");
        review.ProductId = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter Review Person Name");
        review.PersonName = Console.ReadLine();
        Console.WriteLine("Enter Review");
        review.ReviewInformation = Console.ReadLine();
        _reviewRepository.Insert(review);
    }

    public void DeleteReview()
    {
        Console.WriteLine("Enter ID to Delete");
        _reviewRepository.DeleteById(Convert.ToInt32(Console.ReadLine()));
        GetAll();
    }

    public void UpdateReview()
    {
        Review review = new Review();
        Console.WriteLine("Enter Review ID");
        review.Id = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter ProductID");
        review.ProductId = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter Review Person Name");
        review.PersonName = Console.ReadLine();
        Console.WriteLine("Enter Review");
        review.ReviewInformation = Console.ReadLine();
        _reviewRepository.Update(review);
        GetAll();
    }

    public void GetByID()
    {
        Console.WriteLine("Enter Review ID");
        Review review = _reviewRepository.GetById(Convert.ToInt32(Console.ReadLine()));
        Console.WriteLine($"{review.Id}\t {review.ReviewInformation}");
    }

    public void GetAll()
    {
        IEnumerable<Review> reviews = _reviewRepository.GetAll();
        foreach (var review  in reviews)
        {
            Console.WriteLine($"{review.Id}\t {review.ReviewInformation}");
        }
    }

    public void Run()
    {
        GetByID();
    }
}