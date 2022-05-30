using Accesa.SportsBuddy.Database;
using Accesa.SportsBuddy.Mapper;
using Accesa.SportsBuddy.Repositories;
using Accesa.SportsBuddy.Repositories.Interfaces;
using AutoMapper;
using Accesa.SportsBuddy.Database.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accesa.SportsBuddy.Services.Interfaces;
using Accesa.SportsBuddy.Services;
using Accesa.SportsBuddy.Controllers.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Accesa.SportsBuddy
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                    });
            });

            // services.AddResponseCaching();
            services.AddControllers();

            services.AddDbContext<SportsBuddyDBContext>(ServiceLifetime.Transient);
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<SportsBuddyDBContext>()
                .AddDefaultTokenProviders();

            // Adding Authentication  
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })

            // Adding Jwt Bearer  
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = Configuration["JWT:ValidAudience"],
                    ValidIssuer = Configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))
                };

            });
            services.AddScoped<ISportCenterAdminRepository, SportCenterAdminRepository>();
            services.AddScoped<ISportCenterAdminService, SportCenterAdminService>();
            services.AddScoped<ITraineeRepository, TraineeRepository>();
            services.AddScoped<ITraineeService, TraineeService>();
            services.AddScoped<ITrainerRepository, TrainerRepository>();
            services.AddScoped<ITrainerService, TrainerService>();
            services.AddScoped<ITrainerSportCenterService, TrainerSportCenterService>();
            services.AddScoped<ITrainerSportCenterRepository, TrainerSportCenterRepository>();
            services.AddScoped<ISportCenterRepository, SportCenterRepository>();
            services.AddScoped<IAdministratedSportCenterRepository, AdministratedSportCenterRepository>();
            services.AddScoped<IUserTrainingService, UserTrainingService>();
            services.AddScoped<ITrainingProgramRepository, TrainingProgramRepository>();
            services.AddScoped<ITrainingProgramService, TrainingProgramService>();
            services.AddScoped<IUserTrainingRepository, UserTrainingRepository>();
            services.AddScoped<ITrainerTrainingProgramRepository, TrainerTrainingProgramRepository>();
            services.AddScoped<ITrainerTrainingProgramService, TrainerTrainingProgramService>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<IChallengeRepository, ChallengeRepository>();
            services.AddScoped<IChallengeService, ChallengeService>();
            services.AddScoped<ITraineeChallengeRepository, TraineeChallengeRepository>();
            services.AddScoped<ITraineeChallengeService, TraineeChallengeService>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IEventCreatedBySportCenterRepository, EventCreatedBySportCenterRepository>();
            services.AddScoped<IEventCreatedBySportCenterService, EventCreatedBySportCenterService>();
            services.AddScoped<IJoinEventRepository, JoinEventRepository>();
            services.AddScoped<IJoinEventService, JoinEventService>();
            services.AddScoped<IJoinSportCenterEventRepository, JoinSportCenterEventRepository>();
            services.AddScoped<IJoinSportCenterEventService, JoinSportCenterEventService>();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Accesa.SportsBuddy", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Accesa.SportsBuddy v1"));
            }
            app.UseCors();
            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}