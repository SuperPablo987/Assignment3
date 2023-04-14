using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TechSupportData;

namespace Assignment3GUI
{
    /*
    * The purpose of this application is to let the user maintain products. Main Form displays data of all products and allows the user to select one.
    * The application will display product code, name, version, release date. User will be able to add, modify and delete products in the attached database.
    * Created on Apr 6, 2023
    * Author: Peter Thiel
    */
    public partial class frmViewProducts : Form
    {
        // constants
        private const int MODIFY_INDEX = 4;
        private const int DELETE_INDEX = 5;

        // private variables
        private Product currentProduct;

        public frmViewProducts()
        {
            InitializeComponent();
        }

        // on form load
        private void frmViewProducts_Load(object sender, EventArgs e)
        {
            DisplayProducts();
        }

        // displays the products on the form
        private void DisplayProducts()
        {
            dgvProducts.Columns.Clear(); // reset columns
            List<ProductDTO> products = ProductDB.GetProducts();
            dgvProducts.DataSource = products;
            // add two button columns
            var modifyColumn = new DataGridViewButtonColumn()
            {
                UseColumnTextForButtonValue = true,
                Text = "Modify",
                HeaderText = ""
            };
            dgvProducts.Columns.Add(modifyColumn);
            var deleteColumn = new DataGridViewButtonColumn()
            {
                UseColumnTextForButtonValue = true,
                Text = "Delete",
                HeaderText = ""
            };
            dgvProducts.Columns.Add(deleteColumn);
            // do some formatting
            dgvProducts.Columns[0].HeaderText = "Code";
            dgvProducts.Columns[3].HeaderText = "Release Date";
            dgvProducts.Columns[3].Width = 150;
            dgvProducts.Columns[4].Width = 120;
            dgvProducts.Columns[5].Width = 120;
            dgvProducts.AutoResizeColumns();
        }

        // add a new product
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddModifyProducts secondForm = new frmAddModifyProducts(); // makes an object of the second form
            secondForm.isAdd = true;
            secondForm.currentProduct = null;
            DialogResult = secondForm.ShowDialog();
            secondForm.Focus();
            if (DialogResult == DialogResult.OK) // proceed with add
            {
                currentProduct = secondForm.currentProduct;
                if (currentProduct != null)
                {
                    try
                    {
                        ProductDB.AddProduct(currentProduct);
                        DisplayProducts(); // refresh grid
                    }
                    catch (DbUpdateException ex) // errors coming from SaveChanges
                    {
                        string errorMessage = "Error(s) while adding product:\n";
                        var sqlException = (SqlException)ex.InnerException;
                        foreach (SqlError error in sqlException.Errors)
                        {
                            errorMessage += "ERROR CODE:  " + error.Number +
                                            " " + error.Message + "\n";
                        }
                        MessageBox.Show(errorMessage);
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Database connection lost while adding a customer. Try again later");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error while adding a product: " +
                            ex.Message, ex.GetType().ToString());
                    }
                }
            }
        }
        // user clicks somewhere in the grid  view
        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // e.ColumnIndex is the column where the click happened
            // e.RowIndex is the row where the click happened
            if (e.ColumnIndex == MODIFY_INDEX || e.ColumnIndex == DELETE_INDEX)
            {
                string productCode = dgvProducts.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();

                try
                {
                    currentProduct = ProductDB.FindProduct(productCode);
                    if (currentProduct != null)
                    {
                        if (e.ColumnIndex == MODIFY_INDEX) // Modify
                        {
                            ModifyProduct();

                        }
                        else // Delete
                        {
                            DeleteProduct();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while adding a product:" + ex.Message, ex.GetType().ToString());
                }
            }
        }
        // delete the current product
        private void DeleteProduct()
        {
            if (currentProduct != null)
            {
                DialogResult result = MessageBox.Show(
                    $"Do you want to delete {currentProduct.ProductCode}?", "Confirm delete", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (result == DialogResult.Yes) // user confirmed
                {
                    try
                    {
                        ProductDB.DeleteProduct(currentProduct.ProductCode);
                        DisplayProducts(); // refresh grid
                    }
                    catch (DbUpdateException ex) // errors coming from SaveChanges
                    {
                        string errorMessage = "Error(s) while deleting product:\n";
                        var sqlException = (SqlException)ex.InnerException;
                        foreach (SqlError error in sqlException.Errors)
                        {
                            errorMessage += "ERROR CODE:  " + error.Number +
                                            " " + error.Message + "\n";
                        }
                        MessageBox.Show(errorMessage);
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Database connection lost while deleting a product. Try again later");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error while deleting a product:" + ex.Message, ex.GetType().ToString());
                    }
                }
            }
        }
        // modify the current product
        private void ModifyProduct()
        {
            frmAddModifyProducts secondForm = new frmAddModifyProducts();
            secondForm.isAdd = false; // it is modify
            secondForm.currentProduct = currentProduct;
            DialogResult = secondForm.ShowDialog();
            if (DialogResult == DialogResult.OK) // proceed with modify
            {
                currentProduct = secondForm.currentProduct; // new data values
                try
                {
                    ProductDB.UpdateProduct(currentProduct);
                    DisplayProducts(); // refresh grid
                }
                catch (DbUpdateException ex) // errors coming from SaveChanges
                {
                    string errorMessage = "Error(s) while modifying product:\n";
                    var sqlException = (SqlException)ex.InnerException;
                    foreach (SqlError error in sqlException.Errors)
                    {
                        errorMessage += "ERROR CODE:  " + error.Number +
                                        " " + error.Message + "\n";
                    }
                    MessageBox.Show(errorMessage);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Database connection lost while modifying a product. Try again later");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while modifying a product:" + ex.Message, ex.GetType().ToString());
                }
            }
        }

        // closes the application 
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}