 var isPause = false;
 function Update () {
  
    
 }
  
 
 public function pauze()
 {
       isPause = !isPause;
       if(isPause)
          Time.timeScale = 0;
       else
          Time.timeScale = 1;
 }
// function TheMainMenu () {
// if(GUILayout.Button("Main Menu")){
// Application.LoadLevel("MainMenu");
// }
// if(GUILayout.Button("Restart")){
// Application.LoadLevel("InGame");
// }
// if(GUILayout.Button("Quit")){
// Application.Quit();
// }
// }