using Hanan_csharp_backend_teamwork.src.DTOs;
namespace Hanan_csharp_backend_teamwork.src.Abstractions;

public interface IAddressService
{
    public IEnumerable<AddressDTO> FindAll();
    public AddressDTO? FindOne(Guid id);
    public bool DeleteById(Guid id);
    public AddressDTO CreateOne(AddressCreateDTO newUserAddress, string userId);
}
