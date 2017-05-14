using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubeGameLogic : MonoBehaviour {
    public SteamVR_LoadLevel levelLoader;
   public  GameObject ball;
    public GameObject ballPrefab;
    public GameObject starPrefab;
    public GameObject[] stars;
    public GameObject player;
    private Transform ballTransform;
    private Vector3[] starPos;
    private Vector3 initBallPos;
    private uint starCount = 0;
    
	// Use this for initialization
	void Start () {
        initBallPos = ball.transform.position;
        starPos = new Vector3[stars.Length];
       for (int i =0; i< stars.Length; ++i)
        {
            starPos[i] = stars[i].transform.position;
        }
        Debug.Log(stars.Length);
       

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ResetGame()
    {
        StartCoroutine(Wait());
        Destroy(ball);
        player.GetComponent<AudioSource>().Play();
        Debug.Log("ball destroyed");
        ball = Instantiate(ballPrefab, initBallPos, Quaternion.identity);
        ball.transform.SetParent(transform);
        starCount = 0;
        for (int i = 0; i < stars.Length; ++i)
        {
            if (!stars[i].GetComponent<MeshRenderer>().enabled)
            {
                stars[i].GetComponent<MeshRenderer>().enabled = true;
                stars[i].GetComponent<SphereCollider>().enabled = true;
            }
        }
    }
    public void IncrementStar()
    {
      
      
        Debug.Log("star collected");
        starCount++;
    }
    public void Goal()
    {
        if (starCount == stars.Length)
        {
            Debug.Log("Game won");
            levelLoader.Trigger();
            
        }
        else ResetGame();
    }
    IEnumerator Wait()
    {
       
        yield return new WaitForSeconds(.2f);
     
     

    }
}
