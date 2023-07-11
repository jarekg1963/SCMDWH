using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using SCMDWH.Server.Data;
using SCMDWH.Server.Logging;
using SCMDWH.Server.Repository;
using SCMDWH.Server.Sevices;
using SCMDWH.Shared.Models;
using System;
using System.Globalization;
using System.Text;
using System.Text.Json.Serialization;




var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();


builder.Services.AddDbContext<PurchasingContext>
    (options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MSSQLPurchasingConnection")));
// CarAdviceContext

builder.Services.AddDbContext<CarAdviceContext>
    (options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MSSQLPurchasingConnection")));


builder.Services.AddDbContext<TPVstockContext>
    (options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TPVStockConnection")));



builder.Services.AddSwaggerGen();

//Repositories 

builder.Services.AddScoped<IRepoGlobalAppUsers, RepoGlobalAppUsers>();
builder.Services.AddScoped<IRepoGlobalAppRoles, RepoGlobalAppRoles>();
builder.Services.AddTransient<ExportToExcel>();


//IRepoGlobalAppRoles
//End of repositories

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.Configure<GlobalAppInfo>(builder.Configuration.GetSection("GlobalAppInfoAppJson"));

var jwtSettings = builder.Configuration.GetSection("JWTSettings");
builder.Services.AddAuthentication(opt =>
{
	opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
	options.TokenValidationParameters = new TokenValidationParameters
	{
		ValidateIssuer = true,
		ValidateAudience = true,
		ValidateLifetime = true,
		ValidateIssuerSigningKey = true,
		ValidIssuer = jwtSettings["validIssuer"],
		ValidAudience = jwtSettings["validAudience"],
		IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["securityKey"]))
	};
});

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// create a logger factory


builder.Logging.AddDbLogger(options =>
{
    builder.Configuration.GetSection("Logging").GetSection("Database").GetSection("Options").Bind(options);
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Blazor API V1");
    });

    var optionsSection = builder.Configuration.GetSection("Logging")
    .GetSection("Database").GetSection("Options");



    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");


app.Run();
