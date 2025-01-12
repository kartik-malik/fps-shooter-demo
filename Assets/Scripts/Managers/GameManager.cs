using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] GameObject winText;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Restart()
    {
        int currentIdx = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentIdx);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void PlayerWon()
    {
        winText.SetActive(true);
    }
}
