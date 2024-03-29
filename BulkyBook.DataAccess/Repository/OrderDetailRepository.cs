﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.DataAccess.Data;
using WebApplication.DataAccess.Repository.IRepository;
using WebApplication.Models;

namespace WebApplication.DataAccess.Repository;

public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
{
	private ApplicationDBContext _db;

	public OrderDetailRepository(ApplicationDBContext db) : base(db)
	{
		_db = db;
	}

	public void Update(OrderDetail obj)
	{
		_db.OrderDetails.Update(obj);
	}
}