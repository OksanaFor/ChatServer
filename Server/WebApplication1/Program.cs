using BusinessLogic.Common.Auth;
using Microsoft.IdentityModel.Tokens;
using DataAcessLayer;
using BusinessLogic;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ChatServer.Middleware;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddCors();
            builder.Services.AddAuthentication("Bearer").AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                   
                    ValidateIssuer = true,
                
                    ValidIssuer = AuthOptions.ISSUER,
                    
                    ValidateAudience = true,
                   
                    ValidAudience = AuthOptions.AUDIENCE,
                
                    ValidateLifetime = true,
                 
                    IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
              
                    ValidateIssuerSigningKey = true,
                };

            });
            builder.Services.AddControllers();
            builder.Services.AddDALDI();
            builder.Services.AddBLLDI();
            builder.Services.AddDbContext<ChatServerEntities>(options => {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

            });
            builder.Services.AddAutoMapper(typeof(DTOtoEntitiesMapper));
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "My API",
                    Version = "v1"
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme
                        {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                        },
                        new string[] { }
                    }
                    });
            });
            WebApplication app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
    
            }
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.UseMiddleware<ExceptionHandlerMiddleware>();
            app.Run();
        }
    }
}
