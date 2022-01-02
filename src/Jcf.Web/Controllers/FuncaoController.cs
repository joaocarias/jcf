using Jcf.Web.Models.Funcao;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Jcf.Web.Helpers;
using AutoMapper;
using Jcf.Dominio.Entidades;
using Jcf.Dominio.IRepositorio;

namespace Jcf.Web.Controllers
{
    [Authorize]
    public class FuncaoController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IFuncaoRepositorio _funcaoRepositorio;

        public FuncaoController(IMapper mapper, IFuncaoRepositorio funcaoRepositorio)
        {
            _mapper = mapper;
            _funcaoRepositorio = funcaoRepositorio;
        }
        public IActionResult Index()
        {
            var lista = _funcaoRepositorio.ObteTodos();

            var listaViewModel = _mapper.Map<List<FuncaoViewModel>>(lista);

            return View(listaViewModel.OrderBy(x => x.Nome).ToList());
        }

        public IActionResult Novo()
        {
            var model = new FuncaoViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Novo(FuncaoViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.SetNovo(User.GetId());
                var entidade = _mapper.Map<Funcao>(model);

                var novoCadastro = await _funcaoRepositorio.AdicionarAsync(entidade);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public IActionResult Detalhar(Guid id)
        {
            var entidade = _funcaoRepositorio.Obter(id);
            var model = _mapper.Map<FuncaoViewModel>(entidade);

            return View(model);
        }

        public IActionResult Editar(Guid id)
        {
            var entidade = _funcaoRepositorio.Obter(id);
            var model = _mapper.Map<FuncaoViewModel>(entidade);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(FuncaoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var entidade = _funcaoRepositorio.Obter(model.Id);
                if(entidade != null)
                {
                    entidade.Atualizar(model.Nome, User.GetId());

                    await _funcaoRepositorio.AtualizarAsync(entidade);

                    return RedirectToAction(nameof(Detalhar), entidade.Id);
                }                
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Excluir(Guid id)
        {
            if (ModelState.IsValid)
            {
                var entidade = _funcaoRepositorio.Obter(id);
                if (entidade != null)
                {
                    entidade.Excluir(User.GetId());

                    await _funcaoRepositorio.AtualizarAsync(entidade);

                }
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
