namespace Dariyal.Framework.StatSystem
{
    public class StatModBaseAdd : StatModifier
    {
        public override int Order { get { return 2; } }

        public override float ApplyModifier(float statValue, float modValue)
        {
            return modValue;
        }

        public StatModBaseAdd(float value) : base(value) { }
        public StatModBaseAdd(float value, bool stacks) : base(value, stacks) { }
    }
}