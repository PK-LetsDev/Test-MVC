﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.DataAccess.Data;
using WebApplication.DataAccess.Repository.IRepository;
using WebApplication.Models;

namespace WebApplication.DataAccess.Repository;

public class CompanyRepository : Repository<Company>, ICompanyRepository
{
	private ApplicationDBContext _db;

	public CompanyRepository(ApplicationDBContext db) : base(db)
	{
		_db = db;
	}

	public void Update(Company obj)
	{
		_db.Companies.Update(obj);
	}
}