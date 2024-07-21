using UnityEngine;
using UnityEngine.SceneManagement;

public class FeedbackUIHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnRetryBtnClicked()
    {
        SceneManager.LoadScene(0);
    }
    public void OnPlayerLose()
    {
        this.GetComponent<Canvas>().enabled = true;
    }
}
