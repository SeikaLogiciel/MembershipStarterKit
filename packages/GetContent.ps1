$root = '../src/SampleWebsite.Mvc3/'
$appstart_directory = $root + 'App_Start/'
$content_directory = $root + 'Content/'
$area_directory = $root + 'Areas/MvcMembership/'
$controllers_directory = $area_directory + 'Controllers/'
$models_directory = $area_directory + 'Models/UserAdministration/'
$views_directory = $area_directory + 'Views/'
$views_useradministration_directory = $views_directory + 'UserAdministration/'

$output_root = './MvcMembership.Mvc/content/'
$output_appstart_directory = $output_root + 'App_Start/'
$output_content_directory = $output_root + 'Content/'
$output_area_directory = $output_root + 'Areas/MvcMembership/'
$output_controllers_directory = $output_area_directory + 'Controllers/'
$output_models_directory = $output_area_directory + 'Models/UserAdministration/'
$output_views_directory = $output_area_directory + 'Views/'
$output_views_useradministration_directory = $output_views_directory + 'UserAdministration/'

New-Item $output_root -ItemType Directory -Force
New-Item $output_appstart_directory -ItemType Directory -Force
New-Item $output_content_directory -ItemType Directory -Force
New-Item $output_area_directory -ItemType Directory -Force
New-Item $output_controllers_directory -ItemType Directory -Force 
New-Item $output_models_directory -ItemType Directory -Force
New-Item $output_views_directory -ItemType Directory -Force
New-Item $output_views_useradministration_directory -ItemType Directory -Force

Copy-Item -Path (Join-Path $appstart_directory 'MvcMembership.cs') -Destination (Join-Path $output_appstart_directory 'MvcMembership.cs.pp')
Copy-Item -Path (Join-Path $content_directory 'MvcMembership.css') -Destination (Join-Path $output_content_directory 'MvcMembership.css')
Copy-Item -Path (Join-Path $area_directory 'MvcMembershipAreaRegistration.cs') -Destination (Join-Path $output_area_directory 'MvcMembershipAreaRegistration.cs.pp')
Copy-Item -Path (Join-Path $controllers_directory 'UserAdministrationController.cs') -Destination (Join-Path $output_controllers_directory 'UserAdministrationController.cs.pp')
Copy-Item -Path (Join-Path $models_directory 'CreateUserViewModel.cs') -Destination (Join-Path $output_models_directory 'CreateUserViewModel.cs.pp')
Copy-Item -Path (Join-Path $models_directory 'DetailsViewModel.cs') -Destination (Join-Path $output_models_directory 'DetailsViewModel.cs.pp')
Copy-Item -Path (Join-Path $models_directory 'IndexViewModel.cs') -Destination (Join-Path $output_models_directory 'IndexViewModel.cs.pp')
Copy-Item -Path (Join-Path $models_directory 'RoleViewModel.cs') -Destination (Join-Path $output_models_directory 'RoleViewModel.cs.pp')
Copy-Item -Path (Join-Path $views_directory 'Web.config') -Destination (Join-Path $output_views_directory 'Web.config')
Copy-Item -Path (Join-Path $views_useradministration_directory 'CreateUser.cshtml') -Destination (Join-Path $output_views_useradministration_directory 'CreateUser.cshtml.pp')
Copy-Item -Path (Join-Path $views_useradministration_directory 'Details.cshtml') -Destination (Join-Path $output_views_useradministration_directory 'Details.cshtml.pp')
Copy-Item -Path (Join-Path $views_useradministration_directory 'Index.cshtml') -Destination (Join-Path $output_views_useradministration_directory 'Index.cshtml.pp')
Copy-Item -Path (Join-Path $views_useradministration_directory 'Password.cshtml') -Destination (Join-Path $output_views_useradministration_directory 'Password.cshtml.pp')
Copy-Item -Path (Join-Path $views_useradministration_directory 'Role.cshtml') -Destination (Join-Path $output_views_useradministration_directory 'Role.cshtml.pp')
Copy-Item -Path (Join-Path $views_useradministration_directory 'UsersRoles.cshtml') -Destination (Join-Path $output_views_useradministration_directory 'UsersRoles.cshtml.pp')