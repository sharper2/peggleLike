using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using PhysicsLibrary.Interfaces;

namespace PhysicsLibrary.Controllers
{
    public class MouseController : IController
    {
        private Game1 _game;
        private Vector2 _anchor;
        private Vector2 _position;

        private float _gravity;

        public MouseController(Game1 game)
        {
            _game = game;
            _anchor = new Vector2(game.Window.ClientBounds.Width, 0) * 0.5f;
            _position = Vector2.Zero;
            _gravity = 750f;
        }

        public void SetInputs()
        {
            
        }

        public void Update(GameTime gameTime)
        {
            var mouse = Mouse.GetState();
            _position = new Vector2(mouse.X, mouse.Y);

            if (mouse.LeftButton == ButtonState.Pressed)
            {
                // compute multiplier
                float launchY = 600f;
                float yDistance = _position.Y - _anchor.Y;
                float t = (-launchY + MathF.Sqrt(launchY * launchY + 2f * _gravity * yDistance)) / _gravity;
                t = MathF.Max(t, 0.05f);

                Vector2 velocity = _position - _anchor;
                velocity = new Vector2(velocity.X / t, launchY);

                /*float dy = _position.Y - _anchor.Y;
                float dx = _position.X - _anchor.X;

                float vy = 500f;

                // solve using: dy = vy * t + 0.5gt^2
                float discriminant = vy * vy + 2f * _gravity * dy;
                if (discriminant < 0)
                    discriminant = 0;

                float t = (-vy + MathF.Sqrt(discriminant)) / _gravity;
                t = MathF.Max(t, 0.05f);

                float vx = dx / t;
                Vector2 ballistic = new Vector2(vx, vy);

                Vector2 direction = Vector2.Normalize(ballistic);*/

                _game.FireBall(velocity);
            }
        }
    }
}