using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Collections;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Collections.Specialized;

namespace Fulcrum_Data_Testing_Tool
{
    public partial class Form1 : Form
    {
        public string MessageID { get; set; }
        public XmlDocument xDoc { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void ReadData_Click(object sender, EventArgs e)
        {
            xDoc = new XmlDocument();
            xDoc.Load(txtb_FilePath.Text);
            MessageID = XMLOperation.GetNodValue(xDoc, "MessageID", txtb_FilePath.Text);

            DBQuery.CheckMessageIDExist(MessageID);

            XMLOperation XML_obj = new XMLOperation();
            DataSet XML_DS = XML_obj.ReadXml(txtb_FilePath.Text);

            DataTable DataTable1 = new DataTable();
            DataTable FilledDataHeader = DBQuery.EmptyDataTableHeaders();


            /*
            SqlConnection con = new SqlConnection("Persist Security Info=False;User ID=sndpro; Password=sqa@123;Initial Catalog=FulcrumDB;Data Source=ws2016");
            SqlDataAdapter da = new SqlDataAdapter("select * from Fulcrum_XML_Data where messageid = ''", con);
            da.Fill(dtDB);
            */

            string name = XMLOperation.InferfaceName(txtb_FilePath.Text);


            label_InferfaceData.Text = name;
            label_MessageData.Text = MessageID;

            DataTable1 = XML_obj.GetDataFromXmlDataSet(name, MessageID, XML_DS, FilledDataHeader);

            //SqlConnection con = new SqlConnection();
            //SqlDataAdapter da = new SqlDataAdapter("",con);
            //da.Update(DataTable1);

            DBQuery.InsertInterfaceData(DataTable1);

            MessageBox.Show("Data inserted successfully.");
        }

        private void btn_Browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            //fdlg.Title = "C# Corner Open File Dialog";
            fdlg.InitialDirectory = @"D:\";
            fdlg.Filter = "XML Files (*.xml)|*.xml";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                txtb_FilePath.Text = fdlg.FileName;
            }
        }

        private void btn_LoadData_Click(object sender, EventArgs e)
        {
            string name = XMLOperation.InferfaceName(txtb_FilePath.Text);
            MessageID = XMLOperation.GetNodValue(xDoc, "MessageID", txtb_FilePath.Text);

            label_InferfaceData.Text = name;
            label_MessageData.Text = MessageID;

            dataGridView1.DataSource = DBQuery.GetDatafromDataBase();
            MessageBox.Show("Data loaded in Datagrid");
        }

        private void btn_Validate_Click(object sender, EventArgs e)
        {
            if (XMLOperation.FileValidation(txtb_FilePath.Text) == true)
            {
                string InterfaceName = XMLOperation.InferfaceName(txtb_FilePath.Text);
                xDoc = new XmlDocument();
                xDoc.Load(txtb_FilePath.Text);
                MessageID = XMLOperation.GetNodValue(xDoc, "MessageID", txtb_FilePath.Text);

                DBQuery.CheckMessageIDExist(MessageID);

                XMLOperation XML_obj = new XMLOperation();
                DataSet XML_DS = XML_obj.ReadXml(txtb_FilePath.Text);

                DataTable DataTable1 = new DataTable();
                DataTable FilledDataHeader = DBQuery.EmptyDataTableHeaders();

                DataTable1 = XML_obj.GetDataFromXmlDataSet(InterfaceName, MessageID, XML_DS, FilledDataHeader);
                DBQuery.InsertInterfaceData(DataTable1);
                MessageBox.Show("XML file data has been Read and inserted successfully in Tool Database.");

                label_InferfaceData.Text = InterfaceName;
                label_MessageData.Text = MessageID;


                //GETTING PROPERTIES DATA FROM XML

                DataTable CSDPTableSchema = DBQuery.EmptyDataTableHeaders();

                XMLOperation xmlHandler = new XMLOperation();
                DataSet xmlDataSet = xmlHandler.ReadXml(txtb_FilePath.Text);
                DataTable XMLData = new DataTable();
                XMLData = xmlHandler.GetDataFromXmlDataSet(InterfaceName, MessageID, xmlDataSet, CSDPTableSchema);


                //Quries from database
                DataTable InterfaceMapping = new DataTable();
                InterfaceMapping = DBQuery.GetMappingQueries(InterfaceName);


                DataTable FinalTable = XMLOperation.GenerateData(XMLData, InterfaceMapping, xDoc, txtb_FilePath.Text);

                FinalTable.Columns.Add("Result");

                foreach (DataRow row in FinalTable.Rows)
                {
                    if (row["IF_DATA"].ToString() == row["CSDP_Data"].ToString())
                    {
                        row["Result"] = Tools.ResultText.Passed;
                    }
                    else if (row["CSDP_Data"].ToString() == Tools.ResultText.MappingNotFound.ToString())
                    {
                        row["Result"] = Tools.ResultText.MappingNotFound;
                    }
                    else if (row["IF_DATA"].ToString() != row["CSDP_Data"].ToString())
                    {
                        row["Result"] = Tools.ResultText.Failed;
                    }
                    else
                    {
                        row["Result"] = Tools.ResultText.None;
                    }
                }

                dataGridView1.DataSource = FinalTable.DefaultView;
            }

            else
            {
                MessageBox.Show("Please upload XML file");
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells["Result"].Value.ToString() == Tools.ResultText.Passed.ToString())
            {
                dataGridView1.Rows[e.RowIndex].Cells["Result"].Style.BackColor = Color.Green;
                dataGridView1.Rows[e.RowIndex].Cells["Result"].Style.ForeColor = Color.White;
            }
            else if (dataGridView1.Rows[e.RowIndex].Cells["Result"].Value.ToString() == Tools.ResultText.Failed.ToString())
            {
                dataGridView1.Rows[e.RowIndex].Cells["Result"].Style.BackColor = Color.Red;
                dataGridView1.Rows[e.RowIndex].Cells["Result"].Style.ForeColor = Color.White;
            }
            else if (dataGridView1.Rows[e.RowIndex].Cells["Result"].Value.ToString() == Tools.ResultText.MappingNotFound.ToString())
            {
                dataGridView1.Rows[e.RowIndex].Cells["Result"].Style.BackColor = Color.LightYellow;
                dataGridView1.Rows[e.RowIndex].Cells["Result"].Style.ForeColor = Color.Black;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ReadData.Hide();
            btn_LoadData.Hide();
        }
    }
}

