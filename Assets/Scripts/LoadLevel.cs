using UnityEngine;
using UnityEngine.SceneManagement;
using YG;
public class LoadLevel : MonoBehaviour
{
    public AudioClip Clip;

    private void Start()
    {
        if (YandexGame.SDKEnabled == true)
        {
          //  ResetLoad();
        }
    }
    private void Update()
    {
      //  if (StartTime >= EndTime)
      //  {
       //     StartTime = EndTime;
       // }
    }
    private void FixedUpdate()
    {
      //  StartTime += 0.5f * Time.deltaTime;
    }
    public void MainMenu()
    {
        //YandexGame.FullscreenShow();  
        SceneManager.LoadScene(0);
    }
    public void RestrtLevel()
    {
        // SceneManager.LoadScene(1);

        //  if (StartTime == 2f)
        // {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
      //  }
     //   SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void LevelPC()
    {
        // if (StartTime == 2f)
        //  {
       // YandexGame.FullscreenShow();
            SceneManager.LoadScene(1);
      // }
     //   SceneManager.LoadScene(3);
    }
    public void ResetLoad()
    {
        YandexGame.ResetSaveProgress();

        YandexGame.SaveProgress();
    }

}
