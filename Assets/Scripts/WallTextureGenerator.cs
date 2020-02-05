using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTextureGenerator : MonoBehaviour
{
    [SerializeField]
    List<Sprite> sprites = null;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        GenerateTexture();
    }

    void GenerateTexture()
    {
        sr.sprite = sprites[Random.Range(0, sprites.Count-1)];

    }
}
