using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class GameDirector : MonoBehaviour
{
    GameObject timerText;
    float time = 30.0f;
    GameObject pointText;
    int point = 0;

    public void GetApple()
    {
        this.point += 100;
    }
    public void GetWater()
    {
        this.point += 50;
    }
    public void GetRope()
    {
        this.point += 20;
    }
    public void GetKnife()
    {
        this.point /= 2;
    }

    void Start()
    {
        this.timerText = GameObject.Find("Time");
        this.pointText = GameObject.Find("Point");

        if (this.timerText == null)
        {
            Debug.LogError("Time 오브젝트를 찾을 수 없습니다.");
            return;
        }

        if (this.pointText == null)
        {
            Debug.LogError("Point 오브젝트를 찾을 수 없습니다.");
            return;
        }
    }

    void Update()
    {
        this.time -= Time.deltaTime;
        this.timerText.GetComponent<TMPro.TextMeshProUGUI>().text = this.time.ToString("F1");
        this.pointText.GetComponent<TMPro.TextMeshProUGUI>().text = this.point.ToString() + "full";

        if (this.time <= 0)
        {
            ChangeScene();
        }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("HomeScene");
    }
}
