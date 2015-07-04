using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace CWagner.ImageGrabber
{
    /// <summary>
    /// Summary description for ImageGrabber.
    /// </summary>
    /// 
    public delegate void MsgCallback( string msg );
    public delegate void FinishedCallback( int downloadCount, int skippedCount, int errorCount );

    public class Downloader
    {
        private string username;
        private string password;
        private string saveLocation;
        private bool skipIfExists;
        private int downloadedCount = 0;
        private int skippedCount = 0;
        private int errorCount = 0;
        private IEnumerable<string> hrefs;
        private MsgCallback msgCallback;
        private FinishedCallback finishedCallback;

        public Downloader( string saveLocation, bool skipIfExists, IEnumerable<string> hrefs, MsgCallback msgCallback, FinishedCallback finishedCallback )
            : this( String.Empty, String.Empty, saveLocation, skipIfExists, hrefs, msgCallback, finishedCallback )
        { }

        public Downloader( string username, string password, string saveLocation, bool skipIfExists, IEnumerable<string> hrefs, MsgCallback msgCallback, FinishedCallback finishedCallback )
        {
            if( !saveLocation.EndsWith( "\\" ) )
            {
                saveLocation += "\\";
            }
            this.username = username;
            this.password = password;
            this.saveLocation = saveLocation;
            this.skipIfExists = skipIfExists;
            this.hrefs = hrefs;
            this.msgCallback = msgCallback;
            this.finishedCallback = finishedCallback;
        }

        public void GetFiles()
        {
            if( !Directory.Exists( saveLocation ) )
            {
                Directory.CreateDirectory( saveLocation );
            }

            NetworkCredential nc = null;
            if( username != null && username.Length != 0 && password != null && password.Length != 0 )
            {
                nc = new NetworkCredential( username, password );
            }

            string fileName;

            try
            {
                foreach( string href in hrefs )
                {
                    try
                    {
                        fileName = href.Substring( href.LastIndexOf( "/" ) + 1 );

                        string fullPath = saveLocation + fileName;
                        string msg;

                        if( !File.Exists( fullPath ) || !skipIfExists )
                        {
                            if( msgCallback != null )
                            {
                                msgCallback( "Downloading " + fileName + "..." );
                            }

                            WebClient wc = new WebClient();
                            if( nc != null )
                            {
                                wc.Credentials = nc;
                            }

                            wc.DownloadFile( href, fullPath );
                            msg = fileName + " downloaded";
                            downloadedCount++;
                        }
                        else
                        {
                            msg = href + " exists, skipped";
                            skippedCount++;
                        }

                        if( msgCallback != null )
                        {
                            msgCallback( msg );
                        }
                    }
                    catch( IOException ex )
                    {
                        errorCount++;

                        if( msgCallback != null )
                        {
                            msgCallback( "\r\n=========================\r\nAn IOException occurred reading the results from the server. The file being retrieved at the time was " + href + ".\r\n\r\nMessage returned: " + ex.Message + "\r\n=========================\r\n" );
                        }
                        else
                        {
                            throw new Exception( "An IOException occurred reading the results from the server. The file being retrieved at the time was " + href + ".", ex );
                        }
                    }
                    catch( NotSupportedException ex )
                    {
                        errorCount++;

                        if( msgCallback != null )
                        {
                            msgCallback( "\r\n=========================\r\nA NotSupportedException occurred creating the request. The file being retrieved at the time was " + href + ".\r\n\r\nMessage returned: " + ex.Message + "\r\n=========================\r\n" );
                        }
                        else
                        {
                            throw new Exception( "A NotSupportedException occurred creating the request. The file being retrieved at the time was " + href + ".", ex );
                        }
                    }
                    catch( WebException ex )
                    {
                        errorCount++;

                        if( msgCallback != null )
                        {
                            msgCallback( "\r\n=========================\r\nA WebException occurred creating the request. The file being retrieved at the time was " + href + ".\r\n\r\nMessage returned: " + ex.Message + "\r\n=========================\r\n" );
                        }
                        else
                        {
                            throw new Exception( "A WebException occurred creating the request. The file being retrieved at the time was " + href + ".", ex );
                        }
                    }
                    catch( Exception ex )
                    {
                        errorCount++;

                        if( msgCallback != null )
                        {
                            msgCallback( "\r\n=========================\r\nAn exception occurred.\r\n\r\nMessage returned: " + ex.Message + "\r\n=========================\r\n" );
                        }
                        else
                        {
                            throw ex;
                        }
                    }
                }
            }
            finally
            {
                if( finishedCallback != null )
                {
                    finishedCallback( downloadedCount, skippedCount, errorCount );
                }
            }
        }
    }
}