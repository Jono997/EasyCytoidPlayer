using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using NAudio.Wave;

namespace EasyCytoidPlayer
{
    /// <summary>
    /// A class containing information about wav files cached on disk
    /// </summary>
    public class CacheWav
    {
        /// <summary>
        /// The path to the mp3 file
        /// </summary>
        public string mp3_path;

        /// <summary>
        /// A hash of the mp3 file the wav file was created on
        /// </summary>
        private byte[] mp3_hash;

        /// <summary>
        /// The wav file
        /// </summary>
        private byte[] wav;

        private static MD5 md5 = MD5.Create();

        /// <summary>
        /// Create an instance of this class from an MP3 file
        /// </summary>
        /// <param name="filename">The MP3 file to create the object from</param>
        public CacheWav(string filename)
        {
            mp3_path = filename;
        }

        /// <summary>
        /// Creates an instance of this class from a cachewav file
        /// </summary>
        /// <param name="raw">The data of the cachewav file to create the object from</param>
        private CacheWav(string filename, byte[] raw)
        {
            mp3_path = filename;

            #region Load data
            // Create byte arrays
            mp3_hash = new byte[16];
            wav = new byte[raw.Length - 16];

            // Write to byte arrays
            for (int i = 0; i < raw.Length; i++)
            {
                if (i < 16)
                {
                    mp3_hash[i] = raw[i];
                }
                else
                {
                    wav[i - 16] = raw[i];
                }
            }
            #endregion
        }

        /// <summary>
        /// Generate a hash and wav file and save them
        /// </summary>
        private void Generate()
        {
            mp3_hash = GenerateHash();
            wav = GenerateWav();
        }

        /// <summary>
        /// Generate a hash of the mp3 file and returns it
        /// </summary>
        /// <returns>An MD5 hash of the mp3 file</returns>
        private byte[] GenerateHash()
        {
            return md5.ComputeHash(new StreamReader(mp3_path).BaseStream);
        }

        /// <summary>
        /// Convert the mp3 file into wav format and return it
        /// </summary>
        /// <returns>The wav conversion of the mp3 file</returns>
        private byte[] GenerateWav()
        {
            Mp3FileReader mp3 = new Mp3FileReader(mp3_path);
            MemoryStream stream = new MemoryStream();
            WaveFileWriter.WriteWavFileToStream(stream, mp3);
            return stream.ToArray();
        }

        /// <summary>
        /// Returns the wav file for this object. Generates a new wav file if the mp3 file is changed or a wav file has not already been created
        /// </summary>
        /// <returns>The wav file for this object</returns>
        public byte[] GetWav()
        {
            byte[] check = GenerateHash();
            if (mp3_hash != check)
                Generate();
            return wav;
        }

        /// <summary>
        /// Saves this object to a file.
        /// </summary>
        public void Save()
        {
            #region Create file
            // Schema:
            // 16 bytes to store the hash, then the rest of the file contains the wav
            byte[] file = new byte[16 + wav.Length];
            for (int i = 0; i < file.Length; i++)
            {
                if (i < 16)
                {
                    file[i] = mp3_hash[i];
                }
                else
                {
                    file[i] = wav[i - 16];
                }
            }
            #endregion

            File.WriteAllBytes(mp3_path + ".cachewav", file);
        }

        /// <summary>
        /// Loads an object from a file
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static CacheWav Load(string path)
        {
            byte[] file = File.ReadAllBytes(path);
            return new CacheWav(path.Substring(0, path.Length - 9), file);
        }
    }
}
