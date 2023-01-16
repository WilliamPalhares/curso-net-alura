using Escola_Net_Domain.Interfaces;
using Escola_Net_Domain.Model;
using Microsoft.Extensions.Logging;

namespace Escola_Net_Domain.Repositories
{
    public class TipoPessoaRepository : BaseRepository<TipoPessoa>, ITipoPessoaRepository
    {
        public TipoPessoaRepository(ApplicationContext applicationContext
                                  , ILogger logger) : base(applicationContext, logger)
        {
        }
    }
}
