using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.XR.CoreUtils;
using UnityEngine.XR.Interaction.Toolkit;

public class CharacterControllerDriverScript : MonoBehaviour
{
    private XROrigin _xrOrigin;
    private CharacterController _characterController;
    private CharacterControllerDriver _driver;
    static int targetFrameRate;

    void Awake()
    {
        Application.targetFrameRate = 60; //60FPS�ɐݒ�
    }

    // Start is called before the first frame update
    void Start()
    {
        _xrOrigin = GetComponent<XROrigin>();
        _characterController = GetComponent<CharacterController>();
        _driver = GetComponent<CharacterControllerDriver>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCharacterController();
    }
    /// <summary>
    /// Updates the <see cref="CharacterController.height"/> and <see cref="CharacterController.center"/>
    /// based on the camera's position.
    /// </summary>
    protected virtual void UpdateCharacterController()
    {
        if (_xrOrigin == null || _characterController == null)
        {
            return;
        }

        var height = Mathf.Clamp(_xrOrigin.CameraInOriginSpaceHeight, _driver.minHeight, _driver.maxHeight);

        Vector3 center = _xrOrigin.CameraInOriginSpacePos; //�v���C���[�̒��S
        center.y = height / 20f + _characterController.skinWidth; //�v���C���[�̍���

        _characterController.height = height; //�v���C���[�̒��S
        _characterController.center = center; //�v���C���[�̍���

    }
}
