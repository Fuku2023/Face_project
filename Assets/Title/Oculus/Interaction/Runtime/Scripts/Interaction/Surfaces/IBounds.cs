using UnityEngine;

namespace Oculus.Interaction.Surfaces
{
    public interface IBounds
    {
        /// <summary>
        /// The world space axis-aligned bounding box (AABB)
        /// </summary>
        Bounds Bounds { get; }
    }
}
