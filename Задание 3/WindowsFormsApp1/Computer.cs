using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
	class Computer
	{
		private string model;
		private string processor;
		private string RAM_memory;
		private string hard_drive;
		private string operating_system;


		public Computer(string model, string processor, string RAM_memory, string hard_drive, string operating_system)
		{
			this.model = model;
			this.processor = processor;
			this.RAM_memory = RAM_memory;
			this.hard_drive = hard_drive;
			this.operating_system = operating_system;
		}

		public string getModel() { return this.model; }
		public string getProcessor() { return this.processor; }
		public string getRAM_memory() { return this.RAM_memory; }
		public string getHard_drive() { return this.hard_drive; }
		public string getOperating_system() { return this.operating_system; }


		public void setModel(string model) { this.model = model; }
		public void setProcessor(string processor) { this.processor = processor; }
		public void setRAM_memory(string RAM_memory) { this.RAM_memory = RAM_memory; }
		public void setHard_drive(string hard_drive) { this.hard_drive = hard_drive; }
		public void setOperating_system(string operating_system) { this.operating_system = operating_system; }
	}
}
