using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ImpossibleBosses.PlayerController
{
    class PlayerController
    {
        private int playerNumber = 0;
        private Dictionary<Keys, String> commandTable = new Dictionary<Keys, String>();

        private void AddCommand(Keys key, String command)
        { commandTable.Add(key, command); }

        public PlayerController(int playerNumber)
        {
            this.playerNumber = playerNumber;
            Keys[] playerMovement = { Keys.W, Keys.A, Keys.S, Keys.D };
            String[] movementCommands = { "moveUp", "moveLeft", "moveDown", "moveRight" };
            Keys[] playerActions = { Keys.Q, Keys.E, Keys.V };
            String[] actionCommands = { "block", "attack", "special" };

            for (int i = 0; i < playerMovement.Length; i++)
            { AddCommand(playerMovement[i], movementCommands[i]); }
        }

        public Vector2 Update()
        {
            String command = "";
            Vector2 tempMoveDir = new Vector2();
            Vector2 finalMoveDir = new Vector2();
            
            foreach (Keys k in Keyboard.GetState().GetPressedKeys())
            {
                if (!commandTable.TryGetValue(k, out command))
                { continue; }
                tempMoveDir = ProcessCommand(command);
                finalMoveDir += tempMoveDir;
            }

            Vector2.Clamp(finalMoveDir, new Vector2(-1, -1), new Vector2(1, 1));

            return finalMoveDir;

        }

        private Vector2 ProcessCommand(String command)
        {
            switch (command)
            {
                case "moveUp": return new Vector2(0, -1);
                case "moveLeft": return new Vector2(-1, 0);
                case "moveDown": return new Vector2(0, 1);
                case "moveRight": return new Vector2(1, 0);
                default: return new Vector2(0, 0);
            }
        }
    }
}
