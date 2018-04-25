using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    private Text myText;
    public float rate;
    public int fontSize;
    public int score;
    public event Action<GameObject> OnHidden;
    public Ease myEase;
    public Tween fadeTween;
    public Tween moveTween;
    void Awake()
    {
        myText = GetComponentInChildren<Text>();

    }

    void OnEnable()
    {
        if (score == 0)
        {
            Finished();
        }

        fontSize = (int) (fontSize * ((Mathf.Log10(Vector3.Distance(MasterManager.player.transform.position, transform.position)) *
                                       MasterManager.myScoreUIManager.referenceDistance)));

        transform.rotation = MasterManager.myAnchor.transform.rotation;
        myText.text = score.ToString();
        myText.fontSize = fontSize;
        Color tempColour = myText.color;
        tempColour.a = 255;
        myText.color = tempColour;
        fadeTween= myText.DOFade(0, 10 / rate).OnComplete(Finished);
        moveTween= transform.DOMoveY(transform.position.y + rate , rate).SetEase(myEase);
       
    }

    private void Finished()
    {
        if (OnHidden != null) OnHidden(gameObject);
    }

}
