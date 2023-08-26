using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using DataAccsess.Abstract;
using DataAccsess.Concrete.EntityFramework;
using Core.Utilities.Interceptors;
using DataAccsess.Concrete.Entity_Framework;
using Core.Utilities.Security.JWT;

namespace Business.DependencyResolvers.Autofac
{
	public class AutofacBusinessModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
			builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();
			builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
			builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();
			builder.RegisterType<UserManager>().As<IUserService>();
			builder.RegisterType<EfUserDal>().As<IUserDal>();
			builder.RegisterType<AuthManager>().As<IAuthService>();
			builder.RegisterType<JwtHelper>().As<ITokenHelper>();


			var assembly = System.Reflection.Assembly.GetExecutingAssembly();

			builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().
				EnableInterfaceInterceptors(new ProxyGenerationOptions()
				{
					Selector = new AspectInterceptorSelector()
				}).SingleInstance();
		}
	}
}
