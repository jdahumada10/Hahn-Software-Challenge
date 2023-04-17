using Core.Providers;
using Core.UseCases;
using Core.UseCases.Impl;
using DataProvider;
using DataProvider.Adapters;
using DataProvider.Database.Contexts;
using DataProvider.Database.Repositories;
using DataProvider.Database.Repositories.Impl;
using EntryPoint.Presenter;
using EntryPoint.Presenter.Impl;
using EntryPoint.Services;
using EntryPoint.Services.Impl;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetSection("DatabaseConfiguration:ConnectionString").Value;

builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IApplicantService, ApplicantService>();
builder.Services.AddScoped<ICompanyPresenter, CompanyPresenter>();
builder.Services.AddScoped<IApplicantPresenter, ApplicantPresenter>();
builder.Services.AddScoped<IReadCompanyUseCase, ReadCompanyUseCase>();
builder.Services.AddScoped<ISaveCompanyUseCase, SaveCompanyUseCase>();
builder.Services.AddScoped<IDeleteCompanyUseCase, DeleteCompanyUseCase>();
builder.Services.AddScoped<ISaveApplicantUseCase, SaveApplicantUseCase>();
builder.Services.AddScoped<IReadApplicantUseCase, ReadApplicantUseCase>();
builder.Services.AddScoped<IDeleteApplicantUseCase, DeleteApplicantUseCase>();
builder.Services.AddScoped<ICompanyProvider, CompanyProvider>();
builder.Services.AddScoped<IApplicantProvider, ApplicantProvider>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IApplicantRepository, ApplicantRepository>();
builder.Services.AddTransient<CompanyAdapter>();
builder.Services.AddTransient<ApplicantAdapter>();
builder.Services.AddDbContext<CompanyContext>(x => x.UseSqlServer(connectionString));
builder.Services.AddDbContext<ApplicantContext>(x => x.UseSqlServer(connectionString));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var allowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(allowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var companyContext = scope.ServiceProvider.GetRequiredService<CompanyContext>();
    companyContext.Database.EnsureCreated();
    companyContext.Database.Migrate();
    var applicantContext = scope.ServiceProvider.GetRequiredService<ApplicantContext>();
    applicantContext.Database.EnsureCreated();
    applicantContext.Database.Migrate();
}

app.UseHttpsRedirection();

app.UseCors(allowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();