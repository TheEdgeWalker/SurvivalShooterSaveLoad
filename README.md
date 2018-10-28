# SurvivalShooterSaveLoad
This is a challenge project where I had to add a Save/Load feature to the Unity's Survival Shooter Tutorial.
Please refer to the following link to download the Survival Shooter Tutorial asset:
https://assetstore.unity.com/packages/essentials/tutorial-projects/survival-shooter-tutorial-40756

When you start the game, you will be given an option to Start or Load the game. If there is no file to load, the Load button is disabled.
The Save button is in the options menu (press ESC).

The save file is located at "Application.dataPath + SaveData/save.json". The actual directory may differ depending on the platform the game is played on.
Please refer to the following document to find the exact save file path for each platform:
https://docs.unity3d.com/ScriptReference/Application-dataPath.html

I chose JSON as the save method for the following reasons:
1. Easily portable to web
2. Readable by humans (easy debugging)

# First attempt: Serialize the whole scene
Since I have decided to use JSON as my method for saving, and also since Unity has a built in JSON library, I first thought of serializing the whole scene on save, and deserializing the scene on load.
I quickly found that this is not a practical solution for the following reasons:
1. Unity's JsonUtility CANNOT serialize/deserialize many Unity classes (not even Vector3!!!)
   - I would have to implement serialization/deserialization functions for every Component used
   - While there are open sourced Unity GameObject serializers out there, using such libraries are not the point of this challenge 
2. Majority of the GameObjects and their properties are static
   - It would be a waste of memory to serialize all GameObjects, all properties for the whole scene
     - This is especially critical if I were to implement a web based save/load feature

# Second attempt: Only serialize the things that matter
After studying the code of Suvival Shooter Tutorial, I found that only the following GameObjects and their Components need to be serialized:
- Score
- Player
  - Transform
  - PlayerHealth
  - PlayerShooting
- Monsters
  - Transform
  - Name
  - EnemyHealth
- EnemyManagers
  - Enemy
  - Time

On save, all the above GameObjects are searched by tag or by name, and serialized into JSON.
On load, the deserialized Score/Player/EnemyManagers data are applied to the GameObjects on the scene, but for Monsters, they are Instantiated first, and then the deserialized data is applied.

# Conclusion
I have successfully implemented a functional save/load system for Survival Shooter Tutorial.

If there are changes to the game, and the scope of the save file needs to be expanded, I feel that the code is moderately scalable by implementing more children classes of SerializableObject.

However, I feel that I could have vastly increased scalability by implementing a proper Unity GameObject serializer by using reflection. Of course, this will surely have negative performance impacts, and also I felt that this endevour is not for a single weekend, so I decided to approach things the more "manual" way.

The completed Survival Shooter Tutorial does not include a object pool, so the monsters were basically being Instantiated and Destroyed constantly. I was very tempted to fix this and implement a proper object pool, but if I started editing the code for the base project, I was afraid that I might never finish this challenge.
