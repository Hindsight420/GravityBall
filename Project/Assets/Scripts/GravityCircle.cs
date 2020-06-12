using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityCircle : MonoBehaviour
{
    Sprite originalSprite;
    Sprite activatedSprite;
    SpriteRenderer rend;
    public Rigidbody2D playerRB;
    Vector2 coords;
    bool isActivated;
    [SerializeField]
    const float pull = 100;

    // Start is called before the first frame update
    void Awake()
    {
        rend = GetComponent<SpriteRenderer>();
        originalSprite = rend.sprite;
        activatedSprite = Resources.Load<Sprite>("GravCircle_Clicked");
        
        coords = GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        
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
