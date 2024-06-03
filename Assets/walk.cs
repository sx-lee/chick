using UnityEngine;

public class walk : MonoBehaviour
{
    public float moveSpeed = 5f; // 캐릭터의 이동 속도
    private Rigidbody2D rb;
    private Vector2 movement;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // 컴포넌트가 존재하는지 확인합니다.
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D 컴포넌트가 없습니다. Rigidbody2D를 추가해주세요.");
        }

        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer 컴포넌트가 없습니다. SpriteRenderer를 추가해주세요.");
        }
    }

    void Update()
    {
        // 입력값을 받습니다.
        movement.x = Input.GetAxisRaw("Horizontal"); // A, D 또는 좌우 방향키 입력

        // 좌우 입력에 따라 스프라이트 반전
        if (movement.x > 0)
        {
            spriteRenderer.flipX = false; // 오른쪽으로 이동할 때 기본 스프라이트
        }
        else if (movement.x < 0)
        {
            spriteRenderer.flipX = true; // 왼쪽으로 이동할 때 스프라이트 반전
        }

        movement.y = 0; // 상하 이동은 제한
    }

    void FixedUpdate()
    {
        // Rigidbody2D가 존재할 경우에만 이동을 처리합니다.
        if (rb != null)
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }
}
