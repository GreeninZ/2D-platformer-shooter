using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RESUME : MonoBehaviour
{
    public GameObject objectotdisable;
    public void resume()
    {
        Time.timeScale = 1;
        objectotdisable.SetActive(false);
    }
}
