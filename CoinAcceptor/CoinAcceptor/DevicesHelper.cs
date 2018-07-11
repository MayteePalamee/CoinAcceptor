using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinAcceptor
{
    public interface DevicesHelper
    {
        Status Connect(String command);
        Status Send(String command);
        Status Disconnect(String command);
        Status Enabled();
        Status Disabled();
    }
}
