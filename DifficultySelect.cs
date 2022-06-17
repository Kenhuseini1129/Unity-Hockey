using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultySelect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Easy()
    {
        SceneManager.LoadScene("Easy");
    }

    public void Normal()
    {
        SceneManager.LoadScene("Normal");
    }

    public void Hard()
    {
        SceneManager.LoadScene("Hard");
    }
}
