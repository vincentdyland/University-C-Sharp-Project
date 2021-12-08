﻿using MRA_Client.Controller;
using MRA_Client.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace MRA_Client {
    public partial class MRA_Management : Form {
        public Account Account { get; set; }

        public MRA_Management(Account account) {
            Account = account;
            InitializeComponent();
        }

        private void MRA_Management_Load(object sender, EventArgs e) {
            LoadSubject();
            LoadClass();
            LoadTable();
        }

        private void LoadTable() {
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("RollStudentColumn", "Roll");
            dataGridView1.Columns["RollStudentColumn"].Width = 90;
            dataGridView1.Columns["RollStudentColumn"].DataPropertyName = "Roll";
            dataGridView1.Columns["RollStudentColumn"].ReadOnly = true;

            dataGridView1.Columns.Add("NameStudentColum", "Name");
            dataGridView1.Columns["NameStudentColum"].Width = 150;
            dataGridView1.Columns["NameStudentColum"].DataPropertyName = "Name";
            dataGridView1.Columns["NameStudentColum"].ReadOnly = true;

            foreach (GrandItem grandItem in grandItems) {
                dataGridView1.Columns.Add(grandItem.RollType, grandItem.Name + " (" + grandItem.Weight + ")");
                dataGridView1.Columns[grandItem.RollType].Width = 150;
                dataGridView1.Columns[grandItem.RollType].DataPropertyName = grandItem.RollType;
            }
            string rollSubject = SubjectComboBox.SelectedValue.ToString();
            string rollClass = ClassComboBox.SelectedValue.ToString().Trim();
            List<Student> students = ManagementController.GetStudent(rollClass);
            dataGridView1.DataSource = students;

            foreach (DataGridViewRow dataGridViewRow in dataGridView1.Rows) {
                string rollStudent = dataGridViewRow.Cells["RollStudentColumn"].Value.ToString();
                foreach (GrandItem granditem in grandItems) {
                    Double? score = ManagementController.GetScore(rollStudent, rollSubject, granditem.RollType);
                    dataGridViewRow.Cells[granditem.RollType].Value = score != null ? Math.Round((double)score, 1) : score;
                }
            }

            SetVisualColunm();
            buttonSave.Enabled = false;
        }

        private void SetVisualColunm() {
            for (int i = 0; i < GrandItemCheckedListBox.Items.Count; i++) {
                string grandItem = ((GrandItem)GrandItemCheckedListBox.Items[i]).RollType;
                if (GrandItemCheckedListBox.GetItemChecked(i) == true) {
                    dataGridView1.Columns[grandItem].Visible = true;
                } else {
                    dataGridView1.Columns[grandItem].Visible = false;
                }
            }
        }

        List<GrandItem> grandItems;

        private void LoadClass() {
            string rollTeacher = Account.Roll;
            string rollSubject = SubjectComboBox.SelectedValue.ToString();
            ClassComboBox.DataSource = ManagementController.GetListClass(rollTeacher, rollSubject);
        }

        private void LoadSubject() {
            string rollTeacher = Account.Roll;
            SubjectComboBox.DataSource = ManagementController.GetListSubject(rollTeacher);
            LoadGrandItems();
        }

        private void LoadGrandItems() {
            GrandItemCheckedListBox.Items.Clear();
            string rollSuject = SubjectComboBox.SelectedValue.ToString();
            GrandItemCheckedListBox.DisplayMember = "name";
            GrandItemCheckedListBox.ValueMember = "roll";
            grandItems = ManagementController.GetGrandType(rollSuject);
            foreach (GrandItem item in grandItems) {
                GrandItemCheckedListBox.Items.Add(item);
            }
        }

        private void buttonExit_Click(object sender, EventArgs e) {
            if (buttonSave.Enabled == true) {
                DialogResult = MessageBox.Show("You have not updated your score yet\n" +
                    "Do you want to update mark the program?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                if (DialogResult == DialogResult.Yes) {
                    UpdateMark();
                }
            }
            Environment.Exit(0);
        }

        private void GrandItemCheckedListBox_SelectedIndexChanged(object sender, EventArgs e) {
            SetVisualColunm();
        }

        private void SubjectComboBox_SelectionChangeCommitted(object sender, EventArgs e) {
            if (buttonSave.Enabled == true) {
                DialogResult = MessageBox.Show("You have not updated your mark yet\n" +
                   "Do you want to update mark the program?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                if (DialogResult == DialogResult.Yes) {
                    UpdateMark();
                }
            }
            LoadGrandItems();
            LoadClass();
            LoadTable();
            SetVisualColunm();
        }

        private void ClassComboBox_SelectionChangeCommitted(object sender, EventArgs e) {
            if (buttonSave.Enabled == true) {
                DialogResult = MessageBox.Show("You have not updated your mark yet\n" +
                   "Do you want to update mark the program?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                if (DialogResult == DialogResult.Yes) {
                    UpdateMark();
                }
            }
            LoadTable();
            SetVisualColunm();
        }

        private void UpdateMark() {
            this.Enabled = false;
            foreach (DataGridViewRow dataGridViewRow in dataGridView1.Rows) {
                string RollStudent = dataGridViewRow.Cells["RollStudentColumn"].Value + "";
                for (int i = 0; i < dataGridViewRow.Cells.Count - 2; i++) {
                    string RollType = dataGridView1.Columns[dataGridViewRow.Cells[i].ColumnIndex].DataPropertyName;
                    object Mark = dataGridViewRow.Cells[i].Value;
                    //MessageBox.Show(RollStudent + "\t" + RollType + "\t" + Mark);
                    ManagementController.UpDateScore(RollStudent, RollType, Mark);
                }
            }
            this.Enabled = true;
            buttonSave.Enabled = false;
            MessageBox.Show("Update Success");

        }

        object NumberTemplate;
        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e) {
            NumberTemplate = dataGridView1[e.ColumnIndex, e.RowIndex].Value;
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
            if (dataGridView1[e.ColumnIndex, e.RowIndex].Value != null) {
                string NumberInput = dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString();
                double Score = CheckNumber(NumberInput);
                if (Score == -1) {
                    MessageBox.Show("Mark range 0 to 10", "Notification");
                    dataGridView1[e.ColumnIndex, e.RowIndex].Value = NumberTemplate;
                } else {
                    if (dataGridView1[e.ColumnIndex, e.RowIndex].Value != NumberTemplate) {
                        dataGridView1[e.ColumnIndex, e.RowIndex].Value = Math.Round(Score, 1);
                        buttonSave.Enabled = true;
                    }
                }
            } else {
                if (dataGridView1[e.ColumnIndex, e.RowIndex].Value != NumberTemplate) {
                    buttonSave.Enabled = true;
                }
            }
        }
        private double CheckNumber(string NumberInput) {
            double numberTemplate;
            bool ParseSuccess = Double.TryParse(NumberInput, NumberStyles.Number, CultureInfo.CreateSpecificCulture("en-US"), out numberTemplate);
            if (!ParseSuccess || numberTemplate < 0 || numberTemplate > 10) {
                return -1;
            }
            return numberTemplate;
        }

        private void buttonSave_Click(object sender, EventArgs e) {
            UpdateMark();
            LoadTable();
        }
    }
}
