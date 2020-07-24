using Game.Common.GameEvents;

namespace Game.Common.UI
{
    public class CanvasController : IInitializable
    {
        public EInitializationOrder InitializationOrder => EInitializationOrder.Common;

        private readonly ICanvasCamera _camera;
        private readonly ICanvasView _canvas;

        public CanvasController(ICanvasCamera camera,
                                ICanvasView canvas)
        {
            _camera = camera;
            _canvas = canvas;
        }

        public void Initialize()
        {
            _canvas.SetCamera(_camera.Camera);
        }
    }
}
