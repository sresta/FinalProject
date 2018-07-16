using OrphanageFinalEntity.Controllers;
using OrphanageFinalEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace OrphanageFinalEntity.Repository
{
    public interface IOrphanBackgroundRepo
    {
       int Insert(OrphanBackground orphan);
        List<OrphanBackground> GetAll();
    }
    public class OrphanBackgroundRepo : DatabaseController,IOrphanBackgroundRepo
    {
        public int Insert(OrphanBackground orphan)
        {
            string key = "hello world";
            //string Father = EncryptData(orphan.FatherName, key);
            //string mother = EncryptData(orphan.MotherName, key);
            //string relative = EncryptData(orphan.Relative, key);
            //string address = EncryptData(orphan.AddressDetail, key);
            //string contact = EncryptData(orphan.ContactNo, key);
            //string board = EncryptData(orphan.BoardedDetail, key);
            db.OrphanBackgrounds.Add(new OrphanBackground()
            {
                OrphanId=orphan.OrphanId,
                FatherName = EncryptData(orphan.FatherName, key),
                MotherName = EncryptData(orphan.MotherName, key),
                Relative = EncryptData(orphan.Relative, key),
                AddressDetail = EncryptData(orphan.AddressDetail, key),
                ContactNo = EncryptData(orphan.ContactNo, key),
                BoardedDetail = EncryptData(orphan.BoardedDetail, key)

            });
            return db.SaveChanges();
        }
        public string EncryptData(string textData, string Encryptionkey)
        {
            RijndaelManaged objrij = new RijndaelManaged();
            //set the mode for operation of the algorithm   
            objrij.Mode = CipherMode.CBC;
            //set the padding mode used in the algorithm.   
            objrij.Padding = PaddingMode.PKCS7;
            //set the size, in bits, for the secret key.   
            objrij.KeySize = 0x80;
            //set the block size in bits for the cryptographic operation.    
            objrij.BlockSize = 0x80;
            //set the symmetric key that is used for encryption & decryption.    
            byte[] passBytes = Encoding.UTF8.GetBytes(Encryptionkey);
            //set the initialization vector (IV) for the symmetric algorithm    
            byte[] EncryptionkeyBytes = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

            int len = passBytes.Length;
            if (len > EncryptionkeyBytes.Length)

            // POST: Admin/OrphanBackgrounds/Edit/5
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
            {
                len = EncryptionkeyBytes.Length;
            }
            Array.Copy(passBytes, EncryptionkeyBytes, len);

            objrij.Key = EncryptionkeyBytes;
            objrij.IV = EncryptionkeyBytes;

            //Creates symmetric AES object with the current key and initialization vector IV.    
            ICryptoTransform objtransform = objrij.CreateEncryptor();
            byte[] textDataByte = Encoding.UTF8.GetBytes(textData);
            //Final transform the test string.  
            return Convert.ToBase64String(objtransform.TransformFinalBlock(textDataByte, 0, textDataByte.Length));
        }

        public List<OrphanBackground> GetAll()
        {
            
            List<OrphanBackground> list = new List<OrphanBackground>();            
            foreach (var item in db.OrphanBackgrounds)
            {
                string key = "hello world";
                item.OrphanId = item.OrphanId;
                item.FatherName= DecryptData(item.FatherName, key);
                item.MotherName = DecryptData(item.MotherName, key);
                item.Relative = DecryptData(item.Relative, key);
                item.AddressDetail= DecryptData(item.AddressDetail, key);
                item.ContactNo=DecryptData(item.ContactNo, key);
                item.BoardedDetail= DecryptData(item.BoardedDetail, key);
                list.Add(item);               
                
            }
            
            return list;
           
        }
        public string DecryptData(string EncryptedText, string Encryptionkey)
        {
            RijndaelManaged objrij = new RijndaelManaged();
            objrij.Mode = CipherMode.CBC;
            objrij.Padding = PaddingMode.PKCS7;

            objrij.KeySize = 0x80;
            objrij.BlockSize = 0x80;
            byte[] encryptedTextByte = Convert.FromBase64String(EncryptedText);
            byte[] passBytes = Encoding.UTF8.GetBytes(Encryptionkey);
            byte[] EncryptionkeyBytes = new byte[0x10];
            int len = passBytes.Length;
            if (len > EncryptionkeyBytes.Length)
            {
                len = EncryptionkeyBytes.Length;
            }
            Array.Copy(passBytes, EncryptionkeyBytes, len);
            objrij.Key = EncryptionkeyBytes;
            objrij.IV = EncryptionkeyBytes;
            byte[] TextByte = objrij.CreateDecryptor().TransformFinalBlock(encryptedTextByte, 0, encryptedTextByte.Length);
            return Encoding.UTF8.GetString(TextByte);  //it will return readable string  
        }
    }
}
