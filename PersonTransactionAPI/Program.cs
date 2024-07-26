using PersonTransaction.BusinessLayer.Abstract;
using PersonTransaction.BusinessLayer.Concrete;
using PersonTransaction.DataAccessLayer.Abstract;
using PersonTransaction.DataAccessLayer.Concrete;
using PersonTransaction.DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using PersonTransactionAPI.Swagger;
using Hangfire;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
// Add services to the container.

builder.Services.AddDbContext<PersonTransactionContext>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddScoped<IPersonService, PersonManager>();
builder.Services.AddScoped<IPersonDal, EfPersonDal>();

builder.Services.AddScoped<IExpenseTransactionService, ExpenseTransactionManager>();
builder.Services.AddScoped<IExpenseTransactionDal, EfExpenseTransactionDal>();

builder.Services.AddScoped<IExpenseAggregationService, ExpenseAggregationService>();
builder.Services.AddScoped<IExpenseTransactionDal, EfExpenseTransactionDal>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Hangfire
builder.Services.AddHangfire(configuration => configuration
    .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
    .UseSimpleAssemblyNameTypeSerializer()
    .UseDefaultTypeSerializer()
    .UseSqlServerStorage(builder.Configuration.GetConnectionString("HangfireConnection")));


builder.Services.AddHangfireServer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseHangfireDashboard();
app.MapControllers();
app.UseHangfireServer();

RecurringJob.AddOrUpdate<IExpenseAggregationService>("daily-expense-aggregation", service => service.AggregateDailyExpenses(), Cron.Daily);
RecurringJob.AddOrUpdate<IExpenseAggregationService>("weekly-expense-aggregation", service => service.AggregateWeeklyExpenses(), Cron.Weekly);
RecurringJob.AddOrUpdate<IExpenseAggregationService>("monthly-expense-aggregation", service => service.AggregateMonthlyExpenses(), Cron.Monthly);

app.Run();
