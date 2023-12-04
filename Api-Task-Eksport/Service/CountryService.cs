using Api_Task_Eksport.Data;
using Api_Task_Eksport.Dto;
using Api_Task_Eksport.Entity;
using Microsoft.EntityFrameworkCore;

namespace Api_Task_Eksport.Service;

public class CountryService {
    // private readonly DbSet<Country> repositoryNegara;
    private readonly DbSet<Country> repositoryCountry;
    public CountryService(ContextData contextData) {
        repositoryCountry = contextData.Countries;
    }

    public List<CountryResponse> getall() {
        var dataResponse = repositoryCountry
            .Select(coutry => new CountryResponse
            {
                id = coutry.id,
                kd_country = coutry.kd_country,
                name = coutry.name
            })
            .ToList();
        
        return dataResponse;
    }

    public CountryResponse getByName(string nama)
    {
        var data = repositoryCountry.FirstOrDefault(response => response.name.ToLower().Contains(nama.ToLower()));

        return new CountryResponse
        {
            id = data.id,
            kd_country = data.kd_country,
            name = data.name
        };
    }
}