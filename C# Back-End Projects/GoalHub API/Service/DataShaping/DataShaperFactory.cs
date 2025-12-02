using Contracts.DataShaping;
using Microsoft.Extensions.DependencyInjection;

namespace Service.DataShaping
{
    public class DataShaperFactory : IDataShaperFactory
    {
        private readonly IServiceProvider _Provider;

        public DataShaperFactory(IServiceProvider provider)
        {
            _Provider = provider;
        }

        public IDataShaper<T> Create<T>() where T : class
        {
            return _Provider.GetRequiredService<IDataShaper<T>>();
        }
    }

}
