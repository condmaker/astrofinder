using System;
using System.Text;
using System.Collections.Generic;

namespace Astrofinder
{
    /// <summary>
    /// Class responsible for storing data from a Star.
    /// </summary>
    public class Star : IEquatable<Star>, ICelestialBody
    {
        /// <summary>
        /// Compares two specified Star objetcts and returns an integer
        /// that indicates their relative position in the sort order,
        /// based by their Names.
        /// </summary>
        /// <param name="s1">The first Star to compare.</param>
        /// <param name="s2">The second Star to compare.</param>
        /// <returns>A signed integer that indicates the relative values of x 
        /// and y. Less than 0 if <paramref name="s1"> is less than
        /// <paramref name="s2">, 0 if <paramref name="s1"> equals 
        /// <paramref name="s2">, and greater than 0 if <paramref name="s1">
        /// is greater than <paramref name="s2">.</returns>
        public static Comparison<Star> CompareByName = 
            delegate (Star s1, Star s2)
        {
            return String.Compare(s1.Name, s2.Name);
        };

        /// <summary>
        /// Compares two specified Star objetcts and returns an integer
        /// that indicates their relative position in the sort order,
        /// based by their Temperature.
        /// </summary>
        /// <param name="s1">The first Star to compare.</param>
        /// <param name="s2">The second Star to compare.</param>
        /// <returns>A signed integer that indicates the relative values of x 
        /// and y. Less than 0 if <paramref name="s1"> is less than
        /// <paramref name="s2">, 0 if <paramref name="s1"> equals 
        /// <paramref name="s2">, and greater than 0 if <paramref name="s1">
        /// is greater than <paramref name="s2">.</returns>
        public static Comparison<Star> CompareByTemperature = 
            delegate (Star s1, Star s2)
        {
            return s1?.Temperature?.CompareTo(s2.Temperature) ?? -1;
        };

        /// <summary>
        /// Compares two specified Star objetcts and returns an integer
        /// that indicates their relative position in the sort order,
        /// based by their Radius.
        /// </summary>
        /// <param name="s1">The first Star to compare.</param>
        /// <param name="s2">The second Star to compare.</param>
        /// <returns>A signed integer that indicates the relative values of x 
        /// and y. Less than 0 if <paramref name="s1"> is less than
        /// <paramref name="s2">, 0 if <paramref name="s1"> equals 
        /// <paramref name="s2">, and greater than 0 if <paramref name="s1">
        /// is greater than <paramref name="s2">.</returns>
        public static Comparison<Star> CompareByRadius = 
            delegate (Star s1, Star s2)
        {
            return s1?.Radius?.CompareTo(s2.Radius) ?? -1;
        };

        /// <summary>
        /// Compares two specified Star objetcts and returns an integer
        /// that indicates their relative position in the sort order,
        /// based by their Mass.
        /// </summary>
        /// <param name="s1">The first Star to compare.</param>
        /// <param name="s2">The second Star to compare.</param>
        /// <returns>A signed integer that indicates the relative values of x 
        /// and y. Less than 0 if <paramref name="s1"> is less than
        /// <paramref name="s2">, 0 if <paramref name="s1"> equals 
        /// <paramref name="s2">, and greater than 0 if <paramref name="s1">
        /// is greater than <paramref name="s2">.</returns>
        public static Comparison<Star> CompareByMass = 
            delegate (Star s1, Star s2)
        {
            return s1?.Mass?.CompareTo(s2.Mass) ?? -1;
        };

        /// <summary>
        /// Compares two specified Star objetcts and returns an integer
        /// that indicates their relative position in the sort order,
        /// based by their Age.
        /// </summary>
        /// <param name="s1">The first Star to compare.</param>
        /// <param name="s2">The second Star to compare.</param>
        /// <returns>A signed integer that indicates the relative values of x 
        /// and y. Less than 0 if <paramref name="s1"> is less than
        /// <paramref name="s2">, 0 if <paramref name="s1"> equals 
        /// <paramref name="s2">, and greater than 0 if <paramref name="s1">
        /// is greater than <paramref name="s2">.</returns>
        public static Comparison<Star> CompareByAge = 
            delegate (Star s1, Star s2)
        {
            return s1?.Age?.CompareTo(s2.Age) ?? -1;
        };

