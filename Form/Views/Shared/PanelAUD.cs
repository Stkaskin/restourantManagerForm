﻿using restourantManagerForm.DataManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace restourantManagerForm.Views.Shared
{
    public partial class PanelAUD : Form
    {
        Type objType;
        string imageProperty;
        bool Isimage = false;
        int operationCode = -1;
        object obj;
        int startPositionX = 40;
        int startPositionY = 40;
        int heightText = 25;
        int widhtTextBox = 120;
        int extraSpaceLabelAndTextbox = 50;
       
        PropertyInfo[] type;
        Button button = new Button();
        List<(PropertyInfo info, object box)> items = new List<(PropertyInfo info, object box)>();
        public PanelAUD(object obj, int Operation)
        {
            this.obj = obj;
            operationCode = Operation;
            PanelAUDStart();
        }
        public PanelAUD(object obj, int Operation, string imageProperty)
        {
            this.imageProperty = imageProperty;
            Isimage = true;
            if (Isimage) ;
            operationCode = Operation;
            PanelAUDStart();
        }
      
        void PanelAUDStart()
        {
            InitializeComponent();
            if (operationLoad() == 1)
                LoadPageAddControlsProperty(obj);
        }

        private int operationLoad()
        {
            //insert
            if (operationCode == 1)
                button.Text = "Add";
            else if (operationCode == 2)
                button.Text = "Update";
            else if (operationCode == 3)
                button.Text = "Delete";
            else
            {
                MessageBox.Show("Error!. Please contact an authorized person.");
                return -1;
            }
            return 1;
        }

        private void AddPanel_Load(object sender, EventArgs e)
        {
         
            
        }
        public void LoadPageAddControlsProperty(object obj)
        {
            objType = obj.GetType();
            this.obj = obj;
            type = objType.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            //PropertyInfo[] type = objType.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic);
            //tbl values 
            int x = startPositionX;
            int y = startPositionY;
            int maxWidht = 0;
            foreach (var item in type)
            {
                Label label = new Label();
                label.Location = new Point(x, y);
                label.Text = item.Name;
                label.Height = heightText;
                label.Width = item.Name.Length * 10;
                this.Controls.Add(label);
                y += heightText;
                if (maxWidht < label.Width)
                    maxWidht = label.Width;
            }
            x = startPositionX;
            y = startPositionY;
            foreach (var item in type)
            { var propName = item.PropertyType.Name;
                if (propName=="String")
                addTextBox(item,ref y,ref x,ref maxWidht);
                else if (propName== "Boolean") 
                {
                    addCheckBox(item, ref y, ref x, ref maxWidht);
                }
         
            }

            button.Location = new Point((x * 3) / 2, (type.Length + 1) * (heightText + 5));
            button.Height = heightText;
            button.Width = widhtTextBox;
            button.Click += Button_Click;
            this.Controls.Add(button);
        }
        private void addCheckBox(PropertyInfo item, ref int ex, ref int x, ref int maxWidht)
        {
            CheckBox box = new CheckBox();
            //  box.Text = item.Name;
            box.Name = item.Name + ex;
            var a = obj.GetType().GetProperty(item.Name).GetValue(obj);
            box.Checked = (bool)item.GetValue(obj);
            box.Height = heightText;
            box.Width = widhtTextBox;
            box.Location = new Point(x + maxWidht + extraSpaceLabelAndTextbox, ex);
            this.Controls.Add(box);
            items.Add((item, box));
            ex += heightText;
        }
        private void addTextBox( PropertyInfo item,ref int ex,ref int x,ref int maxWidht)
        {
            TextBox box = new TextBox();
            //  box.Text = item.Name;
            box.Name = item.Name + ex;
            var a = obj.GetType().GetProperty(item.Name).GetValue(obj);
            if (item.Name.ToLower() == "id" || item.Name.ToLower() == "ıd")
            {
                box.Enabled = false;
                a = a == null ? "Otomatik" : a;
            }
           
            box.Text = a != null ? a.ToString() : "";
            box.Height = heightText;
            box.Width = widhtTextBox;
            box.Location = new Point(x + maxWidht + extraSpaceLabelAndTextbox, ex);
            this.Controls.Add(box);
            items.Add((item, box));
            ex += heightText;
        }
        private void Button_Click(object sender, EventArgs e)
        {
            string emptyWarning = "";
            for (int i = 0; i < items.Count; i++)
            { 
                var obj2 = items[i].box.GetType();
                if (obj2.Name == "TextBox")
                {

                    if (((TextBox)items[i].box).Text.Length > 0)
                        obj.GetType().GetProperty(items[i].info.Name).SetValue(obj, Convert.ChangeType(((TextBox)items[i].box).Text, type[i].PropertyType));

                    else
                        emptyWarning += items[i].info.Name + " !\n";
                }
                else if (obj2.Name =="CheckBox") 
                {
                    obj.GetType().GetProperty(items[i].info.Name).SetValue(obj, Convert.ChangeType(((CheckBox)items[i].box).Checked, type[i].PropertyType));

                }

            }
            if (emptyWarning.Length > 0)
                MessageBox.Show("Boş yeri Doldurun  : \n" + emptyWarning);
            else
                OperationStart(obj, operationCode);


        }
        private void OperationStart(object obj, int code)
        {
            MessageBox.Show("Added");
           /* if (code == 1)
            {
                new FirebaseManger.Cloud().Add(obj);
            }
            else if (code == 2)
            {
                new FirebaseManger.Cloud().Update(obj);
            }
            else if (code == 3)
            {
                new FirebaseManger.Cloud().Delete(obj);
            }*/
        }



    }
}
