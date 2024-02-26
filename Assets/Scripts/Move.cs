using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed;
    Transform _playerTransform;
    [SerializeField]
    Camera _camera;

    private void Awake()
    {
        Application.targetFrameRate = 90;
    }
    private void Start()
    {
        _playerTransform = this.GetComponent<Transform>();


    }
    void Update()
    {
        this.gameObject.transform.Translate(0, 0, _moveSpeed * Time.deltaTime);
    }
}