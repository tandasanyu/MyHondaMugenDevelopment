//untuk validasi hanya char + spasi

<asp:RegularExpressionValidator 
ID="RegularExpressionValidator2" 
runat="server" 
ErrorMessage="Nama Hanya boleh Huruf" 
ForeColor="Red"
ControlToValidate="TxtNamaPerusahaan1"
ValidationExpression="([A-Za-z])+( [A-Za-z]+)*" 
></asp:RegularExpressionValidator>

                                          <asp:RegularExpressionValidator ID="RegularExpressionValidator4"
                                               runat="server" 
                                              ErrorMessage="Wajib Angka"
                                              ControlToValidate="TxtUsiaSK1"
                                              ForeColor="Red"
                                              ValidationExpression="\d+"
                                              ></asp:RegularExpressionValidator>

<!-- HO -->
SelectCommand="select * from TRXN_KPIH, DATA_STAFF where KPIH_NIK = STAFF_NIK AND STAFF_STATUSKERJALOKASI='HO' and KPIH_TAHUN = ? order by STAFF_STATUSKERJADEPT ASC, STAFF_STATUSKERJAJABATAN ASC, STAFF_STATUSKERJALOKASI DESC " 

<th style="text-align:center; color:white">Tahun PK</th>
                                    <td>
                                        <%#Eval("KPIH_TAHUN")%>
                                    </td>
