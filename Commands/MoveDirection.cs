using Microsoft.Xna.Framework;
using PhysicsLibrary.Interfaces;

namespace PhysicsLibrary.Commands
{
    public class MoveDirection : ICommand
    {
        private IPositionable _thing;
        private Vector2 _velocity;

        public MoveDirection(IPositionable thing, Vector2 velocity)
        {
            _thing = thing;
            _velocity = velocity;
        }

        public void Execute()
        {
            _thing.Position += _velocity;
        }
    }
}