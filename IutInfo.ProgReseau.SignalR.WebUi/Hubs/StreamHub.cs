using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace IutInfo.ProgReseau.SignalR.WebUi.Hubs
{
    public sealed class StreamHub : Hub
    {
        public ChannelReader<int> Counter(int countTo, int sleepTime)
        {
            var channel = Channel.CreateUnbounded<int>();

            _ = StreamAsync(channel.Writer, countTo, sleepTime);

            return channel.Reader;
        }

        private async Task StreamAsync(ChannelWriter<int> writer, int countTo, int sleepTime)
        {
            for (int i = 0; i < countTo; i++)
            {
                await writer.WriteAsync(i);
                await Task.Delay(sleepTime);
            }

            writer.TryComplete();
        }
    }
}