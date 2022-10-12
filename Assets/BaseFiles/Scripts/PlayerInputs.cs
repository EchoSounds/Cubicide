//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/BaseFiles/Scripts/PlayerInputs.inputactions
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

public partial class @PlayerInputs : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputs"",
    ""maps"": [
        {
            ""name"": ""Mouse"",
            ""id"": ""7957a6e0-0272-4c06-85be-b2f3c65c0ebe"",
            ""actions"": [
                {
                    ""name"": ""Mouse Delta"",
                    ""type"": ""PassThrough"",
                    ""id"": ""5ba3b3d7-7a79-4d15-bebe-b40c4acd7297"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""712dcaa2-2d21-4c4f-a4c8-21f8e7ddc921"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mouse Delta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""ButtonMash"",
            ""id"": ""76833813-b49c-4436-8842-acad1a300357"",
            ""actions"": [
                {
                    ""name"": ""Mash"",
                    ""type"": ""Button"",
                    ""id"": ""c440b2c6-b989-4ac9-b5a6-735d8a3ca5c8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2480eae1-e1d3-49cd-808b-2e6a99a52742"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""74e38882-e3dd-4d76-a24c-f70dfc548ee2"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mash"",
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
        m_Mouse_MouseDelta = m_Mouse.FindAction("Mouse Delta", throwIfNotFound: true);
        // ButtonMash
        m_ButtonMash = asset.FindActionMap("ButtonMash", throwIfNotFound: true);
        m_ButtonMash_Mash = m_ButtonMash.FindAction("Mash", throwIfNotFound: true);
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
    private readonly InputAction m_Mouse_MouseDelta;
    public struct MouseActions
    {
        private @PlayerInputs m_Wrapper;
        public MouseActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @MouseDelta => m_Wrapper.m_Mouse_MouseDelta;
        public InputActionMap Get() { return m_Wrapper.m_Mouse; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MouseActions set) { return set.Get(); }
        public void SetCallbacks(IMouseActions instance)
        {
            if (m_Wrapper.m_MouseActionsCallbackInterface != null)
            {
                @MouseDelta.started -= m_Wrapper.m_MouseActionsCallbackInterface.OnMouseDelta;
                @MouseDelta.performed -= m_Wrapper.m_MouseActionsCallbackInterface.OnMouseDelta;
                @MouseDelta.canceled -= m_Wrapper.m_MouseActionsCallbackInterface.OnMouseDelta;
            }
            m_Wrapper.m_MouseActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MouseDelta.started += instance.OnMouseDelta;
                @MouseDelta.performed += instance.OnMouseDelta;
                @MouseDelta.canceled += instance.OnMouseDelta;
            }
        }
    }
    public MouseActions @Mouse => new MouseActions(this);

    // ButtonMash
    private readonly InputActionMap m_ButtonMash;
    private IButtonMashActions m_ButtonMashActionsCallbackInterface;
    private readonly InputAction m_ButtonMash_Mash;
    public struct ButtonMashActions
    {
        private @PlayerInputs m_Wrapper;
        public ButtonMashActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Mash => m_Wrapper.m_ButtonMash_Mash;
        public InputActionMap Get() { return m_Wrapper.m_ButtonMash; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ButtonMashActions set) { return set.Get(); }
        public void SetCallbacks(IButtonMashActions instance)
        {
            if (m_Wrapper.m_ButtonMashActionsCallbackInterface != null)
            {
                @Mash.started -= m_Wrapper.m_ButtonMashActionsCallbackInterface.OnMash;
                @Mash.performed -= m_Wrapper.m_ButtonMashActionsCallbackInterface.OnMash;
                @Mash.canceled -= m_Wrapper.m_ButtonMashActionsCallbackInterface.OnMash;
            }
            m_Wrapper.m_ButtonMashActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Mash.started += instance.OnMash;
                @Mash.performed += instance.OnMash;
                @Mash.canceled += instance.OnMash;
            }
        }
    }
    public ButtonMashActions @ButtonMash => new ButtonMashActions(this);
    public interface IMouseActions
    {
        void OnMouseDelta(InputAction.CallbackContext context);
    }
    public interface IButtonMashActions
    {
        void OnMash(InputAction.CallbackContext context);
    }
}
