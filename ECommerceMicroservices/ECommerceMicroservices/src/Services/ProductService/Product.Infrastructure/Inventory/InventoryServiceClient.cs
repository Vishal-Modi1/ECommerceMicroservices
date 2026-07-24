using System.Net.Http.Json;
using Microsoft.Extensions.Options;
using Product.Application.Common.Interfaces;
using Product.Infrastructure.Services.Inventory.Requests;

namespace Product.Infrastructure.Services.Inventory;

public class InventoryServiceClient : IInventoryService
{
    private readonly HttpClient _httpClient;

    public InventoryServiceClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task CreateInventoryAsync(Guid productId, int availableQuantity, CancellationToken cancellationToken = default)
    {
        var request = new CreateInventoryRequest
        {
            ProductId = productId,
            AvailableQuantity = availableQuantity
        };

        var response = await _httpClient.PostAsJsonAsync(
            "api/inventory",
            request,
            cancellationToken);

        response.EnsureSuccessStatusCode();
    }
}