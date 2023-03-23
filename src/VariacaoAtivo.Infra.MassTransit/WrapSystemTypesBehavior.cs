// using MediatR;
//
// namespace VariacaoAtivo.Infra.MassTransit;
//
// public class WrapSystemTypesBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
// {
//     public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
//     {
//         var messageType = request.GetType();
//         if (messageType.IsPrimitive || messageType == typeof(string) || messageType == typeof(decimal))
//         {
//             var wrapperType = typeof(WrappedMessage<>).MakeGenericType(messageType);
//             var wrappedMessage = Activator.CreateInstance(wrapperType, request);
//             var wrappedResponse = await next((TRequest)wrappedMessage, cancellationToken);
//             if (wrappedResponse is WrappedMessage wrappedResponseMessage)
//             {
//                 return (TResponse)wrappedResponseMessage.Value;
//             }
//
//             return wrappedResponse;
//         }
//         else
//         {
//             return await next(request, cancellationToken);
//         }
//     }
// }