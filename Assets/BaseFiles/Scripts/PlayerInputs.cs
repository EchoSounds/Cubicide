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
            ""name"": ""SingleButtonMash"",
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
        },
        {
            ""name"": ""MultiButtonMash"",
            ""id"": ""480213d7-6eaa-4ef2-b441-6ef658736187"",
            ""actions"": [
                {
                    ""name"": ""Mash"",
                    ""type"": ""Button"",
                    ""id"": ""622571df-d7bf-4f3a-a1cc-389bba1c4859"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""ebe12dca-da86-462e-bbe8-cf852adae87c"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mash"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""bf3c8b8d-95b4-49ac-a85a-8f28e5f005ad"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""d51df416-8ee0-4b0a-ba66-d918c278564e"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Mouse
        m_Mouse = asset.FindActionMap("Mouse", throwIfNotFound: true);
        m_Mouse_MouseDelta = m_Mouse.FindAction("Mouse Delta", throwIfNotFound: true);
        // SingleButtonMash
        m_SingleButtonMash = asset.FindActionMap("SingleButtonMash", throwIfNotFound: true);
        m_SingleButtonMash_Mash = m_SingleButtonMash.FindAction("Mash", throwIfNotFound: true);
        // MultiButtonMash
        m_MultiButtonMash = asset.FindActionMap("MultiButtonMash", throwIfNotFound: true);
        m_MultiButtonMash_Mash = m_MultiButtonMash.FindAction("Mash", throwIfNotFound: true);
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

    // SingleButtonMash
    private readonly InputActionMap m_SingleButtonMash;
    private ISingleButtonMashActions m_SingleButtonMashActionsCallbackInterface;
    private readonly InputAction m_SingleButtonMash_Mash;
    public struct SingleButtonMashActions
    {
        private @PlayerInputs m_Wrapper;
        public SingleButtonMashActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Mash => m_Wrapper.m_SingleButtonMash_Mash;
        public InputActionMap Get() { return m_Wrapper.m_SingleButtonMash; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SingleButtonMashActions set) { return set.Get(); }
        public void SetCallbacks(ISingleButtonMashActions instance)
        {
            if (m_Wrapper.m_SingleButtonMashActionsCallbackInterface != null)
            {
                @Mash.started -= m_Wrapper.m_SingleButtonMashActionsCallbackInterface.OnMash;
                @Mash.performed -= m_Wrapper.m_SingleButtonMashActionsCallbackInterface.OnMash;
                @Mash.canceled -= m_Wrapper.m_SingleButtonMashActionsCallbackInterface.OnMash;
            }
            m_Wrapper.m_SingleButtonMashActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Mash.started += instance.OnMash;
                @Mash.performed += instance.OnMash;
                @Mash.canceled += instance.OnMash;
            }
        }
    }
    public SingleButtonMashActions @SingleButtonMash => new SingleButtonMashActions(this);

    // MultiButtonMash
    private readonly InputActionMap m_MultiButtonMash;
    private IMultiButtonMashActions m_MultiButtonMashActionsCallbackInterface;
    private readonly InputAction m_MultiButtonMash_Mash;
    public struct MultiButtonMashActions
    {
        private @PlayerInputs m_Wrapper;
        public MultiButtonMashActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Mash => m_Wrapper.m_MultiButtonMash_Mash;
        public InputActionMap Get() { return m_Wrapper.m_MultiButtonMash; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MultiButtonMashActions set) { return set.Get(); }
        public void SetCallbacks(IMultiButtonMashActions instance)
        {
            if (m_Wrapper.m_MultiButtonMashActionsCallbackInterface != null)
            {
                @Mash.started -= m_Wrapper.m_MultiButtonMashActionsCallbackInterface.OnMash;
                @Mash.performed -= m_Wrapper.m_MultiButtonMashActionsCallbackInterface.OnMash;
                @Mash.canceled -= m_Wrapper.m_MultiButtonMashActionsCallbackInterface.OnMash;
            }
            m_Wrapper.m_MultiButtonMashActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Mash.started += instance.OnMash;
                @Mash.performed += instance.OnMash;
                @Mash.canceled += instance.OnMash;
            }
        }
    }
    public MultiButtonMashActions @MultiButtonMash => new MultiButtonMashActions(this);
    public interface IMouseActions
    {
        void OnMouseDelta(InputAction.CallbackContext context);
    }
    public interface ISingleButtonMashActions
    {
        void OnMash(InputAction.CallbackContext context);
    }
    public interface IMultiButtonMashActions
    {
        void OnMash(InputAction.CallbackContext context);
    }
}
