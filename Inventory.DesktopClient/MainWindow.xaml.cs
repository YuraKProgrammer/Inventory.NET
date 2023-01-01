using Inventory.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Inventory.DesktopClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Game game = new Game();
        public const int CellSize = 100;
        public IRecipesStorage recipesStorage = new TempRecipesStorage();
        public MainWindow()
        {
            InitializeComponent();
            game.recipes = recipesStorage.LoadAll();
            Update();
        }

        public void Update()
        {
            DrawInventory();
            DrawTakenItemsGroup();
            DrawCraftingTable();
        }

        public void DrawInventory()
        { 
            for (var x=0; x<game.Inventory.xSize; x++)
            {
                for (var y=0; y<game.Inventory.ySize; y++)
                {
                    DrawInventoryCell(x,y);
                }
            }
        }

        public void DrawInventoryCell(int x, int y)
        {
            var bitmapImage = new BitmapImage();
            var cl = game.Inventory.cells[x, y];
            if (cl == null || cl.ItemsGroup.Count==0 || cl.ItemsGroup.Item == null)
            {
                bitmapImage = new BitmapImage(new Uri(@"/Inventory.DesktopClient;component/images/empty.png", UriKind.RelativeOrAbsolute));
            }
            else
            {
                bitmapImage = new BitmapImage(new Uri(cl.ItemsGroup.Item.Image, UriKind.RelativeOrAbsolute));
            }
            System.Windows.Controls.Image image = new System.Windows.Controls.Image();
            image.Width = CellSize;
            image.Height = CellSize;
            image.Source = bitmapImage;
            Canvas.SetLeft(image, CellSize * x);
            Canvas.SetTop(image, CellSize * y);
            _inventory.Children.Add(image);
        }

        public void DrawCraftingTable()
        {
            for (var x = 0; x < 3; x++)
            {
                for (var y = 0; y < 3; y++)
                {
                    DrawInventoryCell(x, y);
                }
            }
            DrawCraftingTableResult();
        }

        public void DrawCraftingTableCell(int x, int y)
        {
            var bitmapImage = new BitmapImage();
            var ig = game.CraftingTable.Ingredients[x, y];
            if (ig == null || ig.ItemsGroup.Count == 0 || ig.ItemsGroup.Item == null)
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
        }

        public void DrawCraftingTableResult()
        {
            /*
            if (game.CraftingTable.cells[x, y] == null || game.Inventory.cells[x, y].ItemsGroup.Count == 0 || game.Inventory.cells[x, y].ItemsGroup.Item == null)
            {
                bitmapImage = new BitmapImage(new Uri(@"/Inventory.DesktopClient;component/images/empty.png", UriKind.RelativeOrAbsolute));
            }
            else
            {
                bitmapImage = new BitmapImage(new Uri(game.Inventory.cells[x, y].ItemsGroup.Item.Image, UriKind.RelativeOrAbsolute));
            }
            */
        }

        public void DrawTakenItemsGroup()
        {

        }
    }
}


