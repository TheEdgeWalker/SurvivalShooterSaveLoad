# SurvivalShooterSaveLoad
This is a test project where I added a Save/Load feature to the Unity's Survival Shooter Tutorial.
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
2. Considering that a big portion of the GameObjects are static, it would be a waste of memory to serialize the whole scene
   - This is especially critical if I were to implement a web based save/load feature

# Second attempt: Only serialize the things that matter


# Conclusion
