using System;

namespace MediatorSceneScripts
{
    public class ViewPanelsMediator
    {
        public event Action DefeatPanelOpened;
        public event Action<int> LevelChanged;
        public event Action<int> HealthChanged;

        public void OnDefeat() => DefeatPanelOpened?.Invoke();

        public void SetLevel(int level) => LevelChanged?.Invoke(level);

        public void SetHealth(int health) => HealthChanged?.Invoke(health);
    }
}
