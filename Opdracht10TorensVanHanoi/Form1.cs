using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Opdracht10TorensVanHanoi
{
    public partial class Form1 : Form
    {
        private const string exceptionTowerNotFoundInTowers = "the given tower was not found";

        private const int numberOfTowers = 3;
        private const int numberOfDisks = 10;

        private int towerWidth;
        private int diskHeight;
        private int diskWidthIncrement;

        private TowerOfHanoiTower[] towers;

        public Form1()
        {
            InitializeComponent();
            SetupVariables();
            ResetLocations();
        }

        private void SetupVariables()
        {
            towerWidth = ClientRectangle.Width / numberOfTowers;
            diskHeight = ClientRectangle.Height / numberOfDisks;
            diskWidthIncrement = towerWidth / numberOfDisks;

            towers = new TowerOfHanoiTower[numberOfTowers];

            for(int i = 0; i < towers.Length; i++)
            {
                towers[i] = new TowerOfHanoiTower(towerWidth*i+ towerWidth/2, ClientRectangle.Height);
            }

            if (towers.Length > 0)
            {
                for(int i = 0; i < numberOfDisks; i++)
                {
                    towers[0].ReceiveDisk(new TowerOfHanoiDisk(this, diskWidthIncrement*(numberOfDisks-i), diskHeight, towers[0]));
                }
            }
        }
        private void ResetLocations()
        {
            foreach(TowerOfHanoiTower tower in towers)
            {
                tower.ResetDiskLocation();
            }
        }
        private int GetTowerIndex(TowerOfHanoiTower tower)
        {
            for(int i = 0; i < towers.Length; i++)
            {
                if (towers[i] == tower)
                {
                    return i;
                }
            }
            throw new Exception(exceptionTowerNotFoundInTowers);
        }

        internal void TryToMoveDiskLeft(TowerOfHanoiDisk disk)
        {
            int towerIndex = GetTowerIndex(disk.GetTower());
            if (towers[towerIndex].IsTopDisk(disk))
            {
                if (towerIndex > 0)
                {
                    if (towers[towerIndex - 1].CanReceiveDisk(disk))
                    {
                        disk.MoveToTower(towers[towerIndex - 1]);
                        ResetLocations();
                    }
                }
            }
        }
        internal void tryToMoveDiskRight(TowerOfHanoiDisk disk)
        {
            int towerIndex = GetTowerIndex(disk.GetTower());
            if (towers[towerIndex].IsTopDisk(disk))
            {
                if (towerIndex <= towers.Length-2)
                {
                    if (towers[towerIndex + 1].CanReceiveDisk(disk))
                    {
                        disk.MoveToTower(towers[towerIndex + 1]);
                        ResetLocations();
                    }
                }
            }
        }
    }
}
