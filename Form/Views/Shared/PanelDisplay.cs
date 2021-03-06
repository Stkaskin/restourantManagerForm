using FireCloud.Business.Operation;
using FireCloud.My_Data;
using restourantManagerForm.DataManager;
using restourantManagerForm.FormDatas;
using restourantManagerForm.Manager;
using restourantManagerForm.ModelManager;
using restourantManagerForm.Models;
using restourantManagerForm.Models.PersonPartial;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace restourantManagerForm.Views.Shared
{
    public partial class PanelDisplay : Form
    {
        //   List<(object obj, string dislay, int value)> modelList = new List<(object obj, string dislay, int value)>();
        DataGridView dataGridView;
        ComboBox comboBox;
        Button addButton;
        Button deleteButton;
        Button updateButton;
        Button restartButton;

        public PanelDisplay()
        {
            InitializeComponent();
        }

        private void PanelDisplay_Load(object sender, EventArgs e)
        {
            loadingItems();
        }
        #region This Form Operations
  
        private List<object> getListModels() =>
         Perdurable.classList;

        private List<(object obj, string dislay, int value)> getComboBoxSource()
        {
            var listModels = getListModels();
            var list = new List<(object obj, string dislay, int value)>();
            for (int i = 0; i < listModels.Count; i++)
                list.Add((listModels[i], listModels[i].GetType().Name, i));
            return list;

        }
        private void getDataGridViewSource()
        {
            var listComboBox = ((object obj, string dislay, int value))comboBox.SelectedItem;


        }

        #endregion
        #region ButtonEvents
        private void AddClick(object sender, EventArgs e)
        {
            foreach (var item in getListModels())
            {
                var t = item.GetType().FullName;
                var t1 = item.GetType().Name;
                if (t1.ToString() == comboBox.SelectedItem.ToString())
                {
                    new PanelAUD(item, 1).ShowDialog();

                    break;
                }
            }

        }
        #endregion
        #region Crud Operations
        private void addOperation()
        {

        }
        #endregion

        #region toolboxItems
        private void loadingItems()
        {
            datagridviewAdd(ref dataGridView);
            comboboxAdd(ref comboBox);
            crudButtons();
            addButton.Click += AddClick;

        }
        private void crudButtons()
        {
            Point gridPoint = dataGridView.Location;
            Size gridSize = dataGridView.Size;
            gridPoint.X = gridSize.Width;
            Point space = new Point(40, 40);
            int tn = 1;
            buttonAdd(ref addButton, "Add", gridPoint, space, tn++);
            buttonAdd(ref deleteButton, "Delete", gridPoint, space, tn++);
            buttonAdd(ref updateButton, "Update", gridPoint, space, tn++);
            buttonAdd(ref restartButton, "Restart", gridPoint, space, tn++);
            this.Controls.AddRange(new Control[] { addButton, deleteButton, restartButton, updateButton });
        }
        private void buttonAdd(ref Button button, string text, Point p, Point space, int tn)
        {

            button = new Button();
            button.Name = text + "Button";
            button.Text = text;
            button.Location = new Point(p.X + (space.X * 1), p.Y + (space.Y * tn));
            button.Size = new Size(50, 50);
        }
        private void datagridviewAdd(ref DataGridView gridView)
        {
            gridView = new DataGridView();
            gridView.Size = new Size(500, 500);
            gridView.Location = new Point(10, 90);
         
            this.Controls.Add(gridView);
        }
        object c = new List<object>();
        

     

        private void comboboxAdd(ref ComboBox box)
        {
            var list = getComboBoxSource();
            box = new ComboBox();
            box.Size = new Size(200, 50);
            box.Location = new Point(10, 10);
            box.SelectedIndexChanged += comboBoxSelectedItemChanged;
            foreach (var item in list)
                box.Items.Add(item.dislay);
            box.SelectedIndex = 0;
           
            this.Controls.Add(box);
        }

        private void comboBoxSelectedItemChanged(object sender, EventArgs e)
        {var f43= FirebaseOperationManager.getList(comboBox.SelectedItem.ToString());

            dataGridView.DataSource = f43;
        }
        #endregion
    }
}
