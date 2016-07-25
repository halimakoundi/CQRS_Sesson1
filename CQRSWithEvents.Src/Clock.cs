using System;

namespace CQRSWithEvents.Src
{
    public interface Clock
    {
        string Now { get; set; }
    }
}