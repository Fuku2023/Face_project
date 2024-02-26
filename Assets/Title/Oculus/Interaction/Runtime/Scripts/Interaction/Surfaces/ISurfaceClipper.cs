using UnityEngine;

namespace Oculus.Interaction.Surfaces
{
    public interface ICylinderClipper
    {
        /// <summary>
        /// Get the segment defining a portion of a cylinder surface
        /// </summary>
        /// <param name="segment">The segment defining the clip area
        /// of a cylinder</param>
        /// <returns>True if clipping should be performed</returns>
        public bool GetCylinderSegment(out CylinderSegment segment);
    }

    /// <summary>
    /// Uses a bounding box to perform clipping
    /// </summary>
    public interface IBoundsClipper
    {
        /// <summary>
        /// Get the bounding box in the local space of a
        /// provided transform.
        /// </summary>
        /// <param name="localTo">The transform the bounds
        /// will be local to</param>
        /// <param name="bounds">The bounding box in local space of
        /// <paramref name="localTo"/></param>
        /// <returns>True if clipping should be performed</returns>
        public bool GetLocalBounds(Transform localTo, out Bounds bounds);
    }
}
