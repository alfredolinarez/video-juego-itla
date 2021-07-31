using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// Creates a wave to be assigned  to a SpawnManager.
    /// </summary>
    [System.Serializable]
    public class Wave
    {
        public string WaveName;
        public List<Element> ObjectsToInstantiate;
        public GameObject WaveContainer;
    }
}