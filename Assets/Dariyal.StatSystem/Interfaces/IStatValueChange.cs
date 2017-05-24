using System;

namespace Dariyal.StatSystem
{
    public interface IStatValueChange
    {
        event EventHandler OnValueChange;
    }
}