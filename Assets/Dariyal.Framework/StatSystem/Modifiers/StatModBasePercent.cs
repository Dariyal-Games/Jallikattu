namespace Dariyal.Framework.StatSystem
{
    public class StatModBasePercent : StatModifier
    {
        public override int Order
        {
            get { return 1; }
        }

        public override float ApplyModifier(float statValue, float modValue)
        {
            return statValue * modValue;
        }

        public StatModBasePercent(float value) : base(value) { }
        public StatModBasePercent(float value, bool stacks) : base(value, stacks) { }
    }
}