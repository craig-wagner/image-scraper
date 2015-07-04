#region using
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Web;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;
using Microsoft.Win32;
#endregion using

namespace CWagner.ImageBrowser
{
    public partial class Browser : Form
    {
        private const string regKey = @"Software\ImageScraper";

        private XPathDocument xpDocSites;

        private string username = null;
        private string password = null;

        public Browser()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        //private IEnumerable<string> GetFilenames()
        //{
        //    List<string> hrefs = new List<string>();

        //    HtmlDocument doc;
        //    HtmlElementCollection anchors;

        //    doc = webBrowser.Document;

        //    anchors = doc.GetElementsByTagName( "A" );

        //    foreach( HtmlElement anchor in anchors )
        //    {
        //        string href = anchor.GetAttribute( "href" );

        //        if( href != null && href.ToLower().IndexOf( "members/contris/homeclips" ) != -1 )
        //        {
        //            string[] parts = href.Split( '/' );

        //            parts[9] = parts[8] + "hq.wmv";

        //            hrefs.Add( String.Join( "/", parts ) );
        //        }
        //    }

        //    return hrefs;
        //}

        private IEnumerable<string> GetFilenames()
        {
            List<string> hrefs = new List<string>();

            var doc = webBrowser.Document;

            var divs = doc.GetElementsByTagName( "div" );
            var thumbs = new List<HtmlElement>();

            foreach( HtmlElement div in divs )
            {
                if( div.GetAttribute( "classname" ) == "thumb" )
                {
                    thumbs.Add( div );
                }
            }

            foreach( HtmlElement div in thumbs )
            {
                var images = div.GetElementsByTagName( "img" );

                foreach( HtmlElement image in images )
                {
                    var src = image.GetAttribute( "src" );
                    var parts = src.Split( '/' );
                    var folder = parts[4].Split( '-' );
                    folder[0] = (Int32.Parse( folder[0] ) - 1).ToString();
                    parts[4] = String.Join( "-", folder );
                    hrefs.Add( String.Join( "/", parts ) );
                }
            }

            return hrefs;
        }

        private void GetImages()
        {
            try
            {
                Cursor.Current = Cursors.AppStarting;

                var hrefs = GetFilenames();

                ProgressDialog p = new ProgressDialog();
                p.Show();
                p.GetImages(
                    username, password, txtSaveLoc.Text,
                    mnuOptionsSkipIfExists.Checked,
                    mnuOptionsCloseOnCompletion.Checked,
                    hrefs );

                Cursor.Current = Cursors.Default;
            }
            catch( Exception ex )
            {
                MessageBox.Show( ex.ToString() );
            }
        }

        private void Browser_Load( object sender, EventArgs e )
        {
            try
            {
                RegistryKey hkcu = Registry.CurrentUser;

                RegistryKey appkey = hkcu.OpenSubKey( regKey );

                if( appkey != null )
                {
                    int left = (int)appkey.GetValue( "Left", 10 );
                    int top = (int)appkey.GetValue( "Top", 10 );
                    int width = (int)appkey.GetValue( "Width", this.Width );
                    int height = (int)appkey.GetValue( "Height", this.Height );
                    mnuOptionsSkipIfExists.Checked = Convert.ToBoolean( appkey.GetValue( "SkipIfExists", 1 ) );
                    tbbSkipIfExists.Pushed = mnuOptionsSkipIfExists.Checked;
                    mnuOptionsCloseOnCompletion.Checked = Convert.ToBoolean( appkey.GetValue( "CloseOnCompletion", 0 ) );
                    tbbCloseOnCompletion.Pushed = mnuOptionsCloseOnCompletion.Checked;

                    this.Location = new Point( left, top );
                    this.Size = new Size( width, height );
                }

            }
            catch( Exception ex )
            {
                MessageBox.Show( "There was a problem getting your saved settings from the registry.\n\r\n\r" + ex.ToString(), this.Text );
            }

            LoadSites();
        }

        private void webBrowser_Navigated( object sender, WebBrowserNavigatedEventArgs e )
        {
            txtUrl.Text = e.Url.ToString();
            mnuFileGetImages.Enabled = true;
            txtUrl.Focus();

            var parts = txtUrl.Text.Split( "/".ToCharArray(), StringSplitOptions.RemoveEmptyEntries );
            txtSaveLoc.Text = HttpUtility.UrlDecode( "D:\\Download\\" + String.Join( "\\", parts, 3, parts.Length - 3 ) );
        }

