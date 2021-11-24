using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
namespace ArcadeCabinets.Games.Bases {
    internal struct ControllerState {
        KeyboardState pastKeyboardState;
        KeyboardState currentKeyboardState;

        MouseState pastMouseState;
        MouseState currentMouseState;

        public void Update() {
            pastKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();

            pastMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();
        }

        // god i hate xna why are buttonstates and keys distinguished
        public KeyPressedState GetKeyPressedState(Keys key) {
            var current = currentKeyboardState.IsKeyDown(key);
            var past = pastKeyboardState.IsKeyDown(key);

            if (current && !past)
                return KeyPressedState.Pressed;
            else if (current && past)
                return KeyPressedState.Held;
            else if (!current && past)
                return KeyPressedState.Released;
            return KeyPressedState.Uninteracted;
        }

        private KeyPressedState GetMousePressedState(ButtonState button, ButtonState oldButton) {
            var current = button == ButtonState.Pressed;
            var past = oldButton == ButtonState.Pressed;

            if (current && !past)
                return KeyPressedState.Pressed;
            else if (current && past)
                return KeyPressedState.Held;
            else if (!current && past)
                return KeyPressedState.Released;
            return KeyPressedState.Uninteracted;
        }

        public KeyPressedState GetLeftClickState() =>
            GetMousePressedState(currentMouseState.LeftButton, pastMouseState.LeftButton);
        public Point GetMousePosition() =>
            new Point(currentMouseState.X, currentMouseState.Y);
    }

    enum KeyPressedState {
        Pressed,
        Held,
        Released,
        Uninteracted
    }
}
