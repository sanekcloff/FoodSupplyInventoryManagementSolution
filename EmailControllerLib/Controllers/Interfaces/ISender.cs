using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailingControllerLib.Controllers.Interfaces
{
    public interface ISender
    {
        Task Send();
    }
}
