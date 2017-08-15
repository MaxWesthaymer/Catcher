using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class GooglePlay : MonoBehaviour
{
		//leaderboard strings
		public string leaderboardID;

		// Use this for initialization
		void Start()
		{
				PlayGamesPlatform.Activate();
		}
				

				//Share Status
				public void LogIn()
				{
						Social.localUser.Authenticate((bool success) =>
								{
										if (success)
										{
												Debug.Log("You've successfully logged in");
										PostToLeaderboard(PlayerPrefs.GetInt ("higscore"));
										ShowSpecificLeaderboard();
										}
										else
										{
												Debug.Log("Login failed for some reason");
										}
								});
				}
										

				//Leaderboard
		public void PostToLeaderboard(int addScore)
				{
						if (Social.localUser.authenticated)
						{
						Social.ReportScore(addScore, leaderboardID, (bool success) =>
										{
												if (success)
												{
												Debug.Log("success!!!!!");
												}
												else
												{
														Debug.Log("Login failed!!!!! for some reason");
												}
										});
						}
				}



				// Show Leaderboard
				public void ShowLeaderboard()
				{
						Social.ShowLeaderboardUI();
				}



				//Show Specific Leaderboard
				public void ShowSpecificLeaderboard()
				{
						((PlayGamesPlatform)Social.Active).ShowLeaderboardUI(leaderboardID);
				}
						

				//Sign Out
				public void SignOut()
				{
						((PlayGamesPlatform)Social.Active).SignOut();
				}


}