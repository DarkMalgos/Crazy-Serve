using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class menucontroller : MonoBehaviour
{
    public void restart() => SceneManager.LoadScene("Flo_test");

    public void leave() => Application.Quit();
}
