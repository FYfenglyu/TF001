using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using LitJson;

// Flyweight Pattern
public class ProjectileData : MonoBehaviour 
{
    public static ProjectileData instance;   // singleton

    // match projectile card id with corresponding information
    private Dictionary<int, ProjAttribute> projectileInfoDict = new Dictionary<int, ProjAttribute>();
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
        List<ProjAttribute> projectileInfoList = JsonMapper.ToObject<List<ProjAttribute>>(File.ReadAllText(jsonFilePath));

        foreach (ProjAttribute projectileInfo_i in projectileInfoList)
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
    public ProjAttribute GetProjectileInfoByID(int projectileCardID)
    {
        return projectileInfoDict[projectileCardID];
    }

    // get projectile type icon path by projectile type
    public string GetTypeIconPathByType(string type)
    {
        return projectileTypeIconDict[type];
    }
}