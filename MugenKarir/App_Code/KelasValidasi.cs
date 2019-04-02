using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

/// <summary>
/// Summary description for KelasValidasi
/// </summary>
public class KelasValidasi
{
    //validasi data pasangan 
    public bool validasi_DataPasangan(string var1,int var2,int sub)
    {
        bool status=false;
        if (sub == 1) {//validasi idlamaran
            if (var1.Length != 0)
            {
                status = true;
            }
            else {
                status = false;
            }
        } else if (sub == 2) {
            if (var2 != 0)
            {
                status = true;
            }
            else {
                status = false;
            }
        }
        return status;
    }

    //validasi data anak
    public bool validasi_DataAnak(string var1, int var2, int sub)
    {
        bool status = false;
        if (sub == 1)
        {//validasi idlamaran
            if (var1.Length != 0)
            {
                status = true;
            }
            else
            {
                status = false;
            }
        }
        else if (sub == 2)
        {
            if (var2 != 0)
            {
                status = true;
            }
            else
            {
                status = false;
            }
        }
        return status;
    }

    public bool validasi_DataSaudara(string var1, int var2, int sub)
    {
        bool status = false;
        if (sub == 1)
        {//validasi idlamaran
            if (var1.Length != 0)
            {
                status = true;
            }
            else
            {
                status = false;
            }
        }
        else if (sub == 2)
        {
            if (var2 != 0)
            {
                status = true;
            }
            else
            {
                status = false;
            }
        }
        return status;
    }

}