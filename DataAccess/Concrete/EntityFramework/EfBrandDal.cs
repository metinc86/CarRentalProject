using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : EfEntityRepositoryBase<Brand, NorthwindContext>, IBrandDal
    {
        public List<BrandDetailDto> GetCarDetails()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from b in context.Brands
                             join c in context.Cars
                             on b.BrandId equals c.BrandId
                             select new BrandDetailDto
                             {
                                 BrandId = b.BrandId,
                                 BrandName = b.BrandName,
                             };
                return result.ToList();
            }
        }
    }
}
