namespace Astrofinder
{
    public interface ICelestialBody
    {
        string Name { get; }
        float? Mass { get; }

        string ToStringDetailed();
    }
}