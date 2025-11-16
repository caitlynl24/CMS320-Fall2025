using UnityEngine;

public class YSort : MonoBehaviour
{
    private SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void LateUpdate()
    {
        int baseOrder = 500; //Ensures scarecrow is always in front of background
        sr.sortingOrder = Mathf.RoundToInt(-transform.position.y * 100) + baseOrder;
    }
}