using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MotoRider.Core.Services;
using MotoRider.Core.Services.Interfaces;
using RabbitMQ.Client;
using System.Text;

namespace MotoRider.API.Rest
{
    public class Startup
    {
        // RabbitMQ Management http://localhost:15672

        internal static ConnectionFactory RmqConnectionFactory;
        internal static IConnection RmqConnection;
        internal static IModel RmqModel;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            
            SetupRabbitMq();
        }

        private static void SetupRabbitMq()
        {
            RmqConnectionFactory = new();
            RmqConnection = RmqConnectionFactory.CreateConnection();
            RmqModel = RmqConnection.CreateModel();
            RmqModel.QueueDeclare(queue: "Customers", exclusive: false);
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => { options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()); });

            services.AddControllers().AddXmlDataContractSerializerFormatters();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["TokenKey"])),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "MotoRider.API.Rest", Version = "v1" }); });

            services
                .AddTransient<IMotorcycleService, MotorcycleService>()
                .AddTransient<ICustomerService, CustomerService>()
                .AddTransient<IRentService, RentService>()
                .AddTransient<IUserService, UserService>();

            services.AddSingleton<IAuthenticationService, AuthenticationService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MotoRider.API.Rest v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("Open");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
