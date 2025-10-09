using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Per.Order.Application.Orders.Commands.CancelOrder;

namespace Per.Order.Presentation.Modules;

public static class OrderModules
{

    private const string BASE_URL = "api/v1/orders/";
    public static void AddOrderModules(this IEndpointRouteBuilder app)
    {
        var orderGroup = app.MapGroup(BASE_URL);

        orderGroup.MapPut("CancelOrder/{id}", CancelOrder);

    }

    private static async Task<IResult> CancelOrder(
        [FromQuery] int orderId, 
        CancellationToken cancellationToken, 
        ISender sender)
    {
        CancelOrderCommand command = new(orderId);
        var result = await sender.Send(command, cancellationToken);

        if(!result.IsSuccess)
        {
            switch (result.StatusCode)
            {
                case 400:
                    return Results.BadRequest(result.Error);
                case 404:
                    return Results.NotFound(result.Error);
                case 409:
                    return Results.Conflict(result.Error);
                case 499:
                    return Results.StatusCode(499);
                case 500:
                    return Results.Problem(result.Error?.ErrorMessage);
            }
        }

        return Results.Ok(result.Value);
    }
}