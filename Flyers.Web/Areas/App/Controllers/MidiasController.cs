using Flyers.Core.Entities;
using Flyers.Core.Helpers;
using Flyers.Core.Interfaces.DataServices;
using Flyers.Core.Values;
using Flyers.Web.Models;
using Flyers.Web.Areas.App.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace Flyers.Web.Areas.App.Controllers
{
    public class MidiasController : BaseController
    {
        public MidiasController(
            ILogger<BaseController> logger,
            IHttpContextAccessor httpContextAccessor,
            IDominioDataService dominioDataService,
            IArquivoDataService arquivoDataService) 
            : base(logger, httpContextAccessor, dominioDataService, arquivoDataService)
        {
        }       

        [HttpGet]
        public async Task<IActionResult> BannerAsync(int id, PastaValue pasta)
        {
            try
            {
                var imagem = new ImagemViewModel();
                imagem.Entidade = id;      
                imagem.Pasta = pasta.GetHashCode();
                var arquivo = await _arquivoDataService.ObtemImagemAsync(id, pasta);                
                if (arquivo == null)
                {
                    imagem.Url = "/img/image.svg";
                }
                else
                {
                    imagem.Url = arquivo.Url;
                }
                return PartialView("_Banner", imagem);
            }
            catch (Exception erro)
            {
                Debug.WriteLine($"Error: {erro}");
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> PosterAsync(int id, PastaValue pasta)
        {
            try
            {
                var imagem = new ImagemViewModel();
                imagem.Entidade = id;
                imagem.Pasta = pasta.GetHashCode();
                var arquivo = await _arquivoDataService.ObtemImagemAsync(id, pasta);
                if (arquivo == null)
                {
                    imagem.Url = "/img/image.svg";
                }
                else
                {
                    imagem.Url = arquivo.Url;
                }
                return PartialView("_Poster", imagem);
            }
            catch (Exception erro)
            {
                Debug.WriteLine($"Error: {erro}");
                return BadRequest();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> _EditaImagemAsync(ImagemViewModel imagem)
        {
            try
            {
                if (ModelState.IsValid && imagem.Arquivo.Length > 0)
                {
                    if (imagem.Entidade == 0)
                    {
                        return BadRequest();
                    }
                    var arquivo = new ArquivoEntity();
                    switch (Enum.GetName(typeof(PastaValue), imagem.Pasta))
                    {
                        case "Categoria":
                            arquivo = await _arquivoDataService.ObtemImagemAsync(
                                imagem.Entidade,
                                PastaValue.Categoria);
                            break;
                        case "Produto":
                            arquivo = await _arquivoDataService.ObtemImagemAsync(
                                imagem.Entidade,
                                PastaValue.Produto);
                            break;
                        case "Oferta":
                            arquivo = await _arquivoDataService.ObtemImagemAsync(
                                imagem.Entidade,
                                PastaValue.Oferta);
                            break;
                        case "Usuario":
                            arquivo = await _arquivoDataService.ObtemImagemAsync(
                                imagem.Entidade,
                                PastaValue.Usuario);
                            break;
                        default:
                            arquivo = await _arquivoDataService.ObtemImagemAsync(
                                imagem.Entidade,
                                PastaValue.Dominio);
                            break;
                    }
                    var nome = Path.GetRandomFileName();
                    var tipo = Path.GetExtension(imagem.Arquivo.FileName);
                    if (arquivo == null)
                    {
                        arquivo = new ArquivoEntity();
                        arquivo.Pasta = (PastaValue)imagem.Pasta;
                    }
                    arquivo.Entidade = imagem.Entidade;
                    arquivo.Nome = $"{nome}{tipo}";
                    arquivo.Tipo = imagem.Arquivo.ContentType;
                    arquivo.Url = $"/midia/imagem?nome={arquivo.Nome}";

                    //revisar quando implementado o dominio padrao
                    arquivo.IdDominio = PastaValue.Dominio.GetHashCode();

                    if (string.IsNullOrEmpty(imagem.Dados))
                    {
                        var memoria = new MemoryStream();
                        imagem.Arquivo.CopyTo(memoria);
                        arquivo.Dados = memoria.ToArray();
                        memoria.Close();
                        memoria.Dispose();
                    }
                    else
                    {
                        arquivo.Dados = ImagemHelper.ImagemByteArray(imagem.Dados);
                    }
                    ModelState.Clear();
                    return Ok(new AppResposta()
                    {
                        Retorno = (await _arquivoDataService.SalvaAsync(arquivo) > 0) ? true : false
                    });
                }
                return BadRequest();
            }
            catch (Exception erro)
            {
                Debug.WriteLine($"Error: {erro}");
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> ApagaAsync(int id)
        {
            try
            {
                if (id == 0)
                {
                    return NotFound();
                }
                var arquivo = await _arquivoDataService.ObtemPorIdAsync(id);
                if (arquivo == null)
                {
                    return NotFound();
                }
                return PartialView("_Apaga", arquivo);
            }
            catch (Exception erro)
            {
                Debug.WriteLine($"Error: {erro}");
                return BadRequest();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> _ApagaAsync(int id)
        {
            try
            {
                if (id == 0)
                {
                    return NotFound();
                }
                return Ok(new AppResposta()
                {
                    Retorno = await _arquivoDataService.ExcluiAsync(id),
                    Carrega = false
                });
            }
            catch (Exception erro)
            {
                Debug.WriteLine($"Error: {erro}");
                return BadRequest();
            }
        }
    }
}
