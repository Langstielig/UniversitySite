using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore.Internal;

namespace CSharp_laba5._1.Service
{
	public class AdminAreaAuthorization: IControllerModelConvention
	{
		private readonly string area;
		private readonly string policy;

		public AdminAreaAuthorization(string area, string policy)
		{
			this.area = area;
			this.policy = policy;
		}

		public void Apply(ControllerModel controller) //проверяем атрибуты для контроллера (авторизация)
		{
			if (controller.Attributes.Any(a => 
			a is AreaAttribute && (a as AreaAttribute).RouteValue.Equals(area, System.StringComparison.OrdinalIgnoreCase))
		    || controller.RouteValues.Any(r => 
			r.Key.Equals("area", System.StringComparison.OrdinalIgnoreCase) && r.Value.Equals(area, System.StringComparison.OrdinalIgnoreCase)))
			{
				controller.Filters.Add(new AuthorizeFilter(policy));
			}
		}
	}
}
