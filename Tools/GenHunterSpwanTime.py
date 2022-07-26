import json

if __name__ == '__main__':
    hunter_gen_time_table = [
        {
            "birthTime": 5,
            "hunterID": 301,
        },
        {
            "birthTime": 7,
            "hunterID": 302
        },
        {
            "birthTime": 9,
            "hunterID": 302
        },
        {
            "birthTime": 11,
            "hunterID": 301
        },
        {
            "birthTime": 12,
            "hunterID": 302
        },
    ]

    with open("../Config/HunterSpwanTime.json", "w+") as hunter_spawn_time_file:
        json.dump(hunter_gen_time_table, hunter_spawn_time_file, indent=4)
