# FitnessClubApi
В приведенном проекте используется подключение к уже существующей базе данных postgressql
Создание database-first

1)скачать Microsoft.EntityFrameworkCore.Tools и Npgsql.EntityFrameworkCore.PostgreSQL

2)перейти Tools > NuGet Package Manager > Package Manager Console

3)Создать подключение к бд Scaffold-DbContext "Host=localhost;Port=5432;Database=test;Username=postgres;Password=postgres " Npgsql.EntityFrameworkCore.PostgreSQL -OutputDir Models

4)добавить в program.cs 
builder.Services.AddDbContext<TestContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("TestContext")));
Тестирование RestApi
1)Перейдите по адресу https://localhost:yourport/swagger/index.html
