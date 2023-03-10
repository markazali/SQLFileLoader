using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLFileLoader
{
    public partial class Form1 : Form
    {
        IDictionary<string, string> scriptDict = new Dictionary<string, string>();
        String currentDir = AppDomain.CurrentDomain.BaseDirectory;
        public Form1()
        {
            InitializeComponent();





        }
        private void textSearch_Enter(object sender, EventArgs e)
        {
            if (textBoxSearch.Text == "Search")
            {
                textBoxSearch.Text = "";
                textBoxSearch.ForeColor = Color.Black;
            }
            else
            {

            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                String test = comboBox1.Text;
                textBoxQuery.Text = scriptDict[test];
            }
            catch
            {

            }

        }



        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();

            comboBox1.ResetText();

            if (textBoxSearch.Text == "")
            {
                return;
            }

            for (int index = 0; index < scriptDict.Count; index++)
            {
                var item = scriptDict.ElementAt(index);
                var itemKey = item.Key;
                var itemValue = item.Value;

                if (itemValue.ToLower().Contains(textBoxSearch.Text.ToLower()))
                {
                    comboBox1.Items.Add(itemKey);
                }

            }


        }

        private void textBoxSearch_Leave(object sender, EventArgs e)
        {
            if (textBoxSearch.Text == "")
            {
                textBoxSearch.Text = "Search";
                textBoxSearch.ForeColor = Color.Silver;
                FillOptions();
            }
        }

        private void FillOptions()
        {
            string[] filePaths = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory);

            foreach (String file in filePaths)
            {
                if (file.Contains(".sql") )
                {
                    if (!scriptDict.ContainsKey(Path.GetFileName(file))) {
                        scriptDict.Add(Path.GetFileName(file), File.ReadAllText(file));
                        
                    }
                    comboBox1.Items.Add(Path.GetFileName(file));

                }

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FillOptions();
        }
    }
}
