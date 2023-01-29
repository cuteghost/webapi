using Dental_App.Repository.Classes.Users.PatientsRepo;
using Dental_App.Repository.Classes.Users.Staff;
using Dental_App.Repository.Classes.Users.StaffRepo;
using Dental_App.Repository.Interfaces.Users.PatientsInterface;
using Dental_App.Repository.Interfaces.Users.StaffInterfaces;
using Dental_App.Repository.Interfaces.Users.StaffRepo;
using Dental_App.Validations.Classes.Users;
using Dental_App.Validations.Interfaces.Users;
using Microsoft.EntityFrameworkCore;
using server.Database;

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
        Console.WriteLine("ERROR: SQL Server Unreachable. Server is not responding");
    }
});


/* USERS */
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
builder.Services.AddTransient<IPatientValidations, PatientValidations>();


builder.Services.AddTransient<IUserValidations, UserValidations>();

/*----------------------------------------------------------------------*/
builder.Services.AddAutoMapper(typeof(Program).Assembly);
var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
