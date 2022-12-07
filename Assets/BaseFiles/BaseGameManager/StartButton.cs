 using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void LoadScene(int i)
    {
        BaseGameManager.LoadScene(false,1, 2);
    }
}
