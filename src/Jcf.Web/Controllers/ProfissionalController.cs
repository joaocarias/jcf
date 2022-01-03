﻿using AutoMapper;
using Jcf.Dominio.Entidades;
using Jcf.Dominio.IRepositorio;
using Jcf.Web.Helpers;
using Jcf.Web.Models.Profissional;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Jcf.Web.Controllers
{
    [Authorize]
    public class ProfissionalController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IProfissionalRepositorio _profissionalRepositorio;
        private readonly IFuncaoRepositorio _funcaoRepositorio;
        private readonly IEnderecoRepositorio _enderecoRepositorio;

        public ProfissionalController(IMapper mapper, IProfissionalRepositorio profissionalRepositorio, IFuncaoRepositorio funcaoRepositorio, IEnderecoRepositorio enderecoRepositorio)
        {
            _mapper = mapper;
            _profissionalRepositorio = profissionalRepositorio;
            _funcaoRepositorio = funcaoRepositorio;
            _enderecoRepositorio = enderecoRepositorio;
        }

        public IActionResult Index()
        {
            var lista = _profissionalRepositorio.ObteTodos();

            var listaViewModel = _mapper.Map<List<ProfissionalViewModel>>(lista);

            return View(listaViewModel.OrderBy(x => x.Nome).ToList());
        }

        public IActionResult Details(Guid id)
        {
            var entidade = _profissionalRepositorio.Obter(id);
            var model = _mapper.Map<ProfissionalViewModel>(entidade);

            return View(model);
        }

        public IActionResult Create()
        {
            var model = new ProfissionalViewModel();

            CriarViewBags();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProfissionalViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.SetNovo(User.GetId());
                model.Endereco?.SetNovo(User.GetId());
                var entidade = _mapper.Map<Profissional>(model);

                var novoCadastro = await _profissionalRepositorio.AdicionarAsync(entidade);
                return RedirectToAction(nameof(Index));
            }

            CriarViewBags();

            return View(model);
        }

        public IActionResult Edit(Guid id)
        {
            var entidade = _profissionalRepositorio.Obter(id);
            var model = _mapper.Map<ProfissionalViewModel>(entidade);

            CriarViewBags();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProfissionalViewModel model)
        {
            if (ModelState.IsValid)
            {
                var entidade = _profissionalRepositorio.Obter(model.Id);
                if (entidade != null)
                {
                    if(entidade.EnderecoId != null && entidade.EnderecoId.HasValue)
                    {
                        var endereco = _enderecoRepositorio.Obter(entidade.EnderecoId.GetValueOrDefault());

                        if (endereco != null)
                        {
                            endereco.Logradouro = model.Endereco == null ? string.Empty : model.Endereco.Logradouro;
                            endereco.Numero = model.Endereco == null ? string.Empty : model.Endereco.Numero;
                            endereco.Complemento = model.Endereco == null ? string.Empty : model.Endereco.Complemento;
                            endereco.Cep = model.Endereco == null ? string.Empty : model.Endereco.Cep;
                            endereco.Bairro = model.Endereco == null ? string.Empty : model.Endereco.Bairro;
                            endereco.Cidade = model.Endereco == null ? string.Empty : model.Endereco.Cidade;
                            endereco.Uf = model.Endereco == null ? string.Empty : model.Endereco.Uf;
                            endereco.Obs = model.Endereco == null ? string.Empty : model.Endereco.Obs;
                        }

                        entidade.Endereco = endereco;
                    }
                    
                    entidade.Atualizar(model.Nome, model.DataNascimento, model.Email, model.Telefone, model.Cpf, model.FuncaoId, User.GetId());

                    await _profissionalRepositorio.AtualizarAsync(entidade);

                    return RedirectToAction(nameof(Details), entidade.Id);
                }
            }

            CriarViewBags();

            return View(model);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            if (ModelState.IsValid)
            {
                var entidade = _profissionalRepositorio.Obter(id);
                if (entidade != null)
                {
                    entidade.Excluir(User.GetId());

                    await _profissionalRepositorio.AtualizarAsync(entidade);
                }
            }

            return RedirectToAction(nameof(Index));
        }
                
        private void CriarViewBags()
        {
            CriarViewBagEstados();
            CriarViewBagFuncoes();
        }

        private void CriarViewBagEstados()
        {
            ViewBag.Estados = EstadosHelper.ObterTodos().Select(
                    c => new SelectListItem()
                        { Text = c.Descricao, Value = c.Sigla }).ToList();
        }

        private void CriarViewBagFuncoes()
        {
            ViewBag.Funcoes = _funcaoRepositorio.ObteTodos().OrderBy(f => f.Nome).Select(
                  f => new SelectListItem()
                  { Text = f.Nome, Value = f.Id.ToString() }
                ).ToList();
        }
    }
}
