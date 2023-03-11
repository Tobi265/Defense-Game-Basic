using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo : MonoBehaviour
{
    //public GameObject heroPrefab;
    public Transform myTransform;
    [Range(0f, 1f)]
    public float timeScaleValue = 1;
    public SpriteRenderer myRenderer;
    float score;
   
    private void Awake()
    {
       // Debug.Log("Awake");
       myRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        //Debug.Log("OnEndale");
    }



    // Start is called before the first frame update
    void Start()
    {
        //score += 10;
        //// Debug.Log(score);
        ////  PlayerPrefs.SetFloat("score", score);
        //float scoreCopy = PlayerPrefs.GetFloat("score", 0);
        //Debug.Log(scoreCopy);
        score = PlayerPrefs.GetFloat("score", 0);
        score += 10;
        PlayerPrefs.SetFloat("score", score);
        Debug.Log(score);

    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = timeScaleValue;
    }

    private void OnDisable()
    {
       // Debug.Log("OnDisable");
    }

    private void OnDestroy()
    {
        //Debug.Log("OnDestroy");
    }
   
}
