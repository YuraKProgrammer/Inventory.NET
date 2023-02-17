using Inventory.Models;
using Inventory.Models.Items;
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
            for (var x = 0; x < game.Inventory.xSize; x++)
            {
                for (var y = 0; y < game.Inventory.ySize; y++)
                {
                    DrawInventoryCell(x, y);
                }
            }
        }

        public void DrawInventoryCell(int x, int y)
        {
            var bitmapImage = new BitmapImage();
            var cl = game.Inventory.cells[x, y];
            if (!CellVoidChecker.CheckCellIsNotEmpty(cl))
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
        }

        public void DrawCraftingTableResult()
        {
            var bitmapImage = new BitmapImage();
            var rs = game.CraftingTable.Result;
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

        public void DrawTakenItemsGroup()
        {
            var tig = game.TakenItemsGroup;
            if (CellVoidChecker.CheckItemsGroupIsNotEmpty(tig))
            {
                var x = (int)(Mouse.GetPosition(_inventory).X);
                var y = (int)(Mouse.GetPosition(_inventory).Y);
                var bitmapImage = new BitmapImage(new Uri(tig.Item.Image, UriKind.RelativeOrAbsolute));
                System.Windows.Controls.Image image = new System.Windows.Controls.Image();
                image.Width = CellSize;
                image.Height = CellSize;
                image.Source = bitmapImage;
                Canvas.SetLeft(image, CellSize * x);
                Canvas.SetTop(image, CellSize * y);
                _craftingTable.Children.Add(image);
            }
        }

        public void _exit(object sender, EventArgs e)
        {
            this.Close();
        }

        public void _takePutOne(object sender, MouseButtonEventArgs e)
        {
            var x = (int)(e.GetPosition(_inventory).X / CellSize);
            var y = (int)(e.GetPosition(_inventory).Y / CellSize);
            var tig = game.TakenItemsGroup;
            if (CellVoidChecker.CheckItemsGroupIsNotEmpty(tig))
            {
                game.TakeOneItem(x, y);
            }
            else
            {
                game.PutOneItem(x, y);
            }
        }

        public void _takePutGroup(object sender, MouseButtonEventArgs e)
        {
            var x = (int)(e.GetPosition(_inventory).X / CellSize);
            var y = (int)(e.GetPosition(_inventory).Y / CellSize);
            var tig = game.TakenItemsGroup;
            if (CellVoidChecker.CheckItemsGroupIsNotEmpty(tig))
            {
                game.TakeItemsGroup(x, y);
            }
            else
            {
                game.PutOneItem(x, y);
            }
        }

        public void _craftTakePutOne(object sender, MouseButtonEventArgs e)
        {

        }

        public void _craftTakePutGroup(object sender, MouseButtonEventArgs e)
        {

        }

        public void _givePlanks(object sender, RoutedEventArgs e)
        {
            game.GiveItem(new Planks());
            Update();
        }

        public void _giveStick(object sender, RoutedEventArgs e)
        {
            game.GiveItem(new Stick());
            Update();
        }


    }
}


