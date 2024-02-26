using System.Collections.Generic;

namespace Oculus.Interaction.Surfaces
{
    public interface IClippedSurface<TClipper> : ISurfacePatch
    {
        /// <summary>
        /// The clippers by which <see cref="BackingSurface"/>
        /// will be clipped.
        /// </summary>
        IEnumerable<TClipper> GetClippers();
    }
}
