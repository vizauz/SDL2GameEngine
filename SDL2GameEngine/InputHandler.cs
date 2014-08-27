using System;
using System.Collections.Generic;
using SDL2;
using OpenTK;

namespace SDL2GameEngine
{
    class InputHandler
    {

        static readonly InputHandler _instance = new InputHandler();
        public static InputHandler Instance { get { return _instance; } }

        bool [] mouseButtonStates = new bool[3];
        
        Vector2d _mousePosition = new Vector2d();
        public Vector2d MousePosition
        {
            get
            {
                return _mousePosition;
            }
        }

        Dictionary<SDL.SDL_Scancode, bool> keyboard = new Dictionary<SDL.SDL_Scancode, bool>()
        {
            { SDL.SDL_Scancode.SDL_SCANCODE_UNKNOWN ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_A ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_B ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_C ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_D ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_E ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_F ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_G ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_H ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_I ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_J ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_K ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_L ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_M ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_N ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_O ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_P ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_Q ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_R ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_S ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_T ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_U ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_V ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_W ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_X ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_Y ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_Z ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_1 ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_2 ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_3 ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_4 ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_5 ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_6 ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_7 ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_8 ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_9 ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_0 ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_RETURN ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_ESCAPE ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_BACKSPACE ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_TAB ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_SPACE ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_MINUS ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_EQUALS ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_LEFTBRACKET ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_RIGHTBRACKET ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_BACKSLASH ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_NONUSHASH ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_SEMICOLON ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_APOSTROPHE ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_GRAVE ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_COMMA ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_PERIOD ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_SLASH ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_CAPSLOCK ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_F1 ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_F2 ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_F3 ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_F4 ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_F5 ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_F6 ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_F7 ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_F8 ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_F9 ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_F10 ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_F11 ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_F12 ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_PRINTSCREEN ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_SCROLLLOCK ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_PAUSE ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_INSERT ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_HOME ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_PAGEUP ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_DELETE ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_END ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_PAGEDOWN ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_RIGHT ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_LEFT ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_DOWN ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_UP ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_NUMLOCKCLEAR ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_KP_DIVIDE ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_KP_MULTIPLY ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_KP_MINUS ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_KP_PLUS ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_KP_ENTER ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_KP_1 ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_KP_2 ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_KP_3 ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_KP_4 ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_KP_5 ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_KP_6 ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_KP_7 ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_KP_8 ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_KP_9 ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_KP_0 ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_KP_PERIOD ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_NONUSBACKSLASH ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_APPLICATION ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_POWER ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_KP_EQUALS ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_F13 ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_F14 ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_F15 ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_F16 ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_F17 ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_F18 ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_F19 ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_F20 ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_F21 ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_F22 ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_F23 ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_F24 ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_EXECUTE ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_HELP ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_MENU ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_SELECT ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_STOP ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_AGAIN ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_UNDO ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_CUT ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_COPY ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_PASTE ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_FIND ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_MUTE ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_VOLUMEUP ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_VOLUMEDOWN ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_KP_COMMA ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_KP_EQUALSAS400 ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_INTERNATIONAL1 ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_INTERNATIONAL2 ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_INTERNATIONAL3 ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_INTERNATIONAL4 ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_INTERNATIONAL5 ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_INTERNATIONAL6 ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_INTERNATIONAL7 ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_INTERNATIONAL8 ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_INTERNATIONAL9 ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_LANG1 ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_LANG2 ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_LANG3 ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_LANG4 ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_LANG5 ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_LANG6 ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_LANG7 ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_LANG8 ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_LANG9 ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_ALTERASE ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_SYSREQ ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_CANCEL ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_CLEAR ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_PRIOR ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_RETURN2 ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_SEPARATOR ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_OUT ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_OPER ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_CLEARAGAIN ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_CRSEL ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_EXSEL ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_KP_00 ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_KP_000 ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_THOUSANDSSEPARATOR ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_DECIMALSEPARATOR ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_CURRENCYUNIT ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_CURRENCYSUBUNIT ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_KP_LEFTPAREN ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_KP_RIGHTPAREN ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_KP_LEFTBRACE ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_KP_RIGHTBRACE ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_KP_TAB ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_KP_BACKSPACE ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_KP_A ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_KP_B ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_KP_C ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_KP_D ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_KP_E ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_KP_F ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_KP_XOR ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_KP_POWER ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_KP_PERCENT ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_KP_LESS ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_KP_GREATER ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_KP_AMPERSAND ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_KP_DBLAMPERSAND ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_KP_VERTICALBAR ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_KP_DBLVERTICALBAR ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_KP_COLON ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_KP_HASH ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_KP_SPACE ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_KP_AT ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_KP_EXCLAM ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_KP_MEMSTORE ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_KP_MEMRECALL ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_KP_MEMCLEAR ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_KP_MEMADD ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_KP_MEMSUBTRACT ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_KP_MEMMULTIPLY ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_KP_MEMDIVIDE ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_KP_PLUSMINUS ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_KP_CLEAR ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_KP_CLEARENTRY ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_KP_BINARY ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_KP_OCTAL ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_KP_DECIMAL ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_KP_HEXADECIMAL ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_LCTRL ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_LSHIFT ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_LALT ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_LGUI ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_RCTRL ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_RSHIFT ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_RALT ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_RGUI ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_MODE ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_AUDIONEXT ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_AUDIOPREV ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_AUDIOSTOP ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_AUDIOPLAY ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_AUDIOMUTE ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_MEDIASELECT ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_WWW ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_MAIL ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_CALCULATOR ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_COMPUTER ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_AC_SEARCH ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_AC_HOME ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_AC_BACK ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_AC_FORWARD ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_AC_STOP ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_AC_REFRESH ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_AC_BOOKMARKS ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_BRIGHTNESSDOWN ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_BRIGHTNESSUP ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_DISPLAYSWITCH ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_KBDILLUMTOGGLE ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_KBDILLUMDOWN ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_KBDILLUMUP ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_EJECT ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_SLEEP ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_APP1 ,false },
            { SDL.SDL_Scancode.SDL_SCANCODE_APP2 ,false },
            { SDL.SDL_Scancode.SDL_NUM_SCANCODES ,false }
        };

