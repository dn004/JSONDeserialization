using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

[System.Serializable]
public class WorkOut
{
    public string ProjectName;
    public int numberOfWorkoutBalls;
    public List<WorkoutInfo> workoutInfo;
}

[System.Serializable]
public class WorkoutInfo
{
    public int workoutID;
    public string workoutName;
    public string description;
    public string ballType;
    public List<WorkoutDetails> workoutDetails;
}

[System.Serializable]
public class WorkoutDetails
{
    public int ballId;
    public float speed;
    public float ballDirection;
}

public class ControlScript : MonoBehaviour
{
    private string fileName = "WorkoutInfoJSONAssignment.json";

    public GameObject ButtonTemplate;
    public TextMeshProUGUI ProjectNameText;
    public WorkOut allData; 



    public void PopulateArea()
    {
        allData = JsonReader();
        ProjectNameText.text = allData.ProjectName;
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



