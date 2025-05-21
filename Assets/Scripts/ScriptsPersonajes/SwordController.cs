using UnityEngine;

public class SwordController : MonoBehaviour
{
    private BoxCollider2D boxColliderSword;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boxColliderSword = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            boxColliderSword.offset = new Vector2( Mathf.Abs(boxColliderSword.offset.x) * Input.GetAxisRaw("Horizontal"), boxColliderSword.offset.y);
        }
    }
}
