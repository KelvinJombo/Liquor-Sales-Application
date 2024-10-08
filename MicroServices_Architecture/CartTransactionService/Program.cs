using AutoMapper;
using CartTransactionService.Data;
using CartTransactionService.MapperProfiles;
using CartTransactionService.Repository;
using LiquorSale.MessageBus;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddHttpClient<ICouponRepository, CouponRepository>(u => u.BaseAddress =
new Uri(builder.Configuration["ServiceUrls:CouponApi"]));
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CartDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CartServiceConnection")));
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<CartDbContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("CartServiceConnection")));
builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<ICouponRepository, CouponRepository>();
builder.Services.AddSingleton<IMessageBus, AzureServiceBusMessageBus>();

var app = builder.Build();

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
// app.UseEndpoints(endpoints =>
// {
//     endpoints.MapControllers();
//  });
 //PrepDb.PrepPopulation(app);

app.Run();

 