using WebApplication.Models;

namespace WebApplication.DataAccess.Repository.IRepository;

public interface ICompanyRepository : IRepository<Company>
{
	void Update(Company obj);
}