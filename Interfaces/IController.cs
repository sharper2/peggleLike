using Microsoft.Xna.Framework;

namespace PhysicsLibrary.Interfaces
{
    public interface IController
    {
        void Update(GameTime gameTime);
        void SetInputs();
    }
}