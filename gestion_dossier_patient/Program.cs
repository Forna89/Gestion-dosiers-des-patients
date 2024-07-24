using gestion_dossier_patient.models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages(op =>{
    op.Conventions.AuthorizeFolder("/Medecin");
    op.Conventions.AuthorizeFolder("/Dossier_patients");
    op.Conventions.AuthorizeFolder("/Consultations");
    op.Conventions.AuthorizeFolder("/Prescriptions");
});

builder.Services.AddDbContext<MedecinContext>(p=>p.UseSqlServer(builder.Configuration.GetConnectionString("GD_Database_sqlserver")));
builder.Services.AddIdentity<AppUser,IdentityRole>().AddEntityFrameworkStores<MedecinContext>().AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(op =>{
    op.LoginPath = "/Admin/Logins";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();    
app.UseAuthorization();

app.MapRazorPages();

app.Run();








//"GD_Database_sqlserver": "Server = DESKTOP-UBKK73O; Database = GD_patient; Trusted_Connection = True; MultipleActiveResultSets = true; TrustServerCertificate = True;"