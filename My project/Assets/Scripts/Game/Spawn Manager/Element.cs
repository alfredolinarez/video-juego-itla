using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// Wave Element.
    /// </summary>
    [System.Serializable]
    public class Element
    {
        public GameObject Object;
        public float TimeToInstantiate;
        public float DelayBetweenThem;
        [Header("Amount")]
        public int TotalAmount;
        [HideInInspector] public int CurrentAmount;
        [HideInInspector] public bool FinishedSpawning;
    }
}