using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpinWheel : MonoBehaviour
{
    // Start is called before the first frame update
    public float numberOfItem = 9;
    private float currentTime;
    public Transform listOfItem;
    public const float CIRCLE = 360f;
    public float angleEachItem;
    public float startIndex;
    public float endIndex;
    public float timeFrequency;
    public AnimationCurve curve;
    public AudioSource audioSource;
    int currentItem = 9;
    public static SpinWheel instance;
    private void Start()
    {
        angleEachItem = CIRCLE / numberOfItem;
        this.transform.rotation = Quaternion.identity;
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }
    IEnumerator Spin(int index)
    {
        float startAngle = transform.eulerAngles.z;
        currentTime = 0;
        int randomCycle = (int)Random.Range(startIndex, endIndex);
        Debug.Log(index);
        float spinAngle = (randomCycle * CIRCLE) + index * angleEachItem - startAngle;
        while (currentTime < timeFrequency)
        {
            yield return new WaitForEndOfFrame();
            currentTime += Time.deltaTime;
            float currentAngle = spinAngle * curve.Evaluate(currentTime / timeFrequency);
            this.transform.eulerAngles = new Vector3(0, 0, currentAngle + startAngle);
        }
        ClaimItem(index);
        string level = "level_" + index;
        SceneManager.LoadScene(level);
    }
    [ContextMenu("Spin")]
    void SpinNow(int index)
    {
        StartCoroutine(Spin(index));
      
    }
    void PressToSpin()
    {
        if (currentItem > 0)
        {
            int keyIndex = default;
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Debug.Log(KeyCode.Alpha1);
                keyIndex = 1;
                SpinNow(keyIndex);
                audioSource.Play();
                currentItem--;
                

            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                keyIndex = 2;
                SpinNow(keyIndex);
                audioSource.Play();
                currentItem--;
             
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                keyIndex = 3;
                SpinNow(keyIndex);
                audioSource.Play();
                currentItem--;
               
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                keyIndex = 4;
                SpinNow(keyIndex);
                audioSource.Play();
                currentItem--;
                
            }
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                keyIndex = 5;
                SpinNow(keyIndex);
                audioSource.Play();
                currentItem--;
                
            }
            if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                keyIndex = 6;
                SpinNow(keyIndex);
                audioSource.Play();
                currentItem--;
               
            }
            if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                keyIndex = 7;
                SpinNow(keyIndex);
                audioSource.Play();
                currentItem--;
                
            }
            if (Input.GetKeyDown(KeyCode.Alpha8))
            {
                keyIndex = 8;
                SpinNow(keyIndex);
                audioSource.Play();
                currentItem--;
                
            }
            if (Input.GetKeyDown(KeyCode.Alpha9))
            {
                keyIndex = 9;
                SpinNow(keyIndex);
                audioSource.Play();
                currentItem--;
                
            } 
        }
    }
    void ClaimItem(int index)
    {
        for(int i =0; i<numberOfItem; i++)
        {
            listOfItem.GetChild(index-1).GetChild(1).GetComponent<SpriteRenderer>().color = Color.gray;
            if (index % 2 == 0)
            {
                Debug.Log("Ban nhan duoc" + index + "Tim");
            }
            else
            {
                Debug.Log("Ban nhan duoc" + index + "ti?n vàng");
            }
        }
        audioSource.Stop();
        if (currentItem == 0)
        {
            Reset();
        }
    }
    private void Reset()
    {
        for (int i =0; i<numberOfItem; i++)
        {
            listOfItem.GetChild(i).GetChild(1).GetComponent<SpriteRenderer>().color = Color.white;
        }
        currentItem = 9;
    }
    private void Update()
    {
       PressToSpin();
    }
}
