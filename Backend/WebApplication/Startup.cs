using BL.Services;
using DAL.Context;
using DAL.Entities;
using DAL.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebApplication
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<IRepository<Question, QuestionContext>, BaseRepository<Question, QuestionContext>>();
            services.AddSingleton<IRepository<Participant, ParticipantContext>, BaseRepository<Participant, ParticipantContext>>();
            services.AddSingleton<IRepository<Answer, AnswerContext>, BaseRepository<Answer, AnswerContext>>();

            services.AddSingleton<ISurveyServices, QuestionServices>();

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("*");
                    });
            });
            AddDbContext(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void AddDbContext(IServiceCollection services)
        {
            services.AddDbContextFactory<QuestionContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("SqlDBC"),
                    assembly => assembly.MigrationsAssembly("DAL"));
            });
            services.AddDbContextFactory<ParticipantContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("SqlDBC"),
                    assembly => assembly.MigrationsAssembly("DAL"));
            });
            services.AddDbContextFactory<AnswerContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("SqlDBC"),
                    assembly => assembly.MigrationsAssembly("DAL"));
            });
        }
    }
}
