# Scene Manager
A reusable scene manager for Unity that can kick-start the prototyping process. Editable with ease.

***
### FEATURES
* Switch between scenes
* Asynchronous loading option
* Comes with a simple start menu with a start button
---

### INSTRUCTIONS
* Either use prefabs or create them on your own.
* You need an instance of Scene Manager in your starting point. This is mostly the Start Menu. Create a new game object named <Scene Manager> and attach the SceneManager script to it.
* Create a canvas and a start button. Attach the <Start Button> script to it.
* Make sure that your desired scenes are added to the build settings.
> To switch between scenes simply call this function => SceneManager.Instance.UpdateGameState(SceneState.Gameplay); You can add more scenes. To do this, get into the script and do the hard-coding.

---
##### USEFUL LINKS
[Singleton Pattern](https://medium.com/codex/game-design-pattern-using-singletons-in-unity-acbd05d8ac9d). 
[Scripting Reference](https://docs.unity3d.com/ScriptReference/). 
