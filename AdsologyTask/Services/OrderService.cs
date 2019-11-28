//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using AdsologyTask.Models;
//using Microsoft.EntityFrameworkCore;

//namespace AdsologyTask.Services
//{
//    public class OrderService : IService
//    {
//        DbContext _context;

//        public OrderService(DbContext context)
//                : base(context)
//        {
//            _context = context;
//            _dbset   = _context.Set<Student>();
//        }

//        public async Task<Orders> GetById(int Id)
//        {
//            return await _dbset.FirstOrDefaultAsync(x => x.Id == Id);
//        }
//    {
        
//    }
//}
