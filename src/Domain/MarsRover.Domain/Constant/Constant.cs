using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MarsRover.Domain.Constant
{
    public static class Constant
    {
        public static readonly IList<char> AcceptableCommandCharacters = new ReadOnlyCollection<char>(new List<char> {'L','R','M'});
    }
}
