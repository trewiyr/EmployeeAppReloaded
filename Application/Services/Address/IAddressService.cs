using Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Address
{
    public interface IAddressService
    {
          Task<AddressDto> CreateAddressAsync(CreateAddressDto createAddressDto);
          Task<AddressDto> GetAddressByIdAsync(Guid id);
          Task<AddressDto> UpdateAddressAsync(UpdateAddressDto dto);
          Task<AddressDto> DeleteAddressAsync(Guid Id);
    }
}
