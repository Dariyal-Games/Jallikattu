using System;

namespace Dariyal.StatSystem
{
    public interface IStatCurrentValueChange
    {
        event EventHandler OnCurrentValueChange;
    }
}