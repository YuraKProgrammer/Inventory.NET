﻿using Inventory.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models
{
    public static class Comparer
    {
        public static bool CompareIngregients(Cell[,] i1, Cell[,] i2)
        {
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if (!CompareItemsGroups(i1[x, y].ItemsGroup, i2[x, y].ItemsGroup))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static bool CompareItemsGroups(ItemsGroup ig1, ItemsGroup ig2)
        {
            if (ig1==null && ig2 == null)
            {
                return true;
            }
            if ((ig1==null && ig2!=null) || (ig1 != null && ig2 == null))
            {
                return false;
            }
            if (CompareItems(ig1.Item,ig2.Item) && ig1.Count == ig2.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CompareItems(IItem it1, IItem it2)
        {
            if (it1.Image == it2.Image)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
