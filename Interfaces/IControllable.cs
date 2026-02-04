using Microsoft.Xna.Framework;

namespace PhysicsLibrary.Interfaces
{
    public interface IControllable
    {
        Vector2 Position { get; set; }
        void MoveLeft();
        void MoveRight();
        void MoveDown();
        void MoveUp();
    }
}