using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityCircle : MonoBehaviour
{
    [SerializeField]
    const float pull = 100;
    Sprite originalSprite;
    Sprite activatedSprite;
    SpriteRenderer rend;
    bool isActivated;
    public Rigidbody2D playerRB;

    void Awake()
    {
        rend = GetComponent<SpriteRenderer>();
        originalSprite = rend.sprite;
        activatedSprite = Resources.Load<Sprite>("GravCircle_Clicked");
    }

    void FixedUpdate()
    {
        if (isActivated)
        {
            Vector2 direction = (Vector2)transform.position - playerRB.position;
            playerRB.AddForce(direction * pull * Time.deltaTime);
        }
    }

    private void OnMouseDown()
    {
        rend.sprite = activatedSprite;
        isActivated = true;
        playerRB = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
    }

    private void OnMouseUp()
    {
        rend.sprite = originalSprite;
        isActivated = false;
    }
}
