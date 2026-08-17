using API.DTOs;
using Core.Entites;
using System.Net;

namespace API.Extensions;

public static class AddressMappingExtensions
{
    public static AddressDto ToDto(this Address address)
    {
        if (address == null) throw new ArgumentNullException(nameof(address));
        return new AddressDto
        {
            Line1 = address.Line1,
            Line2 = address.Line2,
            City = address.City,
            State = address.State,
            Country = address.Country,
            PostalCode = address.PostalCode,
        };
    }

    public static Address ToEntity(this AddressDto addressDto)
    {
        if (addressDto == null) throw new ArgumentNullException(nameof(addressDto));
        return new Address
        {
            Line1 = addressDto.Line1,
            Line2 = addressDto.Line2,
            City = addressDto.City,
            State = addressDto.State,
            Country = addressDto.Country,
            PostalCode = addressDto.PostalCode,
        };
    }
    public static void UpdateFromDto(this Address address , AddressDto addressDto)
    {
        if (address == null) throw new ArgumentNullException(nameof(address));
        if (addressDto == null) throw new ArgumentNullException(nameof(addressDto));

        address.Line1 = addressDto.Line1;
        address.Line2 = addressDto.Line2;
        address.City = addressDto.City;
        address.State = addressDto.State;
        address.Country = addressDto.Country;
        address.PostalCode = addressDto.PostalCode;

    }
}