        private void Navigate( string url )
        {
            webBrowser.Navigate( url );
        }

        private void webBrowser_Navigating( object sender, WebBrowserNavigatingEventArgs e )
        {
            mnuFileGetImages.Enabled = false;
        }

        private void NavigateBack()
        {
            try
            {
                webBrowser.GoBack();
            }
            catch( Exception )
            {
            }
        }

        private void Browser_Closing( object sender, System.ComponentModel.CancelEventArgs e )
        {
            try
            {
                RegistryKey hkcu = Registry.CurrentUser;

                RegistryKey appkey;

                appkey = hkcu.CreateSubKey( regKey );

                appkey.SetValue( "Left", this.Left );
                appkey.SetValue( "Top", this.Top );
                appkey.SetValue( "Width", this.Width );
                appkey.SetValue( "Height", this.Height );
                appkey.SetValue( "SkipIfExists", Convert.ToInt32( mnuOptionsSkipIfExists.Checked ) );
                appkey.SetValue( "CloseOnCompletion", Convert.ToInt32( mnuOptionsCloseOnCompletion.Checked ) );
            }
            catch( Exception ex )
            {
                MessageBox.Show( "There was a problem saving your settings to the registry.\n\r\n\r" + ex.ToString(), this.Text );
            }
        }

        private void ToggleMenuCheck( object sender, System.EventArgs e )
        {
            MenuItem m = (MenuItem)sender;

            m.Checked = !m.Checked;

            if( m == mnuOptionsSkipIfExists )
            {
                tbbSkipIfExists.Pushed = m.Checked;
            }
            else if( m == mnuOptionsCloseOnCompletion )
            {
                tbbCloseOnCompletion.Pushed = m.Checked;
            }
        }

        private void mnuFileExit_Click( object sender, System.EventArgs e )
        {
            this.Close();
        }

        private void mnuFileGetImages_Click( object sender, System.EventArgs e )
        {
            GetImages();
        }

        private void mnuNavigateGo_Click( object sender, System.EventArgs e )
        {
            Navigate( txtUrl.Text );
        }

        private void txtUrl_KeyPress( object sender, System.Windows.Forms.KeyPressEventArgs e )
        {
            if( e.KeyChar == '\r' )
            {
                Navigate( txtUrl.Text );
                e.Handled = true;
            }
        }

        private void tlbBrowser_ButtonClick( object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e )
        {
            ToolBarButton tbb = (ToolBarButton)e.Button;

            if( tbb == tbbCloseOnCompletion )
            {
                tbb.Pushed = !tbb.Pushed;
                mnuOptionsCloseOnCompletion.Checked = tbb.Pushed;
            }
            else if( tbb == tbbSkipIfExists )
            {
                tbb.Pushed = !tbb.Pushed;
                mnuOptionsSkipIfExists.Checked = tbb.Pushed;
            }
            else if( tbb == tbbGetImages )
            {
                GetImages();
            }
            else if( tbb == tbbExit )
            {
                this.Close();
            }
            else if( tbb == tbbBack )
            {
                NavigateBack();
            }
        }

