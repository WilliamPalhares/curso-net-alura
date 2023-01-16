using Escola_Net_Domain.Interfaces;
using Escola_Net_Domain.Model;
using Microsoft.Extensions.Logging;

namespace Escola_Net_Domain.Repositories
{
    public class PessoaRepository : BaseRepository<Pessoa>, IPessoaRepository
    {
        public PessoaRepository(ApplicationContext applicationContext
                              , ILogger logger) : base(applicationContext, logger)
        {
        }
    }
}
