# ASP.NET Core 3.1 project from TEDU
## Technologies
- ASP.NET Core 3.1
- Entity Framework Core 3.1
## Install Packages --data
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools
- Microsoft.EntityFrameworkCore.Design

- Microsoft.Extensions.Configuration.FileExtensions sử dụng cho SetBasePath
- Microsoft.Extensions.Configuration.Json sử dụng cho AddJsonFile
## Youtube tutorial
## How to configure and run
## How to contribute

## Data seeding
trong file dbcontext ghi thêm 
//Data seeding
modelBuilder.Seed();

chạy lệnh: update-database

##table identity
1. kế thua identitydbcontext
2. them bảng AppRole. AppUser (mục đích thêm trường)
3. configuration table
4. khai báo trong dbcontext

## Bai 16 ghi file 
## tao web api
1. tao project
2. tao kết nối data trong dEVELOPMENT.JSON và startUp
	public void ConfigureServices(IServiceCollection services)

3. khai báo DI kết nối service
4. tiêm service, viết phương thức api bên controller gọi method service

## Swashbuckle.AspNetCore
1. cài đặt Swashbuckle.AspNetCore
2. https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-3.1&tabs=visual-studio
	- services.AddSwaggerGen(...)
	- app.UseSwagger();
	-  app.UseSwaggerUI(...)
3. Chỉ định "launchUrl": "swagger", trong launchSetting.json

## api đăng kí đăng nhập
- Tạo IUserservice, Userservice
- DI service
 //services.AddIdentity<AppUser, AppRole>()
   //     .AddEntityFrameworkStores<coreShopDbContext>()
//     .AddDefaultTokenProviders();

services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<coreShopDbContext>().AddDefaultTokenProviders();

- tạo tocken trong appsettings api
- tao controller

##Bài Bài 22: Thêm Authorization header cho Swagger
1. config swagger trong class StartUp.cs  >  services.AddSwaggerGen(c =>
-	c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme)
    {...}
-   c.AddSecurityRequirement(new OpenApiSecurityRequirement()
	{...}
- sửa lại   services.AddControllersWithViews(); >   services.AddControllers();

- cấu hình  services.AddAuthentication:
			string issuer = Configuration.GetValue<string>("Tokens:Issuer");
            string signingKey = Configuration.GetValue<string>("Tokens:Key");
            byte[] signingKeyBytes = System.Text.Encoding.UTF8.GetBytes(signingKey);

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidateAudience = true,
                    ValidAudience = issuer,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ClockSkew = System.TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(signingKeyBytes)
                };
            });

- config trong contrller (ngăn không cho vào controller khi chưa đăng nhập)
    //api/product
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
-> chạy lên có button authorize trên trình duyệt
2. Cách test athocation
- Chưa đăng nhập
get -> trả về 401
- đăng nhập đúng, get sai mã token sai
get -> trả về 401
-Đăng nhập đúng lấy mã token > button authorize > Bearer maToKen > click
- get > trả về 200 get ra sản phẩm