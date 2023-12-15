using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    private Player player;
    private Enemy enemy;
    public string clear;
    public string dead;
    private void SceneChanges(string nextSceneName)
    {
        SceneManager.LoadScene(nextSceneName);
    }

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        Screen.SetResolution(1080, 1280, false);

        player=GameObject.FindWithTag("Player").GetComponent<Player>();
        enemy=GameObject.FindWithTag("Enemy").GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.SendHp() <= 0)
        {
            SceneChanges(clear);
        }
        if(enemy.SendHp() <= 0)
        {
            SceneChanges(dead);
        }
    }
}
