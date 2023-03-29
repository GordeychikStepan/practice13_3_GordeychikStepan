using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
	public partial class Form1 : Form
	{
		//Колонки таблицы
		private DataGridViewColumn dataGridViewColumn1 = null;
		private DataGridViewColumn dataGridViewColumn2 = null;
		private DataGridViewColumn dataGridViewColumn3 = null;
		private DataGridViewColumn dataGridViewColumn4 = null;
		private DataGridViewColumn dataGridViewColumn5 = null;
		private SortedDictionary<string, Computer> computers = new SortedDictionary<string, Computer>();

		public Form1()
		{
			InitializeComponent();
			initDataGridView();
		}

		//Инициализация таблицы
		private void initDataGridView()
		{
			dataGridView1.DataSource = null;
			dataGridView1.Columns.Add(getDataGridViewColumn1());
			dataGridView1.Columns.Add(getDataGridViewColumn2());
			dataGridView1.Columns.Add(getDataGridViewColumn3());
			dataGridView1.Columns.Add(getDataGridViewColumn4());
			dataGridView1.Columns.Add(getDataGridViewColumn5());
			dataGridView1.AutoResizeColumns();
		}
		//Динамическое создание первой колонки в таблице
		private DataGridViewColumn getDataGridViewColumn1()
		{
			if (dataGridViewColumn1 == null)
			{
				dataGridViewColumn1 = new DataGridViewTextBoxColumn();
				dataGridViewColumn1.Name = "";
				dataGridViewColumn1.HeaderText = "Модель";
				dataGridViewColumn1.ValueType = typeof(string);
				dataGridViewColumn1.Width = dataGridView1.Width / 5;
			}
			return dataGridViewColumn1;
		}
		//Динамическое создание второй колонки в таблице
		private DataGridViewColumn getDataGridViewColumn2()
		{
			if (dataGridViewColumn2 == null)
			{
				dataGridViewColumn2 = new DataGridViewTextBoxColumn();
				dataGridViewColumn2.Name = "";
				dataGridViewColumn2.HeaderText = "Процессор";
				dataGridViewColumn2.ValueType = typeof(string);
				dataGridViewColumn2.Width = dataGridView1.Width / 5;
			}
			return dataGridViewColumn2;
		}
		//Динамическое создание третей колонки в таблице
		private DataGridViewColumn getDataGridViewColumn3()
		{
			if (dataGridViewColumn3 == null)
			{
				dataGridViewColumn3 = new DataGridViewTextBoxColumn();
				dataGridViewColumn3.Name = "";
				dataGridViewColumn3.HeaderText = "ОЗУ";
				dataGridViewColumn3.ValueType = typeof(string);
				dataGridViewColumn3.Width = dataGridView1.Width / 5;
			}
			return dataGridViewColumn3;
		}
		//Динамическое создание четвертой колонки в таблице
		private DataGridViewColumn getDataGridViewColumn4()
		{
			if (dataGridViewColumn4 == null)
			{
				dataGridViewColumn4 = new DataGridViewTextBoxColumn();
				dataGridViewColumn4.Name = "";
				dataGridViewColumn4.HeaderText = "Жесткий диск";
				dataGridViewColumn4.ValueType = typeof(string);
				dataGridViewColumn4.Width = dataGridView1.Width / 5;
			}
			return dataGridViewColumn4;
		}
		//Динамическое создание пятой колонки в таблице
		private DataGridViewColumn getDataGridViewColumn5()
		{
			if (dataGridViewColumn5 == null)
			{
				dataGridViewColumn5 = new DataGridViewTextBoxColumn();
				dataGridViewColumn5.Name = "";
				dataGridViewColumn5.HeaderText = "ОС";
				dataGridViewColumn5.ValueType = typeof(string);
				dataGridViewColumn5.Width = dataGridView1.Width / 5;
			}
			return dataGridViewColumn5;
		}

		//Добавление комьютера в колекцию
		private void addPC(string model, string processor, string RAM_memory, string hard_drive, string operating_system)
		{
			Computer pc = new Computer(model, processor, RAM_memory, hard_drive, operating_system);
			computers.Add(pc.getModel(), pc);

			textBox1.Text = "";
			textBox2.Text = "";
			textBox3.Text = "";
			textBox4.Text = "";
			textBox5.Text = "";
			showListInGrid();
		}
		//Удаление комьютера с колекции
		private void deleteStudent(string value)
		{
			computers.Remove(value);
			showListInGrid();
		}
		//Отображение колекции в таблице
		private void showListInGrid()
		{
			dataGridView1.Rows.Clear();
			foreach (KeyValuePair<string, Computer> kvp in computers)
			{
				DataGridViewRow row = new DataGridViewRow();
				row.CreateCells(dataGridView1);

				row.Cells[0].Value = kvp.Value.getModel();
				row.Cells[1].Value = kvp.Value.getProcessor();
				row.Cells[2].Value = kvp.Value.getRAM_memory();
				row.Cells[3].Value = kvp.Value.getHard_drive();
				row.Cells[4].Value = kvp.Value.getOperating_system();

				dataGridView1.Rows.Add(row);
			}
		}

		int countPC = 0;
		private void button1_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox5.Text))
			{
				MessageBox.Show("Заполните все поля.", "Внимание!");
				return;
			}
			if (computers.ContainsKey(textBox1.Text)) 
			{
				MessageBox.Show("Такая модель уже существует.", "Внимание!");
				return;
			}
			if (!double.TryParse(textBox3.Text, out _) || !double.TryParse(textBox4.Text, out _))
			{
				MessageBox.Show("Ну полях 'ОЗУ' и 'Жесткий диск' нужно ввести число.", "Внимание!");
				return;
			}
			countPC++;
			addPC(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text);
		}

		private void toolStripMenuItem1_Click(object sender, EventArgs e)
		{
			int selectedRow = dataGridView1.SelectedCells[0].RowIndex;
			if (selectedRow == 0 && countPC == 0) { return; }
			if (selectedRow == countPC) { return; }

			string value = dataGridView1.Rows[selectedRow].Cells[0].Value.ToString();

			DialogResult dr = MessageBox.Show("Удалить компьютер?", "Внимание!", MessageBoxButtons.YesNo);
			if (dr == DialogResult.Yes)
			{
				try { deleteStudent(value); }
				catch (Exception) { }
			}
			countPC--;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			string models = string.Join(", ", computers.Keys);
			MessageBox.Show(models, "Список всех моделей.");
		}

		private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
		{
			dataGridViewColumn1.Width = dataGridView1.Width / 5;
			dataGridViewColumn2.Width = dataGridView1.Width / 5;
			dataGridViewColumn3.Width = dataGridView1.Width / 5;
			dataGridViewColumn4.Width = dataGridView1.Width / 5;
			dataGridViewColumn5.Width = dataGridView1.Width / 5;
		}
	}
}
