using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
using System.Text;

namespace Catalogus.Models
{
    public class BerichtStuurder(IChannel channel, IServiceProvider provider):BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = provider.CreateScope();
                using var context = scope.ServiceProvider.GetRequiredService<Context>();
                var berichten = await context.TeVersturenBerichten.ToListAsync(stoppingToken);
                foreach (var bericht in berichten)
                {
                    await channel.BasicPublishAsync(bericht.Exchange, string.Empty,
                    Encoding.UTF8.GetBytes(bericht.Bericht));
                }
                context.TeVersturenBerichten.RemoveRange(berichten);
                await context.SaveChangesAsync(stoppingToken);
                await Task.Delay(3_000, stoppingToken);
            }
        }
    }
}
