using MediatR;

public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommandRequest, CreatedBrandCommandResponse>
{
    //Handle(CreateBrandCommandRequest request, CancellationToken cancellationToken) alıp CreatedBrandCommandResponse dönecek.
    public async Task<CreatedBrandCommandResponse>? Handle(CreateBrandCommandRequest request, CancellationToken cancellationToken)
    {
        CreatedBrandCommandResponse response = new CreatedBrandCommandResponse();
        response.Id = Guid.NewGuid();
        response.Name = request.Name;
        return null;
    }
}