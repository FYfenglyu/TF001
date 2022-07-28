import json

if __name__ == '__main__':
	missiles = [
        {   # 石头
            "cardID": 201,
            "icon": "Image/Cards/Missile/kp_st",
            "type": "Missile",
            "prefab": "Prefabs/Missile/stone_PROJ",
            "cost": 10
        },
        {   # 榴莲
            "cardID": 202,
            "icon": "Image/Cards/Missile/kp_ll",
            "type": "Missile",
            "prefab": "Prefabs/Missile/durian_PROJ",
            "cost": 10
        },
        {   # 滚木
            "cardID": 203,
            "icon": "Image/Cards/Missile/kp_gm",
            "type": "Missile",
            "prefab": "Prefabs/Missile/wood_PROJ",
            "cost": 10
        },
        {   # 毒蘑菇
            "cardID": 204,
            "icon": "Image/Cards/Missile/kp_mg",
            "type": "Missile",
            "prefab": "Prefabs/Missile/mushroom_PROJ",
            "cost": 10
        },
        {   # 苹果
            "cardID": 205,
            "icon": "Image/Cards/Missile/kp_pg",
            "type": "Missile",
            "prefab": "Prefabs/Missile/apple_PROJ",
            "cost": 15
        }
    ]

	projectiles_type_info = {
		"Missile" : "Image/Cards/TypeIcon/tb_gj",
		"Guardian" : "Image/Cards/TypeIcon/tb_swz"
	}

	# https://docs.unity3d.com/ScriptReference/Resources.Load.html
	# Resources.Load(FilePath/FileNameWithoutExtension) 

	with open("../Projectiles.json", "w+") as projectiles_info_file:
		json.dump(missiles, projectiles_info_file, indent=4)

	with open("../projectilesType.json", "w+") as projectiles_type_info_file:
		json.dump(projectiles_type_info, projectiles_type_info_file, indent=4)
