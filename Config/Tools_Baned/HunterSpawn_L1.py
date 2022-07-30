import json

if __name__ == '__main__':
    hunter_gen_time_table = [
        {
            "birthTime": 0,
            "hunterID": 301,
        },
        {
            "birthTime": 10,
            "hunterID": 301
        },
        {
            "birthTime": 20,
            "hunterID": 301,
        },
        {
            "birthTime": 25,
            "hunterID": 301
        },
        {
            "birthTime": 25.1,
            "hunterID": 301,
        },
        {
            "birthTime": 25.2,
            "hunterID": 301
        },
        {
            "birthTime": 25.3,
            "hunterID": 301
        },
        {
            "birthTime": 28,
            "hunterID": 301
        },
        {
            "birthTime": 30,
            "hunterID": 301
        },
    ]

    with open("../Config/HunterSpawn_L1.json", "w+") as hunter_spawn_time_file:
        json.dump(hunter_gen_time_table, hunter_spawn_time_file, indent=4)
