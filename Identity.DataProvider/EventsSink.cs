using IdentityServer4.Events;
using IdentityServer4.Services;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Identity.DataProvider
{
    public class EventsSink: IEventSink
    {
        private readonly ILogger<EventsSink> _logger;

        public EventsSink(ILogger<EventsSink> logger)
        {
            _logger = logger;
        }

        public Task PersistAsync(Event evt)
        {
            if (evt.EventType == EventTypes.Success ||
                evt.EventType == EventTypes.Information)
            {
                _logger.LogDebug("{Name} ({Id}), Details: {@details}",
                    evt.Name,
                    evt.Id,
                    evt);
            }
            else
            {
                _logger.LogError("{Name} ({Id}), Details: {@details}",
                    evt.Name,
                    evt.Id,
                    evt);
            }

            return Task.CompletedTask;
        }
    }
}
