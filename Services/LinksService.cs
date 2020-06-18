using Hateoas.Controllers;
using Hateoas.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hateoas
{
    public class LinksService
    {
        private readonly IUrlHelper _urlHelper;

        public LinksService(IUrlHelper urlHelper)
        {
            _urlHelper = urlHelper;
        }

        public void GerateResourceLinks(Resource resource, int id)
        {
            resource._links.Add(new LinkDTO(
                _urlHelper.Link(
                    nameof(ClientsController.GetClient),
                    new { id }),
                    rel: "self",
                    method: RestMehods.GET
                )
            );

            resource._links.Add(new LinkDTO(
                _urlHelper.Link(
                    nameof(ClientsController.PutClient),
                    new { id }),
                    rel: "update-client",
                    method: RestMehods.PUT
                )
            );

            resource._links.Add(new LinkDTO(
                _urlHelper.Link(
                    nameof(ClientsController.DeleteClient),
                    new { id }),
                    rel: "delete-client",
                    method: RestMehods.DELETE
                )
            );
        }

        public void GerateCollectionLinks(ResourceCollection<Client> resources)
        {
            resources._links.Add(new LinkDTO(
                _urlHelper.Link(
                    nameof(ClientsController.GetClients),
                    new { }),
                    rel: "self",
                    method: RestMehods.GET
                )
            );

            resources._links.Add(new LinkDTO(
                _urlHelper.Link(
                    nameof(ClientsController.PostClient),
                    new { }),
                    rel: "create-client",
                    method: RestMehods.POST
                )
            );
        }
    }
}