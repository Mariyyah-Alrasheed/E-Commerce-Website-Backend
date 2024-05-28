using AutoMapper;
using Hanan_csharp_backend_teamwork.src.Abstractions;
using Hanan_csharp_backend_teamwork.src.DTOs;
using Hanan_csharp_backend_teamwork.src.Entities;
namespace Hanan_csharp_backend_teamwork.src.Services;
public class AddressService : IAddressService
{
    private IAddressRepoistory _addressRepoistory;
    private IMapper _mapper;
    public AddressService(IAddressRepoistory addressRepoistory, IMapper mapper)
    {
        _addressRepoistory = addressRepoistory;
        _mapper = mapper;
    }

    public AddressDTO CreateOne(AddressCreateDTO newUserAddress, string userId)
    {
        var userAddress = _mapper.Map<Address>(newUserAddress);
        userAddress.UserId = new Guid(userId);

        var createdAdress = _addressRepoistory.CreateOne(userAddress);

        return _mapper.Map<AddressDTO>(createdAdress);
    }
    public bool DeleteById(Guid id)
    {
        return _addressRepoistory.DeleteById(id);
    }
    public IEnumerable<AddressDTO> FindAll()
    {
        var allAddress = _addressRepoistory.FindAll();
        return _mapper.Map<IEnumerable<AddressDTO>>(allAddress);
    }
    public AddressDTO? FindOne(Guid id)
    {
        var oneAddress = _addressRepoistory.FindOne(id);
        return _mapper.Map<AddressDTO>(oneAddress);

    }
}

