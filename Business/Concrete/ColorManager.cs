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
	public class ColorManager : IColorService
	{
		IColorDal _colorDal;

		public ColorManager(IColorDal colorDal)
		{
			_colorDal = colorDal;
		}

		public void Add(Color color)
		{
			throw new NotImplementedException();
		}

		public void Delete(Color color)
		{
			throw new NotImplementedException();
		}

		public List<Color> GetAll()
		{
			throw new NotImplementedException();
		}

		public Color GetById(int colorId)
		{
			throw new NotImplementedException();
		}

		public void Update(Color color)
		{
			throw new NotImplementedException();
		}
	}
}
