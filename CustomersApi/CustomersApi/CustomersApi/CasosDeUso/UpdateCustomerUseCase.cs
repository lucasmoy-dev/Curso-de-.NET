using CustomersApi.Repositories;

namespace CustomersApi.CasosDeUso
{
    public interface IUpdateCustomerUseCase
    {
        Task<Dtos.CustomerDto?> Execute(Dtos.CustomerDto customer);
    }

    public class UpdateCustomerUseCase : IUpdateCustomerUseCase
    {

        private readonly CustomerDatabaseContext _customerDatabaseContext;

        public UpdateCustomerUseCase(CustomerDatabaseContext customerDatabaseContext)
        {
            _customerDatabaseContext = customerDatabaseContext;
        }


        public async Task<Dtos.CustomerDto?> Execute(Dtos.CustomerDto customer)
        {
            var entity = await _customerDatabaseContext.Get(customer.Id);

            if (entity == null)
                return null;

            entity.FirstName = customer.FirstName;
            entity.LastName = customer.LastName;   
            entity.Email = customer.Email; 
            entity.Phone = customer.Phone;
            entity.Address = customer.Address;

            await _customerDatabaseContext.Actualizar(entity);
            return entity.ToDto();

        }

    }
}
