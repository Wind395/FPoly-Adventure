using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class SpriteChange : MonoBehaviour
{
    public Sprite currentSprite;
    public Sprite newSprite;
    private SpriteRenderer spriteRenderer;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            spriteRenderer.sprite = newSprite;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            spriteRenderer.sprite = currentSprite;
        }
    }
}
