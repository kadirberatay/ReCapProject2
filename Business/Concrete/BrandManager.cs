using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
	public class BrandManager : IBrandService
	{
		IBrandDal _brandDal;

		public BrandManager(IBrandDal brandDal)
		{
			_brandDal = brandDal;
		}

		public void Add(Brand brand)
		{
			_brandDal.Add(brand);
			Console.WriteLine("Marka eklendi.");
		}

		public void Delete(Brand brand)
		{
			_brandDal.Delete(brand);
		}

		public List<Brand> GetAll()
		{
			return _brandDal.GetAll();
			Console.WriteLine("Markalar listeleniyor...");
		}

		public Brand GetById(int brandId)
		{
			return _brandDal.Get(p => p.BrandId == brandId);
		}

		public void Update(Brand brand)
		{
			_brandDal.Update(brand);
			Console.WriteLine($"{brand.BrandName} güncellendi.");
		}
	}
}
