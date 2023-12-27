using Microsoft.EntityFrameworkCore;
using TaskCFT.Models.Entities;

namespace TaskCFT.Data.SeedData
{
    public class ApplicationSeed
    {
        static public void Initialize(IServiceProvider serviceProvider)
        {
            using(var context = new AppDbContext(serviceProvider
                .GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                if (context.Application.Any())
                {
                    return;
                }

                // добавим 21 запись для приложений
                context.Application.AddRange(
                    new Application { Name = "QuickLinkPro" },
                    new Application { Name = "VisionaryHub" },
                    new Application { Name = "SnapTasker" },
                    new Application { Name = "InfoSphere" },
                    new Application { Name = "SmartSync" },
                    new Application { Name = "DataVista" },
                    new Application { Name = "SwiftEdge" },
                    new Application { Name = "CloudPulse" },
                    new Application { Name = "TechVibe" },
                    new Application { Name = "SkyFusion" },
                    new Application { Name = "PixelBoost" },
                    new Application { Name = "ZenithWorks" },
                    new Application { Name = "AppSavvy" },
                    new Application { Name = "AgileSphere" },
                    new Application { Name = "CodeNova" },
                    new Application { Name = "NovaSync" },
                    new Application { Name = "AlphaStream" },
                    new Application { Name = "CyberSync" },
                    new Application { Name = "FlexiConnect" },
                    new Application { Name = "QuantumFlow" },
                    new Application { Name = "MetaSync" }
                    );

                context.SaveChanges();
            }
        }
    }
}
