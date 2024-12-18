using System;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GasStationSimulation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-HPJO022;Initial Catalog=DBGasStation;Integrated Security=True");

        private void filltank_bttn_MouseEnter(object sender, EventArgs e)
        {
            filltank_bttn.BackColor = Color.SlateBlue;
        }

        private void filltank_bttn_MouseLeave(object sender, EventArgs e)
        {
            filltank_bttn.BackColor = Color.Transparent;
        }
        void gas_list()
        {
            // Unleaded 95 Price
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from Tbl_Gas where GasType= 'Unleaded95'", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                unleaded95_price_lbl.Text = dr[3].ToString();
                unleaded95_bar.Value = int.Parse(dr[4].ToString());
                unleaded95_tank.Text = dr[4].ToString();

            }
            conn.Close();

            // Unleaded 97
            conn.Open();
            SqlCommand cmd1 = new SqlCommand("Select * from Tbl_Gas where GasType= 'Unleaded97'", conn);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            while (dr1.Read())
            {
                unleaded97_price_lbl.Text = dr1[3].ToString();
                unleaded97_bar.Value = int.Parse(dr1[4].ToString());
                unleaded97_tank.Text = dr1[4].ToString();
            }
            conn.Close();

            // Euro Diesel 10
            conn.Open();
            SqlCommand cmd2 = new SqlCommand("Select * from Tbl_Gas where GasType= 'EuroDiesel10'", conn);
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                euro_diesel10_price_lbl.Text = dr2[3].ToString();
                eurodiesel10_bar.Value = int.Parse(dr2[4].ToString());
                eurodiesel10_tank.Text = dr2[4].ToString();
            }
            conn.Close();

            // New Pro Diesel
            conn.Open();
            SqlCommand cmd3 = new SqlCommand("Select * from Tbl_Gas where GasType= 'NewProDiesel'", conn);
            SqlDataReader dr3 = cmd3.ExecuteReader();
            while (dr3.Read())
            {
                new_pro_diesel_lbl.Text = dr3[3].ToString();
                newprodiesel_bar.Value = int.Parse(dr3[4].ToString());
                newprodiesel_tank.Text = dr3[4].ToString();
            }
            conn.Close();

            // LPG
            conn.Open();
            SqlCommand cmd4 = new SqlCommand("Select * from Tbl_Gas where GasType= 'LPG'", conn);
            SqlDataReader dr4 = cmd4.ExecuteReader();
            while (dr4.Read())
            {
                lpg_price_lbl.Text = dr4[3].ToString();
                lpg_bar.Value = int.Parse(dr4[4].ToString());
                lpg_tank.Text = dr4[4].ToString();
            }
            conn.Close();
        }
        void gas_types()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Gas", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gas_type_combobox.ValueMember = "ID";
            gas_type_combobox.DisplayMember = "GasType";
            gas_type_combobox.DataSource = dt;

            gas_type_combobox.SelectedIndex = -1;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.TabStop = false;
            gas_types();
            gas_list();
            safe();
            list_transactions();
        }
        void list_transactions()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Transaction", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void unleaded95_numeric_ValueChanged(object sender, EventArgs e)
        {
            unleaded97_numeric.Enabled = false;
            eurodiesel10_numeric.Enabled = false;
            newprodiesel_numeric.Enabled = false;
            lpg_numeric.Enabled = false;

            double unleaded95, liter, total;
            unleaded95 = Convert.ToDouble(unleaded95_price_lbl.Text);
            liter = Convert.ToDouble(unleaded95_numeric.Value);
            total = liter * unleaded95;
            unleaded95_total.Text = total.ToString();
        }

        private void unleaded97_numeric_ValueChanged(object sender, EventArgs e)
        {
            unleaded95_numeric.Enabled = false;
            eurodiesel10_numeric.Enabled = false;
            newprodiesel_numeric.Enabled = false;
            lpg_numeric.Enabled = false;

            double unleaded97, liter, total;
            unleaded97 = Convert.ToDouble(unleaded97_price_lbl.Text);
            liter = Convert.ToDouble(unleaded97_numeric.Value);
            total = liter * unleaded97;
            unleaded97_total.Text = total.ToString();
        }

        private void eurodiesel10_numeric_ValueChanged(object sender, EventArgs e)
        {
            unleaded95_numeric.Enabled = false;
            unleaded97_numeric.Enabled = false;
            newprodiesel_numeric.Enabled = false;
            lpg_numeric.Enabled = false;

            double eurodiesel, liter, total;
            eurodiesel = Convert.ToDouble(euro_diesel10_price_lbl.Text);
            liter = Convert.ToDouble(eurodiesel10_numeric.Value);
            total = liter * eurodiesel;
            eurodiesel10_total.Text = total.ToString();
        }

        private void newprodiesel_numeric_ValueChanged(object sender, EventArgs e)
        {
            unleaded95_numeric.Enabled = false;
            unleaded97_numeric.Enabled = false;
            eurodiesel10_numeric.Enabled = false;
            lpg_numeric.Enabled = false;

            double newprodiesel, liter, total;
            newprodiesel = Convert.ToDouble(new_pro_diesel_lbl.Text);
            liter = Convert.ToDouble(newprodiesel_numeric.Value);
            total = liter * newprodiesel;
            newprodiesel_total.Text = total.ToString();
        }

        private void lpg_numeric_ValueChanged(object sender, EventArgs e)
        {
            unleaded95_numeric.Enabled = false;
            unleaded97_numeric.Enabled = false;
            eurodiesel10_numeric.Enabled = false;
            newprodiesel_numeric.Enabled = false;

            double lpg, liter, total;
            lpg = Convert.ToDouble(lpg_price_lbl.Text);
            liter = Convert.ToDouble(lpg_numeric.Value);
            total = liter * lpg;
            lpg_total.Text = total.ToString();
        }
        void clear()
        {
            unleaded95_numeric.Value = 0;
            unleaded97_numeric.Value = 0;
            eurodiesel10_numeric.Value = 0;
            newprodiesel_numeric.Value = 0;
            lpg_numeric.Value = 0;

            unleaded95_total.Text = "";
            unleaded97_total.Text = "";
            eurodiesel10_total.Text = "";
            newprodiesel_total.Text = "";
            lpg_total.Text = "";

            license_txtbox.Text = "";
        }
        void safe()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from Tbl_Safe", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                safe_amount_lbl.Text = dr[0].ToString();
            }
            conn.Close();
        }
        private void filltank_bttn_Click(object sender, EventArgs e)
        {
            if(unleaded95_numeric.Value != 0)
            {
                if(license_txtbox.Text == "")
                {
                    MessageBox.Show("Enter a license plate.","",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                else
                {
                    // Transaction
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Insert into Tbl_Transaction (LicensePLate,GasType,Liter,Price) values (@p1,@p2,@p3,@p4)", conn);
                    cmd.Parameters.AddWithValue("@p1", license_txtbox.Text);
                    cmd.Parameters.AddWithValue("@p2", "Unleaded95");
                    cmd.Parameters.AddWithValue("@p3", unleaded95_numeric.Value);
                    cmd.Parameters.AddWithValue("@p4", unleaded95_total.Text);
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    // Safe Amount
                    conn.Open();
                    SqlCommand cmd1 = new SqlCommand("Update Tbl_Safe set Amount = Amount + @p1", conn);
                    cmd1.Parameters.AddWithValue("@p1", unleaded95_total.Text);
                    cmd1.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Transaction completed.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Fuel Tank Level
                    conn.Open();
                    SqlCommand cmd2 = new SqlCommand("Update Tbl_Gas set Stock = Stock - @p1 where GasType = 'Unleaded95'", conn);
                    cmd2.Parameters.AddWithValue("@p1", unleaded95_numeric.Value);
                    cmd2.ExecuteNonQuery();
                    conn.Close();
                    gas_list();
                    safe();
                    clear();
                    list_transactions();

                    unleaded97_numeric.Enabled = true;
                    eurodiesel10_numeric.Enabled = true;
                    newprodiesel_numeric.Enabled = true;
                    lpg_numeric.Enabled = true;
                }
            }

            if(unleaded97_numeric.Value != 0)
            {
                if (license_txtbox.Text == "")
                {
                    MessageBox.Show("Enter a license plate.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Transaction
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Insert into Tbl_Transaction (LicensePlate,GasType,Liter,Price) values (@p1,@p2,@p3,@p4)", conn);
                    cmd.Parameters.AddWithValue("@p1", license_txtbox.Text);
                    cmd.Parameters.AddWithValue("@p2", "Unleaded97");
                    cmd.Parameters.AddWithValue("@p3", unleaded97_numeric.Value);
                    cmd.Parameters.AddWithValue("@p4", unleaded97_total.Text);
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    // Safe Amount
                    conn.Open();
                    SqlCommand cmd1 = new SqlCommand("Update Tbl_Safe set Amount = Amount + @p1", conn);
                    cmd1.Parameters.AddWithValue("@p1", unleaded97_total.Text);
                    cmd1.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Transaction completed.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Fuel Tank Level
                    conn.Open();
                    SqlCommand cmd2 = new SqlCommand("Update Tbl_Gas set Stock = Stock - @p1 where GasType='Unleaded97'", conn);
                    cmd2.Parameters.AddWithValue("@p1", unleaded97_numeric.Value);
                    cmd2.ExecuteNonQuery();
                    conn.Close();
                    gas_list();
                    safe();
                    clear();
                    list_transactions();

                    unleaded95_numeric.Enabled = true;
                    eurodiesel10_numeric.Enabled = true;
                    newprodiesel_numeric.Enabled = true;
                    lpg_numeric.Enabled = true;
                }
            }

            if (eurodiesel10_numeric.Value != 0)
            {
                if (license_txtbox.Text == "")
                {
                    MessageBox.Show("Enter a license plate.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Transaction
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Insert into Tbl_Transaction (LicensePlate,GasType,Liter,Price) values (@p1,@p2,@p3,@p4)", conn);
                    cmd.Parameters.AddWithValue("@p1", license_txtbox.Text);
                    cmd.Parameters.AddWithValue("@p2", "EuroDiesel10");
                    cmd.Parameters.AddWithValue("@p3", eurodiesel10_numeric.Value);
                    cmd.Parameters.AddWithValue("@p4", eurodiesel10_total.Text);
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    // Safe Amount
                    conn.Open();
                    SqlCommand cmd1 = new SqlCommand("Update Tbl_Safe set Amount = Amount + @p1", conn);
                    cmd1.Parameters.AddWithValue("@p1", eurodiesel10_total.Text);
                    cmd1.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Transaction completed.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Fuel Tank Level
                    conn.Open();
                    SqlCommand cmd2 = new SqlCommand("Update Tbl_Gas set Stock = Stock - @p1 where GasType='EuroDiesel10'", conn);
                    cmd2.Parameters.AddWithValue("@p1", eurodiesel10_numeric.Value);
                    cmd2.ExecuteNonQuery();
                    conn.Close();
                    gas_list();
                    safe();
                    clear();
                    list_transactions();

                    unleaded95_numeric.Enabled = true;
                    unleaded97_numeric.Enabled = true;
                    newprodiesel_numeric.Enabled = true;
                    lpg_numeric.Enabled = true;
                }
            }

            if (newprodiesel_numeric.Value != 0)
            {
                if (license_txtbox.Text == "")
                {
                    MessageBox.Show("Enter a license plate.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Transaction
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Insert into Tbl_Transaction (LicensePlate,GasType,Liter,Price) values (@p1,@p2,@p3,@p4)", conn);
                    cmd.Parameters.AddWithValue("@p1", license_txtbox.Text);
                    cmd.Parameters.AddWithValue("@p2", "NewProDiesel");
                    cmd.Parameters.AddWithValue("@p3", newprodiesel_numeric.Value);
                    cmd.Parameters.AddWithValue("@p4", newprodiesel_total.Text);
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    // Safe Amount
                    conn.Open();
                    SqlCommand cmd1 = new SqlCommand("Update Tbl_Safe set Amount = Amount + @p1", conn);
                    cmd1.Parameters.AddWithValue("@p1", newprodiesel_total.Text);
                    cmd1.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Transaction completed.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Fuel Tank Level
                    conn.Open();
                    SqlCommand cmd2 = new SqlCommand("Update Tbl_Gas set Stock = Stock - @p1 where GasType='NewProDiesel'", conn);
                    cmd2.Parameters.AddWithValue("@p1", newprodiesel_numeric.Value);
                    cmd2.ExecuteNonQuery();
                    conn.Close();
                    gas_list();
                    safe();
                    clear();
                    list_transactions();

                    unleaded95_numeric.Enabled = true;
                    unleaded97_numeric.Enabled = true;
                    eurodiesel10_numeric.Enabled = true;
                    lpg_numeric.Enabled = true;
                }
            }

            if (lpg_numeric.Value != 0)
            {
                if (license_txtbox.Text == "")
                {
                    MessageBox.Show("Enter a license plate.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Transaction
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Insert into Tbl_Transaction (LicensePlate,GasType,Liter,Price) values (@p1,@p2,@p3,@p4)", conn);
                    cmd.Parameters.AddWithValue("@p1", license_txtbox.Text);
                    cmd.Parameters.AddWithValue("@p2", "LPG");
                    cmd.Parameters.AddWithValue("@p3", lpg_numeric.Value);
                    cmd.Parameters.AddWithValue("@p4", lpg_total.Text);
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    // Safe Amount
                    conn.Open();
                    SqlCommand cmd1 = new SqlCommand("Update Tbl_Safe set Amount = Amount + @p1", conn);
                    cmd1.Parameters.AddWithValue("@p1", lpg_total.Text);
                    cmd1.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Transaction completed.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Fuel Tank Level
                    conn.Open();
                    SqlCommand cmd2 = new SqlCommand("Update Tbl_Gas set Stock = Stock - @p1 where GasType='LPG'", conn);
                    cmd2.Parameters.AddWithValue("@p1", lpg_numeric.Value);
                    cmd2.ExecuteNonQuery();
                    conn.Close();
                    gas_list();
                    safe();
                    clear();
                    list_transactions();

                    unleaded95_numeric.Enabled = true;
                    unleaded97_numeric.Enabled = true;
                    eurodiesel10_numeric.Enabled = true;
                    newprodiesel_numeric.Enabled = true;
                }
            }
        }

        private void purchase_bttn_MouseEnter(object sender, EventArgs e)
        {
            purchase_bttn.BackColor = Color.SlateBlue;
        }

        private void purchase_bttn_MouseLeave(object sender, EventArgs e)
        {
            purchase_bttn.BackColor = Color.Transparent;
        }
        void clear_after_buy()
        {
            gas_type_combobox.SelectedIndex = -1;
            buying_liter_numeric.Value = 0;
            buy_total_txtbox.Text = "";
        }
        private void purchase_bttn_Click(object sender, EventArgs e)
        {
            // Stock Update
            int stock=0, total_stock=0;
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select Stock from Tbl_Gas where ID=@p1", conn);
            cmd.Parameters.AddWithValue("@p1", gas_type_combobox.SelectedValue);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                stock = int.Parse(dr[0].ToString());
                total_stock = stock + int.Parse(buying_liter_numeric.Value.ToString());
            }
            conn.Close();
            if(total_stock > 10000)
            {
                MessageBox.Show("Capacity is exceeded!","ERROR",MessageBoxButtons.OK, MessageBoxIcon.Error);
                clear_after_buy();
            }
            else
            {
                conn.Open();
                SqlCommand cmd1 = new SqlCommand("Update Tbl_Gas set Stock = Stock + @p1 where ID=@p2", conn);
                cmd1.Parameters.AddWithValue("@p1", buying_liter_numeric.Value);
                cmd1.Parameters.AddWithValue("@p2", gas_type_combobox.SelectedValue);
                cmd1.ExecuteNonQuery();
                conn.Close();
                gas_list();

                // Safe Update
                conn.Open();
                SqlCommand cmd2 = new SqlCommand("Update Tbl_Safe set Amount = Amount - @p1", conn);
                cmd2.Parameters.AddWithValue("@p1", buy_total_txtbox.Text);
                cmd2.ExecuteNonQuery();
                conn.Close();
                safe();
                MessageBox.Show("Purchasing is completed.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clear_after_buy();
            }

            
        }
        private void buying_liter_numeric_ValueChanged(object sender, EventArgs e)
        {
            if(buying_liter_numeric.Value != 0)
            {
                double buy_price, total, liter;
                liter = Convert.ToDouble(buying_liter_numeric.Value);
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select BuyingPrice from Tbl_Gas where ID = @p1", conn);
                cmd.Parameters.AddWithValue("@p1", gas_type_combobox.SelectedValue);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    buy_price = Convert.ToDouble(dr[0].ToString());
                    total = buy_price * liter;
                    buy_total_txtbox.Text = total.ToString();
                }
                conn.Close();
            }
            else {;}
        }
    }
}
