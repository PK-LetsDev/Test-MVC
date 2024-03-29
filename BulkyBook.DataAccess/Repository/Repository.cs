﻿using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WebApplication.DataAccess.Data;
using WebApplication.DataAccess.Repository.IRepository;

namespace WebApplication.DataAccess.Repository;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly ApplicationDBContext _db;
    internal DbSet<T> dbSet;

    public Repository(ApplicationDBContext db)
    {
        _db = db;
        //_db.ShoppingCarts.AsNoTracking()
        //_db.ShoppingCarts.Include(u => u.Product).Include(u => u.CoverType);
        this.dbSet = _db.Set<T>();
    }
    public void Add(T entity)
    {
        dbSet.Add(entity);
    }
    //includeProp - "Category,CoverType"
    public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
    {
        IQueryable<T> query = dbSet;
        if (filter != null)
        {
            query = query.Where(filter);
        }

        if (includeProperties != null)
        {
            foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProp);
            }
        }
        return query.ToList();
    }

    public T GetFistOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = true)
    {
        IQueryable<T> query = dbSet;
        if (tracked)
        {
            query = dbSet;
        }
        else
        {
            query = dbSet.AsNoTracking();
        }
        query = query.Where(filter);
        if (includeProperties != null)
        {
            foreach (var includeProp in includeProperties.Split(new char[] { ',' },
                         StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProp);
            }
        }
        return query.FirstOrDefault();
    }

    public void Remove(T entity)
    {
        dbSet.Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entity)
    {
        dbSet.RemoveRange(entity);
    }
}