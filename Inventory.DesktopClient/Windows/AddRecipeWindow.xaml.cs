using Inventory.Models;
using Inventory.Models.Items;
using Inventory.Models.Managers;
using Inventory.RecipesStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Inventory.DesktopClient.Windows
{
    /// <summary>
    /// Interaction logic for AddRecipeWindow.xaml
    /// </summary>
    public partial class AddRecipeWindow : Window
    {
        public const int CellSize = 100;
        public IRecipesStorage recipesStorage = new TempRecipesStorage();
        public ItemsGroup TakenItemsGroup = new ItemsGroup(null, 0);
        public CraftingTable craftingTable = new CraftingTable();
        public ItemGiverManager ItemGiver = new ItemGiverManager();
        public IRecipesStorage recipeStorage = new TempRecipesStorage();
        public const int maxStackSize = 10;
        public AddRecipeWindow()
        {
            InitializeComponent();
            DrawCraftingTable();
        }

        public void _craftTakePutOne(object sender, MouseButtonEventArgs e)
        {
            var x = (int)(e.GetPosition(_craftingTable).X / CellSize);
            var y = (int)(e.GetPosition(_craftingTable).Y / CellSize);
            if (!CellVoidChecker.CheckItemsGroupIsNotEmpty(TakenItemsGroup))
            {
                TakeOneItemCT(x, y);
            }
            else
            {
                PutOneItemCT(x, y);
            }
            DrawCraftingTable();
        }

        public void TakeOneItemCT(int x, int y)
        {
            if (x < 3)
            {
                if (CellVoidChecker.CheckCellIsNotEmpty(craftingTable.Ingredients[x, y]))
                {
                    var i = craftingTable.Ingredients[x, y].ItemsGroup.Item;
                    craftingTable.Ingredients[x, y].ItemsGroup.Count--;
                    TakenItemsGroup = new ItemsGroup(i, 1);
                }
            }
        }

        public void PutOneItemCT(int x, int y)
        {
            if (x < 3)
            {
                if (CellVoidChecker.CheckCellIsNotEmpty(craftingTable.Ingredients[x, y]))
                {
                    if (Comparer.CompareItems(craftingTable.Ingredients[x, y].ItemsGroup.Item, TakenItemsGroup.Item))
                    {
                        craftingTable.Ingredients[x, y].ItemsGroup.Count++;
                        TakenItemsGroup.Count--;
                    }
                }
                else
                {
                    craftingTable.Ingredients[x, y] = new Cell(new ItemsGroup(TakenItemsGroup.Item, 1));
                    TakenItemsGroup.Count--;
                }
            }
            else
            {
                if (CellVoidChecker.CheckCellIsNotEmpty(craftingTable.Result))
                {
                    if (!Comparer.CompareItems(craftingTable.Result.ItemsGroup.Item, TakenItemsGroup.Item))
                    {
                        craftingTable.Result.ItemsGroup.Count++;
                        TakenItemsGroup.Count--;
                    }
                }
                else
                {
                    craftingTable.Result = new Cell(new ItemsGroup(TakenItemsGroup.Item, 1));
                    TakenItemsGroup.Count--;
                }
            }
        }

        public void DrawCraftingTable()
        {
            for (var x = 0; x < 3; x++)
            {
                for (var y = 0; y < 3; y++)
                {
                    DrawCraftingTableCell(x, y);
                }
            }
            DrawCraftingTableResult();
        }

        public void DrawCraftingTableCell(int x, int y)
        {
            var bitmapImage = new BitmapImage();
            var ig = craftingTable.Ingredients[x, y];
            if (!CellVoidChecker.CheckCellIsNotEmpty(ig))
            {
                bitmapImage = new BitmapImage(new Uri(@"/Inventory.DesktopClient;component/images/empty.png", UriKind.RelativeOrAbsolute));
            }
            else
            {
                bitmapImage = new BitmapImage(new Uri(ig.ItemsGroup.Item.Image, UriKind.RelativeOrAbsolute));
            }
            System.Windows.Controls.Image image = new System.Windows.Controls.Image();
            image.Width = CellSize;
            image.Height = CellSize;
            image.Source = bitmapImage;
            Canvas.SetLeft(image, CellSize * x);
            Canvas.SetTop(image, CellSize * y);
            _craftingTable.Children.Add(image);
            TextBlock textBlock = new TextBlock();
            textBlock.FontSize = 12;
            if (CellVoidChecker.CheckCellIsNotEmpty(ig))
            {
                textBlock.Text = (ig.ItemsGroup.Count).ToString();
            }
            Canvas.SetLeft(textBlock, CellSize * x + 0.8 * CellSize);
            Canvas.SetTop(textBlock, CellSize * y + 0.8 * CellSize);
            _craftingTable.Children.Add(textBlock);
        }

        public void DrawCraftingTableResult()
        {
            var bitmapImage = new BitmapImage();
            var rs = craftingTable.Result;
            if (!CellVoidChecker.CheckCellIsNotEmpty(rs))
            {
                bitmapImage = new BitmapImage(new Uri(@"/Inventory.DesktopClient;component/images/empty.png", UriKind.RelativeOrAbsolute));
            }
            else
            {
                bitmapImage = new BitmapImage(new Uri(rs.ItemsGroup.Item.Image, UriKind.RelativeOrAbsolute));
            }
            System.Windows.Controls.Image image = new System.Windows.Controls.Image();
            image.Width = CellSize;
            image.Height = CellSize;
            image.Source = bitmapImage;
            Canvas.SetLeft(image, CellSize * 3);
            Canvas.SetTop(image, CellSize * 1);
            _craftingTable.Children.Add(image);
        }

        public void _givePlanks(object sender, RoutedEventArgs e)
        {
            GiveItem(new Planks());
            DrawCraftingTable();
        }

        public void _giveStick(object sender, RoutedEventArgs e)
        {
            GiveItem(new Stick());
            DrawCraftingTable();
        }

        public void _giveWoodSword(object sender, RoutedEventArgs e)
        {
            GiveItem(new WoodSword());
            DrawCraftingTable();
        }

        public void _giveIronIngot(object sender, RoutedEventArgs e)
        {
            GiveItem(new IronIngot());
            DrawCraftingTable();
        }

        public void _giveDiamond(object sender, RoutedEventArgs e)
        {
            GiveItem(new Diamond());
            DrawCraftingTable();
        }

        public void _giveDiamondPickaxe(object sender, RoutedEventArgs e)
        {
            GiveItem(new DiamondPickaxe());
            DrawCraftingTable();
        }

        public void GiveItem(IItem item)
        {
            craftingTable = ItemGiver.GiveItemCT(craftingTable, item, maxStackSize);
        }

        public void AddRecipe(object sender, RoutedEventArgs e)
        {
            var r = Converter.CraftingTableToRecipe(craftingTable);
            recipesStorage.Save(r);
            this.Close();
        }
    }
}
