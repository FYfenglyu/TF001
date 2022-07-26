using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using LitJson;

// Flyweight Pattern
public class ProjectileInfoManager : MonoBehaviour
{
    public static ProjectileInfoManager instance;   // singleton

    // match projectile card id with corresponding information
    private Dictionary<int, ProjectileInfo> projectileInfoDict = new Dictionary<int, ProjectileInfo>();
    private Dictionary<string, string> projectileTypeIconDict;

    private void Awake()
    {
        instance = this;
        LoadInfoFromJson();
		LoadTypeIconInfoFromJson();
    }

    // load projectile information from json file
    private void LoadInfoFromJson()
    {
        string jsonFilePath = Application.streamingAssetsPath + "/../../Config/Projectiles.json";
        List<ProjectileInfo> projectileInfoList = JsonMapper.ToObject<List<ProjectileInfo>>(File.ReadAllText(jsonFilePath));

        foreach (ProjectileInfo projectileInfo_i in projectileInfoList)
        {
            projectileInfoDict.Add(projectileInfo_i.cardID, projectileInfo_i);
        }
    }

    private void LoadTypeIconInfoFromJson()
    {
        string jsonFilePath = Application.streamingAssetsPath + "/../../Config/projectilesType.json";
        projectileTypeIconDict = JsonMapper.ToObject<Dictionary<string, string>>(File.ReadAllText(jsonFilePath));
    }

    // get projectile information by card id
    public ProjectileInfo GetProjectileInfoByID(int projectileCardID)
    {
        return projectileInfoDict[projectileCardID];
    }

    // get projectile type icon path by projectile type
    public string GetTypeIconPathByType(string type)
    {
        return projectileTypeIconDict[type];
    }
}