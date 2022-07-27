using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageMenu : MonoBehaviour
{
   public void PlayTest ()
       {
        SceneManager.LoadScene("TestArea");
    }

    public void PlayTut ()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
