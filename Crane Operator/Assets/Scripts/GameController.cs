using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private GameObject kran;

    public void RestartGame()
    {
        Destroy(kran);
        StartCoroutine(Loader());

        IEnumerator Loader()
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
            yield return null;
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
