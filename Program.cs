using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using server.Database;
using System.Text;

using Repository.Classes.Users;
using Repository.Classes.Users.PatientsRepo;
using Repository.Classes.Users.StaffRepo;
using Repository.Classes.InvoicesRepo;
using Repository.Classes.LocationsRepo;
using Repository.Classes.EducationsRepo;
using Repository.Classes.ExperiencesRepo;
using Repository.Classes.MaterialsRepo;
using Repository.Classes.TreatmentItemsRepo;
using Repository.Classes.CountriesRepo;
using Repository.Classes.CitiesRepo;
using Repository.Classes.AppointmentsRepo;

using Repository.Interfaces.Users;
using Repository.Interfaces.Users.PatientsInterface;
using Repository.Interfaces.Users.StaffInterfaces;
using Repository.Interfaces.InvoicesInterfaces;
using Repository.Interfaces.LocationInterfaces;
using Repository.Interfaces.EducationInterfaces;
using Repository.Interfaces.ExperienceInterfaces;
using Repository.Interfaces.MaterialInterfaces;
using Repository.Classes.TreatmentItemsInterfaces;
using Repository.Interfaces.CityInterfaces;
using Repository.Interfaces.CountryInterfaces;
using Repository.Interfaces.AppointmentInterfaces;

using Validations.Classes.Users;
using Validations.Common.Validations;
using Validations.Classes.Invoices;
using Validations.Interfaces.Users;
using Validations.Interfaces.Invoices;

using Services.PropertyService;
using Services.ResponseService;

using Repository.Interfaces.TreatmentInterfaces;
using Repository.Classes.TreatmentsRepo;
using Services.TokenHandlerService;
using Services.HashService;


var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

// Replace secrets from environment variables
var dbServer = Environment.GetEnvironmentVariable("DB_SERVER") ?? configuration["ConnectionStrings:DBConnection"];
var dbName = Environment.GetEnvironmentVariable("DB_NAME") ?? configuration["ConnectionStrings:DBConnection"];
var dbUser = Environment.GetEnvironmentVariable("DB_USER") ?? configuration["ConnectionStrings:DBConnection"];
var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? configuration["ConnectionStrings:DBConnection"];

var connectionString = $"Server={dbServer};database={dbName};Trusted_Connection=False;TrustServerCertificate=True;User Id={dbUser};Password={dbPassword};";
configuration["ConnectionStrings:DBConnection"] = connectionString;

configuration["JWT:key"] = Environment.GetEnvironmentVariable("JWT_KEY") ?? configuration["JWT:key"];
// configuration["ApiKeys:ApiKey2"] = Environment.GetEnvironmentVariable("API_KEY_2") ?? configuration["ApiKeys:ApiKey2"];

Console.WriteLine("EVO GA");
Console.WriteLine(configuration.GetConnectionString("JWT:key"));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


/* DbConnection */
builder.Services.AddDbContext<DentalDBContext>(options =>
{
    var mainConnectionString = configuration.GetConnectionString("DBConnection");
    if (mainConnectionString != null)
    {
        options.UseSqlServer(mainConnectionString);
    }
    else
    {
        Console.WriteLine("ERROR: Unable to connect to SQL server(Main)");
    }
});

/* helpServices */
builder.Services.AddScoped<IPropertyService, PropertyService>();
builder.Services.AddScoped<IResponseService, ResponseService>();
/* USERS */
builder.Services.AddScoped<IUsersRead, UsersRead>();

builder.Services.AddScoped<IAppointmentsCreate, AppointmentsCreate>();
builder.Services.AddScoped<IAppointmentsRead, AppointmentsRead>();
builder.Services.AddScoped<IAppointmentsUpdate, AppointmentsUpdate>();
builder.Services.AddScoped<IAppointmentsDelete, AppointmentsDelete>();
/*-----------------------------------------------------------------------*/
builder.Services.AddScoped<IStaffCreate, StaffCreate>();
builder.Services.AddScoped<IStaffUpdate, StaffUpdate>();
builder.Services.AddScoped<IStaffRead, StaffRead>();
builder.Services.AddScoped<IStaffDelete, StaffDelete>();
builder.Services.AddTransient<IStaffValidations, StaffValidations>();
/************************************************************************/
builder.Services.AddScoped<IPatientsCreate, PatientsCreate>();
builder.Services.AddScoped<IPatientsRead, PatientsRead>();
builder.Services.AddScoped<IPatientsUpdate, PatientsUpdate>();
builder.Services.AddScoped<IPatientsDelete, PatientsDelete>();
builder.Services.AddScoped<IPatientValidations, PatientValidations>();
builder.Services.AddScoped<IUserValidations, UserValidations>();
builder.Services.AddScoped<IValidationsService, ValidationsService>();
/*----------------------------------------------------------------------*/
builder.Services.AddScoped<IInvoicesCreate, InvoicesCreate>();
builder.Services.AddScoped<IInvoicesRead, InvoicesRead>();
builder.Services.AddScoped<IInvoicesUpdate, InvoicesUpdate>();
builder.Services.AddScoped<IInvoicesDelete, InvoicesDelete>();
builder.Services.AddScoped<IInvoiceValidations, InvoiceValidations>();
builder.Services.AddScoped<IValidationsService, ValidationsService>();

