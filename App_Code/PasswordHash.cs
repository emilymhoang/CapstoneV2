using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

//Class used to has password, Borrowed from in class PBKDF2 PPT
public class PasswordHash
{
    public const int SaltByteSize = 24; //standard, secure size of salts
    public const int HashByteSize = 20; //to match the size of the PBKDF2-HMAC-SHA-1 hash (standard)
    public const int Pbkdf2Iterations = 1000; //higher number is more secure but takes longer
    public const int IterationIndex = 0; //used to find first section (number of iterations) of PasswordHash DB field
    public const int SaltIndex = 1; //used to find second section (salt) of PasswordHash DB field
    public const int Pbkdf2Index = 2; //used to find third section (hash) of PasswordHash DB field

    public PasswordHash()
    {

    }

    public static string HashPassword(string password)
    {
        var cryptoProvider = new RNGCryptoServiceProvider(); //create a new crypto provider
        byte[] salt = new byte[SaltByteSize]; //creates a new random salt of a certain length
        cryptoProvider.GetBytes(salt); //fills array with cryptographically strong sequence of random values
        var hash = GetPbkdf2Bytes(password, salt, Pbkdf2Iterations, HashByteSize); //call method below to create the hash
        return Pbkdf2Iterations + ":" + Convert.ToBase64String(salt) + ":" + Convert.ToBase64String(hash); //create string to store in DB and return
    }

    private static byte[] GetPbkdf2Bytes(string password, byte[] salt, int iterations, int outputBytes)
    {
        var pbkdf2 = new Rfc2898DeriveBytes(password, salt); //create a new key
        pbkdf2.IterationCount = iterations; //asign number of iterations that the function is run
        return pbkdf2.GetBytes(outputBytes); //return pseudo-random has of certain length
    }

    public static bool ValidatePassword(string password, string correctHash)
    {
        char[] delimiter = { ':' };
        var split = correctHash.Split(delimiter);
        var iterations = Int32.Parse(split[IterationIndex]);
        var salt = Convert.FromBase64String(split[SaltIndex]);
        var hash = Convert.FromBase64String(split[Pbkdf2Index]);
        var testHash = GetPbkdf2Bytes(password, salt, iterations, hash.Length);
        return SlowEquals(hash, testHash);
    }

    private static bool SlowEquals(byte[] a, byte[] b)
    {
        var diff = (uint)a.Length ^ (uint)b.Length;
        for (int i =0; i < a.Length && i < b.Length; i++)
        {
            diff |= (uint)(a[i] ^ b[i]);
        }

        return diff == 0;
    }
}