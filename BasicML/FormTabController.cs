using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicML
{
	public partial class FormBasicML : Form
	{
		// The list of internal tab objects that currently exist
		private static List<FormTab> tabs = new();


		// The number of internal tab objects that currently exist
		public static int TabCount { get { return tabs.Count; } }


		// Returns the internal tab object at the specified index
		public static FormTab TabWithIndex(int index)
		{
			while (tabs.Count <= index) { AddInstance(); }
			return tabs[index];
		}


		// Adds a new tab to the list of internal tab objects
		public static void AddInstance() 
		{
			tabs.Add(new());
		}


		// Removes the last tab from the list of internal tab objects
		public static void RemoveInstance()
		{
			if (tabs.Count > 0) { tabs.RemoveAt(tabs.Count - 1); }
		}


		// Removes the internal tab object at the specified index
		public static void RemoveInstanceAt(int index)
		{
			tabs.RemoveAt(index);
		}


		// Returns the CPU of the tab at the specified index
		public static Cpu GetCpu(int instanceIndex)
		{
			return TabWithIndex(instanceIndex).cpu;
		}


		// Refreshes the content of all tabs in the tab control
		public void RefreshTabContent()
		{
			// Adds or removes internal tab objects until the number of tabs matches the number of tabs in the tab control
			while (TabCount < tabControl.TabCount) { AddInstance(); }
			while (TabCount > tabControl.TabCount) { RemoveInstance(); }

			// Clears the pages of the tab control
			tabControl.TabPages.Clear();

			// Rebuilds the tab control pages with the internal tab objects
			foreach (FormTab tab in tabs) 
			{
				TabPage tabPage = new();
				tabPage.Controls.Add(tab);
				tabControl.TabPages.Add(tabPage);

				tab.Dock = DockStyle.Fill;
				tab.RefreshTab();
			}

			// Renames the tab control pages
			for (int i = 0; i < tabControl.TabPages.Count; i++)
			{
				tabControl.TabPages[i].Text = $"Instance {i + 1}";
			}
		}
	}
}
