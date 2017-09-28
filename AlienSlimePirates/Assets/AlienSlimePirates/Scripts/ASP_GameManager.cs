using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/* 
[System.Serializable]
public struct SceneLoadInfo
{

   public string SceneName;
   public string NextSceneName;
   public string TransitionSceneName;
   public bool UsesTransitionScene;
   public float transitionSceneDelay;
}
*/
//Enum holding all possible application statuses of the application
public enum GameStatus
{
    undetermined,
    menu,
    instructions,
    preLevel,
    LevelinProgress,
    postLevel,
    transitionToNewLevel,
    paused

}



//game manager singleton isnstance
public class ASP_GameManager : MonoBehaviour

{
    //what is currently the statsu of the application
    [SerializeField]
    private GameStatus gameStatus = GameStatus.undetermined;

    //score in current round/level
    [SerializeField]
    private int currentScore = 0;

    //cumulative score in all round/levels played in current session
    [SerializeField]
    private int cumulativeScore = 0;
    //high score out of  all round/levels played in current session
    [SerializeField]
    private int sessionHighScore = 0;

	//UI field allowing output of current score
    [SerializeField]
    private Text currentScoreText;
   // private bool currentLevelOver = false;
	[SerializeField]
	private List<ASP_ProximityDamage> ProximityDamageObjects;
	[SerializeField]
	private List<ASP_Damageable> ProximityDamageableObjects;

	public static ASP_GameManager Instance { get; private set; }

    /* 
     //properties used for scene Loading
     public SceneLoadInfo[] sceneLoadInfo;
     public AsyncOperation status;
     private float startTime;
     public SceneLoadInfo currentSceneLoadInfo;
     public bool newSceneLoaded = false;
     public float tempID;
     */
    void Awake()
    {
        //tempID = Random.value;
        // First we check if there are any other instances conflicting
        if (Instance != null && Instance != this)
        {
            // If that is the case, we destroy other instances
            Destroy(gameObject);
        }
        else
        {
            // Here we save our singleton instance
            Instance = this;
            // Furthermore we make sure thst the GameManager persists in new scenes
            DontDestroyOnLoad(gameObject);
        }
    }

	void OnEnable()
	{

		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		ResetLevel();
	}

    public void IncrementScore(int addToScore)
    {
        if (gameStatus == GameStatus.LevelinProgress)
        {
            currentScore += addToScore;
			currentScoreText.text = currentScore.ToString();
        }
    }

    public void GameOver()
    {
        gameStatus = GameStatus.postLevel;
    }


    public void GameBegin()
    {
        gameStatus = GameStatus.LevelinProgress;
    }



	public void RegisterNewProximityDamageObject(ASP_ProximityDamage newObject)
	{
		ProximityDamageObjects.Add(newObject);
	}


	public void RegisterNewProximityDamagableObject(ASP_Damageable newObject)
	{
		ProximityDamageableObjects.Add(newObject);
	}



	public void UnRegisterNewProximityDamageObject(ASP_ProximityDamage removeObject)
	{
		
			ProximityDamageObjects.Remove(removeObject);

	}


	public void UnRegisterNewProximityDamagableObject(ASP_Damageable removeObject)
	{
		
			ProximityDamageableObjects.Remove(removeObject);

	}

	public ASP_ProximityDamage[] GetProximityDamageObjects(){
		return ProximityDamageObjects.ToArray ();
	}

	private void ResetLevel()
	{
		ProximityDamageObjects = new List<ASP_ProximityDamage> ();
		ProximityDamageableObjects = new List<ASP_Damageable> ();
	}






























    /* 
     * Scene Loading logic disabled
    void OnEnable()
    {

         SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        newSceneLoaded = true;
        startTime = Time.time;

    }


        

    void StartNewLoad()
    {
        status = SceneManager.LoadSceneAsync(GetNextSceneName());
        status.allowSceneActivation = false;
        newSceneLoaded = false;
    }

    public void AllowSceneActivation()
    {
        status.allowSceneActivation = true;
    }

    void SetSceneLoadInfo()
    {
        //must find something for parse to succeed
        //  SceneLoadInfo myScene = sceneLoadInfo[0];
        //if current scene is also active loaded scene
        for (int i = 0; i < sceneLoadInfo.Length; i++)
        {
            if (sceneLoadInfo[i].SceneName == SceneManager.GetActiveScene().name)
            {
                currentSceneLoadInfo = sceneLoadInfo[i];
            }
        }

    }

    string GetNextSceneName()
    {
        if (SceneManager.GetActiveScene().name == currentSceneLoadInfo.SceneName)
        {

            //In a primary scene, load transition or next primary
            if (currentSceneLoadInfo.UsesTransitionScene)
            {
                //load transition scene
                return currentSceneLoadInfo.TransitionSceneName;
            }
            else
            {
                //load next scene
                return currentSceneLoadInfo.NextSceneName;
            }
        }
        else
        {
            //In a transition scene
            return currentSceneLoadInfo.NextSceneName;
        }
    }



    void Update()
    {

        if (newSceneLoaded)
        {

            StartNewLoad();
        }


        //  print("status.progress " + status.progress);

        if (currentSceneLoadInfo.SceneName != SceneManager.GetActiveScene().name && status.progress >= 0.9f)
        {
            //in a transition scene and ready to go

            //print("checking time");
            if (startTime + currentSceneLoadInfo.transitionSceneDelay < Time.time)
            {
                status.allowSceneActivation = true;
            }
        }

    }
	*/

}
