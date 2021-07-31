using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// This class should be attached to all wave elements.
    /// </summary>
    public class WaveElementController : MonoBehaviour
    {
        public string WaveName;
        public string ElementName;

        /// <summary>
        /// Updates the wave by removing this object from there.
        /// </summary>
        public void UpdateWave()
        {
            SpawnManager.RemoveElementFromWave(WaveName, gameObject.name);
        }
    }
}