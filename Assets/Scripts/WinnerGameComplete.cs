using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinnerGameComplete : MonoBehaviour
{
    private const string GameCompleteScene = "GameCompleteScene";

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player player))
        {
            SceneManager.LoadScene(GameCompleteScene);
        }
    }
}