        private void CreateXmlSchema()
        {
            const string nsSchema = "http://www.w3.org/2001/XMLSchema";
            const string nsMsData = "urn:schemas-microsoft-com:xml-msdata";

            XmlTextWriter writer = new XmlTextWriter( SiteMaint.DataFile, null );

            writer.Formatting = Formatting.Indented;

            writer.WriteStartDocument( true );

            writer.WriteStartElement( "sites" );

            writer.WriteStartElement( "xs", "schema", nsSchema );
            writer.WriteAttributeString( "xmlns", "msdata", null, nsMsData );

            writer.WriteStartElement( "element", nsSchema );
            writer.WriteAttributeString( "name", "sites" );
            writer.WriteStartAttribute( "IsDataSet", nsMsData );
            writer.WriteString( "true" );
            writer.WriteEndAttribute(); // IsDataSet

            writer.WriteStartElement( "complexType", nsSchema );

            writer.WriteStartElement( "choice", nsSchema );
            writer.WriteAttributeString( "maxOccurs", "unbounded" );

            writer.WriteStartElement( "element", nsSchema );
            writer.WriteAttributeString( "name", "site" );

            writer.WriteStartElement( "complexType", nsSchema );

            writer.WriteStartElement( "sequence", nsSchema );

            writer.WriteStartElement( "element", nsSchema );
            writer.WriteAttributeString( "name", "url" );
            writer.WriteAttributeString( "type", "xs:string" );
            writer.WriteAttributeString( "minOccurs", "1" );
            writer.WriteAttributeString( "maxOccurs", "1" );
            writer.WriteStartAttribute( "Ordinal", nsMsData );
            writer.WriteString( "0" );
            writer.WriteEndAttribute(); // Ordinal
            writer.WriteEndElement();   // element (url)

            writer.WriteStartElement( "element", nsSchema );
            writer.WriteAttributeString( "name", "username" );
            writer.WriteAttributeString( "type", "xs:string" );
            writer.WriteAttributeString( "minOccurs", "1" );
            writer.WriteAttributeString( "maxOccurs", "1" );
            writer.WriteStartAttribute( "Ordinal", nsMsData );
            writer.WriteString( "1" );
            writer.WriteEndAttribute(); // Ordinal
            writer.WriteEndElement();   // element (username)

            writer.WriteStartElement( "element", nsSchema );
            writer.WriteAttributeString( "name", "password" );
            writer.WriteAttributeString( "type", "xs:string" );
            writer.WriteAttributeString( "minOccurs", "1" );
            writer.WriteAttributeString( "maxOccurs", "1" );
            writer.WriteStartAttribute( "Ordinal", nsMsData );
            writer.WriteString( "2" );
            writer.WriteEndAttribute(); // Ordinal
            writer.WriteEndElement();   // element (password)

            writer.WriteStartElement( "element", nsSchema );
            writer.WriteAttributeString( "name", "savefolder" );
            writer.WriteAttributeString( "type", "xs:string" );
            writer.WriteAttributeString( "minOccurs", "1" );
            writer.WriteAttributeString( "maxOccurs", "1" );
            writer.WriteStartAttribute( "Ordinal", nsMsData );
            writer.WriteString( "3" );
            writer.WriteEndAttribute(); // Ordinal
            writer.WriteEndElement();   // element (password)

            writer.WriteEndElement();   // sequence

            writer.WriteStartElement( "attribute", nsSchema );
            writer.WriteAttributeString( "name", "name" );
            writer.WriteAttributeString( "type", "xs:string" );
            writer.WriteEndElement();   // attribute (name)

            writer.WriteEndElement();   // element (site)
            writer.WriteEndElement();   // choice
            writer.WriteEndElement();   // complexType
            writer.WriteEndElement();   // element (sites)
            writer.WriteEndElement();   // schema
            writer.WriteEndElement();   // sites

            writer.WriteEndDocument();

            writer.Flush();
            writer.Close();
        }

        private void LoadSites()
        {
            if( !File.Exists( SiteMaint.DataFile ) )
            {
                CreateXmlSchema();
            }

            xpDocSites = new XPathDocument( SiteMaint.DataFile );

            XPathNavigator navSites = xpDocSites.CreateNavigator();

            XPathNodeIterator iter = navSites.Select( "/sites/site/@name" );

            cboSite.Items.Clear();

            while( iter.MoveNext() )
            {
                cboSite.Items.Add( iter.Current.ToString() );
            }
        }

        private void SiteMaintenance()
        {
            SiteMaint sm = new SiteMaint();

            if( sm.ShowDialog() == DialogResult.OK )
            {
                LoadSites();
            }
        }

        private void mnuOptionsSiteMaintenance_Click( object sender, System.EventArgs e )
        {
            SiteMaintenance();
        }

        private void NewSite()
        {
            XPathNavigator navSites = xpDocSites.CreateNavigator();

            string s = "/sites/site[@name = '" + cboSite.SelectedItem.ToString() + "']";

            XPathNodeIterator iter = navSites.Select( s );
            iter.MoveNext();

            XPathNodeIterator url = iter.Current.SelectChildren( "url", "" );
            url.MoveNext();
            this.Navigate( url.Current.ToString() );

            XPathNodeIterator username = iter.Current.SelectChildren( "username", "" );
            username.MoveNext();
            this.username = username.Current.ToString();

            XPathNodeIterator password = iter.Current.SelectChildren( "password", "" );
            password.MoveNext();
            this.password = password.Current.ToString();

            XPathNodeIterator saveFolder = iter.Current.SelectChildren( "savefolder", "" );
            saveFolder.MoveNext();
            txtSaveLoc.Text = saveFolder.Current.ToString();
        }

        private void cboSite_SelectedIndexChanged( object sender, System.EventArgs e )
        {
            NewSite();
        }
    }
}