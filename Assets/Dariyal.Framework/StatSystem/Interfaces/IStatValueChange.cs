using System;

namespace Dariyal.Framework.StatSystem
{
    public interface IStatValueChange
    {
        event EventHandler OnValueChange;
    }
}