
using System.Text;
using Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Writers;
using Repository;
using Repository.CityRepository;
using Service.CityService;
using Repository.CountryRepository;
using Service.CountryService;
using Service.FormService;
using Repository.FormRepository;
using Repository.FormProblemRepository;
using Service.FormProblemService;
using Repository.NotificationRepository;
using Service.NotificationService;
using Repository.HotelRepository;
using Service.HotelService;
using Repository.NotificationTemplateRepository;
using Service.NotificationTemplateService;
using Repository.NotificationTypeRepository;
using Service.NotificationTypeService;
using Repository.RoomRepository;
using Service.RoomService;
using Repository.UserRepository;
using Service.UserService;
using WebApplication1.Repository;
using WebApplication1.Service.TokenServices;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreConnection")); //  Постройка связи моделей с базой данных DefaultConnection
});

builder.Services.AddCors(c => c.AddPolicy("cors", opt =>
{
    opt.AllowAnyHeader();
    opt.AllowCredentials();
    opt.AllowAnyMethod();
    opt.WithOrigins(builder.Configuration.GetSection("Cors:Urls").Get<string[]>()!);
}));



builder.Services.AddScoped(typeof(ICityRepository), typeof(CityRepository));  // Добавление в зону видимости программы репозитория книг для возможности управлени содержимым в нем через сервис книг
builder.Services.AddTransient<ICityService, CityService>(); // Добавление в зону видимости программы сервиса книг для управления содержимым репозитория книг
builder.Services.AddScoped(typeof(ICountryRepository), typeof(CountryRepository)); // Добавления в зону видимости программы репозитория авторов для последующего управления содержимым в нем через сервис авторов
builder.Services.AddTransient<ICountryService, CountryService>(); // Добавление в зону видимомти программы сервиса авторов для управления содержимым репозитория авторов
builder.Services.AddScoped(typeof(IFormRepository), typeof(FormRepository));  // Добавление в зону видимости программы репозитория книг для возможности управлени содержимым в нем через сервис книг
builder.Services.AddTransient<IFormService, FormService>(); // Добавление в зону видимости программы сервиса книг для управления содержимым репозитория книг
builder.Services.AddScoped(typeof(IFormProblemRepository), typeof(FormProblemRepository)); // Добавления в зону видимости программы репозитория авторов для последующего управления содержимым в нем через сервис авторов
builder.Services.AddTransient<IFormProblemService, FormProblemService>(); // Добавление в зону видимомти программы сервиса авторов для управления содержимым репозитория авторов
builder.Services.AddScoped(typeof(IHotelRepository), typeof(HotelRepository));  // Добавление в зону видимости программы репозитория книг для возможности управлени содержимым в нем через сервис книг
builder.Services.AddTransient<IHotelService, HotelService>(); // Добавление в зону видимости программы сервиса книг для управления содержимым репозитория книг
builder.Services.AddScoped(typeof(INotificationRepository), typeof(NotificationRepository)); // Добавления в зону видимости программы репозитория авторов для последующего управления содержимым в нем через сервис авторов
builder.Services.AddTransient<INotificationService, NotificationService>(); // Добавление в зону видимомти программы сервиса авторов для управления содержимым репозитория авторов
builder.Services.AddScoped(typeof(INotificationTemplateRepository), typeof(NotificationTemplateRepository));  // Добавление в зону видимости программы репозитория книг для возможности управлени содержимым в нем через сервис книг
builder.Services.AddTransient<INotificationTemplateService, NotificationTemplateService>(); // Добавление в зону видимости программы сервиса книг для управления содержимым репозитория книг
builder.Services.AddScoped(typeof(INotificationTypeRepository), typeof(NotificationTypeRepository)); // Добавления в зону видимости программы репозитория авторов для последующего управления содержимым в нем через сервис авторов
builder.Services.AddTransient<INotificationTypeService, NotificationTypeService>(); // Добавление в зону видимомти программы сервиса авторов для управления содержимым репозитория авторов
builder.Services.AddScoped(typeof(IRoomRepository), typeof(RoomRepository)); // Добавления в зону видимости программы репозитория авторов для последующего управления содержимым в нем через сервис авторов
builder.Services.AddTransient<IRoomService, RoomService>(); // Добавление в зону видимомти программы сервиса авторов для управления содержимым репозитория авторов
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddAuthentication(opt => {
        opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"]!,
            ValidAudience = builder.Configuration["Jwt:Audience"]!,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"]!))
        };
    });
builder.Services.AddAuthorization(options => options.DefaultPolicy =
    new AuthorizationPolicyBuilder
            (JwtBearerDefaults.AuthenticationScheme)
        .RequireAuthenticatedUser()
        .Build());
builder.Services.AddIdentity<User, IdentityRole<long>>()
    .AddEntityFrameworkStores<ApplicationContext>()
    .AddUserManager<UserManager<User>>()
    .AddRoleManager<RoleManager<IdentityRole<long>>>()
    .AddRoles<IdentityRole<long>>()
    .AddSignInManager<SignInManager<User>>();

builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Liskalisovsky", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[]{}
        }
    });
});


var app = builder.Build();
var scope = app.Services.CreateScope();
var servises = scope.ServiceProvider;
SeedData.Initialize(servises);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors("cors");
app.MapControllers();


app.Run();