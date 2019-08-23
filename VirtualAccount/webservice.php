<?php
function bill(){
	
	/*---------------------------------
	 |    Parameter yang di tangkap    |
     ----------------------------------*/
	 
	If (isset($_GET['c'])){
		$c=$_GET['c'];
	}
	If (isset($_GET['bid'])){
		$bid=$_GET['bid'];
	}
	If (isset($_GET['id'])){
		$id=$_GET['id'];
	}
	If (isset($_GET['amt'])){
		$amt=$_GET['amt'];
	}
	If (isset($_GET['lang'])){
		$lang=$_GET['lang'];
	}
	If (isset($_GET['aid'])){
		$aid=$_GET['aid'];
	}
	If (isset($_GET['tid'])){
		$tid=$_GET['tid'];
	}
	If (isset($_GET['RRN'])){
		$RRN=$_GET['RRN'];
	}	
	date_default_timezone_set('Asia/Jakarta');	
	
	/*---------------------------------
	 |        Koneksi Database	       |
     ----------------------------------*/
	 
	$host = "192.168.0.88";
	$user = "sayamugen";
	$pass = "mugensaya";
	$dbnm = "Virtualaccount"; 

	$connectionInfo = array(
	  "Database" => $dbnm,
	  "UID"      => $user,
	  "PWD"      => $pass
	);
	
	$connect = sqlsrv_connect($host,$connectionInfo);
	
	/*-----------------------------------------------------------------------
	 |    Respon ke rintis dengan kode 96 Jika koneksi ke database gagal     |
     ------------------------------------------------------------------------*/
	If($connect === false ){
		$screenText =" ";
		for ($mUlang = 1; $mUlang <= 154; $mUlang++){
			$screenText = $screenText." ";
		}
		header("Content-type: text/xml");
		echo "<?xml version='1.0' encoding='ISO-8859-1'?>";
		$a = "<note>
					<idBiller>".$bid."</idBiller>
					<idCust>".$id."</idCust>
					<custName> </custName>
					<amount>000000000000</amount>
					<amount1>000000000000</amount1>
					<trxType>002</trxType>
					<response>96</response>
					<screenText>".$screenText."</screenText>
				</note>";
		return $a;
	}

	/*-----------------------------
	 |    Proses Inquiry Bill     |
     ------------------------------*/
	If ($c == 1 And $amt == 0) {

		$sql = "SELECT * FROM TRXN_BILL WHERE idCust= ?";  
		$params = array($id);  
		$result = sqlsrv_query($connect, $sql, $params);  
		
		/*-----------------------------------------------------------------------
		|    Respon ke rintis dengan kode 96 Jika koneksi ke database gagal     |
		------------------------------------------------------------------------*/
		If( $result === false ) {  
			$screenText =" ";
			for ($mUlang = 1; $mUlang <= 154; $mUlang++){
				$screenText = $screenText." ";
			}
			header("Content-type: text/xml");
			echo "<?xml version='1.0' encoding='ISO-8859-1'?>";
			$a = "<note>
					<idBiller>".$bid."</idBiller>
					<idCust>".$id."</idCust>
					<custName> </custName>
					<amount>000000000000</amount>
					<amount1>000000000000</amount1>
					<trxType>002</trxType>
					<response>96</response>
					<screenText>".$screenText."</screenText>
				</note>";
			return $a;  
		}  

		$row = sqlsrv_fetch_array( $result ); 

		/*-----------------------------------------------------------------------
		|    Respon ke rintis dengan kode 96 Jika koneksi ke database gagal     |
		------------------------------------------------------------------------*/	
		If( $row === false ){  
			$screenText =" ";
			for ($mUlang = 1; $mUlang <= 154; $mUlang++){
				$screenText = $screenText." ";
			}
			header("Content-type: text/xml");
			echo "<?xml version='1.0' encoding='ISO-8859-1'?>";
			$a = "<note>
					<idBiller>".$bid."</idBiller>
					<idCust>".$id."</idCust>
					<custName> </custName>
					<amount>000000000000</amount>
					<amount1>000000000000</amount1>
					<trxType>002</trxType>
					<response>96</response>
					<screenText>".$screenText."</screenText>
				</note>";
			return $a;  
		}
		
		//Jika customer terdaftar di database
		If (!empty($row['idCust'])){
			$sql1 = "SELECT * FROM TRXN_BILL WHERE idCust= ? and tglPayment is null";  
			$params1 = array($id);  
			$result1 = sqlsrv_query($connect, $sql1, $params1);  
			
			
			/*-----------------------------------------------------------------------
			|    Respon ke rintis dengan kode 96 Jika koneksi ke database gagal     |
			------------------------------------------------------------------------*/	
			If( $result1 === false ) {  
				$screenText =" ";
				for ($mUlang = 1; $mUlang <= 154; $mUlang++){
					$screenText = $screenText." ";
				}
				header("Content-type: text/xml");
				echo "<?xml version='1.0' encoding='ISO-8859-1'?>";
				$a = "<note>
						<idBiller>".$bid."</idBiller>
						<idCust>".$id."</idCust>
						<custName> </custName>
						<amount>000000000000</amount>
						<amount1>000000000000</amount1>
						<trxType>002</trxType>
						<response>96</response>
						<screenText>".$screenText."</screenText>
					</note>";
				return $a;  
			}  
			
			$row = sqlsrv_fetch_array( $result1 );  
			
			/*-----------------------------------------------------------------------
			|    Respon ke rintis dengan kode 96 Jika koneksi ke database gagal     |
			------------------------------------------------------------------------*/	
			If( $row === false ) {  
				$screenText =" ";
				for ($mUlang = 1; $mUlang <= 154; $mUlang++){
					$screenText = $screenText." ";
				}
				header("Content-type: text/xml");
				echo "<?xml version='1.0' encoding='ISO-8859-1'?>";
				$a = "<note>
						<idBiller>".$bid."</idBiller>
						<idCust>".$id."</idCust>
						<custName> </custName>
						<amount>000000000000</amount>
						<amount1>000000000000</amount1>
						<trxType>002</trxType>
						<response>96</response>
						<screenText>".$screenText."</screenText>
					</note>";
				return $a;  
			}  
			
			//Jika customer terdaftar di database
			If (!empty($row['idCust'])){
				//Cek apakah bill sudah lunas atau belum 
				If (is_null($row['tglPayment'])){
					
					$screenText = " ";
					for ($mUlang = 1; $mUlang <= 154; $mUlang++){
						$screenText = $screenText." ";
					}
				
					$sql2 = "UPDATE TRXN_BILL SET screenText =?, idBiller =?, response= ? WHERE idCust = ?";
					//sqlsrv_query($connect, $sql2);
					$params2 = array($screenText, $bid, '0', $id);
					$result2 = sqlsrv_query( $connect, $sql2, $params2);

					
					$sql3 ="SELECT idBiller, idCust, custName, replicate('0', 12- len(amount)) + cast (amount as varchar) as amount, replicate('0', 12- len(amount1)) + cast (amount1 as varchar) as amount1, replicate('0', 3- len(trxType)) + cast (trxType as varchar) as trxType, field1, replicate('0', 2- len(response)) + cast (response as varchar) as response, screenText FROM TRXN_BILL where idCust=? and tglPayment is Null";
					$params3 = array($id);  

					$result3 = sqlsrv_query($connect, $sql3, $params3);  
					
					/*-----------------------------------------------------------------------
					|    Respon ke rintis dengan kode 96 Jika koneksi ke database gagal     |
					------------------------------------------------------------------------*/	
					if( $result3 === false ){  
						$screenText =" ";
						for ($mUlang = 1; $mUlang <= 154; $mUlang++){
							$screenText = $screenText." ";
						}
						header("Content-type: text/xml");
						echo "<?xml version='1.0' encoding='ISO-8859-1'?>";
						$a = "<note>
								<idBiller>".$bid."</idBiller>
								<idCust>".$id."</idCust>
								<custName> </custName>
								<amount>000000000000</amount>
								<amount1>000000000000</amount1>
								<trxType>002</trxType>
								<response>96</response>
								<screenText>".$screenText."</screenText>
							</note>";
						return $a;   
					}  

					$row = sqlsrv_fetch_array( $result3 );  
					
					/*-----------------------------------------------------------------------
					|    Respon ke rintis dengan kode 96 Jika koneksi ke database gagal     |
					------------------------------------------------------------------------*/	
					if( $row === false ) {  
						$screenText =" ";
						for ($mUlang = 1; $mUlang <= 154; $mUlang++){
							$screenText = $screenText." ";
						}
						header("Content-type: text/xml");
						echo "<?xml version='1.0' encoding='ISO-8859-1'?>";
						$a = "<note>
								<idBiller>".$bid."</idBiller>
								<idCust>".$id."</idCust>
								<custName> </custName>
								<amount>000000000000</amount>
								<amount1>000000000000</amount1>
								<trxType>002</trxType>
								<response>96</response>
								<screenText>".$screenText."</screenText>
							</note>";
						return $a;   
					}  
					
					/*-----------------------------------------------------------------------
					 |    Respon ke rintis dengan kode 00 menampilkan jumlah tagihan         |	
					 ------------------------------------------------------------------------*/
					header("Content-type: text/xml");
					echo "<?xml version='1.0' encoding='ISO-8859-1'?>";
					$a = "<note>
								<idBiller>".$row['idBiller']."</idBiller>
								<idCust>".$row['idCust']."</idCust>
								<custName>".$row['custName']."</custName>
								<amount>".$row['amount']."</amount>
								<amount1>".$row['amount1']."</amount1>
								<trxType>".$row['trxType']."</trxType>
								<response>".$row['response']."</response>
								<screenText>".$screenText."</screenText>
							</note>";
					return $a;
				}else{
					
					 /*-----------------------------------------------------------------------
					 |    Respon ke rintis dengan kode 14 jika tagihan sudah lunas            |	
					 ------------------------------------------------------------------------*/
					$screenText =" ";
					for ($mUlang = 1; $mUlang <= 154; $mUlang++){
						$screenText = $screenText." ";
					}
					
					$sql3 ="SELECT idBiller, idCust, custName, replicate('0', 12- len(amount)) + cast (amount as varchar) as amount, replicate('0', 12- len(amount1)) + cast (amount1 as varchar) as amount1, replicate('0', 3- len(trxType)) + cast (trxType as varchar) as trxType, field1, replicate('0', 2- len(response)) + cast (response as varchar) as response, screenText FROM TRXN_BILL where idCust=?";
					$params3 = array($id);

					$result3 = sqlsrv_query($connect, $sql3, $params3);
 
					$row = sqlsrv_fetch_array( $result3 );  

					header("Content-type: text/xml");
					echo "<?xml version='1.0' encoding='ISO-8859-1'?>";
						$a = "<note>
								<idBiller>".$row['idBiller']."</idBiller>
								<idCust>".$row['idCust']."</idCust>
								<custName>".$row['custName']."</custName>
								<amount>".$row['amount']."</amount>
								<amount1>".$row['amount1']."</amount1>
								<trxType>".$row['trxType']."</trxType>
								<response>14</response>
								<screenText>".$screenText."</screenText>
							</note>";
						return $a;
				}	
			}else{
				/*-----------------------------------------------------------------------
				 |  Respon ke rintis dengan kode 14 jika kode va tidak ada di database   |	
				 ------------------------------------------------------------------------*/
				$screenText =" ";
				for ($mUlang = 1; $mUlang <= 154; $mUlang++){
					$screenText = $screenText." ";
				}
					
				header("Content-type: text/xml");
				echo "<?xml version='1.0' encoding='ISO-8859-1'?>";
				$a = "<note>
							<idBiller>".$bid."</idBiller>
							<idCust>".$id."</idCust>
							<custName> </custName>
							<amount>000000000000</amount>
							<amount1>000000000000</amount1>
							<trxType>002</trxType>
							<response>14</response>
							<screenText>".$screenText."</screenText>
						</note>";
				return $a;
			}				
		}else{
			/*-------------------------------------------------------------------------------------------
			|  Respon ke rintis dengan kode 14 jika kode va sudah terbayar dan melakukan inquiry ulang   |	
			---------------------------------------------------------------------------------------------*/
			$screenText =" ";
			for ($mUlang = 1; $mUlang <= 154; $mUlang++){
				$screenText = $screenText." ";
			}
					
			header("Content-type: text/xml");
			echo "<?xml version='1.0' encoding='ISO-8859-1'?>";
			$a = "<note>
						<idBiller>".$bid."</idBiller>
						<idCust>".$id."</idCust>
						<custName> </custName>
						<amount>000000000000</amount>
						<amount1>000000000000</amount1>
						<trxType>002</trxType>
						<response>14</response>
						<screenText>".$screenText."</screenText>
					</note>";
			return $a;
		}		
		
	} elseif ($c == 2) {
		$sql5 = "SELECT * FROM TRXN_BILL where RRN=?";
		$params5 = array($RRN); 
		$result5 = sqlsrv_query($connect, $sql5, $params5); 
		$row = sqlsrv_fetch_array( $result5 ); 
		
		If (!empty($row['RRN'])){
				$screenText =" ";
				for ($mUlang = 1; $mUlang <= 154; $mUlang++){
					$screenText = $screenText." ";
				}		 
		 
					$keterangan='Payment Advice';
					$sql8 = "UPDATE TRXN_BILL SET keterangan =? WHERE RRN = ?";
					$params8 = array($keterangan,$RRN);
					//print_r ($params5); die();
					$result8 = sqlsrv_query( $connect, $sql8, $params8);
				
					$sql7 = "SELECT idBiller, idCust, custName, replicate('0', 3- len(trxType)) + cast (trxType as varchar) as trxType, replicate('0', 12- len(amount)) + cast (amount as varchar) as amount, replicate('0', 12- len(amount1)) + cast (amount1 as varchar) as amount1, field1, replicate('0', 2- len(response2)) + cast (response2 as varchar) as response2, refNo, RRN, screenText, receiptText FROM TRXN_BILL where idCust=? and RRN=?";	
					$params7 = array($id, $RRN);    
					$result7 = sqlsrv_query($connect, $sql7, $params7);  
	 
					$row = sqlsrv_fetch_array( $result7 );  
			 
					header("Content-type: text/xml");
					echo "<?xml version='1.0' encoding='ISO-8859-1'?>";
					$a = "<note>
								<idBiller>".$row['idBiller']."</idBiller>
								<idCust>".$row['idCust']."</idCust>
								<custName>".$row['custName']."</custName>
								<amountPaid>".$row['amount']."</amountPaid>
								<amount>".$row['amount']."</amount>
								<amount1>".$row['amount1']."</amount1>
								<trxType>".$row['trxType']."</trxType>
								<response>".$row['response2']."</response>
								<refNo>".$row['refNo']."</refNo>
								<RRN>".$row['RRN']."</RRN>
								<screenText>".$screenText."</screenText>
								<receiptText>".$row['receiptText']."</receiptText>
							</note>";
					return $a;			 
		}
		else{
	/*-----------------------------
	 |    Proses Payment Bill      |
     ------------------------------*/
		$sql4 = "SELECT * FROM TRXN_BILL where idCust=? and tglPayment is null";
		$params4 = array($id); 
		$result4 = sqlsrv_query($connect, $sql4, $params4); 
		
		/*-----------------------------------------------------------------------
		  |    Respon ke rintis dengan kode 96 Jika koneksi ke database gagal     |
	      ------------------------------------------------------------------------*/			
		if( $result4 === false ){  
			$screenText =" ";
			for ($mUlang = 1; $mUlang <= 154; $mUlang++){
				$screenText = $screenText." ";
			}

			header("Content-type: text/xml");
			echo "<?xml version='1.0' encoding='ISO-8859-1'?>";
			$a = "<note>
						<idBiller>".$bid."</idBiller>
						<idCust>".$id."</idCust>
						<custName> </custName>
						<amountPaid>000000000000</amountPaid>
						<amount>000000000000</amount>
						<amount1>000000000000</amount1>
						<trxType>002</trxType>
						<response>96</response>
						<refNo> </refNo>
						<RRN>".$RRN."</RRN>
						<screenText>".$screenText."</screenText>
						<receiptText> </receiptText>	
					</note>";
			return $a;
		}  

		$row = sqlsrv_fetch_array( $result4 );  
		
		/*-----------------------------------------------------------------------
		  |    Respon ke rintis dengan kode 96 Jika koneksi ke database gagal     |
	      ------------------------------------------------------------------------*/
		if($row === false ) {  
			$screenText =" ";
			for ($mUlang = 1; $mUlang <= 154; $mUlang++){
				$screenText = $screenText." ";
			}

			header("Content-type: text/xml");
			echo "<?xml version='1.0' encoding='ISO-8859-1'?>";
				$a = "<note>
							<idBiller>".$bid."</idBiller>
							<idCust>".$id."</idCust>
							<custName> </custName>
							<amountPaid>000000000000</amountPaid>
							<amount>000000000000</amount>
							<amount1>000000000000</amount1>
							<trxType>002</trxType>
							<response>96</response>
							<refNo> </refNo>
							<RRN>".$RRN."</RRN>
							<screenText>".$screenText."</screenText>
							<receiptText> </receiptText>	
						</note>";
				return $a;
		}  
		
		If (!empty($row['idBiller'])){
			
			//Cek apakah pembayaran sudah lunas ketika sistem mugen mengalami timeout
			If (empty($row['tid']) && empty($row['RRN'])){
				
				//Cek apakah response2 bernilai 0
				If (($row['response'] == 0) && (is_null($row['response2']))){
					If ($lang == 1) {
						$jarak = 4;
						$jarakakhir = 251;
						$receiptText = " TERIMA KASIH TELAH MELAKUKAN";
						$kalimat = "PEMBAYARAN DI HONDA MUGEN";
					} Else {
						$jarak = 10;
						$jarakakhir=256;
						$receiptText = "   THANK YOU FOR YOUR PAYMENT";
						$kalimat = "AT HONDA MUGEN";
					}
					
					
					If (strlen($receiptText) < 31) {
						For ($mUlang = 1; $mUlang <= (31 - (strLen($receiptText))); $mUlang++){
							$receiptText = $receiptText." ";
						}
					}
							
					For ($mUlang = 1; $mUlang <= $jarak; $mUlang++){
						$receiptText = $receiptText." ";	
					}
							
					$receiptText = $receiptText.$kalimat;
					If (strlen($receiptText) < 31) {
						For ($mUlang = 1; $mUlang <= (31 - (strLen($kalimat))); $mUlang++){
							$receiptText = $receiptText." ";
						}
					}
						
					for ($mUlang = 1; $mUlang <= $jarakakhir; $mUlang++){
								$receiptText = $receiptText." ";
					}
					
					$screenText = " ";
					for ($mUlang = 1; $mUlang <= 154; $mUlang++){
								$screenText = $screenText." ";
				     }
					//di buat looping tak terbatas untuk menghabisakan waktu tunggu rintis	
							
					//******* NEW CODE ADDED		
					if( $row['amount'] != $amt) {
						
						// if ($lang == 1){
							// $screenText="BERBEDA JUMLAH";
						// }else {
							// $screenText="INVAILID AMOUNT";
						// }
						$screenText ="";
						for ($mUlang = 1; $mUlang <= 155; $mUlang++){
							$screenText = $screenText." ";
						}
						//$screenText="BERBEDA JUMLAH";
						$sql9 ="UPDATE TRXN_BILL set receiptText =?, RRNCancel=?, amountCancel=? WHERE idCust =? and tglPayment is null  ";
						$param9 = array ($screenText, $RRN, $amt, $id);
						$result9 = sqlsrv_query( $connect, $sql9, $param9);
						
                         
                         //$datew= date('m-d-Y H:i:s') ;
						//$screenText =  $datew ;//date_default_timezone_get();//date("Y-m-d H:i:s");  
						header("Content-type: text/xml");
						echo "<?xml version='1.0' encoding='ISO-8859-1'?>";
						$a = "<note>
									<idBiller>".$bid."</idBiller>
									<idCust>".$id."</idCust>
									<custName> </custName>
									<amountPaid>000000000000</amountPaid>
									<amount>000000000000</amount>
									<amount1>000000000000</amount1>
									<trxType>002</trxType>
									<response>13</response>
									<refNo> </refNo>
									<RRN>".$RRN."</RRN>
									<screenText>".$screenText."</screenText>
									<receiptText> </receiptText>	
								</note>";
								
							return $a; 
							

					} 	

					
					//******* NEW CODE ADDED-- END
					$sql5 = "UPDATE TRXN_BILL SET receiptText =?, aid =?, response2 =?, RRN =?, tid =?, tglPayment =? WHERE idCust = ? and tglPayment is null";
					$params5 = array($receiptText, $aid, '0', $RRN, $tid, date("Y-m-d H:i:s"),$id);
					$result5 = sqlsrv_query( $connect, $sql5, $params5);

					//for ($i=0; $i <=600000000; $i++) { $i++; }
					$sql6 = "SELECT idBiller, idCust, custName, replicate('0', 3- len(trxType)) + cast (trxType as varchar) as trxType, replicate('0', 12- len(amount)) + cast (amount as varchar) as amount, replicate('0', 12- len(amount1)) + cast (amount1 as varchar) as amount1, field1, replicate('0', 2- len(response2)) + cast (response2 as varchar) as response2, refNo, RRN, screenText, receiptText FROM TRXN_BILL where idCust=? and RRN=?";	
					$params6 = array($id, $RRN);    
					
					$result6 = sqlsrv_query($connect, $sql6, $params6);  
					if( $result6 === false ) {  
						$screenText =" ";
						for ($mUlang = 1; $mUlang <= 154; $mUlang++){
							$screenText = $screenText." ";
						}

						header("Content-type: text/xml");
						echo "<?xml version='1.0' encoding='ISO-8859-1'?>";
						$a = "<note>
									<idBiller>".$bid."</idBiller>
									<idCust>".$id."</idCust>
									<custName> </custName>
									<amountPaid>000000000000</amountPaid>
									<amount>000000000000</amount>
									<amount1>000000000000</amount1>
									<trxType>002</trxType>
									<response>96</response>
									<refNo> </refNo>
									<RRN>".$RRN."</RRN>
									<screenText>".$screenText."</screenText>
									<receiptText> </receiptText>	
								</note>";
						return $a;
					}  

					$row = sqlsrv_fetch_array( $result6 );  
					
					/*-----------------------------------------------------------------------
					|    Respon ke rintis dengan kode 96 Jika koneksi ke database gagal     |
					------------------------------------------------------------------------*/
					if( $row === false ) {  
						$screenText =" ";
						for ($mUlang = 1; $mUlang <= 154; $mUlang++){
							$screenText = $screenText." ";
						}

						header("Content-type: text/xml");
						echo "<?xml version='1.0' encoding='ISO-8859-1'?>";
						$a = "<note>
									<idBiller>".$bid."</idBiller>
									<idCust>".$id."</idCust>
									<custName> </custName>
									<amountPaid>000000000000</amountPaid>
									<amount>000000000000</amount>
									<amount1>000000000000</amount1>
									<trxType>002</trxType>
									<response>96</response>
									<refNo> </refNo>
									<RRN>".$RRN."</RRN>
									<screenText>".$screenText."</screenText>
									<receiptText> </receiptText>	
								</note>";
							return $a; 
					}  
					
					header("Content-type: text/xml");
					echo "<?xml version='1.0' encoding='ISO-8859-1'?>";
					$a = "<note>
								<idBiller>".$row['idBiller']."</idBiller>
								<idCust>".$row['idCust']."</idCust>
								<custName>".$row['custName']."</custName>
								<amountPaid>".$row['amount']."</amountPaid>
								<amount>".$row['amount']."</amount>
								<amount1>".$row['amount1']."</amount1>
								<trxType>".$row['trxType']."</trxType>
								<response>".$row['response2']."</response>
								<refNo>".$row['refNo']."</refNo>
								<RRN>".$row['RRN']."</RRN>
								<screenText>".$screenText."</screenText>
								<receiptText>".$row['receiptText']."</receiptText>
							</note>";
					return $a;
				}		
			}else{
					$keterangan='Payment Advice';
					$sql8 = "UPDATE TRXN_BILL SET keterangan =? WHERE idCust = ?";
					$params8 = array($keterangan,$id);
					//print_r ($params5); die();
					$result8 = sqlsrv_query( $connect, $sql8, $params8);
				
					$sql7 = "SELECT idBiller, idCust, custName, replicate('0', 3- len(trxType)) + cast (trxType as varchar) as trxType, replicate('0', 12- len(amount)) + cast (amount as varchar) as amount, replicate('0', 12- len(amount1)) + cast (amount1 as varchar) as amount1, field1, replicate('0', 2- len(response2)) + cast (response2 as varchar) as response2, refNo, RRN, screenText, receiptText FROM TRXN_BILL where idCust=?";	
					$params7 = array($id);    
					$result7 = sqlsrv_query($connect, $sql7, $params7);  
	 
					$row = sqlsrv_fetch_array( $result7 );  
			 
					header("Content-type: text/xml");
					echo "<?xml version='1.0' encoding='ISO-8859-1'?>";
					$a = "<note>
								<idBiller>".$row['idBiller']."</idBiller>
								<idCust>".$row['idCust']."</idCust>
								<custName>".$row['custName']."</custName>
								<amountPaid>".$row['amount']."</amountPaid>
								<amount>".$row['amount']."</amount>
								<amount1>".$row['amount1']."</amount1>
								<trxType>".$row['trxType']."</trxType>
								<response>".$row['response2']."</response>
								<refNo>".$row['refNo']."</refNo>
								<RRN>".$row['RRN']."</RRN>
								<screenText>".$screenText."</screenText>
								<receiptText>".$row['receiptText']."</receiptText>
							</note>";
					return $a;	
				}			
			}else{//jika idBiller kosong
				$screenText =" ";
				for ($mUlang = 1; $mUlang <= 154; $mUlang++){
					$screenText = $screenText." ";
				}

				header("Content-type: text/xml");
				echo "<?xml version='1.0' encoding='ISO-8859-1'?>";
				$a = "<note>
							<idBiller>".$bid."</idBiller>
							<idCust>".$id."</idCust>
							<custName> </custName>
							<amountPaid>000000000000</amountPaid>
							<amount>000000000000</amount>
							<amount1>000000000000</amount1>
							<trxType>002</trxType>
							<response>96</response>
							<refNo> </refNo>
							<RRN>".$RRN."</RRN>
							<screenText>".$screenText."</screenText>
							<receiptText> </receiptText>	
						</note>";
				return $a; 	
			}			
	}}
	}

echo bill();
?>