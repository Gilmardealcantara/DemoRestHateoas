using System.Linq;
using Hateoas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Hateoas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly ILogger<ClientsController> _logger;
        private readonly LinksService _linksService;

        public ClientsController(ILogger<ClientsController> logger, LinksService linksService)
        {
            _logger = logger;
            _linksService = linksService;
        }


        // GET: api/Clients
        [HttpGet(Name = nameof(GetClients))]
        public IActionResult GetClients()
        {
            var clients = (new object[10]).Select((x, i) => new Client
            {
                Id = i + 1,
                Name = $"Gilmar{i}",
                Email = $"gilmar_{i}@mail.com"
            }).ToList();

            clients.ForEach(c => _linksService.GerateResourceLinks(c, c.Id));

            var resources = new ResourceCollection<Client>(clients);
            _linksService.GerateCollectionLinks(resources);
            return Ok(resources);
        }

        [HttpGet("{id}", Name = nameof(GetClient))]
        public IActionResult GetClient(int id)
        {
            var client = new Client
            {
                Id = id,
                Name = "*******",
                Email = "gilmar*****@mail.com"
            };
            _linksService.GerateResourceLinks(client, client.Id);
            return Ok(client);
        }

        [HttpPost(Name = nameof(PostClient))]
        public IActionResult PostClient(Client model) => Ok(model);

        [HttpPut("{id}", Name = nameof(PutClient))]
        public IActionResult PutClient(Client model) => Ok(model);

        [HttpDelete("{id}", Name = nameof(DeleteClient))]
        public IActionResult DeleteClient(Client model) => Ok(model);

    }
}
