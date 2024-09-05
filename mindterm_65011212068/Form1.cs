using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace mindterm_65011212068
{
    public partial class Form1 : Form
    {
        dbCoffeeShopEntities context = new dbCoffeeShopEntities();
        public Form1()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            menuBindingSource.DataSource = context.Menus.ToList();
            menuBindingSource1.DataSource = context.Menus.ToList();
            orderBindingSource.DataSource = context.Orders.ToList();   
            var result = context.TypeCoffees.OrderBy(T => T.Name).Select(T => new { T.idtype, T.Name });
            foreach (var item in result)
            {
                comboBox1.Items.Add(new ComboboxMyItems(item.idtype,item.Name));
                comboBox2.Items.Add(new ComboboxMyItems(item.idtype, item.Name));
            }
            comboBox3.Items.Add(new ComboboxMyItems(0, "เงินสด"));
            comboBox3.Items.Add(new ComboboxMyItems(1, "เงินโอน"));

        }

        private void Delete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            var del = context.Menus.Where(m=> m.idmenu == id).First();
            context.Menus.Remove(del);
            int change = context.SaveChanges();
            if (change > 0) {
                MessageBox.Show("Delete complete");
                menuBindingSource.DataSource = context.Menus.ToList();
            }
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            menuBindingSource.EndEdit();
            int id = int.Parse(textBox1.Text);
            int change = context.SaveChanges();
            if (change > 0)
            {
                MessageBox.Show("Edit complete");
                menuBindingSource.DataSource = context.Menus.ToList();
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
          
        }
        public byte[] ImageToByteArray(System.Drawing.Image image)
        {
            var ms = new MemoryStream();
            image.Save(ms, image.RawFormat);
            return ms.ToArray();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = System.Drawing.Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = System.Drawing.Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void Add_Click_1(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.name = textBox5.Text;
            menu.price = int.Parse(textBox4.Text);
            menu.image = ImageToByteArray(pictureBox2.Image);
            menu.idtype = ((ComboboxMyItems)(comboBox2.SelectedItem)).value;

            context.Menus.Add(menu);
            int change = context.SaveChanges();
            if (change > 0)
            {
                MessageBox.Show("add complete");
                menuBindingSource.DataSource = context.Menus.ToList();
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int number = int.Parse(textBox9.Text);
            int price = int.Parse(textBox8.Text);
            Order order = new Order();
            order.idmenu = int.Parse(textBox10.Text);
            order.number = number;
            order.priceamount = number * price;
            order.date = DateTime.Now;
            order.trans = ((ComboboxMyItems)(comboBox3.SelectedItem)).value;
            context.Orders.Add(order);
            int change = context.SaveChanges();
            if (change > 0)
            {
                MessageBox.Show("ขาย complete");
            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            String search = textBox11.Text;
            menuBindingSource1.DataSource = context.Menus.Where(s => s.name.Contains(search)).ToList();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
          


        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime dt = dateTimePicker1.Value;
            Console.WriteLine(dateTimePicker1.Value);
            orderBindingSource.DataSource = context.Orders.Where(o => o.date.Value.Year == dt.Year && o.date.Value.Month == dt.Month && o.date.Value.Day == dt.Day).ToList();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
 
        }
    }
}
