using Martin_AdventureWorks.Models;
using Martin_AdventureWorks.Services;
using System;
using System.Data;
using System.Windows.Forms;

namespace Martin_AdventureWorks
{
    public partial class MainForm : Form
    {
        private readonly IAdventureWorksService _adventureWorksService;

        public MainForm(IAdventureWorksService adventureWorksService)
        {
            InitializeComponent();
            _adventureWorksService = adventureWorksService;
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            await _adventureWorksService.GetMasterList();
            DisplayMasterList();
        }

        private void DisplayMasterList()
        {
            DataTable table = new DataTable();
            DataColumn column;

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "FirstName";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "LastName";
            table.Columns.Add(column);

            foreach (var item in _adventureWorksService.MasterListModels)
            {
                DataRow row = table.NewRow();
                row["FirstName"] = item.FirstName;
                row["LastName"] = item.LastName;
                table.Rows.Add(row);
            }

            DataGridView.DataSource = table;
            DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridView.AllowUserToResizeColumns = true;
            DataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        }

        private DataTable CreateDetailsDataTable(PersonDetailsModel personDetails)
        {
            DataTable detailsTable = new DataTable();

            foreach (var property in typeof(PersonDetailsModel).GetProperties())
            {
                DataColumn column = new DataColumn();
                column.DataType = property.PropertyType;
                column.ColumnName = property.Name;
                detailsTable.Columns.Add(column);
            }

            DataColumn backButtonColumn = new DataColumn();
            backButtonColumn.DataType = typeof(Button);
            backButtonColumn.ColumnName = "BackButton";
            detailsTable.Columns.Add(backButtonColumn);
            
            DataRow row = detailsTable.NewRow();
            foreach (var property in typeof(PersonDetailsModel).GetProperties())
            {
                row[property.Name] = property.GetValue(personDetails);
            }

            Button BackButton = new Button();
            BackButton.Text = "Back";
            BackButton.Click += BackButton_Click;
            row["BackButton"] = BackButton;

            detailsTable.Rows.Add(row);

            return detailsTable;
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Controls.Remove(DataGridView);
            Controls.Remove((Button)sender);
        }

        private async void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < _adventureWorksService.MasterListModels.Count)
            {
                var selectedPerson = _adventureWorksService.MasterListModels[e.RowIndex];
                var personDetails = await _adventureWorksService.GetPersonDetails(selectedPerson.ID);
                DataTable detailsTable = CreateDetailsDataTable(personDetails);
                DataGridView.DataSource = detailsTable;

                DataGridView.Refresh();
            }
        }
    }
}

