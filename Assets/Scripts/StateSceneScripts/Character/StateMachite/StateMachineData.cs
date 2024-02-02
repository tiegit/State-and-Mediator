namespace StateSceneScripts
{
    public class StateMachineData
    {
        private float _health;
        private float _energy;

        private Character _character;

        public StateMachineData(Character character)
        {
            _character = character;
            _health = character.Config.StartHealth;
            _energy = character.Config.StartEnergy;
        }

        public float Health
        {
            get => _health;
            set
            {
                if (value < 0)
                    _health = 0;
                else if(value > _character.Config.MaxHealth)
                    _health = _character.Config.MaxHealth;
                else
                    _health = value;
            }
        }

        public float Energy
        {
            get => _energy;
            set
            {
                if (value < 0)
                    _energy = 0;
                else if (value > _character.Config.MaxEnergy)
                    _energy = _character.Config.MaxEnergy;
                else
                    _energy = value;
            }
        }
    }
}
