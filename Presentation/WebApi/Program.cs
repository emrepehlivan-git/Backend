using Application;
using Application.Validators.Products;
using FluentValidation.AspNetCore;
using Infrastructure;
using Infrastructure.Filters;
using Infrastructure.Services.Storage.Local;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Persistence;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistenceServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddApplicationServices();
builder.Services.AddStorage<LocalStorage>();


builder.Services.AddControllers(opt =>
                                                                 {
                                                                      opt.Filters.Add<ValidationsFilter>();
                                                                 }).AddFluentValidation(conf => conf.RegisterValidatorsFromAssemblyContaining<CreateProductValidator>())
                                                                     .ConfigureApiBehaviorOptions(opt => opt.SuppressModelStateInvalidFilter = true);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(opt => opt.AddDefaultPolicy(policy =>
   policy.WithOrigins("http://localhost:3000", "https://localhost:3000").AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod()
));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
     .AddJwtBearer(opt =>
          {
               opt.TokenValidationParameters = new()
               {
                    ValidateAudience = true, //token'ý kimlerin kullanacaðýný belirlediðimiz deðerdir.
                    ValidateIssuer = true, //token'ý kimin daðýttýný ifade eder.
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidAudience = builder.Configuration["Token:Audience"],
                    ValidIssuer = builder.Configuration["Token:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"]))
               };
          });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
     app.UseSwagger();
     app.UseSwaggerUI();
}

app.UseCors();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
