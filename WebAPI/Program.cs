using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers.Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class Program
{
	public static void Main(string[] args)
	{
		var host = CreateHostBuilder(args).Build();
		host.Run();
	}

	public static IHostBuilder CreateHostBuilder(string[] args) =>
		Host.CreateDefaultBuilder(args)
			.UseServiceProviderFactory(new AutofacServiceProviderFactory())
			.ConfigureContainer<ContainerBuilder>(builder =>
			{
				builder.RegisterModule(new AutofacBusinessModule());
			})
			.ConfigureWebHostDefaults(webBuilder =>
			{
				webBuilder.ConfigureServices(services =>
				{
					services.AddControllers();
					services.AddEndpointsApiExplorer();
					services.AddSwaggerGen();
					// services.AddSingleton<IProductService, ProductManager>();
					// services.AddSingleton<IProductDal, EfProductDal>();
				});

				webBuilder.Configure(app =>
				{
					var env = app.ApplicationServices.GetService<IWebHostEnvironment>();

					if (env.IsDevelopment())
					{
						app.UseSwagger();
						app.UseSwaggerUI();
					}

					app.UseHttpsRedirection();
					app.UseAuthorization();
					app.UseRouting();

					app.UseEndpoints(endpoints =>
					{
						endpoints.MapControllers();
					});
				});
			});
}
