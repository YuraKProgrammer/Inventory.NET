using Inventory.Models.Items;
using Inventory.Models.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models
{
    public class Game
    {
        public Inventory Inventory = new Inventory(9, 5);
        public CraftingTable CraftingTable = new CraftingTable();
        public ItemsGroup TakenItemsGroup = new ItemsGroup(null, 0);
        public List<Recipe> recipes = new List<Recipe>();
        public CraftingTableManager craftingTableManager = new CraftingTableManager();
        public ItemGiverManager giverManager = new ItemGiverManager();
        public const int maxStackSize = 10;

        public void TakeOneItem(int x, int y)
        {
            if (CellVoidChecker.CheckCellIsNotEmpty(Inventory.cells[x, y]))
            {
                var i = Inventory.cells[x, y].ItemsGroup.Item;
                Inventory.Remove1Item(x, y);
                TakenItemsGroup = new ItemsGroup(i, 1);
            }
        }

        public void PutOneItem(int x, int y)
        {
            if (CellVoidChecker.CheckCellIsNotEmpty(Inventory.cells[x, y]))
            {
                if (Inventory.cells[x, y].ItemsGroup.Item == TakenItemsGroup.Item)
                {
                    Inventory.Add1Item(x, y);
                    TakenItemsGroup.Count--;
                }
            }
            else
            {
                Inventory.cells[x,y]=new Cell(new ItemsGroup(TakenItemsGroup.Item,1));
                TakenItemsGroup.Count--;
            }
        }

        public void TakeItemsGroup(int x, int y)
        {
            if (CellVoidChecker.CheckCellIsNotEmpty(Inventory.cells[x, y]))
            {
                var i = Inventory.cells[x, y].ItemsGroup;
                Inventory.RemoveItems(x, y);
                TakenItemsGroup = i;
            }
        }

        public void PutItemsGroup(int x, int y)
        {
            if (CellVoidChecker.CheckCellIsNotEmpty(Inventory.cells[x, y]))
            {
                var b = Inventory.AddItems(x, y, TakenItemsGroup);
                if (b == true)
                {
                    TakenItemsGroup.Item=null;
                    TakenItemsGroup.Count=0;
                }
            }
            else
            {
                Inventory.cells[x, y] = new Cell(TakenItemsGroup);
                TakenItemsGroup.Item = null;
                TakenItemsGroup.Count = 0;
            }
        }
    }
}
