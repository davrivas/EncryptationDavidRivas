﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EncryptationDavidRivas.WinForms
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            AES();
        }
        
        private void AES()
        {
            try
            {
                string raw = Guid.NewGuid().ToString();
                // Create Aes that generates a new key and initialization vector (IV).    
                // Same key must be used in encryption and decryption    
                using (AesManaged aes = new AesManaged())
                {
                    // Encrypt string    
                    byte[] encrypted = Encrypt(raw, aes.Key, aes.IV);
                    // Print encrypted string    
                    string encryptedString = Encoding.UTF8.GetString(encrypted);
                    // Decrypt the bytes to a string.    
                    string decrypted = Decrypt(encrypted, aes.Key, aes.IV);

                    MessageBox.Show($"::AES::\n" +
                        $"Text : {raw}\n" +
                        $"Encrypted : {encryptedString}\n" +
                        $"Decrypted : {decrypted}\n" +
                        $"{raw == decrypted}");
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        
    }
}
