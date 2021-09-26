using System;
using System.Collections.Generic;
using System.Text;

namespace NumberToWordService
{
    public interface INumberToWordConverter
    {
        string GenerateLiteralForAmount(decimal amount);
    }
}
