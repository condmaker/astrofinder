namespace Astrofinder
{
    /// <summary>
    /// An interface to apply to every celestial body to be searched.
    /// </summary>
    public interface ICelestialBody
    {
        /// <summary>
        /// The name of the celestial body.
        /// </summary>
        /// <value>The value of said name.</value>
        string Name { get; }
        /// <summary>
        /// The mass of the celestial body.
        /// </summary>
        /// <value>The value of the mass.</value>
        float? Mass { get; }

        /// <summary>
        /// A method to show detailed information about the body.
        /// </summary>
        /// <returns>A string with said information.</returns>
        string ToStringDetailed();
    }
}