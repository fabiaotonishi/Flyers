using System.ComponentModel.DataAnnotations;

namespace Flyers.Core.Values
{
    public enum CanalValue
    {
        [Display(Name = "Interno")]
        Interno = 1,
        [Display(Name = "Facebook")]
        Facebook,
        [Display(Name = "Instagram")]
        Instagram,
        [Display(Name = "YouTube")]
        Youtube,
        [Display(Name = "Twitter")]
        Twitter
    }

    public enum GeneroValue
    {
        [Display(Name = "Feminino")]
        Feminino,
        [Display(Name = "Masculino")]
        Masculino
    }

    public enum PastaValue
    {
        Dominio = 1,
        Categoria,
        Produto,
        Oferta,
        Usuario
    }

    public enum PerfilValue
    {
        Administrador = 1,
        Vendedor,
        Consumidor
    }

    public enum PessoaValue
    {
        Fisica,
        Juridica
    }
}