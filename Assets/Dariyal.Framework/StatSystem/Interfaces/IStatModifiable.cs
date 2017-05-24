namespace Dariyal.Framework.StatSystem
{
    public interface IModifiableStat
    {
        float StatModifierValue { get; }

        void AddModifier(StatModifier modifier);
        void RemoveModifier(StatModifier modifier);
        void ClearModifiers();
        void UpdateModifiers();
    }
}