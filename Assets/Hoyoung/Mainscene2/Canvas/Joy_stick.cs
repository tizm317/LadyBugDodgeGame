using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Joy_stick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public GameObject character; // 캐릭터 오브젝트.
    public RectTransform touchArea; // Joystick Touch Area 이미지의 RectTransform.
    public Image outerPad; // OuterPad 이미지.
    public Image innerPad; // InnerPad 이미지.

    private Vector2 joystickVector; // 조이스틱의 방향벡터이자 플레이어에게 넘길 방향정보.

    static public float speed = 3.2f; // 캐릭터 스피드
    
    // 토 속성 슬로우 걸렸을 때
    public float slow = 0.1f; // 캐릭터 스피드에 곱해줌 / 평소에는 1f 라 그대로 이지만 / 슬로우(토 속성 총알) 맞으면 느리게 숫자 바꿈
    public bool IsSlow = false; // 슬로우 걸렸는지
    float SlowTime = 1f;
    
    private float rotateSpeed = 7f; // 회전 속도

    private Coroutine runningCoroutine; // 부드러운 회전 코루틴


    void Start()
    {
        //runningCoroutine = StartCoroutine(RotateAngle(180, -1));
        // 시작하면 charactor를 180도 오른쪽으로 회전
    }


    void Update()
    {
        //character.GetComponent<Rigidbody2D>().velocity = character.transform.up * speed * slow; // 
        if(IsSlow == false)
            character.GetComponent<Rigidbody2D>().velocity = character.transform.up * speed;
        else if(IsSlow == true)
        {
            character.GetComponent<Rigidbody2D>().velocity = character.transform.up * speed * slow;
            // 캐릭터는 (3 * slow)의 속도로 계속 전진

            SlowTime -= Time.deltaTime;
            if(SlowTime <= 0.0)
            {
                SlowTime = 1f;
                IsSlow = false;
            }
        }
    }


    public void OnDrag(PointerEventData eventData)
    {
        if (Pause.IsPause == false)
        {
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(touchArea,
            eventData.position, eventData.pressEventCamera, out Vector2 localPoint))
            {
                localPoint.x = ((localPoint.x - outerPad.rectTransform.anchoredPosition.x) / touchArea.sizeDelta.x);
                localPoint.y = ((localPoint.y - outerPad.rectTransform.anchoredPosition.y) / touchArea.sizeDelta.y);
                // Joystick Touch Area의 비율 구하기 ( -0.5 ~ 0.5 )

                joystickVector = new Vector2(localPoint.x * 2.6f, localPoint.y * 2);
                // 조이스틱 벡터 조절 (2.6과 2를 곱해준 것은 TouchArea의 비율 때문임)

                TurnAngle(joystickVector);
                // Character에게 조이스틱 방향 넘기기

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
            OnDrag(eventData); // 터치가 시작되면 OnDrag 처리.
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        innerPad.rectTransform.anchoredPosition = Vector2.zero;
    }


    private void TurnAngle(Vector3 currentJoystickVec)
    {
        Vector3 originJoystickVec = character.transform.up;
        // character가 바라보고 있는 벡터

        float angle = Vector3.Angle(currentJoystickVec, originJoystickVec);
        int sign = (Vector3.Cross(currentJoystickVec, originJoystickVec).z > 0) ? -1 : 1;
        // angle: 현재 바라보고 있는 벡터와, 조이스틱 방향 벡터 사이의 각도
        // sign: character가 바라보는 방향 기준으로, 왼쪽:+ 오른쪽:-

        if (runningCoroutine != null)
        {
            StopCoroutine(runningCoroutine);
        }
        runningCoroutine = StartCoroutine(RotateAngle(angle, sign));
        // 코루틴이 실행중이면 실행 중인 코루틴 중단 후 코루틴 실행 
        // 코루틴이 한 개만 존재하도록.
        // => 회전 중에 새로운 회전이 들어왔을 경우, 회전 중이던 것을 멈추고 새로운 회전을 함.
    }


    IEnumerator RotateAngle(float angle, int sign)
    {
        float mod = angle % rotateSpeed; // 남은 각도 계산
        for (float i = mod; i < angle; i += rotateSpeed)
        {
            character.transform.Rotate(0, 0, sign * rotateSpeed); // 캐릭터 rotateSpeed만큼 회전
            yield return new WaitForSeconds(0.01f); // 0.01초 대기
        }
        character.transform.Rotate(0, 0, sign * mod); // 남은 각도 회전
    }
}