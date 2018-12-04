using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProfitSymbolAssistant.Classes;
using ProfitSymbolAssistant.Helpers;
using System.Configuration;
using System.IO;
using Newtonsoft.Json;

namespace ProfitSymbolAssistant.DesktopClient
{
    public partial class MainWindow : Form
    {
        public Dictionary<char, string> monthCodesMap;
        public List<NewSymbolTemplate> newSymbolTemplates;
        public List<NewSymbolUserInput> selSymbols;
        public string dbConnectionString;
        public DataTable newSymbolDataTable;

        public MainWindow()
        {
            InitializeComponent();
            monthCodesMap = GeneralHelpers.GetMonthsCodeMap(ConfigurationManager.AppSettings["MonthsCodeMapPath"]);
            newSymbolTemplates = GeneralHelpers.LoadTemplateData(ConfigurationManager.AppSettings["NewSymbolTempaltesPath"]);
            addSymComboBox.DataSource = newSymbolTemplates.Select(item => item.UIDisplayName).OrderBy(item => item).ToList();
            selSymbols = new List<NewSymbolUserInput>();
            dbConnectionString = ConfigurationManager.ConnectionStrings["ROF"].ConnectionString;
            newSymbolDataTable = new DataTable();

        }

        private void addSymButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(monthCodeMaskedTextBox.Text))
            {
                MessageBox.Show("Please enter a month code!", "Input error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!monthCodesMap.Keys.Contains(monthCodeMaskedTextBox.Text.Trim().ToUpper().ToCharArray()[0])
                || monthCodeMaskedTextBox.Text.Length < 2)
            {
                MessageBox.Show("The month code you entered is invalid!", "Input error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (monthCodeMaskedTextBox.Text.ToCharArray()[1] == ' ')
            {
                MessageBox.Show("The month code you entered is invalid!", "Input error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (selSymbols.Select(item => item.UIDisplayName).ToList().Contains(addSymComboBox.Text))
            {
                MessageBox.Show("The symbol you selected is already on the list!", "Input error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                selSymbols.Add(new NewSymbolUserInput
                {
                    ExpireyDate = symExpDateTimePicker.Value,
                    MonthCode = monthCodeMaskedTextBox.Text.Trim().ToUpper(),
                    UIDisplayName = addSymComboBox.Text
                });
                selectedSymbolsListBox_Refresh();
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (selectedSymbolsListBox.SelectedItems.Count > 0)
            {
                foreach (NewSymbolUserInput item in selectedSymbolsListBox.SelectedItems)
                {
                    selSymbols.Remove(item);
                }
                selectedSymbolsListBox_Refresh();
            }
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            if (selSymbols.Count > 0)
            {
                try
                {
                    DAL dbData = new DAL(dbConnectionString);
                    newSymbolDataTable = GeneralHelpers.GetNewSymbolDataTable(GeneralHelpers.GetNewSymbolData(newSymbolTemplates, dbData, selSymbols, ConfigurationManager.AppSettings["MonthsCodeMapPath"]));
                }
                catch(Exception err)
                {
                    MessageBox.Show($"There was error generating the data!\n{err.Message}","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
                if (newSymbolDataTable.Rows.Count > 0 && newSymbolDataTable.Rows.Count == selSymbols.Count)
                {
                    newSymDataGridView.DataSource = newSymbolDataTable;
                    newSymDataGridView.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                    newSymDataGridView.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                    newSymDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
                else
                {
                    MessageBox.Show($"No data was found  for all or some of the selected symbols.\nShould check the symbol templates.", "Incorrect Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        private void selectedSymbolsListBox_Refresh()
        {
            BindingList<NewSymbolUserInput> dataSrc = new BindingList<NewSymbolUserInput>();
            foreach (NewSymbolUserInput item in selSymbols)
            {
                dataSrc.Add(item);
            }
            selectedSymbolsListBox.DataSource = dataSrc;
        }

        private void expSqlButton_Click(object sender, EventArgs e)
        {
            if (newSymbolDataTable.Rows.Count > 0)
            {
                SaveFileDialog expSqlSaveFileDialog = new SaveFileDialog();
                expSqlSaveFileDialog.Filter = "SQL Script|*.sql|All Files|*.*";
                expSqlSaveFileDialog.Title = "Save";
                expSqlSaveFileDialog.ShowDialog();
                if (!String.IsNullOrEmpty(expSqlSaveFileDialog.FileName))
                {
                    string sqlScript = GeneralHelpers.GenerateSqlScript(newSymbolDataTable, ConfigurationManager.AppSettings["SqlTemplatePath"]);
                    try
                    {
                        File.WriteAllText(expSqlSaveFileDialog.FileName, sqlScript);
                    }
                    catch (UnauthorizedAccessException)
                    {
                        MessageBox.Show("Access denied!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (IOException)
                    {
                        MessageBox.Show("An I/O error occurred while writing the file!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch
                    {
                        MessageBox.Show("There was error saving the file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            else
            {
                MessageBox.Show("There is no generated data to export to SQL script!", "No data", MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (selSymbols.Count > 0)
            {
                SaveFileDialog selSymbolsSaveDialogue = new SaveFileDialog();
                selSymbolsSaveDialogue.Filter = "JSON file|*.json";
                selSymbolsSaveDialogue.Title = "Save";
                selSymbolsSaveDialogue.ShowDialog();
                if (!String.IsNullOrEmpty(selSymbolsSaveDialogue.FileName))
                {
                    try
                    {
                        File.WriteAllText(selSymbolsSaveDialogue.FileName, JsonConvert.SerializeObject(selSymbols));
                    }
                    catch (UnauthorizedAccessException)
                    {
                        MessageBox.Show("Access denied!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (IOException)
                    {
                        MessageBox.Show("An I/O error occurred while writing the file!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch
                    {
                        MessageBox.Show("There was error saving the file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openJsonDialog = new OpenFileDialog();
            openJsonDialog.Filter = "JSON file|*.json";
            openJsonDialog.Title = "Open file";
            openJsonDialog.ShowDialog();
            if (!String.IsNullOrEmpty(openJsonDialog.FileName))
            {
                try
                {
                    string jsonData = File.ReadAllText(openJsonDialog.FileName);
                    selSymbols = JsonConvert.DeserializeObject<List<NewSymbolUserInput>>(jsonData);
                    selectedSymbolsListBox_Refresh();
                    generateButton_Click(new Object(), new EventArgs());
                }
                catch
                {
                    MessageBox.Show("There was error Loading the file!\nIt's either inaccessible or malformed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
