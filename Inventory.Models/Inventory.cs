﻿
using Inventory.Models.Items;

namespace Inventory.Models
{
    public class Inventory
    {
        public int xSize { get; set; }
        public int ySize { get; set; }

        public Cell[,] cells;

        public Inventory(int xSize, int ySize)
        {
            this.xSize = xSize;
            this.ySize = ySize;
            cells = new Cell[xSize, ySize];
        }

        public void Add1Item(int x, int y)
        {
            cells[x, y].ItemsGroup.Count++;
        }

        public void Remove1Item(int x, int y)
        {
            cells[x, y].ItemsGroup.Count--;
        }

        public void AddItems(int x, int y, ItemsGroup ig)
        {
            cells[x, y] = new Cell(ig);
        }

        public void RemoveItems(int x, int y)
        {
            cells[x, y].ItemsGroup.Count = 0;
            cells[x, y].ItemsGroup.Item = null;
        }
    }
}