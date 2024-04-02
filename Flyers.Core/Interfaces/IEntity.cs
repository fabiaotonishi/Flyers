using System;

namespace Flyers.Core.Interfaces
{
    public interface IEntity
    {
        int Id { get; set; }
        Guid IdHash { get; set; }
        bool Inativo { get; set; }
        DateTime Inclusao { get; set; }
    }
}
