using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class LoadScene : MonoBehaviour
    {
        public void LoadSceneByName(string name)
        {
            if (GameManager.Instance.IsLoading)
                return;

            GameManager.Instance.LoadScene(name);
        }
    }
}