using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelChecker : MonoBehaviour
{
    public TextMeshProUGUI display_Text;

    // Update is called once per frame
    void Awake()
    {
        display_Text.text = SceneManager.GetActiveScene().name;
    }
}
