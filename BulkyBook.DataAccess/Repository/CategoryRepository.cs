﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.DataAccess.Data;
using WebApplication.DataAccess.Repository.IRepository;
using WebApplication.Models;

namespace WebApplication.DataAccess.Repository;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
	private ApplicationDBContext _db;

	public CategoryRepository(ApplicationDBContext db) : base(db)
	{
		_db = db;
	}

	public void Update(Category obj)
	{
		_db.Categories.Update(obj);
	}
}