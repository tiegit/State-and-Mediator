using System;
using UnityEngine;

namespace StateSceneScripts
{
    [Serializable]
    public class WorkingStateConfig
    {
        [SerializeField] private Vector3 _workPoint;

        public Vector3 WorkPoint => _workPoint;
    }
}
