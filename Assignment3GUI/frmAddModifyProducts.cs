using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechSupportData;

namespace Assignment3GUI
{
    /*
    * The purpose of this application is to handle user input for adding modifying and deleting product data.
    * The application will control product code, name, version, release date 
    * Created on Apr 7, 2023
    * Author: Peter Thiel
    */
    public partial class frmAddModifyProducts : Form
    {

        // form level variables
        // public data for main form to set
        public bool isAdd; // true if Add false if Modify
        public Product? currentProduct = null; // selected product when Modify or null when Add

        // private constants
        private readonly DateTime MIN_DATE = new DateTime(2010, 1, 1);
        private readonly DateTime MAX_DATE = DateTime.Today.AddHours(23).AddMinutes(59);
        public frmAddModifyProducts()
        {
            InitializeComponent();
        }

        // on modal load
        private void frmAddModifyProducts_Load(object sender, EventArgs e)
        {
            // differentiates between Add and Modify
            if (isAdd) // an add operation
            {
                this.Text = "Add Product";
                txtProductCode.Enabled = true;
            }
            else // modify
            {
                this.Text = "Modify Product";
                this.txtProductCode.ReadOnly = true;
                DisplayProduct();

            }
        }

        // display product's data in the form
        private void DisplayProduct()
        {
            if (currentProduct != null)
            {
                txtProductCode.Text = currentProduct.ProductCode;
                txtName.Text = currentProduct.Name;
                txtVersion.Text = currentProduct.Version.ToString();
                dtpReleaseDate.Value = Convert.ToDateTime(currentProduct.ReleaseDate.ToString("d"));
            }
        }

        // user clicks Accept button
        private void btnAccept_Click(object sender, EventArgs e)
        {
            bool valid = true;
            // if valid
            if (isAdd) // validate code
            {
                if (Validator.IsPresent(txtProductCode))
                {
                    if (isAdd) // need to create a new product object
                    {
                        currentProduct = new Product();
                    }

                    // check if unique
                    string code = txtProductCode.Text;
                    List<string> codes = ProductDB.GetProductCodes();
                    foreach (string c in codes)
                    {
                        if (c.Trim() == code.Trim())
                        {
                            MessageBox.Show($"Duplicate product code: {code}");
                            valid = false; // found duplicate
                        }
                    }
                }
                else // empty string
                {
                    valid = false;
                }
            }
            // for both Add and Modify
            if (valid &&
                Validator.IsPresent(txtName) &&
                Validator.IsPresent(txtVersion) &&
                Validator.IsNonNegativeDecimal(txtVersion) &&
                Validator.IsDateInRange(dtpReleaseDate, MIN_DATE, MAX_DATE)
                ) // valid data
            {
                if (isAdd) // need to create the object
                {
                    currentProduct = new Product();
                }
                // fill in data of product object with new values
                currentProduct.ProductCode = txtProductCode.Text;
                currentProduct.Name = txtName.Text;
                currentProduct.Version = Convert.ToDecimal(txtVersion.Text);
                currentProduct.ReleaseDate = Convert.ToDateTime(dtpReleaseDate.Value.ToString("d"));

                DialogResult = DialogResult.OK;
            }
        }

        // no need to write code for Cancel button because it has been set as CancelButton on the form
    }
}
