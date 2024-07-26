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
		public static TabControl tabControlStatic;

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
			tabs.Add(new(tabs.Count));
			//tabControlStatic.TabPages.Add(new TabPage());
		}


		// Removes the last tab from the list of internal tab objects
		public static void RemoveInstance()
		{
			if (tabs.Count > 0) { tabs.RemoveAt(tabs.Count - 1); }
			//tabControlStatic.TabPages.RemoveAt(tabs.Count - 1);
		}


		// Removes the internal tab object at the specified index
		public static void RemoveInstanceAt(int index)
		{
			tabs.RemoveAt(index);
			for (int i = 0; i < tabs.Count; i++)
			{
				tabs[i].index = i;
			}
			//tabControlStatic.TabPages.RemoveAt(0);
		}


		// Returns the CPU of the tab at the specified index
		public static Cpu GetCpu(int instanceIndex)
		{
			return TabWithIndex(instanceIndex).cpu;
		}


		// Refreshes the content of all tabs in the tab control
		public static void RefreshTabContent()
		{
			// Adds or removes internal tab objects until the number of tabs matches the number of tabs in the tab control
			//while (TabCount < tabControlStatic.TabCount) { AddInstance(); }
			//while (TabCount > tabControlStatic.TabCount) { RemoveInstance(); }

			// Clears the pages of the tab control
			tabControlStatic.TabPages.Clear();

			// Rebuilds the tab control pages with the internal tab objects
			foreach (FormTab tab in tabs) 
			{
				TabPage tabPage = new();
				tabPage.Controls.Add(tab);
				tabControlStatic.TabPages.Add(tabPage);

				tab.Dock = DockStyle.Fill;
				tab.RefreshTab();
			}

			// Renames the tab control pages
			for (int i = 0; i < tabControlStatic.TabPages.Count; i++)
			{
				tabControlStatic.TabPages[i].Text = $"Instance {i + 1}";
			}
		}
	}
}
