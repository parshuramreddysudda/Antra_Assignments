using MVCLearnProject.Models;

namespace MVCLearnProject.ViewModel;

public class RandomMovieModel
{
    public Movie Movie { get; set; }
    public List<Customer> Customers { get; set; }
}