using System;
using System.Collections.Generic;

namespace Opdracht10TorensVanHanoi
{
    internal class TowerOfHanoiTower
    {
        private List<TowerOfHanoiDisk> disks;
        private int horizontalMiddle;
        private int bottom;

        public TowerOfHanoiTower(int towerMiddle, int towerBottom)
        {
            disks = new List<TowerOfHanoiDisk>();

            horizontalMiddle = towerMiddle;
            bottom = towerBottom;
        }

        internal void ReceiveDisk(TowerOfHanoiDisk disk)
        {
            disks.Add(disk);
        }
        internal TowerOfHanoiDisk GetTopDisk()
        {
            if (disks.Count > 0)
            {
                return disks[disks.Count - 1];
            }
            return null;
        }
        internal bool CanReceiveDisk(TowerOfHanoiDisk testDisk)
        {
            TowerOfHanoiDisk topDisks = GetTopDisk();
            if (topDisks != null)
            {
                return testDisk.IsSmallerThenDisk(topDisks);
            }
            else
            {
                return true;
            }
        }
        internal void ResetDiskLocation()
        {
            int height = bottom;
            foreach(TowerOfHanoiDisk disk in disks)
            {
                height -= disk.GetHeight();
                disk.ResetLocation(horizontalMiddle, height);
            }
        }
        internal void RemoveDisk(TowerOfHanoiDisk disk)
        {
            disks.Remove(disk);
        }
        internal bool IsTopDisk(TowerOfHanoiDisk disk)
        {
            return GetTopDisk() == disk;
        }
    }
}