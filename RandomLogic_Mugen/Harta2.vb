        ''** REMOVE CHAR BY SUBSTRING AND REMOVE then assign value to arraylist**
        'For Each item In IDs
        '    xx = item.Substring(item.Length - 2) 'get las 2 character
        '    zz = item.Remove(item.Length - 3) 'remove last 2 character
        '    If xx = "DT" Then
        '        listDT.Add(zz) ' masukan value id detail izin sesuai jenis (dt/pc)
        '    Else
        '        listPC.Add(zz) ' masukan value id detail izin sesuai jenis (dt/pc)
        '    End If
        '    'list1 = kl.GetData_FromServerMultiple("select * from ApprovalIzinDetail where id_detail =" + zz + "", 1)
        'Next
        ''** REMOVE CHAR BY SUBSTRING AND REMOVE then assign value to arraylist**
        ''** Cek apakah Array List DT & PC ada Value dan proses semua pembatalan izin**
        'Dim alasanbtl As String = String.Empty
        'alasanbtl = TxtAlasan.Text
        'If listDT.Count <> 0 Then
        '    For x = listDT.Count - 1 To 0 Step -1
        '        dataDT = kl.GetData_FromServerMultiple("select * from ApprovalIzinDetail where id_detail =" + listDT(x) + "", 1)
        '        '*** cek apakah tgl pengajuan tersebut masih aktif
        '        If dataDT(3) >= daretime Then
        '            'inisialisasi variabel sementara
        '            Dim nik_staff As String = String.Empty
        '            Dim nik_spv As String = String.Empty
        '            Dim nik_mng As String = String.Empty
        '            Dim tglapv1 As Date
        '            Dim tglapv2 As Date
        '            Dim izin_id As String = String.Empty
        '            izin_id = dataDT(10)
        '            tglapv2 = dataDT(7)
        '            tglapv1 = dataDT(6)
        '            nik_staff = dataDT(9)
        '            nik_spv = dataDT(4)
        '            nik_mng = dataDT(5)
        '            If nik_mng = String.Empty Then
        '                nik_mng = "--"
        '            End If
        '            ' *** cek apakah alasan batal kosong 
        '            If alasanbtl <> String.Empty Then
        '                'If TxtStaffNIK.Text = nik_staff Then 'untuk case staff yg login
        '                '    'Response.Write("<script>alert('Staff Login')</script>")
        '                '    If nik_mng = "--" And tglapv1 = "" Then 'untuk case staff dengan 1 atasan
        '                '        Call kl.CUD_Data("update DATA_IZIN_BODY set IZIN_STATUS ='Dibatalkan Staff', IZIN_ALASANBTLSTJ='" & alasanbtl & "' where IZIN_ID = '" & izin_id & "'")
        '                '        'Call UpdateData_ServerCancel("update DATA_IZIN set IZIN_SALDO_CUTI ='" & saldo_cutiStaff & "' where IZIN_NIK ='" & TxtDetailNik.Text & "'")
        '                '        Dim result_email As String = kl.GetData_FromServer("select STAFF_EMAIL from DATA_STAFF where STAFF_NIK ='" & TxtStaffNIK.Text & "'", 3) 'get email nama atasan 1 value dan menyimpan ke variabel : result_email
        '                '        Call kl.emailNotifikasi("<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Pengajuan Izin atas nama " + TxtDetailNama.Text + " dengan NIK " + TxtDetailNik.Text + " dan tanggal Pengajuan " + TxtDetailTglPengajuanIzin.Text + " dengan Id Izin " + TxtDetailIdIzin.Text + " telah di batalkan Staff yang Bersangkutan dengan Alasan : " + alasan + " <br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/login.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Menuju Web</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>", result_email)
        '                '        Response.Write("<script>alert('Anda Berhasil Membatalkan Pengajuan Izin staff dengan Nik : " + nik_staff + " dan Id Izin : " + izin_id + " ')</script>")
        '                '    ElseIf nik_mng <> "--" And tglapv1 = "" Or tglapv2 = "" Then 'untuk case staff dengan 2 atasan (special : tidak update saldo cuti karena blm di kurangi saldo cuti awal nya )
        '                '        Call kl.CUD_Data("update DATA_IZIN_BODY set IZIN_STATUS ='Dibatalkan Staff', IZIN_ALASANBTLSTJ='" & TxtDetailAlasanBtlStj.Text & "' where IZIN_ID = '" & TxtDetailIdIzin.Text & "'")
        '                '        Call GetData_UserHead("select STAFF_EMAIL from DATA_STAFF where STAFF_NIK ='" & TxtDetailNik.Text & "'", "5") 'get email nama atasan 1 value dan menyimpan ke variabel : staffEmailnotif
        '                '        Call emailNotifikasi("<div style='background:linear-gradient(#c0c0c0, #f5f5f5);border-bottom:1px solid #d60000;padding:5px;font-family:verdana;'>Pemberitahuan Honda Mugen Web System</div><div style='font-family:verdana;font-size:10pt;padding:4px;margin:5px auto;border-left:3px solid #0080c0;'><div style='margin:0 auto;background: #FFfFD5;width:50%;padding:5px;border-radius:4px;border-left:3px solid #0080c0;font-family:verdana;font-size:10pt;'>Pengajuan Izin atas nama " + TxtDetailNama.Text + " dengan NIK " + TxtDetailNik.Text + " dan tanggal Pengajuan " + TxtDetailTglPengajuanIzin.Text + " dengan Id Izin " + TxtDetailIdIzin.Text + " telah di batalkan Staff yang Bersangkutan dengan Alasan : " + alasan + " <br/><span style='color:blue;font-size:8pt;'></span></div><br/><center><a href='http://office.hondamugen.co.id:8082/login.aspx' style='padding:6px;border:1px solid #f5f5f5;background:#0080c0;color:#f5f5f5;text-decoration:none;' target='_blank'>Klik untuk Menuju Web</a></center><br><center style='color: blue; '>**Pastikan perangkat anda terhubung dengan WI-FI/LAN yang ada di Honda Mugen.</center><br/><center>Atas perhatian dan kerjasamanya kami ucapkan terimakasih.</center><br/><br/><br/><strong style='color:blue;font-family:verdana;'>Regards,<br/><i style='font-size:8pt;color:#666;'>Web Mugen System | Developed by IT Department</i></strong><br/><strong>Honda Mugen Group</strong><br/><i>PT. Mitrausaha Gentaniaga</i><br/><span style='font-size:9pt;color:#666;'>Jl.Raya Pasar Minggu No.10, Jakarta 12740 - Indonesia<br/>Jl.Lingkar luar barat, Cengkareng, Jakarta Barat - Indonesia</span><br/>Telp : (021) 797 3000(Show Room), 797 2000 (Bengkel)<br/>Fax &nbsp;: (021) 797 3834, 798 4735<br/>Website : <a href='www.hondamugen.co.id' target='_blank'>www.hondamugen.co.id</a><br/></div>")
        '                '        Response.Write("<script>alert('Anda Berhasil Membatalkan Pengajuan Izin staff dengan Nik : " + nik_staff1 + " dan Id Izin : " + TxtDetailIdIzin.Text + " ')</script>")
        '                '        Call CallState_ListIzin("Bawahan")
        '                '        'Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
        '                '    Else
        '                '        Response.Write("<script>alert('Anda tidak di Izinkan melakukan Pembatalan')</script>")
        '                '        Response.Write("<script>window.location.href='HRDFORMIZIN.aspx';</script>")
        '                '    End If
        '                'End If
        '                Response.Write("<script language='javascript'>{window.open('../HRDFORMIZIN_DETAILIZINSTAFF.aspx?id=" + dataDT(10) + "');}</script>")
        '            Else
        '                Response.Write("<script>alert('Alasan Pembatalan Wajib di Isi')</script>")
        '            End If
        '        Else
        '            Response.Write("<script>alert('Izin yang Anda Pilih Sudah Lewat Deadline')</script>")
        '        End If
        '        'Response.Write("<script>alert(' " + dataDT(0) + "-" + dataDT(1) + " - " + dataDT(2) + "- " + dataDT(3) + "- " + dataDT(4) + "- " + dataDT(5) + "- " + dataDT(6) + "- " + dataDT(7) + "- " + dataDT(8) + "')</script>")
        '    Next

        'End If
        'If listPC.Count <> 0 Then

