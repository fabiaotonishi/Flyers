using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyers.Api.Application
{
    public abstract class BaseEvent : Mensagem, INotification
    {
    }
}
