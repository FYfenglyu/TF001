import json

if __name__ == '__main__':
	projectiles = [
    {
        "cardID": 1,
        "icon": "Image/Stone",
        "type": "Missile",
        "prefab": "Missile/stone_PROJ",
        "cost": 50,
        "attack": 10
    },
    {
        "cardID": 2,
        "icon": "Image/Elephant_01",
        "type": "Guardian",
        "prefab": "Guardian/elephant_PROJ",
        "cost": 100,
        "attack": 30
    }
]

	projectiles_type_info = {
		"Missile" : "Image/CardTypeIcon_Missile",
		"Guardian" : "Image/CardTypeIcon_Guardian"
	}

	# https://docs.unity3d.com/ScriptReference/Resources.Load.html
	# Resources.Load(FilePath/FileNameWithoutExtension) 

	with open("../Config/Projectiles.json", "w+") as projectiles_info_file:
		json.dump(projectiles, projectiles_info_file, indent=4)

	with open("../Config/projectilesType.json", "w+") as projectiles_type_info_file:
		json.dump(projectiles_type_info, projectiles_type_info_file, indent=4)
