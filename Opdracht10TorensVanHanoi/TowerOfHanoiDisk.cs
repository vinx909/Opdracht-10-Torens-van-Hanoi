using System;
using System.Windows.Forms;

namespace Opdracht10TorensVanHanoi
{
    internal class TowerOfHanoiDisk
    {
        private const string moveLeftButtonString = "<";
        private const string moveRightButtonString = ">";

        private Form1 form;
        private TowerOfHanoiTower tower;

        private Button moveLeftButton;
        private Button moveRightButton;

        public TowerOfHanoiDisk(Form1 form, int diskWidth, int diskHeight)
        {
            this.form = form;

            moveLeftButton = new Button();
            moveRightButton = new Button();
            moveLeftButton.Text = moveLeftButtonString;
            moveRightButton.Text = moveRightButtonString;
            moveLeftButton.Height = diskHeight;
            moveRightButton.Height = diskHeight;
            moveLeftButton.Width = diskWidth / 2;
            moveRightButton.Width = diskWidth / 2;
            form.Controls.Add(moveLeftButton);
            form.Controls.Add(moveRightButton);
            moveLeftButton.Click += new EventHandler(MoveLeftButtonFunction);
            moveRightButton.Click += new EventHandler(MoveRightButtonFunction);
        }
        public TowerOfHanoiDisk(Form1 form, int v, int diskHeight, TowerOfHanoiTower tower) : this(form,v, diskHeight)
        {
            this.tower = tower;
        }

        internal bool IsSmallerThenDisk(TowerOfHanoiDisk topDisks)
        {
            return moveLeftButton.Width < topDisks.moveLeftButton.Width;
        }
        public void SetTower(TowerOfHanoiTower tower)
        {
            this.tower = tower;
        }
        internal int GetHeight()
        {
            return moveLeftButton.Height;
        }
        internal TowerOfHanoiTower GetTower()
        {
            return tower;
        }
        internal void ResetLocation(int horizontalMiddle, int height)
        {
            moveLeftButton.Location = new System.Drawing.Point(horizontalMiddle - moveLeftButton.Width, height);
            moveRightButton.Location = new System.Drawing.Point(horizontalMiddle, height);
        }

        private void MoveLeftButtonFunction(object sender, EventArgs e)
        {
            form.TryToMoveDiskLeft(this);
        }
        private void MoveRightButtonFunction(object sender, EventArgs e)
        {
            form.tryToMoveDiskRight(this);
        }

        internal void MoveToTower(TowerOfHanoiTower newTower)
        {
            tower.RemoveDisk(this);
            tower = newTower;
            tower.ReceiveDisk(this);
        }
    }
}