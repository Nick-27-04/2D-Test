using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour
{
    public enum BlockType { CoinBlock, MushroomBlock }

    [Header("블록 설정")]
    public BlockType bType;
    public bool isInfinite = false;
    public int hitCount = 1;
    public Color usedColor = Color.blue;

    [Header("아이템 프리팹")]
    public GameObject mushroomPrefab;
    public GameObject coinPrefab;

    private bool isAnimating = false;
    private bool isUsed = false;
    private Renderer blockRenderer;
    private PlayerJH player;

    private void Start()
    {
        blockRenderer = GetComponent<Renderer>();

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.GetComponent<PlayerJH>();
        }
        else
        {
            Debug.LogError("플레이어를 찾을 수 없습니다! 마리오 오브젝트의 Tag를 'Player'로 설정했는지 확인하세요.");
        }
    }

    public void OnHit(float playerY)
    {
        // 애니메이션 중이거나 이미 다 쓴 블록이면 무시
        if (isAnimating || player == null) return;
        if (isUsed && !isInfinite) return;

        // 1. 위에서 내려찍기 판정 (회전 공격 중일 때만!)
        // 플레이어 발 위치가 블록 중심보다 높고 + rotateCount가 true여야 함
        bool isSlammedFromAbove = (playerY > transform.position.y + 0.5f) && player.rotateCount;

        // 2. 아래에서 머리로 치기 판정 (회전 상관 없음)
        bool isHitFromBelow = (playerY < transform.position.y - 0.5f);

        // ✅ 그냥 착지(rotateCount가 false)하면 여기서 걸러져서 아무 일도 안 일어남
        if (isSlammedFromAbove || isHitFromBelow)
        {
            StartCoroutine(BounceStep(isSlammedFromAbove));
            SpawnItem(isSlammedFromAbove);

            if (!isInfinite)
            {
                hitCount--;
                if (hitCount <= 0)
                {
                    isUsed = true;
                    ChangeBlockColor();
                }
            }
        }
    }

    private void SpawnItem(bool slammed)
    {
        Vector3 spawnDirection = slammed ? Vector3.down : Vector3.up;
        GameObject itemToSpawn = (bType == BlockType.CoinBlock) ? coinPrefab : mushroomPrefab;

        if (itemToSpawn != null)
        {
            GameObject instance = Instantiate(itemToSpawn, transform.position + spawnDirection, Quaternion.identity);
            Coin coinScript = instance.GetComponent<Coin>();
            if (coinScript != null)
            {
                coinScript.SetupDirection(slammed);
            }
        }
    }

    private void ChangeBlockColor()
    {
        if (blockRenderer != null)
            blockRenderer.material.color = usedColor;
    }

    IEnumerator BounceStep(bool slammed)
    {
        isAnimating = true;
        float duration = 0.1f;
        float time = 0f;
        Vector3 startPos = transform.position;
        // 내려찍혔을 때는 블록이 아래로(-0.5), 머리로 쳤을 때는 위로(+0.5) 튕김
        Vector3 targetPos = slammed ? startPos + new Vector3(0, -0.5f, 0) : startPos + new Vector3(0, 0.5f, 0);

        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPos, targetPos, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(0.02f);

        time = 0f;
        while (time < duration)
        {
            transform.position = Vector3.Lerp(targetPos, startPos, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = startPos;
        isAnimating = false;
    }
}