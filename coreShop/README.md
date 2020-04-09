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

##Bài 23 sử dụng Fluent Validate cho viewModel
- bỏ qua
##Bài 24 Thêm template admin. đăng nhập hệ thống
1. Tải template admin : https://startbootstrap.com/previews/sb-admin/
2. Tạo coreShop.AdminApp
- Gắn layout
- Tạo action đăng nhập + gắn layout dang nhập
- sửa form login
3. install : Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation
4. cấu hình startUp
https://docs.microsoft.com/en-us/aspnet/core/mvc/views/view-compilation?view=aspnetcore-3.1&viewFallbackFrom=asp.netcore-3.1
- trong public void ConfigureServices(IServiceCollection services){...}
- Thêm:
        IMvcBuilder builder = services.AddRazorPages();
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            #if DEBUG
            if (environment == Environments.Development)
            {
                builder.AddRazorRuntimeCompilation();
            }
            #endif
- Lấy web api là port 5001, web admin là port 5002

5. triển khai service IUserApiClient <xem phương thức>
6. khai báo DI service trong starUp
-   services.AddHttpClient();
    services.AddTransient<IUserApiClient, UserApiClient>();
7. Triển khai phương thức controler gọi về web api 
- *chú ý dùng [FormBody] đồng nhất với bên controlller của admin trả về api
8. Chạy multi api . admin
- đăng nhập lấy về dc token -->>>ok

##Bài 26 chứng thực với cookies không dùng identity
1. Chỉnh sửa lại service api return về 1 token, không phải 1 oject token
2. Chỉnh sửa lại host:  "launchBrowser": false, không cần show swagger lên nữa
3. Copy token vào appsetting.json
4. Viết phương thức giải mã token bên controller user admin
    private ClaimsPrincipal ValidateToken(string jwtToken)
        {
            IdentityModelEventSource.ShowPII = true;
            SecurityToken validatedToken;
            TokenValidationParameters validationParameters = new TokenValidationParameters();

            validationParameters.ValidateLifetime = true;
            validationParameters.ValidAudience = _configuration["Tokens:Issuer"];
            validationParameters.ValidIssuer = _configuration["Tokens:Issuer"];
            validationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]));

            ClaimsPrincipal principal = new JwtSecurityTokenHandler().ValidateToken(jwtToken, validationParameters, out validatedToken);
            return principal;
        }
5.chỉnh sữa lại phương thức post vào login()
    [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var token = await _userApiClient.Authenticate(request);
            var usePrinpical = this.ValidateToken(token);
            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                IsPersistent = true
            };
            await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            usePrinpical,
            authProperties);

            return RedirectToAction("Index", "Home");
        }
6. chỉnh sửa lại phương thức login get
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View();
        }
7. [Authorize] trang HomeController admin không cho phép vào khi chưa đăng nhập
8. Cấu hình trong starUp
    services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/User/Login/";
                options.AccessDeniedPath = "/User/Forbidden/";
            });
    
    app.UseAuthentication(); *trên routing và UseAuthorization
9. lấy username bên home/index
-   var user = User.Identity.Name;
-   Gắn vào layout @User.Identity.Name

10. phương thức logout
- bên layoutview
    <form method="post" asp-controller="User" asp-action="Logout">
          <button type="submit" class="dropdown-item">Đăng xuất</button>
    </form>
- Controller
     public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "User");
        }
*gọi lại phương thức logout như khi vào method login (ngăn không vào được trang khác)
