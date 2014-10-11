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

            Vector2.Clamp(finalMoveDir, new Vector2(-2, -2), new Vector2(2, 2));

            return finalMoveDir;

        }

        private Vector2 ProcessCommand(String command)
        {
            switch (command)
            {
                case "moveUp": return new Vector2(0, -2);
                case "moveLeft": return new Vector2(-2, 0);
                case "moveDown": return new Vector2(0, 2);
                case "moveRight": return new Vector2(2, 0);
                default: return new Vector2(0, 0);
            }
        }

        public static int GetFacing(Vector2 direction)
        {
            int facingMask = Convert.ToInt32("11111111", 2);
            switch ((int)direction.X)
            {
                case 2:  facingMask &= Convert.ToInt32("00001110", 2); break;
                case 0:  facingMask &= Convert.ToInt32("00010001", 2); break;
                case -2: facingMask &= Convert.ToInt32("11100000", 2); break;
            }
            switch ((int)direction.Y)
            {
                case 2:  facingMask &= Convert.ToInt32("00111000", 2); break;
                case 0:  facingMask &= Convert.ToInt32("01000100", 2); break;
                case -2: facingMask &= Convert.ToInt32("10000011", 2); break;
            }

            int newFacing = (int)Math.Log((double)facingMask, 2.0);
            if (facingMask == 0) { newFacing = -1; }
            return newFacing;
        }
    }
}
