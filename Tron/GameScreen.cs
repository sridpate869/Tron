﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tron
{
    public partial class GameScreen : UserControl
    {
        List<Trail> playerTrailList = new List<Trail>();
        Rider OrangeRider = new Rider(745, 2, 5);
        Rider BlueRider = new Rider(150, 503, 5);
        int bufferDistanceY = 10, bufferDistanceX = 1;
        SolidBrush blueBrush = new SolidBrush(Color.DeepSkyBlue);
        SolidBrush orangeBrush = new SolidBrush(Color.OrangeRed);
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        public int riderWidth = 20;
        public int riderHeight = 55;
        public static string blueDirection = "Up", orangeDirection = "Down";
        int blueLives = 3, orangeLives = 3;
        Boolean rightArrowDown, leftArrowDown, upArrowDown, downArrowDown, aDown, wDown, sDown, dDown;

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.A:
                    aDown = true;
                    break;
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.D:
                    dDown = true;
                    break;
            }
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.A:
                    aDown = false;
                    break;
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.D:
                    dDown = false;
                    break;
            }
        }

        public GameScreen()
        {
            InitializeComponent();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            #region direction
            //BlueRider
            if (leftArrowDown && blueDirection != "Left" && blueDirection == "Up")
            {
                blueDirection = "Left";
                BlueRider.X -= 32;
                BlueRider.Y += 32;
            }
            else if (leftArrowDown && blueDirection != "Left" && blueDirection == "Down")
            {
                blueDirection = "Left";
                BlueRider.X -= 32;
                BlueRider.Y -= 6;
            }
            else if (rightArrowDown && blueDirection != "Right" && blueDirection == "Up")
            {
                blueDirection = "Right";
                BlueRider.X += 6;
                BlueRider.Y += 32;
            }
            else if (rightArrowDown && blueDirection != "Right" && blueDirection == "Down")
            {
                blueDirection = "Right";
                BlueRider.X += 6;
                BlueRider.Y -= 10;
            }
            else if (upArrowDown && blueDirection != "Up" && blueDirection == "Left")
            {
                blueDirection = "Up";
                BlueRider.X += 32;
                BlueRider.Y -= 32;
            }
            else if (upArrowDown && blueDirection != "Up" && blueDirection == "Right")
            {
                blueDirection = "Up";
                BlueRider.X -= 6;
                BlueRider.Y -= 32;
            }
            else if (downArrowDown && blueDirection != "Down" && blueDirection == "Left")
            {
                blueDirection = "Down";
                BlueRider.X += 32;
                BlueRider.Y += 6;
            }
            else if (downArrowDown && blueDirection != "Down" && blueDirection == "Right")
            {
                blueDirection = "Down";
                BlueRider.X -= 6;
                BlueRider.Y += 6;
            }

            //OrangeRider
            if (aDown && orangeDirection != "Left" && orangeDirection == "Up")
            {
                orangeDirection = "Left";
                OrangeRider.X -= 23;
                OrangeRider.Y += 32;
            }
            else if (aDown && orangeDirection != "Left" && orangeDirection == "Down")
            {
                orangeDirection = "Left";
                OrangeRider.X -= 23;
                OrangeRider.Y -= 6;
            }
            else if (dDown && orangeDirection != "Right" && orangeDirection == "Up")
            {
                orangeDirection = "Right";
                OrangeRider.X += 6;
                OrangeRider.Y += 32;
            }
            else if (dDown && orangeDirection != "Right" && orangeDirection == "Down")
            {
                orangeDirection = "Right";
                OrangeRider.X += 6;
                OrangeRider.Y -= 10;
            }
            else if (wDown && orangeDirection != "Up" && orangeDirection == "Left")
            {
                orangeDirection = "Up";
                OrangeRider.X += 28;
                OrangeRider.Y -= 32;
            }
            else if (wDown && orangeDirection != "Up" && orangeDirection == "Right")
            {
                orangeDirection = "Up";
                OrangeRider.X -= 6;
                OrangeRider.Y -= 32;
            }
            else if (sDown && orangeDirection != "Down" && orangeDirection == "Left")
            {
                orangeDirection = "Down";
                OrangeRider.X += 28;
                OrangeRider.Y += 6;
            }
            else if (sDown && orangeDirection != "Down" && orangeDirection == "Right")
            {
                orangeDirection = "Down";
                OrangeRider.X -= 6;
                OrangeRider.Y += 6;
            }
            #endregion

            #region Movement & Adding Trail
            if (blueDirection == "Up" && BlueRider.Y > 0)
            {
                BlueRider.PlayerMoveUpDown(blueDirection);
                Trail newtrail = new Trail(BlueRider.X + bufferDistanceX, BlueRider.Y + BlueRider.riderHeight + bufferDistanceY, blueBrush);
                playerTrailList.Add(newtrail);
            }
            else if (blueDirection == "Down" && BlueRider.Y + BlueRider.riderHeight < this.Height)
            {
                BlueRider.PlayerMoveUpDown(blueDirection);
                Trail newtrail = new Trail(BlueRider.X + bufferDistanceX, BlueRider.Y - bufferDistanceY, blueBrush);
                playerTrailList.Add(newtrail);
            }
            else if (blueDirection == "Left" && BlueRider.X > 0)
            {
                BlueRider.PlayerMoveLeftRight(blueDirection);
                Trail newtrail = new Trail(BlueRider.X + BlueRider.riderWidth + bufferDistanceY, BlueRider.Y + bufferDistanceX, blueBrush);
                playerTrailList.Add(newtrail);
            }
            else if (blueDirection == "Right" && BlueRider.X + BlueRider.riderWidth < this.Width)
            {
                BlueRider.PlayerMoveLeftRight(blueDirection);
                Trail newtrail = new Trail(BlueRider.X - bufferDistanceY, BlueRider.Y + bufferDistanceX, blueBrush);
                playerTrailList.Add(newtrail);
            }

            if (orangeDirection == "Up" && OrangeRider.Y > 0)
            {
                OrangeRider.PlayerMoveUpDown(orangeDirection);
                Trail newtrail = new Trail(OrangeRider.X + bufferDistanceX, OrangeRider.Y + OrangeRider.riderHeight + bufferDistanceY, orangeBrush);
                playerTrailList.Add(newtrail);
            }
            else if (orangeDirection == "Down" && OrangeRider.Y + OrangeRider.riderHeight < this.Height)
            {
                OrangeRider.PlayerMoveUpDown(orangeDirection);
                Trail newtrail = new Trail(OrangeRider.X + bufferDistanceX, OrangeRider.Y - bufferDistanceY, orangeBrush);
                playerTrailList.Add(newtrail);
            }
            else if (orangeDirection == "Left" && OrangeRider.X > 0)
            {
                OrangeRider.PlayerMoveLeftRight(orangeDirection);
                Trail newtrail = new Trail(OrangeRider.X + OrangeRider.riderWidth + bufferDistanceX, OrangeRider.Y + bufferDistanceX, orangeBrush);
                playerTrailList.Add(newtrail);
            }
            else if (orangeDirection == "Right" && OrangeRider.X + OrangeRider.riderWidth < this.Width)
            {
                OrangeRider.PlayerMoveLeftRight(orangeDirection);
                Trail newtrail = new Trail(OrangeRider.X - bufferDistanceY, OrangeRider.Y + bufferDistanceX, orangeBrush);
                playerTrailList.Add(newtrail);
            }
            #endregion

            #region Collision
            //if (BlueRider.Y <= 0 || BlueRider.Y + BlueRider.riderHeight >= this.Height || BlueRider.X <= 0 || BlueRider.X + BlueRider.riderWidth >= this.Width || OrangeRider.Y <= 0 || OrangeRider.Y + OrangeRider.riderHeight >= this.Height || OrangeRider.X <= 0 || OrangeRider.X + OrangeRider.riderWidth >= this.Width)
            //{
            //    playerTrailList.Clear();
            //    BlueRider.Reset();
            //    OrangeRider.Reset();
            //    blueDirection = "Up";
            //    orangeDirection = "Down";
            //}
            //foreach (Trail x in playerTrailList)
            //{
            //    Trail tempTrail = new Trail(x.trailX, x.trailY, x.colour);
            //    if (BlueRider.Collision(tempTrail) || OrangeRider.Collision(tempTrail))
            //    {
            //        //gameTimer.Enabled = false;
            //        BlueRider.Reset();
            //        OrangeRider.Reset();
            //        blueDirection = "Up";
            //        orangeDirection = "Down";
            //        playerTrailList.Clear();
            //        break;
            //    }
            //}
            #endregion

            Refresh();
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            foreach (Trail b in playerTrailList)
            {
                e.Graphics.FillRectangle(b.colour, b.trailX, b.trailY, b.trailWidth, b.trailHeight);
            }
            e.Graphics.FillRectangle(whiteBrush, BlueRider.X, BlueRider.Y, BlueRider.riderWidth, BlueRider.riderHeight);
            e.Graphics.FillRectangle(whiteBrush, OrangeRider.X, OrangeRider.Y, OrangeRider.riderWidth, OrangeRider.riderHeight);
        }
    }
}