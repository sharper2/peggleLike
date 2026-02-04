using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using PhysicsLibrary.Interfaces;

namespace PhysicsLibrary.Controllers
{
    public class KeyboardController : IController
    {
        private IPositionable _thing;
        private Dictionary<Keys, Vector2> _keyBindings;
        private Vector2 _velocity;

        public KeyboardController(IPositionable thing)
        {
            _thing = thing;
            SetInputs();
            _velocity = Vector2.Zero;
        }

        public void SetInputs()
        {
            _keyBindings = new Dictionary<Keys, Vector2>
                {
                    { Keys.Left, new Vector2(-5f, 0) },
                    { Keys.Right, new Vector2(5f, 0) },
                    { Keys.Down, new Vector2(0, 5f) },
                    { Keys.Up, new Vector2(0, -5f) }
                };
        }

        public void Update(GameTime gameTime)
        {
            _velocity = Vector2.Zero;

            var keyboard = Keyboard.GetState();

            foreach (var binding in _keyBindings)
                if (keyboard.IsKeyDown(binding.Key))
                    _velocity += binding.Value;

            Vector2 temp = _thing.Position;
            _thing.Position = temp + _velocity;
        }
    }
}