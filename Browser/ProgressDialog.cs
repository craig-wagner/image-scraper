using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using CWagner.ImageGrabber;

namespace CWagner.ImageBrowser
{
    internal partial class ProgressDialog : Form
    {
        private Thread t;
        private bool running;
        private bool closeOnCompletion;

        public ProgressDialog()
        {
            InitializeComponent();
        }

        public void GetImages( string username, string password, string saveFolder, bool skipIfExists, bool closeOnCompletion, IEnumerable<string> hrefs )
        {
            Downloader dl = new Downloader( username,
                                            password,
                                            saveFolder,
                                            skipIfExists,
                                            hrefs,
                                            new MsgCallback( DisplayMsg ),
                                            new FinishedCallback( Finished ) );

            this.Text = "Saving to " + saveFolder;
            this.closeOnCompletion = closeOnCompletion;

            t = new Thread( new ThreadStart( dl.GetFiles ) );
            t.Start();
            running = true;
        }

        private void DisplayMsg( string msg )
        {
            if( this.InvokeRequired )
            {
                MsgCallback msgCallback = new MsgCallback( DisplayMsg );
                this.Invoke( msgCallback, new object[] { msg } );
            }
            else
            {
                txtResults.AppendText( msg + "\r\n" );
            }
        }

        private void Finished( int downloadCount, int skippedCount, int errorCount )
        {
            if( this.InvokeRequired )
            {
                FinishedCallback finishedCallback = new FinishedCallback( Finished );
                this.Invoke( finishedCallback, new object[] { downloadCount, skippedCount, errorCount } );
            }
            else
            {
                if( closeOnCompletion && errorCount == 0 )
                {
                    this.Close();
                }
                else
                {
                    running = false;
                    btnCancel.Text = "Close";
                    this.AcceptButton = this.btnCancel;
                    if( downloadCount > 0 )
                    {
                        txtResults.AppendText( "Images downloaded: " + downloadCount.ToString() + "\r\n" );
                    }
                    if( skippedCount > 0 )
                    {
                        txtResults.AppendText( "Images skipped: " + skippedCount.ToString() + "\r\n" );
                    }
                    if( errorCount > 0 )
                    {
                        txtResults.AppendText( "Errors encountered: " + errorCount.ToString() + "\r\n" );
                    }
                }
            }
        }

        private void btnCancel_Click( object sender, System.EventArgs e )
        {
            if( running )
            {
                t.Abort();
                t.Join();
            }
            else
            {
                this.Close();
            }
        }

    }
}
