using UnityEngine;
using UnityEngine.InputSystem;

public class MoveLetter : MonoBehaviour
{
    public Camera mainCamera;
    [SerializeField] private InputAction mouseClick, touchTap;
    private GameObject _movingLetter;
    
    private void OnEnable()
    {
        mouseClick.Enable();
        touchTap.Enable();
        mouseClick.performed += ReceiveInputMouse;
        touchTap.performed += ReceiveInputTouch;
    }
    
    private void OnDisable()
    {
        mouseClick.performed -= ReceiveInputMouse;
        touchTap.performed -= ReceiveInputTouch;
        mouseClick.Disable();
        touchTap.Disable();
    }
    
    private void ReceiveInputMouse(InputAction.CallbackContext ctx)
    {
        Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            _movingLetter = hit.collider.gameObject;
            if (hit.collider != null && hit.collider.gameObject.CompareTag("Letter"))
                _movingLetter.GetComponentInChildren<Letter>().OnPlaceMe();
        }
    }
    
    private void ReceiveInputTouch(InputAction.CallbackContext ctx)
    {
        Ray ray = mainCamera.ScreenPointToRay(Touchscreen.current.position.ReadValue());
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            _movingLetter = hit.collider.gameObject;
            if (hit.collider != null && hit.collider.gameObject.CompareTag("Letter"))
                _movingLetter.GetComponentInChildren<Letter>().OnPlaceMe();
        }
    }
}
