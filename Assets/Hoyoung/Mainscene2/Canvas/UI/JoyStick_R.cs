using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JoyStick_R : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    //public GameObject character; // 캐릭터 오브젝트.
    public RectTransform touchArea; // Joystick Touch Area 이미지의 RectTransform.
    public Image outerPad; // OuterPad 이미지.
    public Image innerPad; // InnerPad 이미지.

    public Vector2 joystickVector; // 조이스틱의 방향벡터이자 플레이어에게 넘길 방향정보.
    
    
    public Vector2 PointerUpVect; // 조이스틱 뗄 때 방향벡터 : 총알 방향 벡터
    
    public bool IsShooting = false; // 현재 총알 나가고 있는 중인지 확인해서 나가고 있는 중에 방향 벡터 안 받게 하면 오류 제거 가능


    private RectTransform rectTransform;
    //출처: https://wergia.tistory.com/231 [베르의 프로그래밍 노트]
    

    //private float rotateSpeed = 5f; // 회전 속도



    //Element element;

    //Skill_Point skillpoint;
    //Skill_Upgrade skillupgrade;
    //private Coroutine runningCoroutine; // 부드러운 회전 코루틴
    //static public float speed = 3f; // 캐릭터 스피드

    Player_Fire player_fire;

    void Start()
    {
        //element = GameObject.Find("Character").GetComponent<Element>();
        //skillupgrade = GameObject.Find("Character").GetComponent<Skill_Upgrade>();

        player_fire = GameObject.Find("Character").GetComponent<Player_Fire>();

        rectTransform = GetComponent<RectTransform>();
    }


    public void OnDrag(PointerEventData eventData )
    {
        if (Pause.IsPause == false)
        {
            var inputDir = eventData.position - rectTransform.anchoredPosition;
            innerPad.rectTransform.anchoredPosition = inputDir;
            ////출처: https://wergia.tistory.com/231 [베르의 프로그래밍 노트]

            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(touchArea,
            eventData.position, eventData.pressEventCamera, out Vector2 localPoint))
            {
                localPoint.x = ((localPoint.x - rectTransform.anchoredPosition.x) / touchArea.sizeDelta.x); // localPoint.x -> localPoint.x - rectTransform.anchoredPosition.x
                localPoint.y = ((localPoint.y - rectTransform.anchoredPosition.y) / touchArea.sizeDelta.y);
                // Joystick Touch Area의 비율 구하기 ( -0.5 ~ 0.5 )

                joystickVector = new Vector2(localPoint.x * 2.6f, localPoint.y * 2);
                // 조이스틱 벡터 조절 (2.6과 2를 곱해준 것은 TouchArea의 비율 때문임)


                //TurnAngle(joystickVector);
                // Character에게 조이스틱 방향 넘기기

                //Utility(joystickVector);
                //조이스틱 방향 넘기기

                joystickVector = (joystickVector.magnitude > 0.35f) ? joystickVector.normalized * 0.35f : joystickVector;
                // innerPad 이미지가 outerPad를 넘어간다면 위치 조절해주기

                innerPad.rectTransform.anchoredPosition = new Vector2(joystickVector.x * (outerPad.rectTransform.sizeDelta.x),
                    joystickVector.y * (outerPad.rectTransform.sizeDelta.y));
                // innerPad 이미지 터치한 곳으로 옮기기
            }
        }
        
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        if (Pause.IsPause == false)
        {
            OnDrag(eventData); // 터치가 시작되면 OnDrag 처리.

            //var inputDir = eventData.position - rectTransform.anchoredPosition;
            //innerPad.rectTransform.anchoredPosition = inputDir;
            ////출처: https://wergia.tistory.com/231 [베르의 프로그래밍 노트]
        }


    }


    public void OnPointerUp(PointerEventData eventData)
    {
        // 손 땔 떼 방향 벡터 얻어오기
        // 발사중이 아닐 때만 방향 벡터 얻어옴
        if (Pause.IsPause == false)
        {
            if (IsShooting == false)
            {
                if (RectTransformUtility.ScreenPointToLocalPointInRectangle(touchArea,
               eventData.position, eventData.pressEventCamera, out Vector2 localPoint))
                {
                    localPoint.x = ((localPoint.x - rectTransform.anchoredPosition.x) / touchArea.sizeDelta.x);
                    localPoint.y = ((localPoint.y - rectTransform.anchoredPosition.y) / touchArea.sizeDelta.y);
                    // Joystick Touch Area의 비율 구하기 ( -0.5 ~ 0.5 )

                    PointerUpVect = new Vector2(localPoint.x * 2.6f, localPoint.y * 2);
                    // 조이스틱 벡터 조절 (2.6과 2를 곱해준 것은 TouchArea의 비율 때문임)


                    //TurnAngle(joystickVector);
                    // Character에게 조이스틱 방향 넘기기

                    //Utility(joystickVector);
                    //조이스틱 방향 넘기기

                    PointerUpVect = (PointerUpVect.magnitude > 0.35f) ? PointerUpVect.normalized * 0.35f : PointerUpVect;
                    // innerPad 이미지가 outerPad를 넘어간다면 위치 조절해주기

                    innerPad.rectTransform.anchoredPosition = new Vector2(PointerUpVect.x * (outerPad.rectTransform.sizeDelta.x),
                        PointerUpVect.y * (outerPad.rectTransform.sizeDelta.y));
                    // innerPad 이미지 터치한 곳으로 옮기기

                    //Debug.Log(PointerUpVect.normalized + "이건가1");
                }

            }

            //
            //Debug.Log(PointerUpVect.normalized + "이건가2");

            player_fire.playerFire(); // 터치가 끝날 때 발동

            innerPad.rectTransform.anchoredPosition = Vector2.zero;
        }
            
    }
    
}