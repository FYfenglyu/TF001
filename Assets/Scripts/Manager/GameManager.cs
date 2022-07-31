using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // singleton
    [Header("当前关卡")]
    public int currLevel = 1;

    [Header("最大关卡")]
    private int maxLevel = 16;

    private LevelConfig levelconfig;
    // Start is called before the first frame update
    private void Awake()
    {
        // if there exists an instance, destroy the unnecessary instance 
        if (instance)
        {
            GameObject.Destroy(gameObject);
            return;
        }

        // create an instance
        instance = this;
        GameObject.DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public int LevelUp()
    {
        currLevel = Mathf.Min(maxLevel, currLevel + 1);
        return currLevel;
    }

    public void LoadLevel(int i)
    {
        levelconfig = LevelData.GetLevelConfig(i);
        //其他加载逻辑
        SceneManager.LoadSceneAsync("SampleScene");

        PlayManager.instance.ResetGameStatus(levelconfig);

        //ProjectileManager.instance.SetCardsList(levelconfig.cardIDList);
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadSceneAsync(name);
    }
}