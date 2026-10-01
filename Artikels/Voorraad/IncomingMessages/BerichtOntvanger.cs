using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text.Json;
using Voorraad.Models;

namespace Voorraad.IncomingMessages
{
    public class BerichtOntvanger:BackgroundService
    {
        readonly IServiceProvider provider;
        readonly IChannel channel;
        public BerichtOntvanger(IServiceProvider provider, IChannel channel)
        {
            this.provider = provider;
            this.channel = channel;
            var consumer = new AsyncEventingBasicConsumer(channel);
            consumer.ReceivedAsync += VerwerkBericht!;
            channel.BasicConsumeAsync("voorraad", false, consumer);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken) => Task.CompletedTask;

        async Task VerwerkBericht(object sender, BasicDeliverEventArgs bericht)
        {
            using var scope = provider.CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<Context>();
            var artikelGemaakt = JsonSerializer.Deserialize<ArtikelGemaakt>(bericht.Body.Span)!;
            if (!context.Artikels.Any(artikel => artikel.Id == artikelGemaakt.Id))
            {
                var artikel = new Artikel { Id = artikelGemaakt.Id };
                await context.Artikels.AddAsync(artikel);
                await context.SaveChangesAsync();
            }
            await channel.BasicAckAsync(bericht.DeliveryTag, false);
        }
    }
}
