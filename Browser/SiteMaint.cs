using System.Data;
using System.Windows.Forms;

namespace CWagner.ImageBrowser
{
    public partial class SiteMaint : Form
    {
        public static readonly string DataFile;

        private DataSet sites;

        static SiteMaint()
        {
            DataFile = Application.ExecutablePath.Substring( 0, Application.ExecutablePath.LastIndexOf( "\\" ) + 1 ) + "sites.xml";
        }

        public SiteMaint()
        {
            InitializeComponent();

            DataGridTableStyle dgStyle = new DataGridTableStyle();
            dgStyle.MappingName = "site";
            dgStyle.RowHeadersVisible = false;

            DataGridTextBoxColumn name = new DataGridTextBoxColumn();
            name.MappingName = "name";
            name.HeaderText = "Name";
            name.Width = 200;
            name.TextBox.MaxLength = 30;

            DataGridTextBoxColumn url = new DataGridTextBoxColumn();
            url.MappingName = "url";
            url.HeaderText = "URL";
            url.Width = 225;

            DataGridTextBoxColumn username = new DataGridTextBoxColumn();
            username.MappingName = "username";
            username.HeaderText = "Username";
            username.Width = 125;

            DataGridTextBoxColumn password = new DataGridTextBoxColumn();
            password.MappingName = "password";
            password.HeaderText = "Password";
            password.Width = 125;

            DataGridTextBoxColumn saveFolder = new DataGridTextBoxColumn();
            saveFolder.MappingName = "savefolder";
            saveFolder.HeaderText = "Save Folder";
            saveFolder.Width = 200;

            dgStyle.GridColumnStyles.AddRange( new DataGridColumnStyle[] { name, url, username, password, saveFolder } );
            dgSites.TableStyles.Add( dgStyle );

            int width = 0;
            foreach( DataGridColumnStyle col in dgStyle.GridColumnStyles )
            {
                width += col.Width;
            }

            dgSites.Width = width + 20;

            this.Width = dgSites.Width + dgSites.Left * 2 + (this.Width - this.ClientSize.Width);

            btnOK.Left = dgSites.Left + dgSites.Width - btnOK.Width;
            btnCancel.Left = dgSites.Left + dgSites.Width - btnCancel.Width;

            sites = new DataSet( "Sites" );

            sites.ReadXml( SiteMaint.DataFile );

            dgSites.SetDataBinding( sites, "site" );

            // Adding the xml to the dataset causes HasChanges to return true, so accept the changes so
            // no modifications are registered
            sites.AcceptChanges();
        }

        private void SaveChanges()
        {
            sites.WriteXml( SiteMaint.DataFile, System.Data.XmlWriteMode.WriteSchema );
        }

        private void btnOK_Click( object sender, System.EventArgs e )
        {
            if( sites.HasChanges() )
            {
                SaveChanges();

                sites.AcceptChanges();
            }
        }

        private void btnInsert_Click( object sender, System.EventArgs e )
        {
            DataRow row = sites.Tables["site"].NewRow();
            sites.Tables["site"].Rows.Add( row );

            BindingManagerBase bmb = dgSites.BindingContext[sites, "site"];
            bmb.Position = sites.Tables["site"].Rows.Count;

            dgSites.Focus();
        }

        private void btnDelete_Click( object sender, System.EventArgs e )
        {
            int position;

            BindingManagerBase bmb = dgSites.BindingContext[sites, "site"];

            position = bmb.Position;

            DataRow r = sites.Tables["site"].Rows[position];
            r.Delete();

            dgSites.Focus();
        }

        private void SiteMaint_Closing( object sender, System.ComponentModel.CancelEventArgs e )
        {
            if( sites.HasChanges() )
            {
                DialogResult result = MessageBox.Show( "Save changes?", this.Text, MessageBoxButtons.YesNoCancel );

                switch( result )
                {
                    case DialogResult.Yes:
                        SaveChanges();
                        this.DialogResult = DialogResult.OK;
                        break;

                    case DialogResult.No:
                        // Do nothing, let the window close, lose changes
                        this.DialogResult = DialogResult.Cancel;
                        break;

                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            }
        }
    }
}