        public InputHandler()
        {
            for (int i = 0; i < 3; i++)
                mouseButtonStates[i] = false;
        }

        public void Update() 
        {
            SDL.SDL_Event _event;

            while (SDL.SDL_PollEvent(out _event) > 0)
            {
                switch (_event.type)
                {
                    case SDL.SDL_EventType.SDL_QUIT:
                        Game.Instance.Running = false;
                        break;
                    case SDL.SDL_EventType.SDL_MOUSEBUTTONDOWN:
                        OnMouseButtonDown(_event);
                        break;
                    case SDL.SDL_EventType.SDL_MOUSEBUTTONUP:
                        OnMouseButtonUp(_event);
                        break;
                    case SDL.SDL_EventType.SDL_MOUSEMOTION:
                        OnMouseMove(_event);
                        break;
                    case SDL.SDL_EventType.SDL_KEYDOWN:
                        OnKeyDown(_event);
                        break;
                    case SDL.SDL_EventType.SDL_KEYUP:
                        OnKeyUp(_event);
                        break;
                    default:
                        break;
                }
            }
        }

        private void OnKeyUp(SDL.SDL_Event _event)
        {
            if (_event.type == SDL.SDL_EventType.SDL_KEYUP)
            {
                keyboard[_event.key.keysym.scancode] = false;
            }
        }

        private void OnKeyDown(SDL.SDL_Event _event)
        {
            if (_event.type == SDL.SDL_EventType.SDL_KEYDOWN)
            {
                keyboard[_event.key.keysym.scancode] = true;
            }
        }

        private void OnMouseMove(SDL.SDL_Event _event)
        {
            if (_event.type == SDL.SDL_EventType.SDL_MOUSEMOTION)
            {
                _mousePosition.X = _event.motion.x;
                _mousePosition.Y = _event.motion.y;
            }
        }

        private void OnMouseButtonDown(SDL.SDL_Event _event)
        {
            if (_event.type == SDL.SDL_EventType.SDL_MOUSEBUTTONDOWN)
            {
                if (_event.button.button == SDL.SDL_BUTTON_LEFT)
                {
                    mouseButtonStates[(int)MouseButtons.LEFT] = true;
                }

                if (_event.button.button == SDL.SDL_BUTTON_MIDDLE)
                {
                    mouseButtonStates[(int)MouseButtons.MIDDLE] = true;
                }

                if (_event.button.button == SDL.SDL_BUTTON_RIGHT)
                {
                    mouseButtonStates[(int)MouseButtons.RIGHT] = true;
                }
            }
        }

        private void OnMouseButtonUp(SDL.SDL_Event _event)
        {
            if (_event.type == SDL.SDL_EventType.SDL_MOUSEBUTTONUP)
            {
                if (_event.button.button == SDL.SDL_BUTTON_LEFT)
                {
                    mouseButtonStates[(int)MouseButtons.LEFT] = false;
                }

                if (_event.button.button == SDL.SDL_BUTTON_MIDDLE)
                {
                    mouseButtonStates[(int)MouseButtons.MIDDLE] = false;
                }

                if (_event.button.button == SDL.SDL_BUTTON_RIGHT)
                {
                    mouseButtonStates[(int)MouseButtons.RIGHT] = false;
                }
            }
        }

        public bool GetMouseButtonState(MouseButtons button)
        {
            return mouseButtonStates[(int)button];
        }

        public bool IsKeyDown(SDL.SDL_Scancode key)
        {
            return keyboard[key];
        }
    }
}
