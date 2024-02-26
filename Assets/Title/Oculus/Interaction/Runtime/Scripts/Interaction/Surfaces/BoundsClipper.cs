using UnityEngine;


namespace Oculus.Interaction.Surfaces
{
    public class BoundsClipper : MonoBehaviour
    {
        [Tooltip("The offset of the bounding box center relative to " +
            "the transform origin, in local space.")]
        [SerializeField]
        private Vector3 _position = Vector3.zero;

        [Tooltip("The local size of the bounding box.")]
        [SerializeField]
        private Vector3 _size = Vector3.one;

        public Vector3 Position
        {
            get => _position;
            set => _position = value;
        }

        public Vector3 Size
        {
            get => _size;
            set => _size = value;
        }

        public bool GetLocalBounds(Transform localTo, out Bounds bounds)
        {
            Vector3 localPos = localTo.InverseTransformPoint(
                transform.TransformPoint(Position));
            Vector3 localSize = localTo.InverseTransformVector(
                transform.TransformVector(_size));
            bounds = new Bounds(localPos, localSize);
            return isActiveAndEnabled;
        }
    }
}
