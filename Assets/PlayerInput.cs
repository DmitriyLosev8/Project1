//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/PlayerInput 1.inputactions
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

public partial class PlayerInput : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput 1"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""7b116bf9-f4eb-4621-9c21-e4a22f8b3caa"",
            ""actions"": [
                {
                    ""name"": ""Run"",
                    ""type"": ""Value"",
                    ""id"": ""8b4359ec-8bf8-487c-9c17-67df5d804c98"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""92a0c001-ff2b-442c-b876-97f4e6f41321"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Shot"",
                    ""type"": ""Button"",
                    ""id"": ""c64f917e-f18a-4ef1-a3d3-2481b99cdf87"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Wall Jump"",
                    ""type"": ""Button"",
                    ""id"": ""be95c585-b3b7-4126-a6c8-9a3a99374c38"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""NextBullet"",
                    ""type"": ""Value"",
                    ""id"": ""c027554f-d7a1-4934-8f07-2b650bd4081f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""PreviosBullet"",
                    ""type"": ""Value"",
                    ""id"": ""cfc4f6ef-6b18-4ee3-883c-e5b1db133b82"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""56fac6c8-ebac-49f6-b152-7e8427890f19"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""down"",
                    ""id"": ""98f4b171-86b5-4c5d-b81c-2d4fcf621585"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ac12290e-466d-4845-b06f-f7596d65ea8e"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""0b59845b-2487-478e-a7b0-c100336184de"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""0850a261-96a3-44d3-8d8f-935183195e5b"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""25f6d048-7b4e-43eb-8fdc-3d2acaf79dff"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""Shot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ed343d8c-058c-4a61-a75c-bdd32bb991b8"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""Wall Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a028bea2-15e3-4f8c-a186-b1835e5ae472"",
                    ""path"": ""<Mouse>/scroll/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""NextBullet"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c611dcd5-079d-4b47-b897-28235d8c144e"",
                    ""path"": ""<Mouse>/scroll/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""PreviosBullet"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""ThrowingHand"",
            ""id"": ""c3d1142f-456e-4cdf-a5af-be4239bce83c"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""86dda7d8-dd3f-4877-a080-c3d01b0a9bdd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Set Thow Direction"",
                    ""type"": ""PassThrough"",
                    ""id"": ""4da47e05-c324-4110-8e50-8eb206922dc5"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""43d83b61-9bb1-46d3-a8c0-5ef3388650c0"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""87d82182-99b8-4b11-9cb5-96fd7472f799"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Set Thow Direction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""8c07256c-3561-43c1-810d-adf752505159"",
            ""actions"": [
                {
                    ""name"": ""PauseButton"",
                    ""type"": ""Button"",
                    ""id"": ""0bd1b818-6757-458d-90dd-23f231404779"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8dbdb103-1e1e-4303-ae3a-99953aeb974c"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""PauseButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Blaster"",
            ""id"": ""1065cfad-0d5d-4313-8148-3ed8023eeebb"",
            ""actions"": [
                {
                    ""name"": ""Set  Direction"",
                    ""type"": ""PassThrough"",
                    ""id"": ""26ea3913-b91e-45f6-b541-2275cbb2a10d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f9983ab3-8e86-4fd6-9da8-fbf8a360dfaa"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Set  Direction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Mouse and Keyboard"",
            ""bindingGroup"": ""Mouse and Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Smartphone"",
            ""bindingGroup"": ""Smartphone"",
            ""devices"": [
                {
                    ""devicePath"": ""<Touchscreen>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<PressureSensor>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<StepCounter>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Run = m_Player.FindAction("Run", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_Shot = m_Player.FindAction("Shot", throwIfNotFound: true);
        m_Player_WallJump = m_Player.FindAction("Wall Jump", throwIfNotFound: true);
        m_Player_NextBullet = m_Player.FindAction("NextBullet", throwIfNotFound: true);
        m_Player_PreviosBullet = m_Player.FindAction("PreviosBullet", throwIfNotFound: true);
        // ThrowingHand
        m_ThrowingHand = asset.FindActionMap("ThrowingHand", throwIfNotFound: true);
        m_ThrowingHand_Newaction = m_ThrowingHand.FindAction("New action", throwIfNotFound: true);
        m_ThrowingHand_SetThowDirection = m_ThrowingHand.FindAction("Set Thow Direction", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_PauseButton = m_UI.FindAction("PauseButton", throwIfNotFound: true);
        // Blaster
        m_Blaster = asset.FindActionMap("Blaster", throwIfNotFound: true);
        m_Blaster_SetDirection = m_Blaster.FindAction("Set  Direction", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Run;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_Shot;
    private readonly InputAction m_Player_WallJump;
    private readonly InputAction m_Player_NextBullet;
    private readonly InputAction m_Player_PreviosBullet;
    public struct PlayerActions
    {
        private PlayerInput m_Wrapper;
        public PlayerActions(PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Run => m_Wrapper.m_Player_Run;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @Shot => m_Wrapper.m_Player_Shot;
        public InputAction @WallJump => m_Wrapper.m_Player_WallJump;
        public InputAction @NextBullet => m_Wrapper.m_Player_NextBullet;
        public InputAction @PreviosBullet => m_Wrapper.m_Player_PreviosBullet;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Run.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRun;
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Shot.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShot;
                @Shot.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShot;
                @Shot.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShot;
                @WallJump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWallJump;
                @WallJump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWallJump;
                @WallJump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWallJump;
                @NextBullet.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNextBullet;
                @NextBullet.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNextBullet;
                @NextBullet.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNextBullet;
                @PreviosBullet.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPreviosBullet;
                @PreviosBullet.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPreviosBullet;
                @PreviosBullet.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPreviosBullet;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Shot.started += instance.OnShot;
                @Shot.performed += instance.OnShot;
                @Shot.canceled += instance.OnShot;
                @WallJump.started += instance.OnWallJump;
                @WallJump.performed += instance.OnWallJump;
                @WallJump.canceled += instance.OnWallJump;
                @NextBullet.started += instance.OnNextBullet;
                @NextBullet.performed += instance.OnNextBullet;
                @NextBullet.canceled += instance.OnNextBullet;
                @PreviosBullet.started += instance.OnPreviosBullet;
                @PreviosBullet.performed += instance.OnPreviosBullet;
                @PreviosBullet.canceled += instance.OnPreviosBullet;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // ThrowingHand
    private readonly InputActionMap m_ThrowingHand;
    private IThrowingHandActions m_ThrowingHandActionsCallbackInterface;
    private readonly InputAction m_ThrowingHand_Newaction;
    private readonly InputAction m_ThrowingHand_SetThowDirection;
    public struct ThrowingHandActions
    {
        private PlayerInput m_Wrapper;
        public ThrowingHandActions(PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_ThrowingHand_Newaction;
        public InputAction @SetThowDirection => m_Wrapper.m_ThrowingHand_SetThowDirection;
        public InputActionMap Get() { return m_Wrapper.m_ThrowingHand; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ThrowingHandActions set) { return set.Get(); }
        public void SetCallbacks(IThrowingHandActions instance)
        {
            if (m_Wrapper.m_ThrowingHandActionsCallbackInterface != null)
            {
                @Newaction.started -= m_Wrapper.m_ThrowingHandActionsCallbackInterface.OnNewaction;
                @Newaction.performed -= m_Wrapper.m_ThrowingHandActionsCallbackInterface.OnNewaction;
                @Newaction.canceled -= m_Wrapper.m_ThrowingHandActionsCallbackInterface.OnNewaction;
                @SetThowDirection.started -= m_Wrapper.m_ThrowingHandActionsCallbackInterface.OnSetThowDirection;
                @SetThowDirection.performed -= m_Wrapper.m_ThrowingHandActionsCallbackInterface.OnSetThowDirection;
                @SetThowDirection.canceled -= m_Wrapper.m_ThrowingHandActionsCallbackInterface.OnSetThowDirection;
            }
            m_Wrapper.m_ThrowingHandActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Newaction.started += instance.OnNewaction;
                @Newaction.performed += instance.OnNewaction;
                @Newaction.canceled += instance.OnNewaction;
                @SetThowDirection.started += instance.OnSetThowDirection;
                @SetThowDirection.performed += instance.OnSetThowDirection;
                @SetThowDirection.canceled += instance.OnSetThowDirection;
            }
        }
    }
    public ThrowingHandActions @ThrowingHand => new ThrowingHandActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_PauseButton;
    public struct UIActions
    {
        private PlayerInput m_Wrapper;
        public UIActions(PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @PauseButton => m_Wrapper.m_UI_PauseButton;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @PauseButton.started -= m_Wrapper.m_UIActionsCallbackInterface.OnPauseButton;
                @PauseButton.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnPauseButton;
                @PauseButton.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnPauseButton;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PauseButton.started += instance.OnPauseButton;
                @PauseButton.performed += instance.OnPauseButton;
                @PauseButton.canceled += instance.OnPauseButton;
            }
        }
    }
    public UIActions @UI => new UIActions(this);

    // Blaster
    private readonly InputActionMap m_Blaster;
    private IBlasterActions m_BlasterActionsCallbackInterface;
    private readonly InputAction m_Blaster_SetDirection;
    public struct BlasterActions
    {
        private PlayerInput m_Wrapper;
        public BlasterActions(PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @SetDirection => m_Wrapper.m_Blaster_SetDirection;
        public InputActionMap Get() { return m_Wrapper.m_Blaster; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BlasterActions set) { return set.Get(); }
        public void SetCallbacks(IBlasterActions instance)
        {
            if (m_Wrapper.m_BlasterActionsCallbackInterface != null)
            {
                @SetDirection.started -= m_Wrapper.m_BlasterActionsCallbackInterface.OnSetDirection;
                @SetDirection.performed -= m_Wrapper.m_BlasterActionsCallbackInterface.OnSetDirection;
                @SetDirection.canceled -= m_Wrapper.m_BlasterActionsCallbackInterface.OnSetDirection;
            }
            m_Wrapper.m_BlasterActionsCallbackInterface = instance;
            if (instance != null)
            {
                @SetDirection.started += instance.OnSetDirection;
                @SetDirection.performed += instance.OnSetDirection;
                @SetDirection.canceled += instance.OnSetDirection;
            }
        }
    }
    public BlasterActions @Blaster => new BlasterActions(this);
    private int m_MouseandKeyboardSchemeIndex = -1;
    public InputControlScheme MouseandKeyboardScheme
    {
        get
        {
            if (m_MouseandKeyboardSchemeIndex == -1) m_MouseandKeyboardSchemeIndex = asset.FindControlSchemeIndex("Mouse and Keyboard");
            return asset.controlSchemes[m_MouseandKeyboardSchemeIndex];
        }
    }
    private int m_SmartphoneSchemeIndex = -1;
    public InputControlScheme SmartphoneScheme
    {
        get
        {
            if (m_SmartphoneSchemeIndex == -1) m_SmartphoneSchemeIndex = asset.FindControlSchemeIndex("Smartphone");
            return asset.controlSchemes[m_SmartphoneSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnRun(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnShot(InputAction.CallbackContext context);
        void OnWallJump(InputAction.CallbackContext context);
        void OnNextBullet(InputAction.CallbackContext context);
        void OnPreviosBullet(InputAction.CallbackContext context);
    }
    public interface IThrowingHandActions
    {
        void OnNewaction(InputAction.CallbackContext context);
        void OnSetThowDirection(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnPauseButton(InputAction.CallbackContext context);
    }
    public interface IBlasterActions
    {
        void OnSetDirection(InputAction.CallbackContext context);
    }
}
