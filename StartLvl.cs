using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLvl : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
