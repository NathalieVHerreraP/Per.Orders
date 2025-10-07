using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Per.Order.Application.Orders.Commands.CancelOrder;
using Per.Order.Domain.Shared;
using System.Diagnostics;

namespace Per.Order.Presentation.Modules;

public static class OrderModules
{
    private const string BASE_URL = "api/v1/orders/";
    public static void AddOrderModules(this IEndpointRouteBuilder app)
    {
        var orderGroup = app.MapGroup(BASE_URL);
        orderGroup.MapPut("cancel/{orderId}", CancelOrder);

    }
    private static async Task<IResult> CancelOrder(
       [FromQuery] int orderId,
       ISender sender
       )
    {
        CancelOrderCommand command = new(orderId);
        Result<CancelOrderCommandResponse> result = await sender.Send(command);
        if (!result.IsSuccess)
        {
            switch (result.StatusCode)
            {
                case 400:
                    return Results.BadRequest(result.Error);
                case 404:
                    return Results.NotFound(result.Error);
                case 409:
                    return Results.Conflict(result.Error);
                case 500:
                    return Results.Problem(result.Error?.ErrorMessage);
            }
        }

        return Results.Ok(result.Value);
    }
}
