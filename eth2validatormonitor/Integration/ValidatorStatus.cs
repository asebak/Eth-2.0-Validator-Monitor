using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eth2validatormonitor.Integration
{
    public enum ValidatorStatus
    {
        Deposited,
        Pending,
        ActiveOnline,
        ActiveOffline,
        ExitingOnline,
        ExitingOffline,
        SlashingOnline,
        SlashingOffline,
        Exited,
        Slashed,
        Unknown
    }
}
