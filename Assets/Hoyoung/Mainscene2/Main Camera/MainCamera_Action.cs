using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera_Action : MonoBehaviour
{
    /* 카메라 무브 */
    /* 플레이어 따라다님 */

    public GameObject player;   // 따라 다니는 대상
    Vector3 cameraPosition;     // 카메라 위치

    void LateUpdate() // 게임 상의 모든 update로직을 마친 후 실행하는 마지막 update 사이클
    {
        cameraPosition.x = player.transform.position.x;
        cameraPosition.y = player.transform.position.y;
        cameraPosition.z = -10;

        transform.position = cameraPosition;
    }

}