        /// <summary>
        /// Compares two specified Star objetcts and returns an integer
        /// that indicates their relative position in the sort order,
        /// based by their Rotation Velocity.
        /// </summary>
        /// <param name="s1">The first Star to compare.</param>
        /// <param name="s2">The second Star to compare.</param>
        /// <returns>A signed integer that indicates the relative values of x 
        /// and y. Less than 0 if <paramref name="s1"> is less than
        /// <paramref name="s2">, 0 if <paramref name="s1"> equals 
        /// <paramref name="s2">, and greater than 0 if <paramref name="s1">
        /// is greater than <paramref name="s2">.</returns>
        public static Comparison<Star> CompareByRotVelocity = 
            delegate (Star s1, Star s2)
        {
            return s1?.RotVelocity?.CompareTo(s2.RotVelocity) ?? -1;
        };

        /// <summary>
        /// Compares two specified Star objetcts and returns an integer
        /// that indicates their relative position in the sort order,
        /// based by their Rotation Period.
        /// </summary>
        /// <param name="s1">The first Star to compare.</param>
        /// <param name="s2">The second Star to compare.</param>
        /// <returns>A signed integer that indicates the relative values of x 
        /// and y. Less than 0 if <paramref name="s1"> is less than
        /// <paramref name="s2">, 0 if <paramref name="s1"> equals 
        /// <paramref name="s2">, and greater than 0 if <paramref name="s1">
        /// is greater than <paramref name="s2">.</returns>
        public static Comparison<Star> CompareByRotPeriod = 
            delegate (Star s1, Star s2)
        {
            return s1?.RotPeriod?.CompareTo(s2.RotPeriod) ?? -1;
        };

        /// <summary>
        /// Compares two specified Star objetcts and returns an integer
        /// that indicates their relative position in the sort order,
        /// based by their Distance to the Sun.
        /// </summary>
        /// <param name="s1">The first Star to compare.</param>
        /// <param name="s2">The second Star to compare.</param>
        /// <returns>A signed integer that indicates the relative values of x 
        /// and y. Less than 0 if <paramref name="s1"> is less than
        /// <paramref name="s2">, 0 if <paramref name="s1"> equals 
        /// <paramref name="s2">, and greater than 0 if <paramref name="s1">
        /// is greater than <paramref name="s2">.</returns>
        public static Comparison<Star> CompareBySunDistance = 
            delegate (Star s1, Star s2)
        {
            return s1?.SunDistance?.CompareTo(s2.SunDistance) ?? -1;
        };


        /// <summary>
        /// Star's name. Derived from hostname column.
        /// </summary>
        /// <value>Star's name.</value>
        public string Name { get; private set; }      

        /// <summary>
        /// Star's effective temperature. Derived from st_teff column.
        /// </summary>
        /// <value>Star's effective temperature (in Kelvin).</value>
        public float? Temperature { get; private set; }
        
        /// <summary>
        /// Star's age. Derived from st_age column.
        /// </summary>
        /// <value>Star's age (in Giga-Years).</value>
        public float? Age { get; private set; }

        /// <summary>
        /// Star's rotation velocity. Derived from st_vsin column.
        /// </summary>
        /// <value>Star's rotation velocity (in km/s).</value>
        public float? RotVelocity { get; private set; }

        /// <summary>
        /// Star's rotation period. Derived from st_rotp column.
        /// </summary>
        /// <value>Star's rotation period (in days).</value>
        public float? RotPeriod { get; private set; }

        /// <summary>
        /// Star's radius relative to the Sun. Derived from st_rad column.
        /// </summary>
        /// <value>Star's radius (relative to the Sun).</value>
        public float? Radius { get; private set; }

        /// <summary>
        /// Star's mass relative to the Sun. Derived from st_mass column.
        /// </summary>
        /// <value>Star's mass (relative to the Sun).</value>
        public float? Mass { get; private set; }

        /// <summary>
        /// Star's distance to the Sun. Derived from sy_dist column.
        /// </summary>
        /// <value>Star's distance to the Sun (In Parsecs).</value>
        public float? SunDistance { get; private set; }

        /// <summary>
        /// Names of the Planets that orbit the Star. 
        /// Derived from pl_name column.
        /// </summary>
        /// <value>Collection with the names of the planets.</value>
        public ICollection<string> OrbitingPlanets { get; private set; }

        /// <summary>
        /// Determines whether the specified Star is equal to the current 
        /// Star.
        /// </summary>
        /// <param name="other">The Star to compare with the current 
        /// Star.</param>
        /// <returns><c>true</c> if the specified Star is equal to the 
        /// current Star; otherwise <c>false</c>.</returns>
        public bool Equals(Star other)
        {
            return this.Name == other.Name; 
        }


