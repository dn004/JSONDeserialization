using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;

public class ControlScript : MonoBehaviour
{
    private string fileName = "WorkoutInfoJSONAssignment.json";

    public GameObject ButtonTemplate;
    public TextMeshProUGUI ProjectNameText;
    public Transform ParentUI;
    public Transform ParentBall;
    public GameObject BallPrefab;
    public int BallsToSpawn = 0;
    public WorkOut allData;
   
    private int ButtonsToSpawn = 0;

    List<GameObject> allButtons = new List<GameObject>();


    public void PopulateArea()
    {
        allData = JsonReader();
        ProjectNameText.text = allData.ProjectName;
        BallsToSpawn = allData.workoutInfo.Count;
        ButtonsToSpawn = allData.numberOfWorkoutBalls;

        for(int i = 0; i < ButtonsToSpawn; i++)
        {
            GameObject useButton = Instantiate(ButtonTemplate, Vector3.zero, Quaternion.identity, ParentUI);
            TextMeshProUGUI currentText = useButton.transform.GetComponentInChildren<TextMeshProUGUI>();
            currentText.text = allData.workoutInfo[i].workoutName;
            currentText.text += "\n" + "<size=12>" + allData.workoutInfo[i].description + "</size>";
            allButtons.Add(useButton);

            Button currentBtn = useButton.GetComponent<Button>();
            if (allData.workoutInfo[i].workoutID == 1)
            {
                currentBtn.onClick.AddListener(RollingBall);
                continue;
            }

            if (allData.workoutInfo[i].workoutID == 2)
            {
                currentBtn.onClick.AddListener(BouncingBalling);
                continue;
            }

            if (allData.workoutInfo[i].workoutID == 3)
            {
                currentBtn.onClick.AddListener(LineDriveWorkOut);
                continue;
            }

            if (allData.workoutInfo[i].workoutID == 4)
            {
                currentBtn.onClick.AddListener(RollingBall);
                continue;
            }

            if (allData.workoutInfo[i].workoutID == 5)
            {
                currentBtn.onClick.AddListener(PopUpWorkOut);
                continue;
            }

            if (allData.workoutInfo[i].workoutID == 6)
            {
                currentBtn.onClick.AddListener(PopUpWorkOut);
                break;
            }


        }

        //setup listeners
      
    }


    public void BouncingBalling()
    {
        for (int j = 0; j < allData.workoutInfo.Count; j++)
        {
            if (allData.workoutInfo[j].ballType == "bouncing ball")
            {
                for (int i = 0; i < BallsToSpawn; i++)
                {
                    GameObject obj = Instantiate(BallPrefab, new Vector3(Random.insideUnitSphere.x, 0, Random.insideUnitSphere.z), Quaternion.identity,ParentBall);
                    obj.name = "bouncing ball";
                    ballMove ball = obj.GetComponent<ballMove>();
                    ball.ballId = allData.workoutInfo[j].workoutDetails[i].ballId;
                    ball.FireBall(allData.workoutInfo[j].workoutDetails[i].ballDirection, allData.workoutInfo[j].workoutDetails[i].speed);
                }
            }
        }
    }

    public void PopUpWorkOut()
    {
        for (int j = 0; j < allData.workoutInfo.Count; j++)
        {
            if (allData.workoutInfo[j].ballType == "pop-up ball")
            {
                for (int i = 0; i < BallsToSpawn; i++)
                {
                    GameObject obj = Instantiate(BallPrefab, new Vector3(Random.insideUnitSphere.x, 0, Random.insideUnitSphere.z), Quaternion.identity, ParentBall);
                    obj.name = "PopUp ball";
                    ballMove ball = obj.GetComponent<ballMove>();
                    ball.ballId = allData.workoutInfo[j].workoutDetails[i].ballId;
                    ball.FireBall(allData.workoutInfo[j].workoutDetails[i].ballDirection, allData.workoutInfo[j].workoutDetails[i].speed);
                }
            }
        }
    }

    public void LineDriveWorkOut()
    {
        for (int j = 0; j < allData.workoutInfo.Count; j++)
        {
            if (allData.workoutInfo[j].ballType == "linedrive ball")
            {
                for (int i = 0; i < BallsToSpawn; i++)
                {
                    GameObject obj = Instantiate(BallPrefab, new Vector3(Random.insideUnitSphere.x, 0, Random.insideUnitSphere.z), Quaternion.identity, ParentBall);
                    obj.name = "linedrive ball";
                    ballMove ball = obj.GetComponent<ballMove>();
                    ball.ballId = allData.workoutInfo[j].workoutDetails[i].ballId;
                    ball.FireBall(allData.workoutInfo[j].workoutDetails[i].ballDirection, allData.workoutInfo[j].workoutDetails[i].speed);
                }
            }
        }
    }


    public void RollingBall()
    {
        for (int j = 0; j < allData.workoutInfo.Count; j++)
        {
            if (allData.workoutInfo[j].ballType == "rolling ball")
            {
                for (int i = 0; i < BallsToSpawn; i++)
                {
                    GameObject obj = Instantiate(BallPrefab, new Vector3(Random.insideUnitSphere.x, 0, Random.insideUnitSphere.z), Quaternion.identity, ParentBall);
                    obj.name = "rolling ball";
                    ballMove ball = obj.GetComponent<ballMove>();
                    ball.ballId = allData.workoutInfo[j].workoutDetails[i].ballId;
                    ball.FireBall(allData.workoutInfo[j].workoutDetails[i].ballDirection, allData.workoutInfo[j].workoutDetails[i].speed);
                }
            }

        }
    }


    private void Start()
    {
       PopulateArea();
    }

    public WorkOut JsonReader()
    {
        string filePath = Path.Combine(Application.dataPath, fileName);
        string data = File.ReadAllText(filePath);
        WorkOut dataInfo = JsonUtility.FromJson<WorkOut>(data);
        return dataInfo;
    }
}



