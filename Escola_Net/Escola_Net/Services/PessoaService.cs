using Escola_Net.Interfaces;
using Escola_Net.ViewModel;
using Escola_Net_Domain.Interfaces;
using Escola_Net_Domain.Model;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escola_Net.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository pessoaRepository;
        private readonly ILogger logger;

        public PessoaService(IPessoaRepository pessoaRepository, ILogger logger)
        {
            this.pessoaRepository = pessoaRepository;
            this.logger = logger;  
        }

        public async Task<IEnumerable<PessoaViewModel>> Get()
        {
            try
            {
                var listPessoas = await this.pessoaRepository.GetListAsync();
                return (from p in listPessoas select new PessoaViewModel(p)).ToList();
            } 
            catch (Exception ex)
            {
                logger.LogError($"Error ao obter a lista de pessoas {ex.Message}");
                throw ex;
            }
        }

        public async Task<PessoaViewModel> Get(Int64 id)
        {
            try
            {
                return new PessoaViewModel(await this.pessoaRepository.GetObjectAsync(id));
            }
            catch (Exception ex)
            {
                logger.LogError($"Error ao obter a pessoa {ex.Message}");
                throw ex;
            }
        }

        public async Task Insert(PessoaViewModel viewModel)
        {
            try
            {
                await this.pessoaRepository.InsertAsync(new Pessoa(viewModel.Nome, viewModel.NomePai, viewModel.NomeMae, viewModel.CPF, viewModel.Identidade,
                                                                   viewModel.OrgaoExpeditor, viewModel.TituloEleitor, viewModel.Endereco, viewModel.CEP,
                                                                   viewModel.IdTipoPessoa));
            }
            catch (Exception ex)
            {
                logger.LogError($"Error ao inserir a pessoa {ex.Message}");
                throw ex;
            }
        }
    }
}
