using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using LitJson;

// Flyweight Pattern
public class ProjectileInfoManager : MonoBehaviour
{
	public static ProjectileInfoManager instance;	// singleton

	// match projectile card id with corresponding information
	private Dictionary<int, ProjectileInfo> ProjectileInfoDict = new Dictionary<int, ProjectileInfo>();

	private void Awake()
	{
		instance = this;
		loadInfoFromJson();
	}

	// load projectile information from json file
	private void loadInfoFromJson()
	{
		string jsonFilePath = Application.streamingAssetsPath + "/../../Config/Projectiles.json";
		List<ProjectileInfo> list = JsonMapper.ToObject<List<ProjectileInfo>>(File.ReadAllText(jsonFilePath));

		foreach(ProjectileInfo projectileInfo_i in list)
		{
			ProjectileInfoDict.Add(projectileInfo_i.cardID, projectileInfo_i);
		}
	}

	// get projectile information by card id
	public ProjectileInfo GetProjectileInfoByID(int projectileCardID)
	{
		return ProjectileInfoDict[projectileCardID];
	}
}