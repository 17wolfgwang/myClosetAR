using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class LinearCarouselController : MonoBehaviour
{
    [Header("Carousel Settings")]
    public float spacing = .5f;              // 아이템 간 간격
    public float slideSpeed = 5f;           // 슬라이드 속도
    public float itemHeight = 0f;           // 아이템의 Y축 위치
    public int visibleItems = 3;            // 한 번에 보이는 아이템 수

    [Header("Item Settings")]
    public List<GameObject> itemPrefabs;    // 표시할 아이템들의 프리팹

    private List<GameObject> spawnedItems = new List<GameObject>();
    private float targetPosition = 0f;
    private float currentPosition = 0f;
    private int currentIndex = 0;
    private Vector2 touchStart;
    private bool isDragging = false;
    private PlayerInput playerInput;
    private Camera mainCamera;

    void Awake()
    {
        mainCamera = Camera.main;
        // PlayerInput 컴포넌트가 없다면 추가
        playerInput = GetComponent<PlayerInput>();
        if (playerInput == null)
        {
            playerInput = gameObject.AddComponent<PlayerInput>();
        }
    }

    void Start()
    {
        InitializeCarousel();
    }

    void InitializeCarousel()
    {
        foreach (var item in spawnedItems)
        {
            Destroy(item);
        }
        spawnedItems.Clear();

        for (int i = 0; i < itemPrefabs.Count; i++)
        {
            Vector3 position = CalculatePosition(i);
            GameObject newItem = Instantiate(itemPrefabs[i], position, Quaternion.identity);
            newItem.transform.parent = transform;
            spawnedItems.Add(newItem);
        }

        UpdateItemPositions(0);
    }

    void Update()
    {
        UpdateSlideAnimation();
    }

    // 터치/클릭 시작
    public void OnPointerDown(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            touchStart = Pointer.current.position.ReadValue();
            isDragging = true;
        }
    }

    // 드래그 중
    public void OnDrag(InputAction.CallbackContext context)
    {
        if (isDragging && context.performed)
        {
            Vector2 currentPosition = Pointer.current.position.ReadValue();
            float delta = (currentPosition.x - touchStart.x) / Screen.width;
            float tempTarget = targetPosition + delta * spacing;

            // 범위 제한
            float maxPosition = 0f;
            float minPosition = -(itemPrefabs.Count - visibleItems) * spacing;
            tempTarget = Mathf.Clamp(tempTarget, minPosition, maxPosition);

            targetPosition = tempTarget;
            touchStart = currentPosition;
        }
    }

    // 터치/클릭 종료
    public void OnPointerUp(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isDragging = false;
            targetPosition = Mathf.Round(targetPosition / spacing) * spacing;
            currentIndex = Mathf.RoundToInt(-targetPosition / spacing);
        }
    }

    void UpdateSlideAnimation()
    {
        if (currentPosition != targetPosition)
        {
            currentPosition = Mathf.Lerp(currentPosition, targetPosition, Time.deltaTime * slideSpeed);
            UpdateItemPositions(currentPosition);
        }
    }

    Vector3 CalculatePosition(int index)
    {
        return new Vector3(index * spacing, itemHeight, 0);
    }

    void UpdateItemPositions(float offset)
    {
        for (int i = 0; i < spawnedItems.Count; i++)
        {
            GameObject item = spawnedItems[i];
            Vector3 targetPos = CalculatePosition(i) + new Vector3(offset, 0, 0);
            item.transform.position = transform.position + targetPos;

            // 거리에 따른 크기 조절
            float distanceFromCenter = Mathf.Abs(targetPos.x);
            float scale = Mathf.Lerp(1f, 0.7f, distanceFromCenter / (spacing * visibleItems));
            item.transform.localScale = new Vector3(scale, scale, scale);
        }
    }

    public void NextItem()
    {
        if (currentIndex < itemPrefabs.Count - visibleItems)
        {
            currentIndex++;
            targetPosition = -currentIndex * spacing;
        }
    }

    public void PreviousItem()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
            targetPosition = -currentIndex * spacing;
        }
    }
}