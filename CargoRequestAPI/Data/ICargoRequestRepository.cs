using CargoRequestAPI.Models;

namespace CargoRequestAPI.Data;

public interface ICargoRequestRepository
{
    public Task<IEnumerable<CargoRequest>> GetCargoRequests();

    public Task<CargoRequest> GetById(int id);

    public Task Create(CargoRequest cargoRequest);

    public Task Update(CargoRequest cargoRequest);

    public Task Delete(int id);

    public Task<IEnumerable<CargoRequest>> SearchAll(string searchString);
}