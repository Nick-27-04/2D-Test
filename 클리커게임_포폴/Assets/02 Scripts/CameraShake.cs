using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    public static CameraShake instance;

    private Vector3 originalPos;

    void Awake()
    {
        // 씬이 바뀌어도 유지되거나 어디서든 접근 가능하게 인스턴스 할당
        if (instance == null) instance = this;
    }

    void OnEnable()
    {
        // 켜질 때 현재 위치를 저장 (0, 0, -10 등)
        originalPos = transform.localPosition;
    }

    public void Shake(float duration, float magnitude)
    {
        // 이미 흔들리고 있다면 멈추고 새로 시작
        StopAllCoroutines();
        StartCoroutine(ShakeRoutine(duration, magnitude));
    }

    IEnumerator ShakeRoutine(float duration, float magnitude)
    {
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            // 아주 미세하게 랜덤 좌표 생성
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            // Z축은 유지하면서 X, Y만 흔듦
            transform.localPosition = new Vector3(originalPos.x + x, originalPos.y + y, originalPos.z);

            elapsed += Time.deltaTime;
            yield return null;
        }

        // 끝난 후 정확하게 원래 위치로 복귀
        transform.localPosition = originalPos;
    }
}