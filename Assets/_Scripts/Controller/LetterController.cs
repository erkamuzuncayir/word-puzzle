//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/_Scripts/Controller/LetterController.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @LetterController : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @LetterController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""LetterController"",
    ""maps"": [
        {
            ""name"": ""Mouse"",
            ""id"": ""8ea7fd4b-e5da-486c-8ae7-378128474405"",
            ""actions"": [
                {
                    ""name"": ""MouseClick"",
                    ""type"": ""Button"",
                    ""id"": ""ff53f9ce-2eb1-4bd8-8d8c-e85dd47d4fad"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ce1cbc92-8cf7-4f2b-91be-3b662de03067"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Touch"",
            ""id"": ""cd49c775-0a2d-492b-8530-92277e9aa832"",
            ""actions"": [
                {
                    ""name"": ""Tap"",
                    ""type"": ""Button"",
                    ""id"": ""abc528df-e03d-4ff0-a07c-0b6a4cdffc3c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4287d903-f822-4f13-bfc4-7b5dd3bf9b6b"",
                    ""path"": ""<Touchscreen>/Press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Tap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Mouse
        m_Mouse = asset.FindActionMap("Mouse", throwIfNotFound: true);
        m_Mouse_MouseClick = m_Mouse.FindAction("MouseClick", throwIfNotFound: true);
        // Touch
        m_Touch = asset.FindActionMap("Touch", throwIfNotFound: true);
        m_Touch_Tap = m_Touch.FindAction("Tap", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Mouse
    private readonly InputActionMap m_Mouse;
    private IMouseActions m_MouseActionsCallbackInterface;
    private readonly InputAction m_Mouse_MouseClick;
    public struct MouseActions
    {
        private @LetterController m_Wrapper;
        public MouseActions(@LetterController wrapper) { m_Wrapper = wrapper; }
        public InputAction @MouseClick => m_Wrapper.m_Mouse_MouseClick;
        public InputActionMap Get() { return m_Wrapper.m_Mouse; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MouseActions set) { return set.Get(); }
        public void SetCallbacks(IMouseActions instance)
        {
            if (m_Wrapper.m_MouseActionsCallbackInterface != null)
            {
                @MouseClick.started -= m_Wrapper.m_MouseActionsCallbackInterface.OnMouseClick;
                @MouseClick.performed -= m_Wrapper.m_MouseActionsCallbackInterface.OnMouseClick;
                @MouseClick.canceled -= m_Wrapper.m_MouseActionsCallbackInterface.OnMouseClick;
            }
            m_Wrapper.m_MouseActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MouseClick.started += instance.OnMouseClick;
                @MouseClick.performed += instance.OnMouseClick;
                @MouseClick.canceled += instance.OnMouseClick;
            }
        }
    }
    public MouseActions @Mouse => new MouseActions(this);

    // Touch
    private readonly InputActionMap m_Touch;
    private ITouchActions m_TouchActionsCallbackInterface;
    private readonly InputAction m_Touch_Tap;
    public struct TouchActions
    {
        private @LetterController m_Wrapper;
        public TouchActions(@LetterController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Tap => m_Wrapper.m_Touch_Tap;
        public InputActionMap Get() { return m_Wrapper.m_Touch; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TouchActions set) { return set.Get(); }
        public void SetCallbacks(ITouchActions instance)
        {
            if (m_Wrapper.m_TouchActionsCallbackInterface != null)
            {
                @Tap.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnTap;
                @Tap.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnTap;
                @Tap.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnTap;
            }
            m_Wrapper.m_TouchActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Tap.started += instance.OnTap;
                @Tap.performed += instance.OnTap;
                @Tap.canceled += instance.OnTap;
            }
        }
    }
    public TouchActions @Touch => new TouchActions(this);
    public interface IMouseActions
    {
        void OnMouseClick(InputAction.CallbackContext context);
    }
    public interface ITouchActions
    {
        void OnTap(InputAction.CallbackContext context);
    }
}