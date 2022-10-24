using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEditor;

public class ImageAnimation : MonoBehaviour
{
    public float speed;
    public Sprite image1;
    public Sprite image2;

    private Animator animator;
    private Image image;
    private int curIdx;
    private float curTime;
    private List<Sprite> sprites;
    private bool valid;

    void Awake()
    {
        image = GetComponent<Image>();
        Color white = Color.white;
        white.a = 1;
        image.color = white;
        animator = GetComponent<Animator>();
        if (animator.runtimeAnimatorController == null)
        {
            valid = false;
        }
        else
        {
            sprites.Add(image1);
            sprites.Add(image2);
            curIdx = 0;
            curTime = speed;
            valid = true;
        }
    }

    public void Reset()
    {
        Awake();
    }

    public void Flush()
    {
        Color white = Color.white;
        white.a = 0;
        image.color = white;
        valid = false;
    }

    void Update()
    {
        if (valid)
        {
            curTime -= Time.deltaTime;
            if (curTime < 0)
            {
                curTime = speed;
                if (curIdx >= sprites.Count)
                {
                    curIdx = 0;
                }
                image.sprite = sprites[curIdx];
                curIdx++;
            }
        }
    }
}