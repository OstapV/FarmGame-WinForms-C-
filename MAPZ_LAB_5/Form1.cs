using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MAPZ_LAB_5.ChainOfResponsibility;
using MAPZ_LAB_5.Strategy;
using MAPZ_LAB_5.TemplateMethod;

namespace MAPZ_LAB_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int upgrade;
        int change;
        Image bgImg;
        Image secondLevelFarm;

        Timer treeTimer;
        Timer wheatTimer;
        Timer pumpkinTimer;
        Timer chickenTimer;
        Timer fishingTimer;

        AbstractFarm abstractFarm1;
        AbstractFarm abstractFarm2;
        Client SecondLevelFarm;
        Client FirstLevelFarm;

        WarehouseMan warehouseMan;
        StorageBuilder storageBuilder;
        Storage woodStorage;
        Storage productStorage;

        BoosterFacade facadeClient;
        ChickenGateBooster chickenB;
        FishingPortBooster fishB;
        ForestBooster forestB;
        GardenBooster gardenB;
        SawmillBooster sawmillB;

        ImageChangerProxy proxy;

        Folder root;
        Folder buildings;
        Folder other;


        Boost boostChicken;
        Boost boostFishing;
        Boost boostForest;

        Customer customer;
        PurchaseHandler purchaseSimple;
        PurchaseHandler purchaseMaintance;
        PurchaseHandler purchaseWithDiscount;

        List<string> units;
        ContextAnalyzer buildingsAnalyzer;
        ContextAnalyzer productAnalyzer;

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // -> Composite
            root = new Folder("Images", "C:\\Users\\lenovo\\source\\repos\\MAPZ_LAB_4\\Images");
            buildings = new Folder("Buildings", "C:\\Users\\lenovo\\source\\repos\\MAPZ_LAB_4\\Buildings");
            other = new Folder("Other", "C:\\Users\\lenovo\\source\\repos\\MAPZ_LAB_4\\Other");

            buildings.Add(new FolderLeaf("farmSecondLevel", "C:\\Users\\lenovo\\source\\repos\\MAPZ_LAB_4\\Images\\farmSecondLevel.png"));
            buildings.Add(new FolderLeaf("fishing", "C:\\Users\\lenovo\\source\\repos\\MAPZ_LAB_4\\Images\\fishing.png"));
            buildings.Add(new FolderLeaf("fishing2", "C:\\Users\\lenovo\\source\\repos\\MAPZ_LAB_4\\Images\\fishing2.png"));
            buildings.Add(new FolderLeaf("sawmill", "C:\\Users\\lenovo\\source\\repos\\MAPZ_LAB_4\\Images\\sawmill.png"));
            buildings.Add(new FolderLeaf("sawmill2", "C:\\Users\\lenovo\\source\\repos\\MAPZ_LAB_4\\Images\\sawmill2.png"));
            buildings.Add(new FolderLeaf("farm", "C:\\Users\\lenovo\\source\\repos\\MAPZ_LAB_4\\Images\\farm.png"));

            root.Add(buildings);

            other.Add(new FolderLeaf("tree", "C:\\Users\\lenovo\\source\\repos\\MAPZ_LAB_4\\Images\\tree.png"));
            other.Add(new FolderLeaf("chickenGreen", "C:\\Users\\lenovo\\source\\repos\\MAPZ_LAB_4\\Images\\chickenGreen.png"));
            other.Add(new FolderLeaf("treeFelled", "C:\\Users\\lenovo\\source\\repos\\MAPZ_LAB_4\\Images\\treeFelled.png"));
            other.Add(new FolderLeaf("farmSecondLevel", "C:\\Users\\lenovo\\source\\repos\\MAPZ_LAB_4\\Images\\farmSecondLevel.png"));
            other.Add(new FolderLeaf("garbuz", "C:\\Users\\lenovo\\source\\repos\\MAPZ_LAB_4\\Images\\garbuz.png"));
            other.Add(new FolderLeaf("psenizia", "C:\\Users\\lenovo\\source\\repos\\MAPZ_LAB_4\\Images\\psenizia.png"));

            root.Add(other);

            
            // -> ChainOfResponsibility
            purchaseSimple = new Purchase();
            purchaseMaintance = new PurchaseMaintance();
            purchaseWithDiscount = new PurchaseWithDiscount();
            
            purchaseSimple.Succesor = purchaseMaintance;
            purchaseMaintance.Succesor = purchaseWithDiscount;

            
            // -> Abstract Factory
            abstractFarm1 = new ConcreteFarmLvl1();
            FirstLevelFarm = new Client(abstractFarm1);
            abstractFarm2 = new ConcreteFarmLvl2();
            SecondLevelFarm = new Client(abstractFarm2);

            // -> Proxy
            proxy = new ImageChangerProxy();
          
            // -> Builder
            warehouseMan = new WarehouseMan();
            storageBuilder = new WoodStorage();
            woodStorage = warehouseMan.Service(storageBuilder);
            storageBuilder = new ProductsStorage();
            productStorage = warehouseMan.Service(storageBuilder);
          

            // -> Timers
            treeTimer = new Timer();
            wheatTimer = new Timer();
            pumpkinTimer = new Timer();
            chickenTimer = new Timer();
            fishingTimer = new Timer();

            FirstLevelFarm.Forest.resourceDropTime = new TimeSpan(0, 1, 0);
            FirstLevelFarm.Garden.wheatDropTime = new TimeSpan(0, 0, 55);
            FirstLevelFarm.Garden.pumpkinDropTime = new TimeSpan(0, 0, 45);
            FirstLevelFarm.ChickenGate.resourceDropTime = new TimeSpan(0, 0, 10);
            FirstLevelFarm.FishingPort.fishDropTime = new TimeSpan(0, 0, 20);
            FirstLevelFarm.Sawmill.productionIncrease = 2;

            //-> Strategy

            boostChicken = new Boost(FirstLevelFarm.ChickenGate.resourceDropTime, new ChickenGateBoost());
            boostFishing = new Boost(FirstLevelFarm.FishingPort.fishDropTime, new FishingPortBoost());
            boostForest = new Boost(FirstLevelFarm.Forest.resourceDropTime, new ForestBoost());
            boostChicken.MakeBoost();
            boostFishing.MakeBoost();
            boostForest.MakeBoost();



            // -> TemplateMethod
            units = new List<string>();
            units.Add("Sawmill");
            units.Add("Fishing Port");
            units.Add("Egg");
            units.Add("Pumpkin");
            units.Add("Garden");
            units.Add("Wheat");
            units.Add("Forest");
            units.Add("Fish");
            units.Add("Chicken Gate");

            buildingsAnalyzer = new Buildings();
            buildingsAnalyzer.Analyze(units);

            productAnalyzer = new Products();
            productAnalyzer.Analyze(units);

            // -> Facade
            chickenB = new ChickenGateBooster();
            fishB = new FishingPortBooster();
            forestB = new ForestBooster();
            gardenB = new GardenBooster();
            sawmillB = new SawmillBooster();


            forestB.CurrentDropTime = FirstLevelFarm.Forest.resourceDropTime;
            forestB.BoostValue = 2;

            chickenB.CurrentDropTime = FirstLevelFarm.ChickenGate.resourceDropTime;
            chickenB.BoostValue = 2;

            fishB.CurrentDropTime = FirstLevelFarm.FishingPort.fishDropTime;
            fishB.BoostValue = 2;

            gardenB.CurrentDropTimePumpkin = FirstLevelFarm.Garden.pumpkinDropTime;
            gardenB.CurrentDropTimeWheat = FirstLevelFarm.Garden.wheatDropTime;
            gardenB.BoostValue = 2;

            sawmillB.BoostValue = 3;

            facadeClient = new BoosterFacade(chickenB, fishB, forestB, sawmillB, gardenB);
            facadeClient.CreateBoost();

            // -> SetTimers
            treeTimer.Interval = (int)FirstLevelFarm.Forest.resourceDropTime.TotalMilliseconds;
            treeTimer.Tick += new EventHandler(timer1_Tick);
            treeTimer.Start();

            wheatTimer.Interval = (int)FirstLevelFarm.Garden.wheatDropTime.TotalMilliseconds;
            wheatTimer.Tick += new EventHandler(timer2_Tick);
            wheatTimer.Start();

            pumpkinTimer.Interval = (int)FirstLevelFarm.Garden.pumpkinDropTime.TotalMilliseconds;
            pumpkinTimer.Tick += new EventHandler(timer3_Tick);
            pumpkinTimer.Start();

            chickenTimer.Interval = (int)FirstLevelFarm.ChickenGate.resourceDropTime.TotalMilliseconds;
            chickenTimer.Tick += new EventHandler(timer4_Tick);
            //chickenTimer.Start();

            fishingTimer.Interval = (int)FirstLevelFarm.FishingPort.fishDropTime.TotalMilliseconds;
            fishingTimer.Tick += new EventHandler(timer5_Tick);
            fishingTimer.Start();

            upgrade = 0;
            change = 0;
            bgImg = Image.FromFile(@"C:\Users\lenovo\source\repos\MAPZ_LAB_3\Images\gradka.png");

            for (int i = 0; i < 5; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView2.Rows.Add();
                if (i > 1)
                {
                    dataGridView3.Rows.Add();
                }
            }

            
            secondLevelFarm = Image.FromFile(@"C:\Users\lenovo\source\repos\MAPZ_LAB_3\Images\farmSecondLevel.png");

            FirstLevelFarm.Garden.ChangeImage(proxy.ChangeSize(34,34), other);
            FirstLevelFarm.Forest.ChangeImage(proxy.ChangeSize(80,80), other);
            FirstLevelFarm.ChickenGate.ChangeImage(proxy.ChangeSize(78,78), other);
            FirstLevelFarm.Sawmill.ChangeImage(proxy.ChangeSize(200,200), buildings);
            FirstLevelFarm.FishingPort.ChangeImage(proxy.ChangeSize(76, 76), buildings);
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            row.DefaultCellStyle.BackColor = Color.Transparent;
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            e.Graphics.DrawImage(bgImg, e.RowBounds);
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if(FirstLevelFarm is null)
            {
                if (SecondLevelFarm.Garden.isWheatClicked == false)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                    e.Graphics.DrawImage(SecondLevelFarm.Garden.wheatImage, e.CellBounds.Left + 0, e.CellBounds.Top + 0);

                    e.Handled = true;
                }
            }
            else 
            {
                if (FirstLevelFarm.Garden.isWheatClicked == false)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                    e.Graphics.DrawImage(FirstLevelFarm.Garden.wheatImage, e.CellBounds.Left + 0, e.CellBounds.Top + 0);

                    e.Handled = true;
                }
            }
            

        }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRow row = dataGridView2.Rows[e.RowIndex];
            row.DefaultCellStyle.BackColor = Color.Transparent;
        }

        private void dataGridView2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if(FirstLevelFarm is null)
            {
                if (SecondLevelFarm.Garden.isPumpkinClicked == false)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                    e.Graphics.DrawImage(SecondLevelFarm.Garden.pumpkinImage, e.CellBounds.Left + 0, e.CellBounds.Top + 0);

                    e.Handled = true;
                }
            }
            else
            {
                if (FirstLevelFarm.Garden.isPumpkinClicked == false)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                    e.Graphics.DrawImage(FirstLevelFarm.Garden.pumpkinImage, e.CellBounds.Left + 0, e.CellBounds.Top + 0);

                    e.Handled = true;
                }
            }

        }

        private void dataGridView2_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            e.Graphics.DrawImage(bgImg, e.RowBounds);
        }

        private void dataGridView3_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

            if(FirstLevelFarm is null)
            {
                if (SecondLevelFarm.Forest.IsFelled == false)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                    e.Graphics.DrawImage(SecondLevelFarm.Forest.TreeImage, e.CellBounds.Left + 0, e.CellBounds.Top + 0);

                    e.Handled = true;


                }
            }
            else
            {
                if (FirstLevelFarm.Forest.IsFelled == false)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                    e.Graphics.DrawImage(FirstLevelFarm.Forest.TreeImage, e.CellBounds.Left + 0, e.CellBounds.Top + 0);

                    e.Handled = true;
                }
            }
           
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView4_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e) // -> fishing port
        {
            fishingTimer.Start();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
          
        }

        private void timer1_Tick(Object myObject, EventArgs myEventArgs)
        {
            var grid = (DataGridView)dataGridView3;
            Image tree;
            if(FirstLevelFarm is null)
            {
                tree = SecondLevelFarm.Forest.TreeImage;
            }
            else
            {
                tree = FirstLevelFarm.Forest.TreeImage;
            }

            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView3.Columns.Count; j++)
                {
                    dataGridView3.Rows[i].Cells[j].Value = tree; //FirstLevelFarm.Forest.TreeImage;
                }
            }



            treeTimer.Stop();
            treeTimer.Start();

        }

        private void timer2_Tick(Object myObject, EventArgs myEventArgs)
        {
            var grid = (DataGridView)dataGridView1;

            Image wheat;
            if (FirstLevelFarm is null)
            {
                wheat = SecondLevelFarm.Garden.wheatImage;
            }
            else
            {
                wheat = FirstLevelFarm.Garden.wheatImage;
            }

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = wheat; //FirstLevelFarm.Garden.wheatImage;
                }
            }

            wheatTimer.Stop();
            wheatTimer.Start();
        }

        private void timer3_Tick(Object myObject, EventArgs myEventArgs)
        {
            var grid = (DataGridView)dataGridView2;

            Image pumpkin;
            if (FirstLevelFarm is null)
            {
                pumpkin = SecondLevelFarm.Garden.pumpkinImage;
            }
            else
            {
                pumpkin = FirstLevelFarm.Garden.pumpkinImage;
            }

            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView2.Columns.Count; j++)
                {
                    dataGridView2.Rows[i].Cells[j].Value = pumpkin; //FirstLevelFarm.Garden.pumpkinImage;
                }
            }

            pumpkinTimer.Stop();
            pumpkinTimer.Start();
        }

        private void timer4_Tick(Object myObject, EventArgs myEventArgs)
        {
            if(FirstLevelFarm is null)
            {
                productStorage.Products[2].Count += SecondLevelFarm.ChickenGate.chickenCount;  // <---
            }
            else
            {
                productStorage.Products[2].Count += FirstLevelFarm.ChickenGate.chickenCount;  // <---
            }

            textBox2.Text = productStorage.Products[2].Count.ToString();
            textBox1.Text = productStorage.Products[0].Count.ToString();
            chickenTimer.Stop();

        }

        private void timer5_Tick(Object myObject, EventArgs myEventArgs)
        {
            fishingTimer.Stop();
            productStorage.Products[3].Count += 2;
            textBox4.Text = productStorage.Products[3].Count.ToString();
            
            //fishingTimer.Start();
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var grid = (DataGridView)sender;
            Image felled;
            if(FirstLevelFarm is null)
            {
                felled = SecondLevelFarm.Forest.FelledTree;
                SecondLevelFarm.Forest.IsFelled = true;
            }
            else
            {
                felled = FirstLevelFarm.Forest.FelledTree;
                FirstLevelFarm.Forest.IsFelled = true;
            }

            if (grid[e.ColumnIndex, e.RowIndex] is DataGridViewImageCell cell)
            {
                //FirstLevelFarm.Forest.IsFelled = true;
               

                if (cell.Value != felled)//FirstLevelFarm.Forest.FelledTree)
                {
                    woodStorage.RawMaterials[0].Count++;
       
                    textBox6.Text = woodStorage.RawMaterials[0].Count.ToString();
                }

                treeTimer.Start();
                cell.Value = felled;//FirstLevelFarm.Forest.FelledTree;
            }
        }

        private void dataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Image felled;
            if (FirstLevelFarm is null)
            {
                felled = SecondLevelFarm.Forest.FelledTree;
            }
            else
            {
                felled = FirstLevelFarm.Forest.FelledTree;
            }
            if (treeTimer.Enabled == false)
            {
                var grid = (DataGridView)sender;
                if (grid[e.ColumnIndex, e.RowIndex] is DataGridViewImageCell cell)
                {
                    cell.Value = felled; //FirstLevelFarm.Forest.FelledTree;
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var grid = (DataGridView)sender;

            Image felled;
            if (FirstLevelFarm is null)
            {
                felled = SecondLevelFarm.Forest.FelledTree;
                SecondLevelFarm.Garden.isWheatClicked = true;
            }
            else
            {
                felled = FirstLevelFarm.Forest.FelledTree;
                FirstLevelFarm.Garden.isWheatClicked = true;
            }

            if (grid[e.ColumnIndex, e.RowIndex] is DataGridViewImageCell cell)
            {
                //FirstLevelFarm.Garden.isWheatClicked = true;
               

                if (cell.Value != felled)//FirstLevelFarm.Forest.FelledTree)
                {
                    productStorage.Products[0].Count++;
                   
                    textBox1.Text = productStorage.Products[0].Count.ToString();
                }

                cell.Value = felled;//FirstLevelFarm.Forest.FelledTree;
               
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var grid = (DataGridView)sender;

            Image wheat;
            if (FirstLevelFarm is null)
            {
                wheat = SecondLevelFarm.Garden.wheatImage;
            }
            else
            {
                wheat = FirstLevelFarm.Garden.wheatImage;
            }

            if (grid[e.ColumnIndex, e.RowIndex] is DataGridViewImageCell cell)
            {
                cell.Value = wheat; //FirstLevelFarm.Garden.wheatImage;
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var grid = (DataGridView)sender;
            Image felled;
            if(FirstLevelFarm is null)
            {
                felled = SecondLevelFarm.Forest.FelledTree;
                SecondLevelFarm.Garden.isPumpkinClicked = true;
            }
            else
            {
                felled = FirstLevelFarm.Forest.FelledTree;
                FirstLevelFarm.Garden.isPumpkinClicked = true;
            }

            if (grid[e.ColumnIndex, e.RowIndex] is DataGridViewImageCell cell)
            {
                //FirstLevelFarm.Garden.isPumpkinClicked = true;
               

                if(cell.Value != felled)//FirstLevelFarm.Forest.FelledTree)
                {
                    productStorage.Products[1].Count++;
                    
                    textBox3.Text = productStorage.Products[1].Count.ToString();
                }

                cell.Value = felled; //FirstLevelFarm.Forest.FelledTree;
            }
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var grid = (DataGridView)sender;
            if (grid[e.ColumnIndex, e.RowIndex] is DataGridViewImageCell cell)
            {
                cell.Value = FirstLevelFarm.Garden.pumpkinImage;
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if(FirstLevelFarm is null)
            {
                if (SecondLevelFarm.ChickenGate.chickenCount == 9)
                {
                    MessageBox.Show("Max Count Of Chickens = 9", "Max count!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (Farmer.Instance.Money >= 100 && SecondLevelFarm.ChickenGate.chickenCount < 9)
                    {
                        Farmer.Instance.Buy("Chickens");
                        dataGridView4.Rows.Add(SecondLevelFarm.ChickenGate.chickenImage,
                            SecondLevelFarm.ChickenGate.chickenImage,
                            SecondLevelFarm.ChickenGate.chickenImage);
                        SecondLevelFarm.ChickenGate.chickenCount += 3;
                        textBox5.Text = Farmer.Instance.Money.ToString();
                    }
                }
            }
            else
            {
                if (FirstLevelFarm.ChickenGate.chickenCount == 9)
                {
                    MessageBox.Show("Max Count Of Chickens = 9", "Max count!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (Farmer.Instance.Money >= 100 && FirstLevelFarm.ChickenGate.chickenCount < 9)
                    {
                        Farmer.Instance.Buy("Chickens");
                        dataGridView4.Rows.Add(FirstLevelFarm.ChickenGate.chickenImage,
                            FirstLevelFarm.ChickenGate.chickenImage,
                            FirstLevelFarm.ChickenGate.chickenImage);
                        FirstLevelFarm.ChickenGate.chickenCount += 3;
                        textBox5.Text = Farmer.Instance.Money.ToString();
                    }
                }
            }


            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Farmer.Instance.Money > 1000)
            {
                pictureBox2.Image = secondLevelFarm;
           }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            int value;
            if(FirstLevelFarm is null)
            {
                value = (int)SecondLevelFarm.Sawmill.productionIncrease;
            }
            else
            {
                //FirstLevelFarm.Sawmill.Boost();
                value = (int)FirstLevelFarm.Sawmill.productionIncrease;
            }

            if (woodStorage.RawMaterials[0].Count >= 0)
            {
                woodStorage.RawMaterials[1].Count += (woodStorage.RawMaterials[0].Count * value);
                woodStorage.RawMaterials[0].Count -= woodStorage.RawMaterials[0].Count;
                textBox7.Text = woodStorage.RawMaterials[1].Count.ToString();
                textBox6.Text = woodStorage.RawMaterials[0].Count.ToString();
            }
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            pictureBox3.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.BorderStyle = BorderStyle.None;
        }

        private void dataGridView4_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            if(FirstLevelFarm is null)
            {
                if (Farmer.Instance.IsEnoughToFeed(productStorage.Products[0].Count, SecondLevelFarm.ChickenGate.chickenCount))
                {
                    button3.Enabled = true;
                    productStorage.Products[0].Count -= Farmer.Instance.FeedChicken(productStorage.Products[0].Count, SecondLevelFarm.ChickenGate.chickenCount);
                    textBox1.Text = productStorage.Products[0].Count.ToString();

                    chickenTimer.Start();

                    textBox2.Text = productStorage.Products[2].Count.ToString();

                }
            }
            else
            {
                if (Farmer.Instance.IsEnoughToFeed(productStorage.Products[0].Count, FirstLevelFarm.ChickenGate.chickenCount))
                {
                    button3.Enabled = true;
                    productStorage.Products[0].Count -= Farmer.Instance.FeedChicken(productStorage.Products[0].Count, FirstLevelFarm.ChickenGate.chickenCount);
                    textBox1.Text = productStorage.Products[0].Count.ToString();

                    chickenTimer.Start();

                    textBox2.Text = productStorage.Products[2].Count.ToString();

                }
            }


           
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text != "")
            {
                if(comboBox2.Text == "Wheat" && productStorage.Products[0].Count >= 10)
                {
                    productStorage.Products[0].Count -= (int)numericUpDown2.Value;
                    textBox1.Text = productStorage.Products[0].Count.ToString();
                    Farmer.Instance.Sell(comboBox2.Text, (int)numericUpDown2.Value);
                }
                else if(comboBox2.Text == "Pumpkin" && productStorage.Products[1].Count >= 10)
                {
                    productStorage.Products[1].Count -= (int)numericUpDown2.Value;
                    textBox3.Text = productStorage.Products[1].Count.ToString();
                    Farmer.Instance.Sell(comboBox2.Text, (int)numericUpDown2.Value);
                }

                textBox5.Text = Farmer.Instance.Money.ToString();
            }
        }

        private void pictureBox7_MouseHover(object sender, EventArgs e)
        {
            pictureBox7.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox7_MouseLeave(object sender, EventArgs e)
        {
            pictureBox7.BorderStyle = BorderStyle.None;
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
           
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(FirstLevelFarm is null)
            {
                if (!Farmer.Instance.IsEnoughToFeed(Int32.Parse(textBox1.Text.ToString()), SecondLevelFarm.ChickenGate.chickenCount))
                {
                    button3.Enabled = false;
                }
                else
                {
                    button3.Enabled = true;
                }
            }
            else
            {
                if (!Farmer.Instance.IsEnoughToFeed(Int32.Parse(textBox1.Text.ToString()), FirstLevelFarm.ChickenGate.chickenCount))
                {
                    button3.Enabled = false;
                }
                else
                {
                    button3.Enabled = true;
                }
            }

            
        }

        private void button5_Click(object sender, EventArgs e) // -> Buy/Upgrade
        {
           
            if (upgrade == 0)
            {
                int chickenCountDefault = FirstLevelFarm.ChickenGate.chickenCount;
                SecondLevelFarm.ChickenGate.chickenCount = chickenCountDefault;
                FirstLevelFarm = null;

                SecondLevelFarm.Forest.resourceDropTime = new TimeSpan(0, 1, 0);
                SecondLevelFarm.Garden.wheatDropTime = new TimeSpan(0, 0, 55);
                SecondLevelFarm.Garden.pumpkinDropTime = new TimeSpan(0, 0, 45);
                SecondLevelFarm.ChickenGate.resourceDropTime = new TimeSpan(0, 0, 10);
                SecondLevelFarm.FishingPort.fishDropTime = new TimeSpan(0, 0, 30);

                treeTimer.Interval = (int)SecondLevelFarm.Forest.resourceDropTime.TotalMilliseconds;
                treeTimer.Tick += new EventHandler(timer1_Tick);
                treeTimer.Start();

                wheatTimer.Interval = (int)SecondLevelFarm.Garden.wheatDropTime.TotalMilliseconds;
                wheatTimer.Tick += new EventHandler(timer2_Tick);
                wheatTimer.Start();

                pumpkinTimer.Interval = (int)SecondLevelFarm.Garden.pumpkinDropTime.TotalMilliseconds;
                pumpkinTimer.Tick += new EventHandler(timer3_Tick);
                pumpkinTimer.Start();

                chickenTimer.Interval = (int)SecondLevelFarm.ChickenGate.resourceDropTime.TotalMilliseconds;
                chickenTimer.Tick += new EventHandler(timer4_Tick);
                

                fishingTimer.Interval = (int)SecondLevelFarm.FishingPort.fishDropTime.TotalMilliseconds;
                fishingTimer.Tick += new EventHandler(timer5_Tick);


                SecondLevelFarm.Garden.ChangeImage(proxy.ChangeSize(34,34), other);
                SecondLevelFarm.Forest.ChangeImage(proxy.ChangeSize(80,80), other);
                SecondLevelFarm.ChickenGate.ChangeImage(proxy.ChangeSize(78,78), other);

                upgrade++;
            }
            
            if(Farmer.Instance.Money >= 150)
            {
                if (pictureBox2.Image == secondLevelFarm)
                {
                    customer = new Customer(false, false, true, Farmer.Instance);

                    if (comboBox1.Text == "Sawmill" && Farmer.Instance.Money >= 400)
                    {
                        purchaseSimple.BuyHandle(customer, "Sawmill");
                        textBox5.Text = customer.Farmer.Money.ToString();

                        SecondLevelFarm.Sawmill.productionIncrease = sawmillB.Production;
                        SecondLevelFarm.Sawmill.ChangeImage(proxy.ChangeSize(200, 200), buildings);
                        pictureBox3.Image = SecondLevelFarm.Sawmill.sawmillImage;
                        change++;
                    }
                    else if(comboBox1.Text == "Fishing Port" && Farmer.Instance.Money >= 600)
                    {
                        purchaseSimple.BuyHandle(customer, "Fishing Port");
                        textBox5.Text = customer.Farmer.Money.ToString();

                        SecondLevelFarm.FishingPort.ChangeImage(proxy.ChangeSize(200, 200), buildings);
                        pictureBox7.Image = SecondLevelFarm.FishingPort.portImage;
                        SecondLevelFarm.FishingPort.fishDropTime = boostFishing.CurrentDropTime;
                        change++;
                    }
                    else if(comboBox1.Text == "Forest" && Farmer.Instance.Money >= 150)
                    {
                        purchaseSimple.BuyHandle(customer, "Forest");
                        textBox5.Text = customer.Farmer.Money.ToString();
                        SecondLevelFarm.Forest.resourceDropTime = boostForest.CurrentDropTime;
                    }
                    else if(comboBox1.Text == "Garden" && Farmer.Instance.Money >= 200)
                    {
                        purchaseSimple.BuyHandle(customer, "Garden");
                        SecondLevelFarm.Garden.pumpkinDropTime = gardenB.CurrentDropTimePumpkin;
                        SecondLevelFarm.Garden.wheatDropTime = gardenB.CurrentDropTimeWheat;
                    }
                }
                else
                {
                    if (radioButton1.Checked)
                    {
                        customer = new Customer(true, false, false, Farmer.Instance);

                        if (comboBox1.Text == "Sawmill" && Farmer.Instance.Money >= 400)
                        {
                            purchaseSimple.BuyHandle(customer, "Sawmill");
                            textBox5.Text = customer.Farmer.Money.ToString();

                            SecondLevelFarm.Sawmill.productionIncrease = sawmillB.Production;
                            SecondLevelFarm.Sawmill.ChangeImage(proxy.ChangeSize(200, 200), buildings);
                            pictureBox3.Image = SecondLevelFarm.Sawmill.sawmillImage;
                            change++;
                        }
                        else if (comboBox1.Text == "Fishing Port" && Farmer.Instance.Money >= 600)
                        {
                            purchaseSimple.BuyHandle(customer, "Fishing Port");
                            textBox5.Text = customer.Farmer.Money.ToString();

                            SecondLevelFarm.FishingPort.ChangeImage(proxy.ChangeSize(200, 200), buildings);
                            pictureBox7.Image = SecondLevelFarm.FishingPort.portImage;
                            SecondLevelFarm.FishingPort.fishDropTime = boostFishing.CurrentDropTime;
                            change++;
                        }
                        else if (comboBox1.Text == "Forest" && Farmer.Instance.Money >= 150)
                        {
                            purchaseSimple.BuyHandle(customer, "Forest");
                            textBox5.Text = customer.Farmer.Money.ToString();
                            SecondLevelFarm.Forest.resourceDropTime = boostForest.CurrentDropTime;
                        }
                        else if (comboBox1.Text == "Garden" && Farmer.Instance.Money >= 200)
                        {
                            purchaseSimple.BuyHandle(customer, "Garden");
                            SecondLevelFarm.Garden.pumpkinDropTime = gardenB.CurrentDropTimePumpkin;
                            SecondLevelFarm.Garden.wheatDropTime = gardenB.CurrentDropTimeWheat;
                        }
                    }
                    else if(radioButton2.Checked)
                    {
                        customer = new Customer(false, true, false, Farmer.Instance);

                        if (comboBox1.Text == "Sawmill" && Farmer.Instance.Money >= 480)
                        {
                            purchaseSimple.BuyHandle(customer, "Sawmill");
                            textBox5.Text = customer.Farmer.Money.ToString();

                            SecondLevelFarm.Sawmill.productionIncrease = sawmillB.Production;
                            SecondLevelFarm.Sawmill.ChangeImage(proxy.ChangeSize(200, 200), buildings);
                            pictureBox3.Image = SecondLevelFarm.Sawmill.sawmillImage;
                            change++;
                        }
                        else if (comboBox1.Text == "Fishing Port" && Farmer.Instance.Money >= 720)
                        {
                            purchaseSimple.BuyHandle(customer, "Fishing Port");
                            textBox5.Text = customer.Farmer.Money.ToString();

                            SecondLevelFarm.FishingPort.ChangeImage(proxy.ChangeSize(200, 200), buildings);
                            pictureBox7.Image = SecondLevelFarm.FishingPort.portImage;
                            SecondLevelFarm.FishingPort.fishDropTime = boostFishing.CurrentDropTime;
                            change++;
                        }
                        else if (comboBox1.Text == "Forest" && Farmer.Instance.Money >= 180)
                        {
                            purchaseSimple.BuyHandle(customer, "Forest");
                            textBox5.Text = customer.Farmer.Money.ToString();
                            SecondLevelFarm.Forest.resourceDropTime = boostForest.CurrentDropTime;
                        }
                        else if (comboBox1.Text == "Garden" && Farmer.Instance.Money >= 240)
                        {
                            purchaseSimple.BuyHandle(customer, "Garden");
                            SecondLevelFarm.Garden.pumpkinDropTime = gardenB.CurrentDropTimePumpkin;
                            SecondLevelFarm.Garden.wheatDropTime = gardenB.CurrentDropTimeWheat;
                        }
                    }
                    else
                    {
                        customer = new Customer(true, false, false, Farmer.Instance);

                        if (comboBox1.Text == "Sawmill" && Farmer.Instance.Money >= 400)
                        {
                            purchaseSimple.BuyHandle(customer, "Sawmill");
                            textBox5.Text = customer.Farmer.Money.ToString();

                            SecondLevelFarm.Sawmill.productionIncrease = sawmillB.Production;
                            SecondLevelFarm.Sawmill.ChangeImage(proxy.ChangeSize(200, 200), buildings);
                            pictureBox3.Image = SecondLevelFarm.Sawmill.sawmillImage;
                            change++;
                        }
                        else if (comboBox1.Text == "Fishing Port" && Farmer.Instance.Money >= 600)
                        {
                            purchaseSimple.BuyHandle(customer, "Fishing Port");
                            textBox5.Text = customer.Farmer.Money.ToString();

                            SecondLevelFarm.FishingPort.ChangeImage(proxy.ChangeSize(200, 200), buildings);
                            pictureBox7.Image = SecondLevelFarm.FishingPort.portImage;
                            SecondLevelFarm.FishingPort.fishDropTime = boostFishing.CurrentDropTime;
                            change++;
                        }
                        else if (comboBox1.Text == "Forest" && Farmer.Instance.Money >= 150)
                        {
                            purchaseSimple.BuyHandle(customer, "Forest");
                            textBox5.Text = customer.Farmer.Money.ToString();
                            SecondLevelFarm.Forest.resourceDropTime = boostForest.CurrentDropTime;
                        }
                        else if (comboBox1.Text == "Garden" && Farmer.Instance.Money >= 200)
                        {
                            purchaseSimple.BuyHandle(customer, "Garden");
                            SecondLevelFarm.Garden.pumpkinDropTime = gardenB.CurrentDropTimePumpkin;
                            SecondLevelFarm.Garden.wheatDropTime = gardenB.CurrentDropTimeWheat;
                        }
                    }
                }
            }

            if(change == 2)
            {
                pictureBox2.Image = secondLevelFarm;
            }
            
        }
    }
}
