using RecapProject.Entities;
namespace RecapProject

{
    public partial class Form1 : Form
    {
    ProductDal _productDal = new ProductDal();
    
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ListProducts();
            ListCategories();
            
        }
        private void ListProducts()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                dgwProducts.DataSource = context.Products.ToList();
            }
        }
       
       
        private void ListCategories()
        {
            using(NorthwindContext context = new NorthwindContext())
            {
                cbxCategory.DataSource = context.Categories.ToList();
                cbxCategory.DisplayMember = "CategoryName";//listede görünecek kýsým
                cbxCategory.ValueMember = "CategoryId";//listede seçilcek kýsmýn deðeri yani seçilen kategorinin idsini seçiyoruz.
                cbxAddCategory.DataSource = context.Categories.ToList();
                cbxAddCategory.DisplayMember = "CategoryName";
                cbxAddCategory.ValueMember = "CategoryId";


            }
        }

        private void cbxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ListProductsByCategory(Convert.ToInt32(cbxCategory.SelectedValue));
                
                
            }
            catch 
            {

                
            }
        }

        private void ListProductsByCategory(int categoryId)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                dgwProducts.DataSource = context.Products.Where(x=>x.CategoryId==categoryId).ToList();
            }
        }
        private void ListProductsByName(string productName)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                dgwProducts.DataSource = context.Products.Where(x => x.ProductName.ToLower().Contains(productName)).ToList();
            }
        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            string key = tbxSearch.Text;
            if (string.IsNullOrEmpty(key))
            {
                ListProducts();
            }
            else
            {
                ListProductsByName(tbxSearch.Text);
            }

        }

        private void btnProductAdd_Click(object sender, EventArgs e)
        {

            _productDal.Add(new Product
            {
                ProductName = tbxProductName.Text,
                UnitPrice=Convert.ToDecimal(tbxProductPrice.Text),
                QuantityPerUnit=tbxProductStock.Text,
                CategoryId =Convert.ToInt32(lblAddCategory.Text)
               
               
            });
            ListProducts();
            MessageBox.Show("Ürün Eklendi"+ProductName.ToString());
            
            

        }

        private void tbxProductStock_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgwProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            tbxUpdateName.Text = dgwProducts.CurrentRow.Cells[1].Value.ToString();
            tbxUpdatePrice.Text=dgwProducts.CurrentRow.Cells[3].Value.ToString();
            tbxUpdateInfo.Text=dgwProducts.CurrentRow.Cells[5].Value.ToString();
            tbxUpdateQuantity.Text = dgwProducts.CurrentRow.Cells[4].Value.ToString();
            lblUpCategory.Text = dgwProducts.CurrentRow.Cells[2].Value.ToString();




        }

        

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _productDal.Update(new Product
            {
                ProductId = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value),
                ProductName=tbxUpdateName.Text,
                UnitPrice=Convert.ToDecimal(tbxUpdatePrice.Text),
                QuantityPerUnit=tbxUpdateInfo.Text,
                ReorderLevel=Convert.ToInt16(tbxUpdateQuantity.Text),
                CategoryId=Convert.ToInt32(lblUpCategory.Text)
            });
            ListProducts();
            MessageBox.Show("Ürün Güncellendi!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _productDal.Delete(new Product
            {
                ProductId = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value),
            });
            ListProducts();
            MessageBox.Show("Silindi!");
        }

        private void cbxAddCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblAddCategory.Text = cbxAddCategory.SelectedValue.ToString();
            lblAddCategory.Visible = true;
        }
    }
    
}