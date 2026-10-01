using ModelContextProtocol.Server;
using System.ComponentModel;

namespace MijnMCPServer
{
    [McpServerToolType]
    public class EventService
    {
        [McpServerTool, Description("events in onze winkel")]
        List<Event> Events() => new()
        {
            new Event("Bart Kaell signeert", DateTime.Now.AddDays(1)),
            new Event("Dana Winner akoestisch", DateTime.Now.AddDays(3)),
        };
    }
}
