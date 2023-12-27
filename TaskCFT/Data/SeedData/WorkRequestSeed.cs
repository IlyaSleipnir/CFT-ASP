using Microsoft.EntityFrameworkCore;
using TaskCFT.Models.Entities;

namespace TaskCFT.Data.SeedData
{
    public class WorkRequestSeed
    {
        static public void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(serviceProvider
                .GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                if (!context.Application.Any() || context.Application.Count() < 10)
                {
                    ApplicationSeed.Initialize(serviceProvider);
                }

                if (context.WorkRequest.Any())
                {
                    return;
                }

                // добавим 21 запись для приложений
                context.WorkRequest.AddRange(
                    new WorkRequest
                    {
                        Name = "Интеграция API с платежной системой",
                        EndDate = DateTime.Now.AddDays(1).Date,
                        Description = "Необходимо интегрировать API платежной системы для обработки онлайн-платежей.",
                        Email = "user1@example.com",
                        Application = context.Application.ToList()[0],
                        ApplicationId = context.Application.ToList()[0].Id
                    },
                    new WorkRequest
                    {
                        Name = "Обновление безопасности приложения",
                        EndDate = DateTime.Now.AddDays(2).Date,
                        Description = "Требуется обновить уровень безопасности приложения для защиты от потенциальных угроз.",
                        Email = "customer2@email.com",
                        Application = context.Application.ToList()[1],
                        ApplicationId = context.Application.ToList()[1].Id
                    },
                    new WorkRequest
                    {
                        Name = "Добавление функции чата в реальном времени",
                        EndDate = DateTime.Now.AddDays(3).Date,
                        Description = "Создание функционала чата в реальном времени для взаимодействия пользователей приложения.",
                        Email = "support3@example.com",
                        Application = context.Application.ToList()[2],
                        ApplicationId = context.Application.ToList()[2].Id
                    },
                    new WorkRequest
                    {
                        Name = "Оптимизация базы данных для большего объема данных",
                        EndDate = DateTime.Now.AddDays(4).Date,
                        Description = "Оптимизация базы данных для эффективной работы с большим объемом данных и быстрого доступа к информации.",
                        Email = "developer4@mail.com",
                        Application = context.Application.ToList()[3],
                        ApplicationId = context.Application.ToList()[3].Id
                    },
                    new WorkRequest
                    {
                        Name = "Создание мобильной версии приложения",
                        EndDate = DateTime.Now.AddDays(5).Date,
                        Description = "Разработка мобильной версии приложения для расширения его охвата и увеличения удобства использования.",
                        Email = "tester5@example.com",
                        Application = context.Application.ToList()[4],
                        ApplicationId = context.Application.ToList()[4].Id
                    },
                    new WorkRequest
                    {
                        Name = "Разработка модуля администрирования",
                        EndDate = DateTime.Now.AddDays(6).Date,
                        Description = "Создание модуля администрирования для управления содержимым приложения.",
                        Email = "user6@mail.com",
                        Application = context.Application.ToList()[5],
                        ApplicationId = context.Application.ToList()[5].Id
                    },
                    new WorkRequest
                    {
                        Name = "Улучшение процесса регистрации пользователей",
                        EndDate = DateTime.Now.AddDays(7).Date,
                        Description = "Улучшение процесса регистрации пользователей с целью снижения порога входа и повышения удобства.",
                        Email = "admin7@example.com",
                        Application = context.Application.ToList()[6],
                        ApplicationId = context.Application.ToList()[6].Id
                    },
                    new WorkRequest
                    {
                        Name = "Интеграция с социальными сетями",
                        EndDate = DateTime.Now.AddDays(8).Date,
                        Description = "Интеграция с социальными сетями для увеличения вовлеченности пользователей.",
                        Email = "info8@email.com",
                        Application = context.Application.ToList()[7],
                        ApplicationId = context.Application.ToList()[7].Id
                    },
                    new WorkRequest
                    {
                        Name = "Рефакторинг кода для улучшения производительности",
                        EndDate = DateTime.Now.AddDays(9).Date,
                        Description = "Рефакторинг кода для оптимизации производительности приложения и устранения возможных ошибок.",
                        Email = "manager9@example.com",
                        Application = context.Application.ToList()[8],
                        ApplicationId = context.Application.ToList()[8].Id
                    },
                    new WorkRequest
                    {
                        Name = "Добавление поддержки мультиязычности",
                        EndDate = DateTime.Now.AddDays(10).Date,
                        Description = "Добавление поддержки мультиязычности для привлечения более широкой аудитории.",
                        Email = "contact10@mail.com",
                        Application = context.Application.ToList()[9],
                        ApplicationId = context.Application.ToList()[9].Id
                    });

                context.SaveChanges();
            }
        }
    }
}
