using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tip : MonoBehaviour
{
    public Text tip;

    // Start is called before the first frame update
    void Start()
    {
        switch(Random.Range(1,12))
        {
            case 1:
                tip.text = "속성 상성에 맞춰 공격하면 더욱 효과적입니다!";
                break;
            case 2:
                tip.text = "속성 상성은 내 공격도 적용되지만, 적의 공격에도 적용됩니다";
                break;
            case 3:
                tip.text = "속성 레벨은 3레벨까지 있으며 SKILL LEVEL UP을 눌러 업그레이드 할 수 있습니다";
                break;
            case 4:
                tip.text = "중복되는 속성은 먹을 수 없습니다. ";
                break;
            case 5:
                tip.text = "속성버리기를 하면 현재 사용 중인 속성을 버리고, 그 속성은 다시 1레벨로 초기화됩니다";
                break;
            case 6:
                tip.text = "8마리의 벌레에게 둘러 쌓이면 카운트 다운이 시작되니, 그 전에 처리하세요!";
                break;
            case 7:
                tip.text = "무당벌레의 하루는 보통 진딧물을 먹는 게 대부분이라고 합니다";
                break;
            case 8:
                tip.text = "이런 게임에도 로딩이? 라는 생각이 들 수도 있지만 놀랍게도 있습니다";
                break;
            case 9:
                tip.text = "상단의 바로 낮, 밤을 확인할 수 있습니다\n밤에는 시야가 어두우니 주의하세요";
                break;
            case 10:
                tip.text = "속성이 가득 찼을 때 벌레를 먹으면 체력이 조금 오릅니다";
                break;
            case 11:
                tip.text = "적을 죽이면 더 많이 경험치를 얻습니다";
                break;
        }
    }

}
