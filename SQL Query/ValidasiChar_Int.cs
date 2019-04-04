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