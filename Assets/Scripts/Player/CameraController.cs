using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;

    private Vector2 _turn;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //_turn.x += Input.GetAxis("Mouse X");
        //_turn.y += Input.GetAxis("Mouse Y");

        //_camera.transform.localRotation = Quaternion.Euler(-1 * _turn.y, _turn.x, 0);
    }
}
