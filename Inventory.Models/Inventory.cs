
using Inventory.Models.Items;
using Inventory.Models.Managers;

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

        public bool AddItems(int x, int y, ItemsGroup ig)
        {
            if (CellVoidChecker.CheckCellIsNotEmpty(cells[x, y]))
            {
                cells[x, y] = new Cell(ig);
                return true;
            }
            else
            {
                if (cells[x, y].ItemsGroup.Item == ig.Item)
                {
                    cells[x, y].ItemsGroup.Count = cells[x, y].ItemsGroup.Count + ig.Count;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public ItemsGroup RemoveItems(int x, int y)
        {
            var c = cells[x, y].ItemsGroup;
            cells[x, y].ItemsGroup.Count = 0;
            cells[x, y].ItemsGroup.Item = null;
            return c;
        }
    }
}