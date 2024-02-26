using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _fllowMoveSpeed = 0.1f;
    [SerializeField] private float _fllowRotateSpeed = 0.02f;
    [SerializeField] private float _rotateSpeedThreshold = 0.9f;
    [SerializeField] private bool _isImmediateMove;
    [SerializeField] private bool _isLockX;
    [SerializeField] private bool _isLockY;
    [SerializeField] private bool _isLockZ;

    private Quaternion rot;
    private Quaternion rotDif;

    // Start is called before the first frame update
    private void Start()
    {
        if (!_target) _target = Camera.main.transform;
    }

    private void LateUpdate()
    {
        if (_isImmediateMove)
        {
            transform.position = _target.position;
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, _target.position, _fllowMoveSpeed);
        }
        rotDif = _target.rotation * Quaternion.Inverse(transform.rotation);
        rot = _target.rotation;

        if (_isLockX) { rot.x = default; }
        if (_isLockY) { rot.y = default; }
        if (_isLockZ) { rot.z = default; }

        if (rotDif.w < _rotateSpeedThreshold)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, rot,
                _fllowRotateSpeed * 4);
        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation,
                rot, _fllowRotateSpeed);
        }
    }
    public void ImmediateSync(Transform targetTransform)
    {
        transform.position = targetTransform.position;
        transform.rotation = targetTransform.rotation;
    }
        // Update is called once per frame
        void Update()
    {
        
    }
}
