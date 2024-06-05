using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    [SerializeField] Transform playerOBJ;
    [SerializeField] float mouseSens;
    float _mouseX, _mouseY;

    [SerializeField] Transform fpsCam, tpsCam;
    bool _isThirdPersonCam;
    // Start is called before the first frame update
    void OnEnable(){
        Player.changeCam += changeCams;
    }
    void Start()
    {
         //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        CameraFunctions();
    }
    void CameraFunctions() { 
        updateCamPos();
        RotateCam();
    }
    void updateCamPos() {
        if (_isThirdPersonCam) transform.position = tpsCam.position;
        else transform.position = fpsCam.position;
    }
    void RotateCam() {
        _mouseX += Input.GetAxisRaw("Mouse X") * mouseSens;
        _mouseY += Input.GetAxisRaw("Mouse Y") * mouseSens;

        if (!_isThirdPersonCam) _mouseY = Mathf.Clamp(_mouseY, -90f, 90f);
        else _mouseY = Mathf.Clamp(_mouseY, -30f, 20f);
       
        playerOBJ.rotation = Quaternion.Euler(0f, _mouseX, 0f).normalized;
        transform.rotation = Quaternion.Euler(-_mouseY, _mouseX, 0).normalized;       
    }
    void changeCams() => _isThirdPersonCam = !_isThirdPersonCam;
}
