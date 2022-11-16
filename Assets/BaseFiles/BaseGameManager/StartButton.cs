 using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void LoadScene(int i)
    {
        BaseGameManager.LoadScene(1, 2);
    }
}
