using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

namespace Chapter.Observer
{

    public class HUDController : Chapter.Singleton.Singleton<HUDController>
    {

        private int player1Deaths = 0;
        private int player2Deaths = 0;
        private PlayerMovement1 player1;
        private PlayerMovement2 player2;

        void OnGUI()
        {
            GUILayout.BeginArea(
                new Rect(300, 20, 100, 200));

            GUILayout.BeginHorizontal("box");
            GUILayout.Label("Player 1 Deaths: " + player1Deaths);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal("box");
            GUILayout.Label("Player 2 Deaths: " + player2Deaths);
            GUILayout.EndHorizontal();

            GUILayout.EndArea();
        }

        public override void Notify(Subject subject)
        {
            if (!player1)
                player1 = subject.GetComponent<PlayerMovement1>();

            if (!player2)
                player2 = subject.GetComponent<PlayerMovement2>();

            if (player1)
            {
                player1Deaths++;
            }
            if (player2)
            {
                player2Deaths++;
            }
        }

    }

}