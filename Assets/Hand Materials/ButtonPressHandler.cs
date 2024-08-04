using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonPressHandler : MonoBehaviour
{
    public InputActionProperty buttonPressAction; // Reference to the input action

    private void OnEnable()
    {
        buttonPressAction.action.Enable();
        buttonPressAction.action.performed += OnButtonPress;
    }

    private void OnDisable()
    {
        buttonPressAction.action.performed -= OnButtonPress;
        buttonPressAction.action.Disable();
    }

    private void OnButtonPress(InputAction.CallbackContext context)
    {
        Debug.Log("Button Pressed");
        // Add your button press logic here
    }
}
