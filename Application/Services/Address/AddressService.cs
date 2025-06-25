using Application.ContractMapping;
using Application.Dtos;
using Application.Services.Employee;
using Data.Context;
using Microsoft.EntityFrameworkCore;


namespace Application.Services.Address
{
    public class AddressService : IAddressService

    {     private readonly EmployeeAppDbContext _context;

            public AddressService(EmployeeAppDbContext context)
            {
                _context = context;
            }

            public async Task<AddressDto> GetAddressByIdAsync(Guid id)
            {
                var address = await _context.Addresses.Include(e => e.Employee)
                     .FirstOrDefaultAsync(e => e.Id == id);
                return address!.ToDto();
            }

            public async Task<AddressDto> CreateAddressAsync(CreateAddressDto createAddressDto)
            {
                var data = new CreateAddressDto
                {
                    Id = Guid.NewGuid(),
                    StreetNo = createAddressDto.StreetNo,
                    //State = createAddressDto.State,
                    StreetName = createAddressDto.StreetName,
                    City = createAddressDto.City
                    

                };
                var address = data.ToModel();

                await _context.Addresses.AddAsync(address);
                await _context.SaveChangesAsync();

                return address.ToDto();

            }

            public async Task<AddressDto> UpdateAddressAsync(UpdateAddressDto dto)
            {
                var address = _context.Addresses.FirstOrDefault(d => d.Id == dto.Id);


                    address.StreetNo = dto.StreetNo;
                    //address.State = dto.State;
                    address.StreetName = dto.StreetName;
                    address.City = dto.City;


                try
                {
                    _context.Addresses.Update(address);
                    await _context.SaveChangesAsync();

                    return address.ToDto();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred while creating the address.", ex);
                    return new AddressDto();
                }

            }
            public async Task<AddressDto> DeleteAddressAsync(Guid Id)
            {
                var address = await _context.Addresses.FirstOrDefaultAsync(d => d.Id == Id);
                _context.Addresses.Remove(address!);
                await _context.SaveChangesAsync();
                return address?.ToDto()!;
            }


        }
    }

