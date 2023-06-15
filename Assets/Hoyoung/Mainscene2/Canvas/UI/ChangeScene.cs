using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    /* 씬 바꾸기 */

    public void ChangeToMain()
    {
        LoadingSceneManager.LoadScene("Main");
    }

    public void ChangeToTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void ChangeToHowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }
    public void ChangeToHowToPlay2()
    {
        SceneManager.LoadScene("HowToPlay2");
    }
    public void ChangeToHowToPlay2_5()
    {
        SceneManager.LoadScene("HowToPlay2.5");
    }

    public void ChangeToCredit()
    {
        SceneManager.LoadScene("Credit");
    }
    public void CHangeToHowToPlay3()
    {
        SceneManager.LoadScene("HowToPlay3");
    }
    
    public void ChangeToHowToplay4()
    {
        SceneManager.LoadScene("HowToPlay4");
    }
}


