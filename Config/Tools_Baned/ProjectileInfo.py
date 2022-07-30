import json

if __name__ == '__main__':
    missiles = [
        {   # 石头
            "cardID": 201,
            "iconPath": "Image/Cards/Missile/kp_st",
            "type": "Missile",
            "prefabPath": "prefabs/Missile/stone_PROJ",
            "cost": 10
        },
        {   # 榴莲
            "cardID": 202,
            "iconPath": "Image/Cards/Missile/kp_ll",
            "type": "Missile",
            "prefabPath": "prefabs/Missile/durian_PROJ",
            "cost": 10
        },
        {   # 滚木
            "cardID": 203,
            "iconPath": "Image/Cards/Missile/kp_gm",
            "type": "Missile",
            "prefabPath": "prefabs/Missile/wood_PROJ",
            "cost": 10
        },
        {   # 毒蘑菇
            "cardID": 204,
            "iconPath": "Image/Cards/Missile/kp_mg",
            "type": "Missile",
            "prefabPath": "prefabs/Missile/mushroom_PROJ",
            "cost": 10
        },
        {   # 苹果
            "cardID": 205,
            "iconPath": "Image/Cards/Missile/kp_pg",
            "type": "Missile",
            "prefabPath": "prefabs/Missile/apple_PROJ",
            "cost": 15
        }
    ]

    guardians = [
        {   # 大象
            "cardID": 103,
            "iconPath": "Image/Cards/Guardian/kp_dx",
            "type": "Guardian",
            "prefabPath": "prefabs/Guardian/elephant_PROJ",
            "cost": 25
        }
    ]

    projectiles_type_info = {
        "Missile" : "Image/Cards/TypeIcon/tb_gj",
        "Guardian" : "Image/Cards/TypeIcon/tb_swz"
    }

    # https://docs.unity3d.com/ScriptReference/Resources.Load.html
    # Resources.Load(FilePath/FileNameWithoutExtension) 

    projectils = missiles + guardians
    with open("../Projectiles.json", "w+") as projectiles_info_file:
        json.dump(projectils, projectiles_info_file, indent=4)

    with open("../projectilesType.json", "w+") as projectiles_type_info_file:
        json.dump(projectiles_type_info, projectiles_type_info_file, indent=4)
