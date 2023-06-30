using FluentValidation;
using FluentValidation.Results;
using Reservation.Domain.Models;
using Reservation.Domain.Types;
using Reservation.Infrastructure.Abstracts;
using ShareLib.Abstracts;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Reservation.Application.Features.Assets
{
    public record CreateAssetCommand(string Name, int AllItemCount) : ICommand<Asset>;

    public class CreateAssetCommandHandler : ICommandHandler<CreateAssetCommand, Asset>
    {
        private readonly IDataContext _db;

        public CreateAssetCommandHandler(IDataContext db)
        {
            _db = db;
        }

        public async Task<Asset> Handle(CreateAssetCommand request, CancellationToken cancellationToken)
        {
            Asset newAsset = new Asset(
                    AssetId.Create(),
                    request.Name,
                    request.AllItemCount,
                    request.AllItemCount
                );

            _db.Assets.Add(newAsset);

           // throw new Exception("เกิดข้อผิลพลาด (ทดสอบ)");

            await _db.SaveChangeAsync(cancellationToken);

            return newAsset;
        }
    }

    public class CreateAssetValidation : AbstractValidator<CreateAssetCommand>
    {
        public CreateAssetValidation(IDataContext db)
        {
            RuleFor(x => x.Name)
              .NotEmpty()
              .MaximumLength(255);

            RuleFor(x => x.Name)
                .Must((name) =>
                {
                    return !db.Assets
                        .Any(x => x.Name == name);
                })
                .WithMessage("Asset ห้ามมีชื่อที่ซ้ำกัน");
        }
    }
}
