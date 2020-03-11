using CompanyCob.Domain.Model;
using CompanyCob.Domain.Model.Interface.Repository;
using CompanyCob.Domain.Model.Interface.Service;
using CompanyCob.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanyCob.Service
{
    /// <summary>
    /// Classe responsável por conter regras e validações de negócio referentes à devedores.
    /// </summary>
    public class DevedorService : IDevedorService
    {
        private readonly IDevedorRepository _devedorRepository;

        public DevedorService(IDevedorRepository devedorRepository)
        {
            _devedorRepository = devedorRepository;
        }

        public async Task<ValidacaoResult> ValidarAsync(Devedor devedor)
        {
            bool valido = true;
            List<string> erros = new List<string>();

            if (!CpfUtils.ValidarCpf(devedor.Cpf))
            {
                valido = false;
                erros.Add($"O cpf {devedor.Cpf} é inválido");
            }

            if ((await _devedorRepository.GetByCpfAsync(devedor.Cpf)) != null)
            {
                valido = false;
                erros.Add($"Já existe um devedor cadastrado com o cpf {devedor.Cpf}");
            }

            /* demais validações necessárias podem ser feitas como as de cima */

            return new ValidacaoResult(valido, erros);
        }
    }
}
