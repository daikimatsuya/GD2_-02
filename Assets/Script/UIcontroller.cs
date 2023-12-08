using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIcontroller : MonoBehaviour
{
    GameObject playerHpBar;

    public float playerHpBuff;
    private float playerHpBarMove;
    private float playerHpBuffMax;
    private float playerHpYScale;


    public void SendPlayerHp(float hp)
    {
        playerHpBuff = hp;
    }
    public void SendPlayerHpMax(float hpM)
    {
        playerHpBuffMax=hpM;
    }
    private void PlayerHpBar()
    {
        playerHpBar.transform.localScale = new Vector3(1.0f, playerHpYScale / playerHpBuffMax * playerHpBuff);
        playerHpBar.transform.localPosition = new Vector2(-465, -200 - playerHpBarMove * (playerHpBuffMax - playerHpBuff));
    }
    private void EnemyUIcontroller()
    {

    }
    private void PlayerUIcontroller()
    {
        PlayerHpBar();
    }
    // Start is called before the first frame update
    void Start()
    {
        playerHpBar = GameObject.FindWithTag("PlayerHpBar");
        playerHpYScale = 15.0f;
        playerHpBar.transform.localScale = new Vector2(1.0f, 15.0f);
        playerHpBarMove = 110;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerUIcontroller();
    }
}
