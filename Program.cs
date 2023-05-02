using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using Repository.Classes.Users;
using Repository.Classes.Users.PatientsRepo;
using Repository.Classes.Users.StaffRepo;
using Repository.Classes.InvoicesRepo;
using Repository.Interfaces.Users;
using Repository.Interfaces.Users.PatientsInterface;
using Repository.Interfaces.Users.StaffInterfaces;
using Repository.Interfaces.InvoicesInterfaces;
using Validations.Classes.Users;
using Validations.Common.Validations;
using Validations.Classes.Invoices;
using Validations.Interfaces.Users;
using Validations.Interfaces.Invoices;
using Microsoft.EntityFrameworkCore;
using server.Database;
using Services.PropertyService;
using Services.ResponseService;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


/* DbConnection */
builder.Services.AddDbContext<DentalDBContext>(options =>
{
    var mainConnectionString = builder.Configuration.GetConnectionString("DBConnection");
    if (mainConnectionString != null)
    {
        options.UseSqlServer(mainConnectionString);
    }
    else
    {
        Console.WriteLine("ERROR: Unable to connect to SQL server(Main)");
    }
});
/* AuthDB Connection */
builder.Services.AddDbContext<AuthDBContext>(options => 

    options.UseSqlServer(builder.Configuration.GetConnectionString("AuthConnection"))
);
/* helpServices */
builder.Services.AddScoped<IPropertyService, PropertyService>();
builder.Services.AddScoped<IResponseService, ResponseService>();
/* USERS */
builder.Services.AddScoped<IUsersRead, UsersRead>();

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



builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddIdentityCore<IdentityUser>()
.AddRoles<IdentityRole>()
.AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("webapi")
.AddEntityFrameworkStores<AuthDBContext>()
.AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase= true;
    options.Password.RequireUppercase= true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 8;
    options.Password.RequiredUniqueChars = 1;
} 
);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => 
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JWT:issuer"],
        ValidAudience = builder.Configuration["JWT:audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:key"])),
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
