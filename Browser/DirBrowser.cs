using System;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace CWagner.ImageBrowser
{
	public class DirBrowser : FolderNameEditor
	{
		FolderBrowser fb = new FolderBrowser();

		private string _description = "Choose Directory";
		private string _returnPath = String.Empty;

		public string Description
		{
			set { _description = value; }
			get { return _description; }
		}
		public string ReturnPath
		{
			get { return _returnPath; }
		}

		public DialogResult ShowDialog()
		{
			fb.Description = _description;
			fb.StartLocation = FolderBrowserFolder.MyComputer;
			DialogResult r = fb.ShowDialog();
			if (r == DialogResult.OK)
				_returnPath = fb.DirectoryPath;
			else
				_returnPath = String.Empty;
			return r;
		}
	}
}