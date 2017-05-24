using System;

namespace Dariyal.Framework.StatSystem
{
    public interface IStatCurrentValueChange
    {
        event EventHandler OnCurrentValueChange;
    }
}