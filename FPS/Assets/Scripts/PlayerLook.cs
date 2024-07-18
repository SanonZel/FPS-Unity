
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    private const float _sensivity = 100.0f;
    private float _Yrot = 0f;

    [SerializeField] private Transform _playerTr;
    [SerializeField] private Transform _weaponTr;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

 
    void Update()
    {
       float mouseX = Input.GetAxis("Mouse X");
       float mouseY = Input.GetAxis("Mouse Y");

        _Yrot -= mouseY;
        _Yrot = Mathf.Clamp(_Yrot, -90.0f, 90.0f); 

        transform.localRotation = Quaternion.Euler(_Yrot, .0f, .0f);
        _weaponTr.localRotation = Quaternion.Euler(_Yrot, .0f, .0f);
        
        _playerTr.Rotate(Vector3.up * mouseX);

    }
}
