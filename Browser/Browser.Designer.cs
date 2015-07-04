using System.Windows.Forms;

namespace CWagner.ImageBrowser
{
    partial class Browser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if( disposing && (components != null) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code
        /// <summary>
        ///    Required method for Designer support - do not modify
        ///    the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Browser));
            this.tlbBrowser = new System.Windows.Forms.ToolBar();
            this.tbbBack = new System.Windows.Forms.ToolBarButton();
            this.tbbSep1 = new System.Windows.Forms.ToolBarButton();
            this.tbbGetImages = new System.Windows.Forms.ToolBarButton();
            this.tbbSep2 = new System.Windows.Forms.ToolBarButton();
            this.tbbSkipIfExists = new System.Windows.Forms.ToolBarButton();
            this.tbbCloseOnCompletion = new System.Windows.Forms.ToolBarButton();
            this.tbbSep3 = new System.Windows.Forms.ToolBarButton();
            this.tbbExit = new System.Windows.Forms.ToolBarButton();
            this.ilToolbar = new System.Windows.Forms.ImageList(this.components);
            this.lblUrl = new System.Windows.Forms.Label();
            this.mnuMain = new System.Windows.Forms.MainMenu(this.components);
            this.mnuFile = new System.Windows.Forms.MenuItem();
            this.mnuFileGetImages = new System.Windows.Forms.MenuItem();
            this.mnuFileSep01 = new System.Windows.Forms.MenuItem();
            this.mnuFileExit = new System.Windows.Forms.MenuItem();
            this.mnuOptions = new System.Windows.Forms.MenuItem();
            this.mnuOptionsSkipIfExists = new System.Windows.Forms.MenuItem();
            this.mnuOptionsCloseOnCompletion = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.mnuOptionsSiteMaintenance = new System.Windows.Forms.MenuItem();
            this.mnuNavigate = new System.Windows.Forms.MenuItem();
            this.mnuNavigateGo = new System.Windows.Forms.MenuItem();
            this.mnuNavigateBack = new System.Windows.Forms.MenuItem();
            this.lblSaveTo = new System.Windows.Forms.Label();
            this.txtSaveLoc = new System.Windows.Forms.TextBox();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.cboSite = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // tlbBrowser
            // 
            this.tlbBrowser.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.tlbBrowser.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.tbbBack,
            this.tbbSep1,
            this.tbbGetImages,
            this.tbbSep2,
            this.tbbSkipIfExists,
            this.tbbCloseOnCompletion,
            this.tbbSep3,
            this.tbbExit});
            this.tlbBrowser.DropDownArrows = true;
            this.tlbBrowser.ImageList = this.ilToolbar;
            this.tlbBrowser.Location = new System.Drawing.Point(0, 0);
            this.tlbBrowser.Name = "tlbBrowser";
            this.tlbBrowser.ShowToolTips = true;
            this.tlbBrowser.Size = new System.Drawing.Size(860, 42);
            this.tlbBrowser.TabIndex = 5;
            this.tlbBrowser.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.tlbBrowser_ButtonClick);
            // 
            // tbbBack
            // 
            this.tbbBack.ImageIndex = 2;
            this.tbbBack.Name = "tbbBack";
            this.tbbBack.Text = "Back";
            // 
            // tbbSep1
            // 
            this.tbbSep1.Name = "tbbSep1";
            this.tbbSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // tbbGetImages
            // 
            this.tbbGetImages.ImageIndex = 0;
            this.tbbGetImages.Name = "tbbGetImages";
            this.tbbGetImages.Text = "Images";
            // 
            // tbbSep2
            // 
            this.tbbSep2.Name = "tbbSep2";
            this.tbbSep2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // tbbSkipIfExists
            // 
            this.tbbSkipIfExists.ImageIndex = 3;
            this.tbbSkipIfExists.Name = "tbbSkipIfExists";
            this.tbbSkipIfExists.Pushed = true;
            this.tbbSkipIfExists.Text = "Skip";
            // 
            // tbbCloseOnCompletion
            // 
            this.tbbCloseOnCompletion.ImageIndex = 4;
            this.tbbCloseOnCompletion.Name = "tbbCloseOnCompletion";
            this.tbbCloseOnCompletion.Text = "Close";
            // 
            // tbbSep3
            // 
            this.tbbSep3.Name = "tbbSep3";
            this.tbbSep3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // tbbExit
            // 
            this.tbbExit.ImageIndex = 1;
            this.tbbExit.Name = "tbbExit";
            this.tbbExit.Text = "Exit";
            // 
            // ilToolbar
            // 
            this.ilToolbar.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilToolbar.ImageStream")));
            this.ilToolbar.TransparentColor = System.Drawing.Color.Transparent;
            this.ilToolbar.Images.SetKeyName(0, "");
            this.ilToolbar.Images.SetKeyName(1, "");
            this.ilToolbar.Images.SetKeyName(2, "");
            this.ilToolbar.Images.SetKeyName(3, "");
            this.ilToolbar.Images.SetKeyName(4, "");
            // 
            // lblUrl
            // 
            this.lblUrl.Location = new System.Drawing.Point(288, 88);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(85, 21);
            this.lblUrl.TabIndex = 2;
            this.lblUrl.Text = "&URL:";
            this.lblUrl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mnuMain
            // 
            this.mnuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuFile,
            this.mnuOptions,
            this.mnuNavigate});
            // 
            // mnuFile
            // 
            this.mnuFile.Index = 0;
            this.mnuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuFileGetImages,
            this.mnuFileSep01,
            this.mnuFileExit});
            this.mnuFile.Text = "File";
            // 
            // mnuFileGetImages
            // 
            this.mnuFileGetImages.Index = 0;
            this.mnuFileGetImages.Shortcut = System.Windows.Forms.Shortcut.F12;
            this.mnuFileGetImages.Text = "&Get Images";
            this.mnuFileGetImages.Click += new System.EventHandler(this.mnuFileGetImages_Click);
            // 
            // mnuFileSep01
            // 
            this.mnuFileSep01.Index = 1;
            this.mnuFileSep01.Text = "-";
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Index = 2;
            this.mnuFileExit.Shortcut = System.Windows.Forms.Shortcut.AltF4;
            this.mnuFileExit.ShowShortcut = false;
            this.mnuFileExit.Text = "E&xit";
            this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
            // 
            // mnuOptions
            // 
            this.mnuOptions.Index = 1;
            this.mnuOptions.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuOptionsSkipIfExists,
            this.mnuOptionsCloseOnCompletion,
            this.menuItem1,
            this.mnuOptionsSiteMaintenance});
            this.mnuOptions.Text = "Options";
            // 
            // mnuOptionsSkipIfExists
            // 
            this.mnuOptionsSkipIfExists.Checked = true;
            this.mnuOptionsSkipIfExists.Index = 0;
            this.mnuOptionsSkipIfExists.Text = "Skip if Exists";
            this.mnuOptionsSkipIfExists.Click += new System.EventHandler(this.ToggleMenuCheck);
            // 
            // mnuOptionsCloseOnCompletion
            // 
            this.mnuOptionsCloseOnCompletion.Index = 1;
            this.mnuOptionsCloseOnCompletion.Text = "Close on Completion";
            this.mnuOptionsCloseOnCompletion.Click += new System.EventHandler(this.ToggleMenuCheck);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 2;
            this.menuItem1.Text = "-";
            // 
            // mnuOptionsSiteMaintenance
            // 
            this.mnuOptionsSiteMaintenance.Index = 3;
            this.mnuOptionsSiteMaintenance.Text = "Site Maintenance...";
            this.mnuOptionsSiteMaintenance.Click += new System.EventHandler(this.mnuOptionsSiteMaintenance_Click);
            // 
            // mnuNavigate
            // 
            this.mnuNavigate.Index = 2;
            this.mnuNavigate.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuNavigateGo,
            this.mnuNavigateBack});
            this.mnuNavigate.Text = "Navigate";
            // 
            // mnuNavigateGo
            // 
            this.mnuNavigateGo.Index = 0;
            this.mnuNavigateGo.Text = "Go";
            this.mnuNavigateGo.Click += new System.EventHandler(this.mnuNavigateGo_Click);
            // 
            // mnuNavigateBack
            // 
            this.mnuNavigateBack.Index = 1;
            this.mnuNavigateBack.Shortcut = System.Windows.Forms.Shortcut.AltBksp;
            this.mnuNavigateBack.Text = "Back";
            // 
            // lblSaveTo
            // 
            this.lblSaveTo.Location = new System.Drawing.Point(288, 56);
            this.lblSaveTo.Name = "lblSaveTo";
            this.lblSaveTo.Size = new System.Drawing.Size(85, 21);
            this.lblSaveTo.TabIndex = 0;
            this.lblSaveTo.Text = "&Save To Folder:";
            this.lblSaveTo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSaveLoc
            // 
            this.txtSaveLoc.Location = new System.Drawing.Point(376, 56);
            this.txtSaveLoc.Name = "txtSaveLoc";
            this.txtSaveLoc.Size = new System.Drawing.Size(361, 20);
            this.txtSaveLoc.TabIndex = 1;
            this.txtSaveLoc.Text = "D:\\Download";
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(376, 88);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(361, 20);
            this.txtUrl.TabIndex = 2;
            this.txtUrl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUrl_KeyPress);
            // 
            // cboSite
            // 
            this.cboSite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSite.DropDownWidth = 200;
            this.cboSite.Location = new System.Drawing.Point(64, 56);
            this.cboSite.Name = "cboSite";
            this.cboSite.Size = new System.Drawing.Size(200, 21);
            this.cboSite.Sorted = true;
            this.cboSite.TabIndex = 0;
            this.cboSite.SelectedIndexChanged += new System.EventHandler(this.cboSite_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 21);
            this.label1.TabIndex = 7;
            this.label1.Text = "S&ite:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // webBrowser
            // 
            this.webBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser.Location = new System.Drawing.Point(8, 124);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(844, 522);
            this.webBrowser.TabIndex = 8;
            this.webBrowser.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.webBrowser_Navigated);
            this.webBrowser.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.webBrowser_Navigating);
            // 
            // Browser
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(860, 654);
            this.Controls.Add(this.webBrowser);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboSite);
            this.Controls.Add(this.tlbBrowser);
            this.Controls.Add(this.lblUrl);
            this.Controls.Add(this.lblSaveTo);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.txtSaveLoc);
            this.Location = new System.Drawing.Point(10, 10);
            this.Menu = this.mnuMain;
            this.Name = "Browser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ImageDownloader";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Browser_Closing);
            this.Load += new System.EventHandler(this.Browser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.TextBox txtSaveLoc;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Label lblSaveTo;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.MenuItem mnuFile;
        private System.Windows.Forms.MenuItem mnuFileExit;
        private System.Windows.Forms.MenuItem mnuFileGetImages;
        private System.Windows.Forms.MenuItem mnuFileSep01;
        private System.Windows.Forms.MenuItem mnuOptions;
        private System.Windows.Forms.MenuItem mnuOptionsSkipIfExists;
        private System.Windows.Forms.MenuItem mnuNavigate;
        private System.Windows.Forms.MenuItem mnuNavigateGo;
        private System.Windows.Forms.MenuItem mnuNavigateBack;
        private System.Windows.Forms.MainMenu mnuMain;
        private System.Windows.Forms.ToolBarButton tbbGetImages;
        private System.Windows.Forms.ImageList ilToolbar;
        private System.Windows.Forms.ToolBarButton tbbExit;
        private System.Windows.Forms.ToolBarButton tbbSep1;
        private System.Windows.Forms.ToolBar tlbBrowser;
        private System.Windows.Forms.ToolBarButton tbbBack;
        private System.Windows.Forms.ToolBarButton tbbSep2;
        private System.Windows.Forms.ToolBarButton tbbSep3;
        private System.Windows.Forms.ToolBarButton tbbSkipIfExists;
        private System.Windows.Forms.ToolBarButton tbbCloseOnCompletion;
        private System.Windows.Forms.ComboBox cboSite;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem mnuOptionsSiteMaintenance;
        private WebBrowser webBrowser;
        private System.Windows.Forms.MenuItem mnuOptionsCloseOnCompletion;
    }
}
