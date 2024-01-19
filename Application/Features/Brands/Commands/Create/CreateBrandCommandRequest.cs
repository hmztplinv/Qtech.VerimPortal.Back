using MediatR;

public class CreateBrandCommandRequest: IRequest<CreatedBrandCommandResponse>
{
    public string Name { get; set; }
}