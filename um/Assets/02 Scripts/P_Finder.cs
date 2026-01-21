using System;
using System.Collections.Generic;
using UnityEngine;

public class P_Finder : MonoBehaviour
{
    [Header("감지설정")]
    [SerializeField] float checkRadious = 5f; //객체 감지 범위
    [SerializeField] LayerMask interactableLayer;
    [SerializeField] float activationDistance = 3f; // 실제로 아이콘이 활성화되는 거리

    [Header("UI설정")]
    [SerializeField] Canvas uiCanvas; //아이콘이 표시될 UI컨버스
    [SerializeField] GameObject IconPrefab; //생성할 아이콘 프리팹

    Dictionary<Transform,GameObject> activeIcons = new Dictionary<Transform,GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] nearObjects = Physics.OverlapSphere(transform.position, checkRadious, interactableLayer);

        //현재 프레임에서 아이콘을 표시해야할 객체들을 저장할 HashSet
        HashSet<Transform> currentObjects = new HashSet<Transform>();

        foreach (Collider obj in nearObjects)
        {
            Transform targetTransform = obj.transform;
            float distance = Vector3.Distance(transform.position, targetTransform.position);

            if (distance > activationDistance)
            {
                ShowIcon(targetTransform);
                currentObjects.Add(targetTransform);
            }

        }
    }
    private void ShowIcon(Transform targetTransform)
    {

        //이미 이 객체에 대한 아이콘이 존재할 경우
        if(activeIcons.ContainsKey(targetTransform))
        {

            //기존 아이콘의 위치만 업데이트하고 함수 종료
            UpdateIconPosition(targetTransform, activeIcons[targetTransform]);
            return;
        }

        GameObject iconInstance = Instantiate(IconPrefab,uiCanvas.transform);
        activeIcons[targetTransform] = iconInstance;

        //생성 직후 위치 설정

        UpdateIconPosition(targetTransform, iconInstance);
    }

    private void UpdateIconPosition(Transform targetTransform, GameObject Icon)
    {
        Vector3 screenPosition =
            Camera.main.WorldToScreenPoint(new Vector3(targetTransform.position.x,
            targetTransform.position.y + 1.5f,
            targetTransform.position.z));

        Icon.GetComponent<RectTransform>().position = screenPosition;
    }



    //범위에서 벗어난 객체들의 아이콘 제거 작업
    //딕션너리에서 동시에 수정할 수 없으므로 제거할 항목들을 별도로 리스트로 관리(저장)

    List<Transform> toRemove = new List<Transform>();

        foreach(var iconEntry in activelcons)
        {
            if(!currentObjects.Contains(iconEntry.Key))
               {
                       Destroy(iconEntry.Value)
                   toRemove.Add(iconEntry.KEy);
                  }
        }

foreach(var transformToRemove in toRemove)
{
    activelocons.Remove(transformToRemove);

}



}

