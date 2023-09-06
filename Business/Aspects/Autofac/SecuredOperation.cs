using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Core.Extensions;
using Business.Contants;
using Core.Utilities.IoC;

namespace Business.Aspects.Autofac
{
	public class SecuredOperation:MethodInterception
	{
		private string[]? roles;
		private IHttpContextAccessor? _httpContextAccessor;

        public SecuredOperation(string role)
        {
			roles = role.Split(',');
			_httpContextAccessor = ServiceTool.ServiceProvider?.GetService<IHttpContextAccessor>();
        }

        protected override void OnBefore(IInvocation invocation)
		{
			List<string> roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
			foreach (string role in roleClaims)
			{
				if (roleClaims.Contains(role))
					return; 
			}

			throw new Exception(Messages.AuthorizationDenied);
		}
	}
}
