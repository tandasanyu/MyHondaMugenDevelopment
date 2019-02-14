<?php
defined('BASEPATH') OR exit('No direct script access allowed');

/*
| -------------------------------------------------------------------------
| URI ROUTING
| -------------------------------------------------------------------------
| This file lets you re-map URI requests to specific controller functions.
|
| Typically there is a one-to-one relationship between a URL string
| and its corresponding controller class/method. The segments in a
| URL normally follow this pattern:
|
|	example.com/class/method/id/
|
| In some instances, however, you may want to remap this relationship
| so that a different class/function is called than the one
| corresponding to the URL.
|
| Please see the user guide for complete details:
|
|	https://codeigniter.com/user_guide/general/routing.html
|
| -------------------------------------------------------------------------
| RESERVED ROUTES
| -------------------------------------------------------------------------
|
| There are three reserved routes:
|
|	$route['default_controller'] = 'welcome';
|
| This route indicates which controller class should be loaded if the
| URI contains no data. In the above example, the "welcome" class
| would be loaded.
|
|	$route['404_override'] = 'errors/page_missing';
|
| This route will tell the Router which controller/method to use if those
| provided in the URL cannot be matched to a valid route.
|
|	$route['translate_uri_dashes'] = FALSE;
|
| This is not exactly a route, but allows you to automatically route
| controller and method names that contain dashes. '-' isn't a valid
| class or method name character, so it requires translation.
| When you set this option to TRUE, it will replace ALL dashes in the
| controller and method URI segments.
|
| Examples:	my-controller/index	-> my_controller/index
|		my-controller/my-method	-> my_controller/my_method
*/
$route['default_controller'] = 'welcome';
$route['profile'] = 'welcome/profile';
$route['fasilitas'] = 'welcome/fasilitas';
$route['produk'] = 'welcome/produk';
$route['accord'] = 'welcome/accord';
$route['brio'] = 'welcome/brio';
$route['brv'] = 'welcome/brv';
$route['city'] = 'welcome/city';
$route['civic'] = 'welcome/civic';
$route['hatchback'] = 'welcome/civicH';
$route['typeR'] = 'welcome/typeR';
$route['crv'] = 'welcome/crv';
$route['crz'] = 'welcome/crz';
$route['freed'] = 'welcome/freed';
$route['hrv'] = 'welcome/hrv';
$route['jazz'] = 'welcome/jazz';
$route['mobilio'] = 'welcome/mobilio';
$route['mobiliors'] = 'welcome/mobiliors';
$route['odyssey'] = 'welcome/odyssey';
$route['testdrive'] = 'welcome/testdrive';
$route['event'] = 'welcome/event/$1';
$route['event/(:num)'] = 'welcome/event/$1';
$route['karir'] = 'welcome/karir';
$route['lokasi'] = 'welcome/lokasi';
$route['buatAkun/(:num)'] = 'welcome/buatAkun/$id_lowongan';
$route['form_testdrive'] = 'welcome/form_testdrive';
$route['simpan_testdrive'] = 'welcome/simpan_testdrive';
$route['testdrive'] = 'welcome/testdrive';
$route['faq'] = 'welcome/faq';
$route['survey'] = 'welcome/survey';
$route['login'] = 'welcome/login';
$route['backend'] = 'login';
$route['daftar'] = 'career';
$route['dataDiri'] = 'career/formDataDiri';
$route['dataKeluarga'] = 'career/formDataKeluarga';
$route['dataPendidikan'] = 'career/formDataPendidikan';
$route['dataOrganisasi'] = 'career/formDataOrganisasi';
$route['dataPekerjaan'] = 'career/formDataPekerjaan';
$route['dataPertanyaan'] = 'career/formDataPertanyaan';
$route['dokumenFoto'] = 'career/formFoto';
$route['dokumenKTP'] = 'career/formKTP';
$route['dokumenIjazah'] = 'career/formIjazah';
$route['dokumenNilai'] = 'career/formNilai';
$route['dokumenSuratLamaran'] = 'career/formSurat';
$route['dokumenCV'] = 'career/formCV';
$route['dokumenNPWP'] = 'career/formNPWP';
$route['dokumenKK'] = 'career/formKK';
$route['jadwalpud'] = 'welcome/bookingpud';
$route['pudpasming'] = 'welcome/pudpasming';
$route['pudpuri'] = 'welcome/pudpuri';
$route['form_bookingpud'] = 'welcome/form_bookingpud';
$route['simpan_bookingpud'] = 'welcome/simpan_bookingpud';
$route['404_override'] = 'welcome/notfound';
$route['translate_uri_dashes'] = FALSE;
