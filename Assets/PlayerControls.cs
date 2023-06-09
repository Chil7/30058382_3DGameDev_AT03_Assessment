//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.2.0
//     from Assets/PlayerControls.inputactions
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

public partial class @PlayerControls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""d7c76c1e-eb78-41b6-bfe4-0ab0e0bb0b75"",
            ""actions"": [
                {
                    ""name"": ""Movement (Keyboard)"",
                    ""type"": ""Value"",
                    ""id"": ""26d35dec-9861-4b0e-9da2-8b6ada2442f6"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Rotation (Keyboard)"",
                    ""type"": ""Value"",
                    ""id"": ""006783c1-b52d-4dbb-b520-b993c3665cbc"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Interact (Keyboard)"",
                    ""type"": ""Button"",
                    ""id"": ""20503539-8f6b-4949-b620-a296801b218c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Shoot (Keyboard)"",
                    ""type"": ""Button"",
                    ""id"": ""314c32ce-5de0-4819-977a-e2da874008eb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump (Keyboard)"",
                    ""type"": ""Button"",
                    ""id"": ""b67eaf55-1fdf-4b45-9040-ddd08c701196"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Movement (Gamepad)"",
                    ""type"": ""Value"",
                    ""id"": ""f43dba6c-9a63-415d-8a15-0c448d9655cf"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Rotation (Gamepad)"",
                    ""type"": ""Value"",
                    ""id"": ""8e5e846c-52e1-4007-8461-fa95dae92e3a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Interact (Gamepad)"",
                    ""type"": ""Button"",
                    ""id"": ""a5a6e886-5f39-4a80-a39c-421dd409613e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Shoot (Gamepad)"",
                    ""type"": ""Button"",
                    ""id"": ""17d6c28e-bd1b-4e92-9f1f-4234eea30abd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump (Gamepad)"",
                    ""type"": ""Button"",
                    ""id"": ""81209497-315a-4d61-ba1a-0b858385181c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d718a0aa-fbd8-4e62-b389-390cb6624818"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation (Gamepad)"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7f3b9e68-150c-4333-84f8-8a7de65672f5"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact (Keyboard)"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""616f75d9-c33c-473e-844c-5ef5b71d3dae"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact (Gamepad)"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b94ecfb0-0ed0-4a83-98f9-6def895ec6fa"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot (Keyboard)"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ef109a90-d33e-4ee0-9b2a-3824ac829fe5"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot (Gamepad)"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""2e496304-ad46-4015-9ad2-895b52b2aca1"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement (Keyboard)"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""f1a78e5d-6177-4a3a-902b-e704a2c254bf"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement (Keyboard)"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""c09e3842-cc68-4d11-bb01-858517285ae8"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement (Keyboard)"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""64a29aa1-43ff-4ee8-9416-499a80faab59"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement (Keyboard)"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""b82841ee-f70c-4183-b655-9021b042b214"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement (Keyboard)"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""LeftJoystick"",
                    ""id"": ""87895408-1f66-4b5e-8ba1-61ff77e2f9af"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement (Gamepad)"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""dcc57355-72ba-4fb0-9349-9c6ec00c3dc1"",
                    ""path"": ""<Joystick>/stick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement (Gamepad)"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""9926af7d-a280-497d-b874-180ae60f5b71"",
                    ""path"": ""<Joystick>/stick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement (Gamepad)"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c144bf79-0011-44f9-b02e-7b39d947ef99"",
                    ""path"": ""<Joystick>/stick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement (Gamepad)"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a1484ed4-cac1-4a46-b69e-185d24934d9b"",
                    ""path"": ""<Joystick>/stick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement (Gamepad)"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""456e3a90-c0b3-4d87-8d26-74adf6d68672"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump (Keyboard)"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""75a4dc91-1e3d-4de5-aa08-91f82e84e0bd"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump (Gamepad)"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""993817bc-4337-43ac-b80b-0bff9f56e174"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation (Keyboard)"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_MovementKeyboard = m_Gameplay.FindAction("Movement (Keyboard)", throwIfNotFound: true);
        m_Gameplay_RotationKeyboard = m_Gameplay.FindAction("Rotation (Keyboard)", throwIfNotFound: true);
        m_Gameplay_InteractKeyboard = m_Gameplay.FindAction("Interact (Keyboard)", throwIfNotFound: true);
        m_Gameplay_ShootKeyboard = m_Gameplay.FindAction("Shoot (Keyboard)", throwIfNotFound: true);
        m_Gameplay_JumpKeyboard = m_Gameplay.FindAction("Jump (Keyboard)", throwIfNotFound: true);
        m_Gameplay_MovementGamepad = m_Gameplay.FindAction("Movement (Gamepad)", throwIfNotFound: true);
        m_Gameplay_RotationGamepad = m_Gameplay.FindAction("Rotation (Gamepad)", throwIfNotFound: true);
        m_Gameplay_InteractGamepad = m_Gameplay.FindAction("Interact (Gamepad)", throwIfNotFound: true);
        m_Gameplay_ShootGamepad = m_Gameplay.FindAction("Shoot (Gamepad)", throwIfNotFound: true);
        m_Gameplay_JumpGamepad = m_Gameplay.FindAction("Jump (Gamepad)", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_MovementKeyboard;
    private readonly InputAction m_Gameplay_RotationKeyboard;
    private readonly InputAction m_Gameplay_InteractKeyboard;
    private readonly InputAction m_Gameplay_ShootKeyboard;
    private readonly InputAction m_Gameplay_JumpKeyboard;
    private readonly InputAction m_Gameplay_MovementGamepad;
    private readonly InputAction m_Gameplay_RotationGamepad;
    private readonly InputAction m_Gameplay_InteractGamepad;
    private readonly InputAction m_Gameplay_ShootGamepad;
    private readonly InputAction m_Gameplay_JumpGamepad;
    public struct GameplayActions
    {
        private @PlayerControls m_Wrapper;
        public GameplayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MovementKeyboard => m_Wrapper.m_Gameplay_MovementKeyboard;
        public InputAction @RotationKeyboard => m_Wrapper.m_Gameplay_RotationKeyboard;
        public InputAction @InteractKeyboard => m_Wrapper.m_Gameplay_InteractKeyboard;
        public InputAction @ShootKeyboard => m_Wrapper.m_Gameplay_ShootKeyboard;
        public InputAction @JumpKeyboard => m_Wrapper.m_Gameplay_JumpKeyboard;
        public InputAction @MovementGamepad => m_Wrapper.m_Gameplay_MovementGamepad;
        public InputAction @RotationGamepad => m_Wrapper.m_Gameplay_RotationGamepad;
        public InputAction @InteractGamepad => m_Wrapper.m_Gameplay_InteractGamepad;
        public InputAction @ShootGamepad => m_Wrapper.m_Gameplay_ShootGamepad;
        public InputAction @JumpGamepad => m_Wrapper.m_Gameplay_JumpGamepad;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @MovementKeyboard.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovementKeyboard;
                @MovementKeyboard.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovementKeyboard;
                @MovementKeyboard.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovementKeyboard;
                @RotationKeyboard.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotationKeyboard;
                @RotationKeyboard.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotationKeyboard;
                @RotationKeyboard.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotationKeyboard;
                @InteractKeyboard.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteractKeyboard;
                @InteractKeyboard.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteractKeyboard;
                @InteractKeyboard.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteractKeyboard;
                @ShootKeyboard.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShootKeyboard;
                @ShootKeyboard.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShootKeyboard;
                @ShootKeyboard.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShootKeyboard;
                @JumpKeyboard.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJumpKeyboard;
                @JumpKeyboard.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJumpKeyboard;
                @JumpKeyboard.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJumpKeyboard;
                @MovementGamepad.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovementGamepad;
                @MovementGamepad.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovementGamepad;
                @MovementGamepad.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovementGamepad;
                @RotationGamepad.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotationGamepad;
                @RotationGamepad.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotationGamepad;
                @RotationGamepad.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotationGamepad;
                @InteractGamepad.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteractGamepad;
                @InteractGamepad.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteractGamepad;
                @InteractGamepad.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteractGamepad;
                @ShootGamepad.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShootGamepad;
                @ShootGamepad.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShootGamepad;
                @ShootGamepad.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShootGamepad;
                @JumpGamepad.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJumpGamepad;
                @JumpGamepad.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJumpGamepad;
                @JumpGamepad.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJumpGamepad;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MovementKeyboard.started += instance.OnMovementKeyboard;
                @MovementKeyboard.performed += instance.OnMovementKeyboard;
                @MovementKeyboard.canceled += instance.OnMovementKeyboard;
                @RotationKeyboard.started += instance.OnRotationKeyboard;
                @RotationKeyboard.performed += instance.OnRotationKeyboard;
                @RotationKeyboard.canceled += instance.OnRotationKeyboard;
                @InteractKeyboard.started += instance.OnInteractKeyboard;
                @InteractKeyboard.performed += instance.OnInteractKeyboard;
                @InteractKeyboard.canceled += instance.OnInteractKeyboard;
                @ShootKeyboard.started += instance.OnShootKeyboard;
                @ShootKeyboard.performed += instance.OnShootKeyboard;
                @ShootKeyboard.canceled += instance.OnShootKeyboard;
                @JumpKeyboard.started += instance.OnJumpKeyboard;
                @JumpKeyboard.performed += instance.OnJumpKeyboard;
                @JumpKeyboard.canceled += instance.OnJumpKeyboard;
                @MovementGamepad.started += instance.OnMovementGamepad;
                @MovementGamepad.performed += instance.OnMovementGamepad;
                @MovementGamepad.canceled += instance.OnMovementGamepad;
                @RotationGamepad.started += instance.OnRotationGamepad;
                @RotationGamepad.performed += instance.OnRotationGamepad;
                @RotationGamepad.canceled += instance.OnRotationGamepad;
                @InteractGamepad.started += instance.OnInteractGamepad;
                @InteractGamepad.performed += instance.OnInteractGamepad;
                @InteractGamepad.canceled += instance.OnInteractGamepad;
                @ShootGamepad.started += instance.OnShootGamepad;
                @ShootGamepad.performed += instance.OnShootGamepad;
                @ShootGamepad.canceled += instance.OnShootGamepad;
                @JumpGamepad.started += instance.OnJumpGamepad;
                @JumpGamepad.performed += instance.OnJumpGamepad;
                @JumpGamepad.canceled += instance.OnJumpGamepad;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnMovementKeyboard(InputAction.CallbackContext context);
        void OnRotationKeyboard(InputAction.CallbackContext context);
        void OnInteractKeyboard(InputAction.CallbackContext context);
        void OnShootKeyboard(InputAction.CallbackContext context);
        void OnJumpKeyboard(InputAction.CallbackContext context);
        void OnMovementGamepad(InputAction.CallbackContext context);
        void OnRotationGamepad(InputAction.CallbackContext context);
        void OnInteractGamepad(InputAction.CallbackContext context);
        void OnShootGamepad(InputAction.CallbackContext context);
        void OnJumpGamepad(InputAction.CallbackContext context);
    }
}