/**************************************************************************/
builder.Services.AddScoped<ITreatmentsCreate, TreatmentsCreate>();
builder.Services.AddScoped<ITreatmentsRead, TreatmentsRead>();
builder.Services.AddScoped<ITreatmentsUpdate, TreatmentsUpdate>();
builder.Services.AddScoped<ITreatmentsDelete, TreatmentsDelete>();

/*----------------------------------------------------------------------*/
builder.Services.AddScoped<ILocationCreate, LocationCreate>();
builder.Services.AddScoped<ILocationRead, LocationRead>();
builder.Services.AddScoped<ILocationPatch, LocationPatch>();
builder.Services.AddScoped<ILocationDelete, LocationDelete>();
/*----------------------------------------------------------------------*/
builder.Services.AddScoped<IEducationsCreate, EducationsCreate>();
builder.Services.AddScoped<IEducationsRead, EducationsRead>();
builder.Services.AddScoped<IEducationsUpdate, EducationsUpdate>();
builder.Services.AddScoped<IEducationsDelete, EducationsDelete>();
/*----------------------------------------------------------------------*/
builder.Services.AddScoped<IExperiencesCreate, ExperiencesCreate>();
builder.Services.AddScoped<IExperiencesRead, ExperiencesRead>();
builder.Services.AddScoped<IExperiencesUpdate, ExperiencesUpdate>();
builder.Services.AddScoped<IExperiencesDelete, ExperiencesDelete>();
/*----------------------------------------------------------------------*/
builder.Services.AddScoped<IMaterialsCreate, MaterialsCreate>();
builder.Services.AddScoped<IMaterialsRead, MaterialsRead>();
builder.Services.AddScoped<IMaterialsUpdate, MaterialsUpdate>();
builder.Services.AddScoped<IMaterialsDelete, MaterialsDelete>();
/*-----------------------------------------------------------------------*/
builder.Services.AddScoped<ITreatmentItemsCreate, TreatmentItemsCreate>();
// builder.Services.AddScoped<ITreatmentItemsRead, TreatmentItemsRead>();
// builder.Services.AddScoped<ITreatmentItemsUpdate, TreatmentItemsUpdate>();
// builder.Services.AddScoped<ITreatmentItemsDelete, TreatmentItemsDelete>();
/*-----------------------------------------------------------------------*/
builder.Services.AddScoped<ICityCreate, CityCreate>();
builder.Services.AddScoped<ICityRead, CityRead>();
builder.Services.AddScoped<ICityPatch, CityPatch>();
builder.Services.AddScoped<ICityDelete, CityDelete>();
/*-----------------------------------------------------------------------*/
builder.Services.AddScoped<ICountryCreate, CountryCreate>();
builder.Services.AddScoped<ICountryRead, CountryRead>();
builder.Services.AddScoped<ICountryPatch, CountryPatch>();
builder.Services.AddScoped<ICountryDelete, CountryDelete>();
/*-----------------------------------------------------------------------*/
builder.Services.AddScoped<ITokenHandlerService, TokenHandlerService>();
/*-----------------------------------------------------------------------*/
builder.Services.AddScoped<IHashService, HashService>();
/*-----------------------------------------------------------------------*/
builder.Services.AddScoped<ILoginRepo, LoginRepo>();
/*-----------------------------------------------------------------------*/
builder.Services.AddScoped<IChangePassword, ChangePasswordRepo>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:key"]))
    });
    
builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddCors(option =>
{
    option.AddPolicy("FirstPolicy", builder => 
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();

    });
});

var app = builder.Build();

//// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseCors("FirstPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

