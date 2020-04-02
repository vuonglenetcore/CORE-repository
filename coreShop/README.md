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