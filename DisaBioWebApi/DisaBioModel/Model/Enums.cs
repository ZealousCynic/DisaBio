using System;
using System.Collections.Generic;
using System.Text;

namespace DisaBioModel.Model
{
    public enum SeatStatus
    {
        INVALID = 0,
        RESERVED,
        FREE
    }

    public enum SeatType
    {
        INVALID = 0,
        NORMAL,
        VIP,
        HANDICAP,
        COUCH

    }
}
