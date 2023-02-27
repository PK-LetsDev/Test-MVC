﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.DataAccess.Data;
using WebApplication.DataAccess.Repository.IRepository;
using WebApplication.Models;

namespace WebApplication.DataAccess.Repository;

public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
{
	private ApplicationDBContext _db;

	public OrderHeaderRepository(ApplicationDBContext db) : base(db)
	{
		_db = db;
	}

	public void Update(OrderHeader obj)
	{
		_db.OrderHeaders.Update(obj);
	}

	public void UpdateStatus(int id, string orderStatus, string? paymentStatus = null)
	{
		var orderFromDb = _db.OrderHeaders.FirstOrDefault(u => u.Id == id);
		if (orderFromDb != null)
		{
			orderFromDb.OrderStatus = orderStatus;
			if (paymentStatus != null)
			{
				orderFromDb.PaymentStatus = paymentStatus;
			}
		}
	}

	public void UpdateStripePaymentID(int id, string sessionId, string paymentIntentId)
	{
		var orderFromDb = _db.OrderHeaders.FirstOrDefault(u => u.Id == id);
		orderFromDb.SessionId = sessionId;
		orderFromDb.PaymentIntentId = paymentIntentId;
	}
}