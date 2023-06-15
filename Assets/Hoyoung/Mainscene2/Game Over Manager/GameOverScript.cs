using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{

    public GameObject player;
    public GameObject CountDownTimer;
    public int TowerNumber;
    public bool isGameover = false;
    public float TimeLimit;
    public Text TimerText;

    public AudioSource audioSource;
    bool Isplayed = false;


    void countdown() // 카운트다운 함수
    {
        CountDownTimer.SetActive(true);
        TimeLimit -= Time.deltaTime;

        if (TimeLimit <= 10)
        {
            TimerText.text = "HURRY! " + Mathf.Round(TimeLimit);

            if(Isplayed == false)
            {
                audioSource.Play();
                Isplayed = true;
            }
        }
        else if (TimeLimit <= 60)
        {
            audioSource.Stop();
            Isplayed = false;
            TimerText.text = "HURRY!";
        }
        else
        {
            audioSource.Stop();
            Isplayed = false;
        }

        
    }


    void ResetandHideTimer() //시간 리셋과 숨기기
    {
        TimeLimit = 60; //다시 시간을 60초로 설정
        audioSource.Stop();
        Isplayed = false;
        CountDownTimer.SetActive(false); //카운트다운타이머를 setactive false시킴
    }

    void GameOverActivate()
    {

        if (TimeLimit < 0 || GameObject.Find("Character").GetComponent<Hp>().hp < 0) // 남은 시간이 0이거나 플레이어의 체력이 0보다 낮을 경우라면
        {

            isGameover = true; // 게임 오버 BOOL 활성화를 시키고,

            if (isGameover == true)// 게임 오버 활성화가 참이라면,
            {
                SceneManager.LoadScene("GameOverScene"); // 게임오버 씬으로 넘어가라
            }

        }

    }

    void Update()
    {
        TowerNumber = GameObject.Find("Map Example").GetComponent<TowerSpawn>().TowerCount;

        if (TowerNumber == 8) //타워의 개수가 8개라면
        {
            countdown(); // 카운트다운 실행시켜라

            // curTime 초기화 해줘야 타워가 부서지고 바로 다시 안 생김
            GameObject.Find("Map Example").GetComponent<TowerSpawn>().curTime = 0.0f;
        }

        else
        {
            ResetandHideTimer(); //아니라면 시간을 10으로 리셋시키고 숨기기 시켜라
        } 

            GameOverActivate(); // 게임 오버 실행 조건확인

    }
}
