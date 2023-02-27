using WebApplication.Models;

namespace WebApplication.DataAccess.Repository.IRepository;

public interface ICategoryRepository : IRepository<Category>
{
	void Update(Category obj);
}