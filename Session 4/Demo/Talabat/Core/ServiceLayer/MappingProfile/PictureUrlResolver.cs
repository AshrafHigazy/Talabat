using AutoMapper;
using DomanLayer.Models;
using Microsoft.Extensions.Configuration;
using Shared.DTOs.ProducrDTOs;

namespace ServiceLayer.MappingProfiles
{
    internal class PictureUrlResolver(IConfiguration _configuration) : IValueResolver<Product, ProductDTO, string>
    {
        public string Resolve(Product source, ProductDTO destination, string destMember, ResolutionContext context)
        {
            if (string.IsNullOrWhiteSpace(source.PictureUrl))
                return string.Empty;
            else
            {
                var url =

                    $"{_configuration.GetSection("Urls")["baseUrl"]}{source.PictureUrl}";
                return url;
            }
        }
    }
}
