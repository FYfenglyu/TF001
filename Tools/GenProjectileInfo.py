import json

if __name__ == '__main__':
	projectiles = [
		{
			"cardID" : 1 ,
			"icon" : "../Image/Wood.png",
			"type" : "Missile",
			"prefab" : "Prefabs/test",
			"cost" : 50,
			"attack" : 10
		},
		{
			"cardID" : 2 ,
			"icon" : "../Image/Elephant.png",
			"type" : "Guardian",
			"prefabPath" : "Prefabs/test",
			"cost" : 200,
			"attack" : 20
		},
	]

	with open("../Config/Projectiles.json", "w+") as projectiles_info_file:
		json.dump(projectiles, projectiles_info_file, indent=4)