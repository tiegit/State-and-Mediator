using UnityEngine;

namespace CharacterSceneScripts
{
    [CreateAssetMenu(menuName = "Configs/CharacterConfig", fileName = "CharacterConfig")]
    public class CharacterConfig : ScriptableObject
    {
        [Space(20), SerializeField] private RunningStateConfig _runningStateConfig;
        [Space(20), SerializeField] private AirbornStateConfig _airbornStateConfig;

        public RunningStateConfig RunningStateConfig => _runningStateConfig;
        public AirbornStateConfig AirbornStateConfig => _airbornStateConfig;
    }
}