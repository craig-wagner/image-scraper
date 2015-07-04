
namespace CWagner.ImageBrowser
{
    partial class SiteMaint
    {
        private System.Windows.Forms.DataGrid dgSites;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgSites = new System.Windows.Forms.DataGrid();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgSites)).BeginInit();
            this.SuspendLayout();
            // 
            // dgSites
            // 
            this.dgSites.CaptionVisible = false;
            this.dgSites.DataMember = "";
            this.dgSites.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgSites.Location = new System.Drawing.Point( 8, 8 );
            this.dgSites.Name = "dgSites";
            this.dgSites.Size = new System.Drawing.Size( 496, 400 );
            this.dgSites.TabIndex = 0;
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point( 8, 416 );
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size( 75, 23 );
            this.btnInsert.TabIndex = 1;
            this.btnInsert.Text = "&Insert";
            this.btnInsert.Click += new System.EventHandler( this.btnInsert_Click );
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point( 88, 416 );
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size( 75, 23 );
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.Click += new System.EventHandler( this.btnDelete_Click );
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point( 424, 416 );
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size( 75, 23 );
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler( this.btnOK_Click );
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point( 424, 448 );
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size( 75, 23 );
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            // 
            // SiteMaint
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size( 5, 13 );
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size( 512, 479 );
            this.Controls.Add( this.btnCancel );
            this.Controls.Add( this.btnOK );
            this.Controls.Add( this.btnDelete );
            this.Controls.Add( this.btnInsert );
            this.Controls.Add( this.dgSites );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SiteMaint";
            this.Text = "Site Maintenance";
            this.Closing += new System.ComponentModel.CancelEventHandler( this.SiteMaint_Closing );
            ((System.ComponentModel.ISupportInitialize)(this.dgSites)).EndInit();
            this.ResumeLayout( false );

        }
        #endregion

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose( bool disposing )
        {
            if( disposing )
            {
                if( components != null )
                {
                    components.Dispose();
                }
            }
            base.Dispose( disposing );
        }
    }
}