        /// <summary>
        /// Constructor method. Instantiates a new Star.
        /// </summary>
        /// <param name="name">Star's unique name.</param>
        /// <param name="planetName">The name of the Planet were the information 
        /// was retrieved from.</param>
        /// <param name="temp">Star's temperature.</param>
        /// <param name="age">Star's age.</param>
        /// <param name="rotVel">Star's rotation velocity.</param>
        /// <param name="rotPer">Star's rotation period.</param>
        /// <param name="radius">Star's radius.</param>
        /// <param name="mass">Star's mass.</param>
        /// <param name="sunDis">Star's distancet to the sun.</param>
        public Star(string name, string planetName, float? temp = null,
        float? age = null,  float? rotVel = null, float? rotPer = null, 
        float? radius = null, float? mass = null, float? sunDis = null)
        {
            OrbitingPlanets = new List<string>();
            Name = name;
            Temperature = temp;
            Age = age;
            RotVelocity = rotVel;
            Radius = radius;
            Mass = mass;
            SunDistance = sunDis;
            
            //Add new planet to the collection
            OrbitingPlanets.Add(planetName);
        }
    
        /// <summary>
        /// Updates the Star with new information coming from a different Star.
        /// </summary>
        /// <param name="newInfo">New Star with different information</param>
        /// <param name="planetName">The name of the Planet were the information 
        /// was retrieved from.</param>
        public void UpdateStar(Star newInfo, string planetName)
        {           
            Temperature = 
                Temperature == null ? newInfo.Temperature: Temperature;                  
            Age = 
                Age == null ? newInfo.Age: Age ;            
            RotVelocity = 
                RotVelocity == null ? newInfo.RotVelocity: RotVelocity;          
            Mass = 
                Mass == null ? newInfo.Mass: Mass;
            Radius = 
                Radius == null ? newInfo.Radius: Radius;            
            SunDistance = 
                SunDistance == null ? newInfo.SunDistance: SunDistance;
       
            //Add new planet to the collection
            OrbitingPlanets.Add(planetName);
       
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            string nS = "N/A";

            // Obligatory Parameters, cannot be null
            sb.Append(
             $"{Name.MaxLength(14),-14}  ");
            // Optional Parameters, can be null
            sb.Append(
             $"{(Age.HasValue ? Age.ToString() : nS),-14}  ");
            sb.Append(
             $"{(SunDistance.HasValue ? SunDistance.ToString() : nS),-14}  ");
            sb.Append(
             $"{(RotVelocity.HasValue ? RotVelocity.ToString() : nS),-14}  ");
            sb.Append(
             $"{(RotPeriod.HasValue ? RotPeriod.ToString() : nS),-14}  ");
            sb.Append(
             $"{(Radius.HasValue ? Radius.ToString() : nS),-14}  ");
            sb.Append(
             $"{(Mass.HasValue ? Mass.ToString() : nS),-14}  ");
            sb.Append(
             $"{(Temperature.HasValue ? Temperature.ToString() : nS),-14}");
            sb.Append(
             $"{OrbitingPlanets.Count,-14}");

            return sb.ToString();
        }
        public string ToStringDetailed()
        {
            StringBuilder sb = new StringBuilder();
            string nS = "N/A";

            // Obligatory Parameter, cannot be null
            sb.Append(
             $"Name: {Name, -14}\n");

            // Optional Parameters, can be null
            sb.Append(
             $"Star Age: {(Age.HasValue ? Age.ToString() : nS), -14}\n");
            sb.Append(
             $"Distance to the Sun: ");
            sb.Append(
             $"{(SunDistance.HasValue ? SunDistance.ToString() : nS), -14}\n");
            sb.Append(
             $"Rotational Velocity (km/s): ");
            sb.Append(
             $"{(RotVelocity.HasValue ? RotVelocity.ToString() : nS), -14}\n");
            sb.Append(
             $"Rotational Period (days): ");
            sb.Append(
             $"{(RotPeriod.HasValue ? RotPeriod.ToString() : nS), -14}\n");
            sb.Append(
             $"Radius (vs Earth): ");
            sb.Append(
             $"{(Radius.HasValue ? Radius.ToString() : nS), -14}\n");
            sb.Append(
             $"Mass (vs Earth): ");
            sb.Append(
             $"{(Mass.HasValue ? Mass.ToString() : nS), -14}\n");
            sb.Append(
             $"Efective Star Temperature (Kelvin): ");
            sb.Append(
             $"{(Temperature.HasValue ? Temperature.ToString() : nS), -14}\n");
             
            // Obligatory Parameter, cannot be null
            sb.Append(
             $"Number of Planets Orbiting: {OrbitingPlanets.Count, -14}\n"); 

            return sb.ToString();
        }

    }
}