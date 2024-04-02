using Flyers.Core.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flyers.Core.Entities
{
    /// <summary>
    /// Implementacao base da interface IEntity
    /// </summary>
    public abstract class BaseEntity : IEntity
    {
        //Propriedades
        //Chave pk
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }

        public Guid IdHash { get; set; }

        public bool Inativo { get; set; }

        [Display(Name = "Data de inclusão")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime Inclusao { get; set; }

        //Metodos
        public BaseEntity()
        {
            IdHash = Guid.NewGuid();
            Inativo = false;
            Inclusao = DateTime.Now;
        }

        public override bool Equals(object obj)
        {
            var compare = obj as BaseEntity;
            if (ReferenceEquals(this, compare))
            {
                return true;
            }
            if (ReferenceEquals(null, compare))
            {
                return false;
            }
            return IdHash.Equals(compare.IdHash);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 999) + IdHash.GetHashCode();
        } 
    }
}
