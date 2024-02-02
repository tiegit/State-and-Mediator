using UnityEngine;

namespace StateSceneScripts
{
    public interface IState
    {
        void Enter();
        void Exit();
        void HandleInput();
        void Update();
        void MoveTo(Vector3 position);
    }
}
