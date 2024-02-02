namespace MediatorSceneScripts
{
    public interface IRestartLevel
    {
        public void BlockPlayerInput();

        public void UnblockPlayerInput();

        public void RestartGame();
    }
}